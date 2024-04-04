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
    public partial class Number_Detail : Page
    {
        const string TableRows = "TableRows";
        const string WorkingTableParent = "WorkingTableParent";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Authenticated"] == null)
                Page.Response.Redirect("Login.aspx");
            saveButton.Click += SaveButton_Click;
            if (!Page.IsPostBack)
            {
                if (Session[TableRows] == null)
                    //TODO: Show message table row empty
                    return;

                var id = Page.Request.QueryString["ID"];
                if (id == null)
                    return;
                var table = (Session[TableRows] as TableRow[]).Select(x => x.Cells).SelectMany(c => c.Cast<TableCell>().Where(u => u.Controls.Count == 1)).FirstOrDefault(y => y.Controls[0].ID == id).Controls[0] as Table;
                if (table == null)
                    //TODO: Show message table empty
                    return;
                var parent = table.Parent;
                Session[WorkingTableParent] = parent;
                //A measure table should have 5 rows
                if (table.Rows.Count != 5)
                    //TODO: Show error message
                    return;
                TableEdit.Rows.Clear();
                //TableEdit.Style.Add("Width", $"{(table.Rows[2].Cells.Count * 10) / 4}%");
                var rows = new TableRow[table.Rows.Count];
                table.Rows.CopyTo(rows, 0);

                for (int i = 1; i < 5; i++)
                {
                    //Rows with index 1, 2 and 4 are editable, other rows can just be copied straight away
                    if (i != 1 && i != 2 && i != 4)
                    {
                        TableEdit.Rows.Add(rows[i]);
                        continue;
                    }
                    //The 1st, 2nd and 4th row contain editable values 
                    var numberRow = rows[i];
                    var inputRow = new TableRow() { ID = numberRow.ID };
                    TableEdit.Rows.Add(inputRow);
                    foreach (TableCell cell in numberRow.Cells)
                    {
                        var inputCell = new TableCell() { ID = cell.ID };
                        var inputField = new TextBox() { Text = ((Label)cell.Controls[0]).Text };
                        inputCell.Controls.Add(inputField);
                        inputRow.Controls.Add(inputCell);
                    }
                }
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var workingCell = Session[WorkingTableParent] as TableCell;
            workingCell.Controls.Clear();

            workingCell.Controls.Add(new Label() { Text = "Test" });
            Page.Response.Redirect("Default.aspx");
        }
    }
}