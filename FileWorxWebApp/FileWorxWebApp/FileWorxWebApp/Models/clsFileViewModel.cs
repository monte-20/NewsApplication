using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxWebApp.Models
{
    public class clsFileViewModel
    {
        public clsTableModel table { get; set; }
        public clsFileFilter filter { get; set; }
    }
}