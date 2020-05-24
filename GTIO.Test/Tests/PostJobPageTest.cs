using GTIO.Framework.DataModel;
using GTIO.Framework.Extensions;
using GTIO.Framework.WebDriver;
using GTIO.Pages;
using GTIO.Test.Tests.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using static GTIO.Framework.WebDriver.WebDriverFactory;

namespace GTIO.Test.Tests
{
    [TestFixture]
    public class PostJobPageTest : BaseTest
    {
        public PostJobPageTest()
        {

        }
        public PostJobPageTest(WebDriverType webDriverType, BrowserType browserType) : base(webDriverType, browserType) { }

        [Test]
        public void PostJob()
        {
            //new LoginPage(Driver).Open<LoginPage>().LoginAs(new User
            //{
            //    Email = "recruiter@mvp.studio",
            //    Password = "GLobalTalent"
            //});
            Driver.Navigate().GoToUrl("http://localhost:5034/");
            /*For example
             * from 30000 to 70000
             * Range 0 - 150000
             */
            decimal salaryMin = 0;
            decimal salaryMax = 150000;

            decimal salaryRangeFrom = 30000;
            decimal salaryRangeTo = 70000;

            //get the slider width
            var slider = Driver.FindElement(By.CssSelector(".ant-slider"));
            var sliderWidthInPixels = slider.Size.Width;

            //calculate the expected handle location (pixel from left)
            var handle1FromLeft = (salaryRangeFrom / salaryMax) * sliderWidthInPixels;
            var handle2FromLeft = (salaryRangeTo / salaryMax) * sliderWidthInPixels;

            var actions = new Actions(Driver);
            var handle = Driver.FindElement(By.CssSelector(".ant-slider-handle"));

            actions.ClickAndHold(handle).MoveByOffset(Convert.ToInt32(handle1FromLeft), 0).Release().Perform();
            actions.ClickAndHold(handle).MoveByOffset(Convert.ToInt32(handle2FromLeft - handle1FromLeft), 0).Release().Perform();

        }

        [Test]
        public void testsomething()
        {
            By by = By.CssSelector(".ant-slider");
            Console.WriteLine(by);

        }
    }


}
