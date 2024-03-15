using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NoteToNumberWeb
{
    public sealed class CacheTable
    {
        private static CacheTable instance = null;
        private static readonly object padlock = new object();
        public TableRow[] TableRowArray;

        CacheTable()
        {
        }
      
        public static CacheTable Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CacheTable();
                    }
                    return instance;
                }
            }
        }
    }
}