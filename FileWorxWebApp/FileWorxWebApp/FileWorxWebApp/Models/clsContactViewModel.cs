using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxWebApp.Models
{
    public class clsContactViewModel
    {
        public clsListView list { get; set; }
        public clsContactFilter filter { get; set; }
    }
}