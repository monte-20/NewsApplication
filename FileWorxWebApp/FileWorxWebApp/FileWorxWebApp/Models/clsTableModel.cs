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
            items=GenerateTable(list);
        }
        public clsTableModel()
        {
            
        }
      public List<clsRowModel> items { get; set; }


        public List<clsRowModel> GenerateTable(clsListView list)
        {
            List < clsRowModel > table=new List<clsRowModel>();
            foreach (clsListViewItem item in list.Items)
            {
                clsRowModel row=new clsRowModel();
                row.GenerateRow(item);
                table.Add(row);
            }
            return table;
        }

        
    }
}