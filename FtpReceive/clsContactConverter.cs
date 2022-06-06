using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpReceive
{
    internal class clsContactConverter
    {
        public async Task<List<clsContact>> ConvertListViewAsync(clsListView listView)
        {
           
            List<clsContact> contactList = new List<clsContact>();
            foreach(var item in listView.Items)
            {
               contactList.Add(await ConvertListViewItemAsync(item));
            }
            return contactList;
        }

        public async Task<clsContact> ConvertListViewItemAsync(clsListViewItem item)
        {
            Guid.TryParse(item.Values[item.Values.Count - 2].Value, out Guid id);
            clsContact contact = new clsContact() { ID = id };
            await contact.Read();
            return contact;
        }
    }


}
