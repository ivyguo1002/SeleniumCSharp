using GTIO.Framework.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GTIO.Framework.Helper
{
    public class ScreenshotHelper
    {
        public static string TakeAndSaveScreenshot(IWebDriver driver)
        {
            var screenshotTaker = driver as ITakesScreenshot;
            var screenshot = screenshotTaker.GetScreenshot();
            if (screenshot == null)
            {
                return null;
            }
            else
            {
                var screenshotFilePath = CreateScreenshotFilePath();
                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                return screenshotFilePath;
            }

        }

        private static string CreateScreenshotFilePath()
        {
            var screenshotFolderPath = PathHelper.BaseDir() + ConfigManager.Settings.Test.ScreenshotPath;
            var screenshotFileName = "screenshot" + DateTime.Now.ToString("_MM_dd_yyyy_HH-mm") + ".png";
            return Path.Combine(screenshotFolderPath, screenshotFileName);
        }
    }
}
