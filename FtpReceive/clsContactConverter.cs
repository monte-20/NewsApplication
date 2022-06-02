using FileWorxService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpReceive
{
    internal class clsContactConverter
    {
        public List<clsContact> ConvertListView(clsListView listView)
        {
           
            List<clsContact> contactList = new List<clsContact>();
            foreach(var item in listView.Items)
            {
               contactList.Add(ConvertListViewItem(item));
            }
            return contactList;
        }

        public clsContact ConvertListViewItem(clsListViewItem item)
        {
            Guid.TryParse(item.Values[item.Values.Count - 2].Value, out Guid id);
            clsContact contact = new clsContact() { ID = id };
            contact.Read();
            return contact;
        }
    }


}
