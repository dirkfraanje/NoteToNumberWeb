using System;
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
                warningLabel.Visible = false;
            }
            var translator = new Translator();

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
            warningLabel.Visible = true;
            return;
        }
    }
}