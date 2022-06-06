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
    internal class clsNewsUpdater
    {
        public clsSharedInfo shared=new clsSharedInfo();

       public async Task UpdateAsync()
        {
            string[] files = Directory.GetFiles(shared.newsDirecotry,"*.json");
           foreach(string file in files)
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string data = reader.ReadToEnd();
                    clsNews news = JsonConvert.DeserializeObject<clsNews>(data);
                    await news.Update();
                }
            }
        }
    }
}
