﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace NoteToNumberWeb
{
    public partial class _Default : Page
    {
        const string TableRows = "TableRows";

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            var existingRows = Session[TableRows];
            if (existingRows != null)
            {
                foreach (var row in existingRows as TableRow[])
                {
                    result.Rows.Add(row);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Authenticated"] == null)
                Page.Response.Redirect("Login.aspx");
            translate.Click += Translate_Click;
            test.Click += Test_Click;
        }

        private void Test_Click(object sender, EventArgs e)
        {
            var translator = new Translator();

            //Read the file
            try
            {
                string xml;
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Assets\noodgezeten.musicxml");
                FileInfo fi = new FileInfo(path);
                FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
                using (var inputReader = new StreamReader(fs))
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
            result.Rows.Clear();
            translator.NumberToHTML(result);
            Session[TableRows] = new TableRow[result.Rows.Count];
            result.Rows.CopyTo((TableRow[])Session[TableRows], 0);
            resultHead.Text = translator.Scorepartwise.Work?.WorktTitle?.Text ?? "Titel onbekend";
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
            result.Rows.Clear();
            translator.NumberToHTML(result);

            Session[TableRows] = new TableRow[result.Rows.Count];
            result.Rows.CopyTo((TableRow[])Session[TableRows], 0);
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