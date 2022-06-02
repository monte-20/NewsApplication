using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileWorxWebApp.Models
{
    public class clsRowConverter
    {

        public clsFile convertToFile(clsRowModel row)
        {
            clsFile file = new clsFile();
            Guid.TryParse(row.id,out Guid fileID);
            file.ID = fileID;
            int.TryParse(row.classId,out int classId);
            file.ClassID = (clsBusiness.BusinessClass)classId;
        
            return file;
        }

        public clsContact convertToContact(clsRowModel row)
        {
            clsContact contact = new clsContact();
            Guid.TryParse(row.id, out Guid fileID);
            contact.ID = fileID;

            return contact;
        }
    }
}