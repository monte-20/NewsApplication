using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxWebApp.Models
{
    public class clsTableModel
    {
        public clsTableModel(clsListView list)
        {
            items=convertListView(list);
        }
      public List<clsRowModel> items { get; set; }


        private List<clsRowModel> convertListView(clsListView list)
        {
            List < clsRowModel > table=new List<clsRowModel>();
            foreach (clsListViewItem item in list.Items)
            {
                table.Add(new clsRowModel() { item = item , transfer=false});
            }
            return table;
        }
    }
}