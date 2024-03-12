using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            translate.Click += Translate_Click;
            testbutton.Click += Testbutton_Click;
        }

        private void Testbutton_Click(object sender, EventArgs e)
        {
            if (CacheTable.Instance.Table != null)
            {
                var text = ((Label)CacheTable.Instance.Table.Rows[2].Cells[3].Controls[0].Controls[1].Controls[0].Controls[0]).Text;
                warningLabel.Text = text;
                warningLabel.CssClass = $"alert alert-danger";
                translate.CssClass = "btn btn-success mt-5";
                warningLabelPanel.Visible = true;
                TableRow[] tableRowArray = new TableRow[CacheTable.Instance.Table.Rows.Count];
                CacheTable.Instance.Table.Rows.CopyTo(tableRowArray, 0);
                foreach (var item in tableRowArray)
                {
                    result.Rows.Add(item);
                }
                return;
            }
        }

        private void Translate_Click(object sender, EventArgs e)
        {
            //Check the upload
            if (!upload.HasFile)
            {
                SetError("Selecteer een bestand", "alert-danger");
                return;
            }
            else if (!upload.FileName.EndsWith(".musicxml"))
            {
                SetError("Alleen .musicxml bestanden kunnen worden vertaald", "alert-danger");
                return;
            }
            else
            {
                translate.CssClass = "btn btn-success";
                warningLabelPanel.Visible = false;
            }
            var translator = new Translator();
            CacheTable.Instance.Table = result;

            //Read the file
            try
            {
                string xml;
                using (var inputReader = new StreamReader(upload.FileContent))
                {
                    xml = inputReader.ReadToEnd();
                    XmlSerializer serializer = new XmlSerializer(typeof(Scorepartwise));
                    using (StringReader xmlReader = new StringReader(xml))
                    {
                        translator.Scorepartwise = (Scorepartwise)serializer.Deserialize(xmlReader);
                    }
                }
            }
            catch (Exception ex)
            {
                SetError("Er is iet mis gegaan:\n" + ex.Message, "alert-danger");
            }

            //Translate
            if (translator.Scorepartwise != null)
                translator.Scorepartwise.TranslateToNumber(translator);
            else
            {
                SetError("Er zijn geen noten gevonden om te vertalen.", "alert-warning");
                return;
            }


            //Create HTML table 
            translator.NumberToHTML(result);
            resultHead.Text = translator.Scorepartwise.Work?.WorktTitle?.Text ?? "Titel onbekend";

            //Show warnings/errors if any
            //TODO: Show error
            //if (translator.ErrorLog.Length > 0)
            //    SetError("Tijdens het vertalen hebben zich de volgende problemen voor gedaan:\n" + translator.ErrorLog.ToString(), "alert-warning");

        }

        private void SetError(string warning, string type)
        {
            warningLabel.Text = warning;
            warningLabel.CssClass = $"alert {type}";
            translate.CssClass = "btn btn-success mt-5";
            warningLabelPanel.Visible = true;
            return;
        }
    }
}