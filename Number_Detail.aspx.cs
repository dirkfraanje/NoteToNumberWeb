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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CacheTable.Instance.TableRowArray == null)
                //TODO: Show message table row empty
                return;
            var id = Page.Request.QueryString["ID"];
            var table = CacheTable.Instance.TableRowArray.Select(x => x.Cells).SelectMany(c => c.Cast<TableCell>().Where(u => u.Controls.Count == 1)).FirstOrDefault(y => y.Controls[0].ID == id).Controls[0] as Table;
            if (table == null)
                //TODO: Show message table empty
                return;
            //A measure table should have 5 rows
            if (table.Rows.Count != 5)
                //TODO: Show error message
                return;
            TableEdit.Rows.Clear();
            //TableEdit.Style.Add("Width", $"{(table.Rows[2].Cells.Count * 10) / 4}%");
            var rows = new TableRow[table.Rows.Count];
            table.Rows.CopyTo(rows, 0);
           
            
            for(int i=0; i < 5; i++)
            {
                //TODO: Create inputfields
                if(i != 1 && i != 2 && i != 4)
                {
                    TableEdit.Rows.Add(rows[i]);
                    continue;
                }
                //The 3th and 5th row contain the numbers
                var numberRow = rows[i];
                var inputRow = new TableRow() { ID= numberRow.ID };
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
}