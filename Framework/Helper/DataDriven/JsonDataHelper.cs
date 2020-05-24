using GTIO.Framework.Config;
using GTIO.Framework.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GTIO.Framework.Helper.DataDriven
{
    public class JsonDataHelper
    {
        public static Ttype ToObject<Ttype>(string filePath)
        {
            var path = PathHelper.BaseDir() + filePath;
            if (!File.Exists(path))
            {
                throw new ArgumentNullException("The data file doesn't exist");
            }

            var data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Ttype>(data);
        }


        public static JObject ToJObject(string filePath)
        {
            var path = ConfigManager.BaseDir + filePath;
            if (!File.Exists(path))
            {
                throw new ArgumentNullException("The data file doesn't exist");
            }

            var data = File.ReadAllText(path);
            return JObject.Parse(data);
        }
    }
}
