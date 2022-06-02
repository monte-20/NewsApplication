using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpTransfer
{
    internal class JsonConverter
    {

        public string ConvertToJson(object data)
        {
            string json=JsonConvert.SerializeObject(data);
            return json;
        }
    }
}
