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
        const string WorkingTable = "WorkingTable";
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
                //Store the table
                Session[WorkingTable] = table;
                //A measure table should have 5 rows
                if (table.Rows.Count != 5)
                    //TODO: Show error message
                    return;
                TableEdit.Rows.Clear();
                //TableEdit.Style.Add("Width", $"{(table.Rows[2].Cells.Count * 10) / 4}%");

                //Create the rows to work with
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
            //TODO: Restore the data from the inputfields back to the original cells
            var workingTable = Session[WorkingTable] as Table;
            var parent = workingTable.Parent;
            parent.Controls.Clear();

            parent.Controls.Add(workingTable);
            Page.Response.Redirect("Default.aspx");
        }
    }
}