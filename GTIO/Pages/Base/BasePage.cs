
using OpenQA.Selenium;
using System;
using AventStack.ExtentReports;
using GTIO.Framework.Config;
using GTIO.Framework.Extensions;
using GTIO.Framework.Helper;
using static GTIO.Framework.WebDriver.WebDriverFactory;

namespace GTIO.Pages.Pages.Base
{
    public abstract class BasePage
    {
        public string BaseUrl => ConfigManager.Settings.Test.BaseUrl;
        public virtual string Url { get; set; }
        public virtual string Title { get; set; }

        public TPage Open<TPage>() where TPage : BasePage
        {
            ReportHelper.LogTestStepInfo($"Navigate to {Title} page: {BaseUrl}{Url}");
            Driver.Navigate().GoToUrl(BaseUrl + Url);
            Driver.WaitForPageLoad(Title);
            return this as TPage;
        }

        public void Open()
        {
            ReportHelper.LogTestStepInfo($"Navigate to {Title} page: {BaseUrl}{Url}");
            Driver.Navigate().GoToUrl(BaseUrl + Url);
            Driver.WaitForPageLoad(Title);
        }

        public bool IsLoaded()
        {
            ReportHelper.LogTestStepInfo($"Check if the {Title} page is loaded successully");
            try
            {
                Driver.WaitForPageLoad(Title);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}