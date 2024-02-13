using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (!upload.HasFile)
            {
                SetError("Selecteer een bestand");
                return;
            }
            else if (!upload.FileName.EndsWith(".musicxml"))
            {
                SetError("Alleen .musicxml bestanden kunnen worden vertaald");
                return;
            }
            else
            {
                translate.CssClass = "btn btn-success";
                emptyFileWarning.Visible = false;
            }
                
        }

        private void SetError(string warning)
        {
            emptyFileWarning.Text = warning;
            emptyFileWarning.CssClass = "alert alert-danger";
            translate.CssClass = "btn btn-success mt-5";
            emptyFileWarning.Visible = true;
            return;
        }
    }
}