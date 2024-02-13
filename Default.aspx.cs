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

        }
    }
}