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
            string[] files = Directory.GetFiles(shared.photosDirecotry, "*.json");
            foreach (string file in files)
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string data = reader.ReadToEnd();
                    clsPhotos photos = JsonConvert.DeserializeObject<clsPhotos>(data);
                    await photos.Update();
                }
               
            }
        }
    }
}
