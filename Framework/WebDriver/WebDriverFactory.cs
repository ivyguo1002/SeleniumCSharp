using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using System.Collections.Specialized;
using GTIO.Framework.Config;
using OpenQA.Selenium.Support.UI;

namespace GTIO.Framework.WebDriver
{
    public class WebDriverFactory
    {
        [ThreadStatic]
        public static IWebDriver Driver;

        public static void InitDriver()
        {
            CreateDriverFromConfig();
        }

        private static void CreateDriverFromConfig()
        {
            var webDriver = ConfigManager.Settings.Driver.WebDriverType;
            var webDriverType = string.IsNullOrEmpty(webDriver) ? WebDriverType.Local : (WebDriverType)Enum.Parse(typeof(WebDriverType), webDriver);
            var browser = ConfigManager.Settings.Driver.BrowserType;
            var browserType = string.IsNullOrEmpty(browser) ? BrowserType.Chrome : (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            CreateDriver(webDriverType, browserType, TestContext.CurrentContext);
        }

        private static void CreateDriverFromRunSetting()
        {
            var webDriver = TestContext.Parameters["WebDriverType"];
            var webDriverType = string.IsNullOrEmpty(webDriver) ? WebDriverType.Local : (WebDriverType)Enum.Parse(typeof(WebDriverType), webDriver);
            var browser = TestContext.Parameters["Browser"];
            var browserType = string.IsNullOrEmpty(browser) ? BrowserType.Chrome : (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            CreateDriver(webDriverType, browserType, TestContext.CurrentContext);
        }

        public static void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        public static void CreateDriver(WebDriverType webDriverType, BrowserType browserType, TestContext currentContext)
        {
            switch (webDriverType)
            {
                case WebDriverType.Local:
                    CreateLocalDriver(browserType);
                    break;
                case WebDriverType.Remote:
                    CreateRemoteDriver(browserType);
                    break;
                case WebDriverType.Sauce:
                    CreateSauceDriver(browserType, currentContext);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The web driver type isn't supported");
            }
        }
        public static void CreateLocalDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    Driver = new ChromeDriver(chromeOptions);
                    break;
                case BrowserType.Edge:
                    break;
                case BrowserType.Firefox:
                    var profile = new FirefoxProfile();
                    profile.SetPreference("intl.accept_languages", "en,en-US");
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.Profile = profile;
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    Driver = new FirefoxDriver(firefoxOptions);
                    break;
                case BrowserType.Safari:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The browser type isn't supported");

            }
        }

        public static void CreateRemoteDriver(BrowserType browserType)
        {
            var remoteWebDriverUrl = ConfigManager.Settings.Driver.RemoteWebDriverHub;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    Driver = new RemoteWebDriver(new Uri(remoteWebDriverUrl), chromeOptions);
                    break;
                case BrowserType.Edge:
                    break;
                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    Driver = new RemoteWebDriver(new Uri(remoteWebDriverUrl), firefoxOptions);
                    break;
                case BrowserType.Safari:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The browser type isn't supported");
            }
        }

        public static void CreateSauceDriver(BrowserType browserType, TestContext currentContext)
        {
            var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");

            var sauceLabUrl = ConfigurationManager.AppSettings["SauceLabWebDriverHub"];

            /*
              * In this section, we will configure our test to run on some specific
              * browser/os combination in Sauce Labs
              */
            var sauceOptions = new Dictionary<string, object>()
            {
                ["username"] = sauceUserName,
                ["accessKey"] = sauceAccessKey,
                ["name"] = currentContext.Test.Name
            };

            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeCaps = ConfigManager.Settings.Chrome;
                    var chromeOptions = new ChromeOptions()
                    {
                        UseSpecCompliantProtocol = true,
                        PlatformName = chromeCaps.PlatForm,
                        BrowserVersion = chromeCaps.BrowserVersion
                    };

                    chromeOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);
                    Driver = new RemoteWebDriver(new Uri(sauceLabUrl),
                      chromeOptions);
                    break;

                case BrowserType.Edge:
                    break;
                case BrowserType.Firefox:
                    var firefoxCaps = ConfigManager.Settings.Firefox;
                    var firefoxOptions = new FirefoxOptions()
                    {
                        PlatformName = firefoxCaps.PlatForm,
                        BrowserVersion = firefoxCaps.BrowserVersion
                    };
                   
                    firefoxOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);

                    Driver = new RemoteWebDriver(new Uri(sauceLabUrl), firefoxOptions);
                    break;

                case BrowserType.Safari:
                    break;
                default:
                    break;
            }
        }

        


    }
}