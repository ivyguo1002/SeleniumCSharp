using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTIO.Framework.Extensions
{
    public static class WebElementExtension
    {
        //public static IWebElement Find(this IWebElement element, By by, int timeOutInSeconds = (int)BrowserSetting.DefaultTimeOut)
        //{
        //    try
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
        //        return wait.Until(d => d.FindElement(by));
        //    }
        //    catch (WebDriverTimeoutException)
        //    {
        //        throw new WebDriverTimeoutException($"Wait for element with locator {by} failed");
        //    }
        //}
        public static IWebElement Contains(this IWebElement element, string text)
        {
            //todo: add wait
            return element.FindElement(By.XPath($"//*[contains(translate(.,'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), {text})]"));
        }

        public static void Hover(this IWebElement element, IWebDriver driver)
        {
            var actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        //public static void WaitForDisplayed(this)
        //{

        //    throw new NotImplementedException();
        //}

    }
}
