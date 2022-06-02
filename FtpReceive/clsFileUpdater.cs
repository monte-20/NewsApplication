using FileWorxService;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpReceive
{
    internal class clsFileUpdater
    {
        public List<clsContact> contacts { get; set; }
        public clsSharedInfo sharedInfo=new clsSharedInfo();
        public void UpdateFiles()
        {
            clsContactQuery query = new clsContactQuery();
            var listView = query.ListLoad();
            clsContactConverter converter = new clsContactConverter();
            contacts = converter.ConvertListView(listView);
            foreach(clsContact contact in contacts)
            {
                GetFiles(contact);
            }
        }

        private void GetFiles(clsContact contact)
        {
            FtpClient client=new FtpClient(contact.Host,21,new System.Net.NetworkCredential(contact.Username,contact.Password));
            client.Connect();
            updateNews(client);
            updatePhotos(client);
        }
        private void updateNews(FtpClient client)
        {
           
            client.DownloadDirectory(sharedInfo.newsDirecotry, "/news");
            clsNewsUpdater updater=new clsNewsUpdater();
            updater.Update();
        }
        private void updatePhotos(FtpClient client)
        {
            client.DownloadDirectory(sharedInfo.photosDirecotry, "/photos");
            clsPhotosUpdater updater=new clsPhotosUpdater();
            updater.Update();
        }

       
    }
}
