using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Gherkin.Ast;
using GTIO.Framework.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static GTIO.Framework.WebDriver.WebDriverFactory;


namespace GTIO.Framework.Helper
{
    public class ReportHelper
    {
        private static AventStack.ExtentReports.ExtentReports Extent { get; set; }
        private static ExtentTest CurrentTest { get; set; }
        private static ExtentTest Feature { get; set; }
        private static ExtentTest Scenario { get; set; }
        public static ExtentTest Step { get; private set; }

        public static string CreateReportDirectory()
        {
            var reportFolder = ConfigManager.BaseDir + ConfigManager.Settings.Test.ReportPath;
            return Directory.CreateDirectory(reportFolder + "Report" +
                DateTime.Now.ToString("_MM_dd_yyyy_HH-mm") + "\\").ToString();
        }

        public static void LogTestStepInfo(string message)
        {
            CurrentTest.Info(message);
        }

        public static void StartReporter()
        {
            var reportDirectory = CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(reportDirectory);
            Extent = new AventStack.ExtentReports.ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        public static void AddErrorLogToReport(Exception e)
        {
            CurrentTest.Fail(e);
        }

        public static void AddTestMethodMetadataToReport(TestContext testContext)
        {
            CurrentTest = Extent.CreateTest(testContext.Test.Name);
            if (testContext.Test.Properties.ContainsKey("Category"))
            {
                var categories = testContext.Test.Properties["Category"];
                foreach (var category in categories)
                {
                    CurrentTest.AssignCategory(category.ToString());
                }
            }
        }

        public static void AddTestOutcomeToReport(TestContext testContext)
        {
            var result = testContext.Result.Outcome.Status;
            var fullTestName = testContext.Test.FullName;

            switch (result)
            {
                case TestStatus.Failed:
                    var screenshotFilePath = ScreenshotHelper.TakeAndSaveScreenshot(Driver);
                    CurrentTest.Fail($"{testContext.Result.Message} {testContext.Result.StackTrace}")
                        .AddScreenCaptureFromPath(screenshotFilePath);
                    break;
                case TestStatus.Inconclusive:
                    break;
                case TestStatus.Passed:
                    CurrentTest.Pass($"Test Passed: {fullTestName}");
                    break;

                case TestStatus.Skipped:
                    CurrentTest.Skip($"Test Skipped: {fullTestName}");
                    break;

                default:
                    break;
            }
        }

        public static void Flush()
        {
            Extent.Flush();
        }

        public static void AddScenarioInfo(string title)
        {
            Scenario = Feature.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(title);
        }

        public static void AddFeatureInfo(string title)
        {
            Feature = Extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(title);
        }

        public static void AddStepInfo(string keyword, string text)
        {
            switch (keyword)
            {
                case "Given":
                    Step = Scenario.CreateNode<Given>(text);
                    break;
                case "And":
                    Step = Scenario.CreateNode<And>(text);
                    break;
                case "When":
                    Step = Scenario.CreateNode<When>(text);
                    break;
                case "Then":
                    Step = Scenario.CreateNode<Then>(text);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("The step isn't defined");
            }
        }
    }
}

