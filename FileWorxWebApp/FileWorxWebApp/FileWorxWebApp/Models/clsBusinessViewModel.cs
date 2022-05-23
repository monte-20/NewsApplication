using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxWebApp.Models
{
    public class clsBusinessViewModel
    {

        public clsListView list { get; set; }
        public clsBusinessFilter filter { get; set; } 
    }
}