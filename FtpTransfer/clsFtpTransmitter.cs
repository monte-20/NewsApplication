using FileWorxObjects;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FtpTransfer
{
    public class clsFtpTransmitter
    {
       public async Task TransferFiles(List<clsContact> contacts ,List<clsFile> files)
        {
            foreach (clsContact contact in contacts)
            {
                await contact.Read();
               foreach(clsFile file in files)
                {
                    await TransferFileAsync(contact, file);    
                }
            }    
        }

        private async Task TransferFileAsync(clsContact contact, clsFile file)
        {
            if (file.ClassID == clsBusiness.BusinessClass.NEWS)
            {
                await transferNewsAsync(contact,file.ID);
            }
            else if (file.ClassID == clsBusiness.BusinessClass.PHOTOS)
            {
                await transferPhotoAsync(contact,file.ID); 
            }
        }

        private async Task transferNewsAsync(clsContact contact, Guid ID)
        {
            clsNews news= new clsNews() {ID=ID };
            await news.Read();
            JsonConverter converter= new JsonConverter(); 
            var jsonData=converter.ConvertToJson(news);
            string path = generatePath(ID);
            
            File.WriteAllText(path, jsonData);
            try
            {
                FtpClient ftpClient = new FtpClient(contact.Host, 21, new NetworkCredential(contact.Username, contact.Password));
                ftpClient.Connect();
                await ftpClient.UploadFileAsync(path, "/news/"+ ID.ToString() + ".Json");
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
           
        }
        
        private async Task transferPhotoAsync(clsContact contact, Guid ID)
        {
            clsPhotos photo = new clsPhotos() { ID = ID };
            await photo.Read();
            JsonConverter converter = new JsonConverter();
            var jsonData = converter.ConvertToJson(photo);
            string path = generatePath(ID);
            File.WriteAllText(path, jsonData);

            try { 
                FtpClient ftpClient = new FtpClient(contact.Host, 21, new NetworkCredential(contact.Username, contact.Password));
                ftpClient.Connect();
                await ftpClient.UploadFileAsync(path, "/photos/"+ ID.ToString() + ".Json");
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private string generatePath(Guid ID)
        {
            clsShared shared = new clsShared();

            string fileName = ID.ToString() + ".Json";
            string path = Path.Combine(shared.TempFilesSharedDir, fileName);
            return path;
        }

     


    }
}
