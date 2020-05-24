using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GTIO.Framework.Helper
{
    public class PathHelper
    {
        public static string BaseDir()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return currentDirectory.Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        }
    }
}
