using FileWorxObjects;
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
        public async Task UpdateFiles()
        {
            clsContactQuery query = new clsContactQuery();
             var listView = await query.run();
            clsContactConverter converter = new clsContactConverter();
            contacts = await converter.ConvertListViewAsync(listView);
            foreach(clsContact contact in contacts)
            {
                await GetFiles(contact);
            }
        }

        private async Task GetFiles(clsContact contact)
        {
            FtpClient client=new FtpClient(contact.Host,21,new System.Net.NetworkCredential(contact.Username,contact.Password));
            client.Connect();
            await updateNews(client);
            await updatePhotos(client);
        }
        private async Task updateNews(FtpClient client)
        {
           
           await  client.DownloadDirectoryAsync(sharedInfo.newsDirecotry, "/news");
            clsNewsUpdater updater=new clsNewsUpdater();
           await  updater.UpdateAsync();
        }
        private async Task updatePhotos(FtpClient client)
        {
            await client.DownloadDirectoryAsync(sharedInfo.photosDirecotry, "/photos");
            clsPhotosUpdater updater=new clsPhotosUpdater();
           await  updater.UpdateAsync();
        }

       
    }
}
