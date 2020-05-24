using Applitools.Selenium;
using GTIO.Framework.AppliTools;
using GTIO.Framework.Helper;
using GTIO.Framework.WebDriver;
using GTIO.Pages.Pages.Base;
using MongoDB.Driver.Core.WireProtocol.Messages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static GTIO.Framework.WebDriver.WebDriverFactory;

[assembly: Parallelizable(ParallelScope.Children)]
[assembly: LevelOfParallelism(2)]
namespace GTIO.Test.Tests.Base
{
    public class BaseTest
    {
        public const string APP_NAME = "TALENT";

        //Cross Browser Setting
        public WebDriverType WebDriverType { get; set; }
        public BrowserType BrowserType { get; set; }
        public BaseTest(WebDriverType webDriverType, BrowserType browserType)
        {
            WebDriverType = webDriverType;
            BrowserType = browserType;
        }
        public BaseTest()
        {

        }

        
        [SetUp]
        public void SetUpForEveryTestMethod()
        {
            ReportHelper.AddTestMethodMetadataToReport(TestContext.CurrentContext);
            WebDriverFactory.InitDriver();
            //WebDriverFactory.CreateDriver(WebDriverType, BrowserType, TestContext.CurrentContext);
            EyesFactory.Init();
            PageFactory.InitPages();
        }

        [TearDown]
        public void TearDownForEveryTestMethod()
        {
            ReportHelper.AddTestOutcomeToReport(TestContext.CurrentContext);

            WebDriverFactory.Quit();

            EyesFactory.Quit();
        }

    }
}
