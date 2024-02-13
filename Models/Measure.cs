using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{

    [XmlRoot(ElementName = "measure")]
    public class Measure
    {
        #region XML Import region
        [XmlElement(ElementName = "print")]
        public Print Print { get; set; }

        [XmlElement(ElementName = "attributes")]
        public Attributes Attributes { get; set; }

        [XmlElement(ElementName = "sound")]
        public Sound Sound { get; set; }

        [XmlElement(ElementName = "note")]
        public List<Note> Notes { get; set; }

        [XmlElement(ElementName = "backup")]
        public List<Backup> Backup { get; set; }

        [XmlElement(ElementName = "forward")]
        public List<Forward> Forwards { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public int Number { get; set; }

        [XmlAttribute(AttributeName = "width")]
        public int Width { get; set; }

        [XmlText]
        public string Text { get; set; }
        #endregion

        public IEnumerable<DurationAttribute> DurationAttributes()
        {
            var durations = new List<DurationAttribute>();
            durations.AddRange(Forwards);
            durations.AddRange(Notes);

            return durations.OrderBy(d => d.Sequence);
        }

        internal void Translate(Translator translator)
        {
            //Clear durations
            translator.Durations.Clear();
            translator.CurrentMeasure = this;

            //Get the durations
            var durationAttributes = DurationAttributes().ToList();
            var currentVoice = 1;
            translator.CurrentDuration = 1;
            while (durationAttributes.Any())
            {
                var item = durationAttributes.First();
                if (item is Note note)
                {
                    if (note.Voice != currentVoice)
                    {
                        translator.CurrentDuration = 1;
                        currentVoice = note.Voice;
                        continue;
                    }
                    note.SetDurations(translator);
                    translator.CurrentDuration += note.Duration;
                }
                else if (item is Forward forward)
                    translator.CurrentDuration += forward.Duration;
                durationAttributes.Remove(item);
            }
            var durationError = false;
            if (translator.CurrentDuration - 1 != translator.MeasureDuration)
            {
                durationError = true;
                if (translator.CurrentDuration < translator.MeasureDuration - 1)
                    translator.ErrorLog.AppendLine($"Maat {this.Number} kon niet worden vertaald omdat de noten de maat niet vol maken");
                else
                    translator.ErrorLog.AppendLine($"Maat {this.Number} kon niet worden vertaald omdat de lengte van de noten meer is dan de aangegeven maatlengte.");
            }

            Number lastResult = null;
            Note currentNote = null;
            var durationCounter = 1;
            var last = translator.Durations.Last();
            foreach (var item in translator.Durations)
            {
                //Create the numbers based on the durations
                if (lastResult == null)
                {
                    lastResult = NewNumber(translator, item, durationError);
                    currentNote = item.Value.Note;
                }
                else
                {
                    if (item.Value.Note == currentNote && NumberExists(lastResult, item))
                    {
                        durationCounter++;
                        if (item.Equals(last))
                            lastResult.Duration = durationCounter;
                        continue;
                    }
                    if (currentNote.Voice == 1)
                        lastResult.Duration = durationCounter;
                    lastResult = NewNumber(translator, item, durationError);
                    durationCounter = 1;
                    currentNote = item.Value.Note;
                }
                if (item.Equals(last))
                    lastResult.Duration = durationCounter;
            }
        }

        private bool NumberExists(Number lastResult, KeyValuePair<int, Duration> item)
        {
            for (var i = 0; i < item.Value.Durations.Count; i++)
            {
                if (i == 0)
                {
                    if (lastResult.First != item.Value.Durations[i])
                        return false;
                }
                else if (i == 1)
                {
                    if (lastResult.Second != item.Value.Durations[i])
                        return false;
                }
                else if (i == 2)
                {
                    if (lastResult.Third != item.Value.Durations[i])
                        return false;
                }
                else if (i == 3)
                    if (lastResult.Fourth != item.Value.Durations[i])
                        return false;
            }
            return true;
        }
        Number NewNumber(Translator translator, KeyValuePair<int, Duration> item, bool error)
        {
            var number = new Number(Number);
            translator.Numbers.Add(number);
            if (error)
            {
                number.First = "x";
                number.Second = "x";
                number.Third = "x";
                number.Fourth = "x";
                return number;
            }

            for (var i = 0; i < item.Value.Durations.Count; i++)
            {
                if (i == 0)
                    number.First = item.Value.Durations[i];
                else if (i == 1)
                    number.Second = item.Value.Durations[i];
                else if (i == 2)
                    number.Third = item.Value.Durations[i];
                else if (i == 3)
                    number.Fourth = item.Value.Durations[i];
                else
                    throw new Exception("Can't translate");
            }
            if (item.Value.Durations.Count < 4)
                translator.ErrorLog.AppendLine($"<p>Waarschuwing bij maat {Number}: Mogelijk staan de cijfers niet op de juiste plaats omdat er maar {item.Value.Durations.Count} noten zijn ingevoerd</p>");
            return number;
        }
    }
}
