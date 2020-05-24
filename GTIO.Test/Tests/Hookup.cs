using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using GTIO.Token;
using GTIO.Framework.Config;
using GTIO.Framework.Helper;

namespace GTIO.Test.Tests
{
    [SetUpFixture]
    public class Hookup
    {
        [OneTimeSetUp]
        public void AssemblySetup()
        {
            ConfigManager.LoadConfiguration();

            ReportHelper.StartReporter();

            TokenManager.InitializeToken();
            
        }

        [OneTimeTearDown]
        public void AssemblyTearDown()
        {
            ReportHelper.Flush();
        }
    }
}
