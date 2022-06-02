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
    internal class clsNewsUpdater
    {
        public clsSharedInfo shared=new clsSharedInfo();

       public void Update()
        {
            string[] files = Directory.GetFiles(shared.newsDirecotry,"*.json");
           foreach(string file in files)
            {
              ClsNews news = JsonConvert.DeserializeObject<ClsNews>(file);
                news.Update();
            }
        }
    }
}
