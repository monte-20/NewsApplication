using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileWorxObjects;

namespace FileWorxWebApp.Models
{
    public class clsRowModel
    {
        public string id { get; set; }
        public string classId { get; set; }

        public string name { get; set; }

        public string date { get; set; } 
        public string descripton { get; set; }  

        public bool transfer { get; set; }

        public void GenerateRow(clsListViewItem item)
        {
           
            name = item.Values[0].Value;
            date = item.Values[1].Value;
            descripton = item.Values[2].Value;
            id = item.Values[3].Value;
            classId = item.Values[4].Value;
            transfer = false;
        }
    }
}