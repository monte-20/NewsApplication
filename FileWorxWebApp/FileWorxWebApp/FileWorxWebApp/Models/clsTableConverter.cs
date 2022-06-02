using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxWebApp.Models
{
    public class clsTableConverter
    {

        public List<clsFile> convertToFiles(clsTableModel table)
        { 
            List<clsFile> list = new List<clsFile>();
            clsRowConverter rowConverter = new clsRowConverter();
            foreach (clsRowModel row in table.items){
                if(row.transfer)
                list.Add(rowConverter.convertToFile(row));
            }
            return list;
        }

        public List<clsContact> convertToContacts(clsTableModel table)
        {
            List<clsContact> list = new List<clsContact>();
            clsRowConverter rowConverter = new clsRowConverter();
            foreach (clsRowModel row in table.items)
            {
                if (row.transfer)
                    list.Add(rowConverter.convertToContact(row));
            }
            return list;
        }
    }
}