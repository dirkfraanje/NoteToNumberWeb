using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoteToNumberWeb
{
    public partial class Login : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //Authentication is not further developed, it has been setup for the users to start testing
            bool valid = true;
            if (!Password.Text.ToLower().Equals("cijfer"))
            {
                PasswordWarning.Visible = true;
                valid = false;
            }
            if (!UserName.Text.ToLower().Equals("jan"))
            {
                UserWarning.Visible = true;
                valid = false;
            }

            if (!valid)
                return;

            Session["Authenticated"] = true;
            Page.Response.Redirect("Default.aspx");
        }
    }
}