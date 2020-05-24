using GTIO.Framework.Helper;
using GTIO.Framework.Helper.DataDriven;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTIO.Framework.Config
{
    public class ConfigManager
    {
        public static Setting Settings { get; set; }
        public static string BaseDir { get; set; }
        public static void LoadConfiguration()
        {
            BaseDir = PathHelper.BaseDir();
            Settings = JsonDataHelper.ToObject<Setting>("Configuration\\settings.json");
        }
    }
}
