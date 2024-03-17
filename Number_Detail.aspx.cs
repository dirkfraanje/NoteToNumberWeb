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
            TableEdit.Rows.Clear();
            var rows = new TableRow[table.Rows.Count];
            table.Rows.CopyTo(rows, 0);
            foreach (var row in rows)
            {
                //TODO: Create inputfields
                TableEdit.Rows.Add(row);
                TableEdit.Style.Add("Width", $"{(rows[2].Cells.Count* 10)/2}%");
            }
        }
    }
}