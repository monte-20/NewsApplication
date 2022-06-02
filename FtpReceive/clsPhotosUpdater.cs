using FileWorxService;
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

        public void Update()
        {
            string[] files = Directory.GetFiles(shared.photosDirecotry, "*.json");
            foreach (string file in files)
            {
                ClsPhotos photos = JsonConvert.DeserializeObject<ClsPhotos>(file);
                photos.Update();
            }
        }
    }
}
