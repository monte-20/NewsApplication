using FileWorxObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpReceive
{
    internal class clsPhotosUpdater
    {
        public clsSharedInfo shared = new clsSharedInfo();

        public async Task UpdateAsync()
        {
            string[] files = getAllFiles();
            foreach (string file in files)
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string data = reader.ReadToEnd();
                    clsPhotos photos = JsonConvert.DeserializeObject<clsPhotos>(data);
                    photos.CanInsert = true;
                    await photos.Update();
                }
               
            }
        }

        private string[] getAllFiles()
        {
           return Directory.GetFiles(shared.photosDirecotry, "*.json"); 
        }
    }
}
