using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NoteToNumberWeb
{
    public class Translator
    {
        Table table;
        readonly StringBuilder _result = new StringBuilder();
        readonly StringBuilder _errorlog = new StringBuilder();
        readonly List<Number> _numbers = new List<Number>();
        readonly List<string> _neutralizedNotes = new List<string>();
        readonly Dictionary<int, Duration> _durations = new Dictionary<int, Duration>();
        const int NUMBER_OF_CELLS = 18;
        public Scorepartwise Scorepartwise { get; set; }
        public int CurrentDuration { get; set; }
        public Measure CurrentMeasure { get; set; }
        public int DefaultOctave { get; private set; }
        public int MeasureDuration { get; set; }
        public StringBuilder Result { get => _result; }
        public StringBuilder ErrorLog { get => _errorlog; }
        public List<Number> Numbers { get => _numbers; }
        //TODO: Neutralized check
        public List<string> NeutralizedNotes { get => _neutralizedNotes; }
        public Dictionary<int, Duration> Durations { get => _durations; }

        public void SetDefaults(Part part)
        {
            //Measure duration
            var firstMeasureWithDivision = part.Measures.FirstOrDefault(m => m.Attributes.Divisions != 0 && m.Attributes.Time.Beats != 0);
            if (firstMeasureWithDivision != null)
                MeasureDuration = firstMeasureWithDivision.Attributes.Divisions * firstMeasureWithDivision.Attributes.Time.Beats;

            //Default octave
            var firstMeasureWithNote = part.Measures.FirstOrDefault(x => x.Notes != null);
            if (firstMeasureWithNote == null)
                return;
            var firtsNoteWithPitchAndOctave = firstMeasureWithNote.Notes?.FirstOrDefault(x => x.Pitch?.Octave != null);
            if (firtsNoteWithPitchAndOctave == null)
                return;
            DefaultOctave = firtsNoteWithPitchAndOctave.Pitch.Octave;


        }
        public async Task<bool> GetPDF(string filepath)
        {
            var toPDF = new HTMLToPDF();
            string html = NumberToHTMLOld(Scorepartwise.Work?.WorktTitle?.Text ?? "Titel onbekend");
            return await toPDF.Generate(html, filepath);
        }

        public string NumberToHTMLOld(string title)
        {
            var numbers = GetNumbers();
            var currentMeasure = numbers[0][0].Measure;
            var totalNumbers = numbers[0].Count();
            var html = new StringBuilder();
            html.Append("<!DOCTYPE html>");
            html.Append("<html lang=\"nl\">");
            html.Append("<head>");
            html.Append($"<title>{title}</title>");
            html.Append(@"<style>
      table td {
        border: 0px;
        text-align: center;
      }
      .td_border_top {
        border-top: 1px solid black;
      }
      .duration {font-size: 8px;}
      table.no-spacing {
        border-spacing:0; 
        border-collapse: collapse;
      }</style>");
            html.Append("</head>");
            html.Append("<body>");
            html.Append($"<h3>{title}</h3>");
            html.Append("<table style=\"width:100%\">");
            html.Append("<tr>");
            for (int i = 0; i < NUMBER_OF_CELLS; i++)
            {
                html.Append($"<td></td>");
            }
            html.Append("</tr><tr>");

            int cellsUsedInRow = 0;
            //Start looping over all numbers
            for (int i = 0; i < totalNumbers;)
            {
                var measureStart = i;

                var colspan = GetColspanForMeasure(currentMeasure, numbers, ref i);
                if (colspan == -1)
                    break;
                //Check if colspan fits or if it needs to go partly to the next row
                if (cellsUsedInRow + colspan <= NUMBER_OF_CELLS)
                {
                    cellsUsedInRow += colspan;
                    var colspanAttribute = colspan > 1 ? $" colspan=\"{colspan}\"" : "";
                    html.Append($"<td{colspanAttribute}>");
                    CreateMeasureTableOld(html, numbers, measureStart, colspan);
                    html.Append("</td>");
                    //Add the divider
                    //TODO: Check if a divider is needed anyway, even if it's at the end of the row
                    //if (cellsUsedInRow < NUMBER_OF_CELLS)
                    //{
                    //    html.Append("<td><h1>|</h1></td>");
                    //    cellsUsedInRow++;
                    //}
                    //If all cells are used, start a new row
                    if (cellsUsedInRow == NUMBER_OF_CELLS)
                    {
                        html.Append("</tr><tr>");
                        cellsUsedInRow = 0;
                    }

                }
                //Else fill the current row to the end and put what's left on a new row
                else
                {
                    var cellsLeft = NUMBER_OF_CELLS - cellsUsedInRow;
                    var colspanAttribute = cellsLeft > 1 ? $" colspan=\"{cellsLeft}\"" : "";
                    html.Append($"<td{colspanAttribute}>");
                    CreateMeasureTableOld(html, numbers, measureStart, cellsLeft);
                    html.Append("</td>");
                    //Start a new row
                    html.Append("</tr><tr>");
                    colspanAttribute = colspan - cellsLeft > 1 ? $" colspan=\"{colspan - cellsLeft}\"" : "";
                    html.Append($"<td{colspanAttribute}>");
                    CreateMeasureTableOld(html, numbers, measureStart + cellsLeft, colspan - cellsLeft);
                    html.Append("</td>");
                    cellsUsedInRow = colspan - cellsLeft;
                    //if (cellsUsedInRow < NUMBER_OF_CELLS)
                    //{
                    //    html.Append("<td><h1>|</h1></td>");
                    //    cellsUsedInRow++;
                    //}
                }
                if (i > numbers[0].Count - 1)
                    break;
                currentMeasure = numbers[0][i].Measure;

            }
            for (int i = cellsUsedInRow; i < NUMBER_OF_CELLS; i++)
            {
                html.Append("<td></td>");
            }
            html.Append("</tr></table></body></html>");
            return html.ToString();
        }

        Table CreateMeasureTable(List<List<NumberTranslated>> numbers, int measureStart, int colspan)
        {
            var result = new Table();
            result.Style.Add("width", "100%");
            result.Style.Add("border-right", "1px solid black");
            TableCell cell;
            //var html = new StringBuilder();
            //html.Append("<table style=\"width:100%; border-right: 1px solid black;\">");
            //Build 4 rows: The first row specifies the length, the second row specifies the right hand, the third is the solid line the fourth is the right hand
            List<string> lengthRowValues = new List<string>();
            List<string> rightHandValues = new List<string>();
            List<string> leftHandValues = new List<string>();
            for (int i = measureStart; i < measureStart + colspan; i++)
            {
                var translatedAbove = numbers[0][i];
                lengthRowValues.Add(translatedAbove.Duration);
                rightHandValues.Add(GetValue(translatedAbove));
                var translatedBelow = numbers[1][i];
                leftHandValues.Add(GetValue(translatedBelow));
            }
            //Add length row
            //html.Append($"<tr>");
            var currentRow = new TableRow();
            result.Rows.Add(currentRow);
            foreach (var length in lengthRowValues)
            {
                //html.Append($"<td class=\"duration\">{length}</td>");
                cell = new TableCell() { CssClass = "duration" };
                cell.Controls.Add(new Label() { Text = length });
                currentRow.Cells.Add(cell);
            }
            //html.Append($"</tr><tr>");
            currentRow = new TableRow();
            result.Rows.Add(currentRow);
            //Add right hand row
            foreach (var rightHand in rightHandValues)
            {
                //html.Append($"<td>{rightHand}</td>");
                cell = new TableCell();
                cell.Controls.Add(new Label() { Text = rightHand });
                currentRow.Cells.Add(cell);
            }
            //Add solid line
            var colspanAttribute = colspan > 1 ? $" colspan=\"{colspan}\"" : "";
            //html.Append($"</tr><tr><td{colspanAttribute} class=\"td_border_top\"></td></tr><tr>");
            currentRow = new TableRow();
            result.Rows.Add(currentRow);
            cell = new TableCell() { CssClass = "td_border_top" };
            if (colspan > 1)
                cell.ColumnSpan = colspan;
            currentRow.Cells.Add(cell);
            //Add left hand row
            currentRow = new TableRow();
            result.Rows.Add(currentRow);
            foreach (var leftHand in leftHandValues)
            {
                //html.Append($"<td>{leftHand}</td>");
                cell = new TableCell();
                cell.Controls.Add(new Label() { Text = leftHand});
                currentRow.Cells.Add(cell);
            }
            //html.Append("</tr></table>");
            //return html.ToString();
            return result;
        }
        void CreateMeasureTableOld(StringBuilder html, List<List<NumberTranslated>> numbers, int measureStart, int colspan)
        {
            html.Append("<table style=\"width:100%; border-right: 1px solid black;\">");
            //Build 4 rows: The first row specifies the length, the second row specifies the right hand, the third is the solid line the fourth is the right hand
            List<string> lengthRowValues = new List<string>();
            List<string> rightHandValues = new List<string>();
            List<string> leftHandValues = new List<string>();
            for (int i = measureStart; i < measureStart + colspan; i++)
            {
                var translatedAbove = numbers[0][i];
                lengthRowValues.Add(translatedAbove.Duration);
                rightHandValues.Add(GetValue(translatedAbove));
                var translatedBelow = numbers[1][i];
                leftHandValues.Add(GetValue(translatedBelow));
            }
            //Add length row
            html.Append($"<tr>");
            foreach (var length in lengthRowValues)
            {
                html.Append($"<td class=\"duration\">{length}</td>");
            }
            html.Append($"</tr><tr>");
            //Add right hand row
            foreach (var rightHand in rightHandValues)
            {
                html.Append($"<td>{rightHand}</td>");
            }
            //Add solid line
            var colspanAttribute = colspan > 1 ? $" colspan=\"{colspan}\"" : "";
            html.Append($"</tr><tr><td{colspanAttribute} class=\"td_border_top\"></td></tr><tr>");
            //Add left hand row
            foreach (var leftHand in leftHandValues)
            {
                html.Append($"<td>{leftHand}</td>");
            }
            html.Append("</tr></table>");
        }

        private int GetColspanForMeasure(int currentMeasure, List<List<NumberTranslated>> numbers, ref int i)
        {
            if (i >= numbers[0].Count)
                return -1;
            var colspanCount = 0;
            while (true)
            {
                if (i >= numbers[0].Count)
                    return colspanCount;
                var nextMeasure = numbers[0][i].Measure;
                if (nextMeasure == currentMeasure)
                {
                    colspanCount++;
                    i++;
                }
                else
                    return colspanCount;
            }
        }

        private string GetValue(NumberTranslated number)
        {
            var splitted = number.Line.Split('-');
            if (splitted.Length == 2 && splitted[0].Equals(splitted[1]))
                return splitted[0];
            return number.Line;
        }

        internal List<List<NumberTranslated>> GetNumbers()
        {
            var numbersLine1 = new List<NumberTranslated>();
            var numbersLine2 = new List<NumberTranslated>();
            var lastLine2 = "";
            foreach (var number in _numbers)
            {
                //First line
                var line1 = !string.IsNullOrEmpty(number.First) ? number.First : "";
                if (!string.IsNullOrEmpty(number.Second))
                {
                    if (!string.IsNullOrEmpty(line1))
                    {
                        if (number.SecondHigherThenFirst)
                            line1 = line1 + "-" + number.Second;
                        else
                            line1 = number.Second + "-" + line1;
                    }

                    else
                        line1 = number.Second;
                }
                if (string.IsNullOrEmpty(line1))
                    line1 = "-";


                //Second line
                var line2 = !string.IsNullOrEmpty(number.Third) ? number.Third : "";
                if (!string.IsNullOrEmpty(number.Fourth))
                {
                    if (!string.IsNullOrEmpty(line2))
                    {
                        if (number.FourthHigherThenThird)
                            line2 = line2 + "-" + number.Fourth;
                        else
                            line2 = number.Fourth + "-" + line2;
                    }

                    else
                        line2 = number.Fourth;
                }
                if (string.IsNullOrEmpty(line2))
                    line2 = "-";

                //Get the duration: 
                if (lastLine2.Equals(line2) && lastLine2 != "x-x")
                {
                    numbersLine1.Add(new NumberTranslated(line1, GetDurationSign(number.Duration), number.Measure));
                    numbersLine2.Add(new NumberTranslated("---"));

                }
                else
                {
                    numbersLine1.Add(new NumberTranslated(line1, GetDurationSign(number.Duration), number.Measure));
                    numbersLine2.Add(new NumberTranslated(line2));

                }
                lastLine2 = line2;
            }

            var result = new List<List<NumberTranslated>>();
            result.Add(numbersLine1);
            result.Add(numbersLine2);
            return result;
        }

        private string GetDurationSign(int duration)
        {
            //4
            if (duration == MeasureDuration)
                return "\x275A";
            //3
            if (duration == (MeasureDuration / 4 + MeasureDuration / 2))
                return "▬■";
            //2
            if (duration == MeasureDuration / 2)
                return "\x25AC";
            //1
            if (duration == MeasureDuration / 4)
                return "\x25A0";
            //0,5
            if (duration == MeasureDuration / 8)
                return ",";
            //1,5
            if (duration == MeasureDuration / 4 + MeasureDuration / 8)
                return "■,";
            //0,25
            if (duration == MeasureDuration / 16)
                return ";";
            //1,25
            if (duration == MeasureDuration / 4 + MeasureDuration / 16)
                return "■;";
            return "?";
        }

        public void NumberToHTML(Table result)
        {
            var numbers = GetNumbers();
            var currentMeasure = numbers[0][0].Measure;
            var totalNumbers = numbers[0].Count();
            var currentRow = new TableRow();
            result.Rows.Add(currentRow);

            for (int i = 0; i < NUMBER_OF_CELLS; i++)
            {
                currentRow.Cells.Add(new TableCell() { CssClass = "main-cell" });
            }

            currentRow = new TableRow();
            result.Rows.Add(currentRow);
            var currentCell = new TableCell();
            currentRow.Cells.Add(currentCell);
            int cellsUsedInRow = 0;
            //Start looping over all numbers
            for (int i = 0;     i < totalNumbers;)
            {
                var measureStart = i;

                var colspan = GetColspanForMeasure(currentMeasure, numbers, ref i);
                if (colspan == -1)
                    break;
                //Check if colspan fits or if it needs to go partly to the next row
                if (cellsUsedInRow + colspan <= NUMBER_OF_CELLS)
                {
                    cellsUsedInRow += colspan;
                    
                    if (colspan > 1)
                        currentCell.ColumnSpan = colspan;
                    if (currentCell.Controls.Count > 0)
                        throw new Exception("Controls should not be filled yet");
                    currentCell.Controls.Add(CreateMeasureTable(numbers, measureStart, colspan));

                    currentRow.Cells.Add(currentCell);
                    //If all cells are used, start a new row
                    if (cellsUsedInRow == NUMBER_OF_CELLS)
                    {
                        currentRow = new TableRow();
                        result.Rows.Add(currentRow);
                        cellsUsedInRow = 0;
                    }
                    
                    
                }
                //Else fill the current row to the end and put what's left on a new row
                else
                {
                    var cellsLeft = NUMBER_OF_CELLS - cellsUsedInRow;
                    if (cellsLeft > 1)
                        currentCell.ColumnSpan = cellsLeft;
                    currentRow.Cells.Add(currentCell);
                    if (currentCell.Controls.Count > 0)
                        throw new Exception("Controls should not be filled yet");
                    currentCell.Controls.Add(CreateMeasureTable(numbers, measureStart, cellsLeft));

                    currentRow = new TableRow();
                    result.Rows.Add(currentRow);
                    currentCell = new TableCell();
                    if (colspan - cellsLeft > 1)
                        currentCell.ColumnSpan = colspan - cellsLeft;
                    currentRow.Cells.Add(currentCell);
                    if (currentCell.Controls.Count > 0)
                        throw new Exception("Controls should not be filled yet");
                    currentCell.Controls.Add(CreateMeasureTable(numbers, measureStart + cellsLeft, colspan - cellsLeft));
                    cellsUsedInRow = colspan - cellsLeft;
                }
                if (i > numbers[0].Count - 1)
                    break;
                currentMeasure = numbers[0][i].Measure;
                if (currentCell.Controls.Count == 0)
                    throw new Exception();

                    currentCell = new TableCell();
            }
            for (int i = cellsUsedInRow; i < NUMBER_OF_CELLS; i++)
            {
                currentRow.Cells.Add(new TableCell());
            }
        }
    }

}