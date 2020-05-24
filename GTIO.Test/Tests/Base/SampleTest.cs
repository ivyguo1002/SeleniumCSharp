using GTIO.Framework.Extensions;
using GTIO.Framework.WebDriver;
using GTIO.Token;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static GTIO.Framework.WebDriver.WebDriverFactory;

namespace GTIO.Test.Tests.Base
{
    [TestFixture]
    public class SampleTest : BaseTest
    {
        public SampleTest()
        {
        }
        //public SampleTest(WebDriverType webDriverType, BrowserType browserType) : base(webDriverType, browserType)
        //{ }
        [Test]
        public void SauceTest()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Assert.IsTrue(true);
        }

        [Test]
        public void TestDelete()
        {
            Driver.SigninWith(TokenManager.TalentToken);
            Driver.Navigate().GoToUrl("http://localhost:5034/profile");
            Driver.FindElement(By.CssSelector(".ant-collapse-header")).Click();
            Driver.FindElement(By.XPath("//span[@class='ant-form-item-children']//button[@class='ant-btn']")).Click();
            var summary = Driver.FindElement(By.XPath("//textarea[@id='summary']"));
            Console.WriteLine(summary);
            summary.Clear();
            summary.Click();
            summary.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        [Test]
        public void VisualTest1()
        {

        }



    }
}
