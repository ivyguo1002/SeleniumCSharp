using Applitools;
using Applitools.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTIO.Framework.AppliTools
{
    public static class EyesFactory
    {
        [ThreadStatic]
        public static Eyes Eyes;

        [ThreadStatic]
        public static Applitools.Selenium.Configuration Config;

        public static void Init()
        {
            //Initialize the Runner for your test.
            var runner = new ClassicRunner();

            // Initialize the eyes SDK (IMPORTANT: make sure your API key is set in the APPLITOOLS_API_KEY env variable).$Env:<variable-name>
            Eyes = new Eyes(runner);
            Config = new Applitools.Selenium.Configuration
            {
                ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY")
            };

            Eyes.SetConfiguration(Config);
        }

        public static void Quit()
        {
            Eyes.AbortIfNotClosed();
        }
    }
}
