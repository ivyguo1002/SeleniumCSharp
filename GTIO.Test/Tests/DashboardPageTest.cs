using GTIO.Framework.Extensions;
using GTIO.Framework.WebDriver;
using GTIO.Pages.Pages;
using GTIO.Test.Tests.Base;
using GTIO.Token;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static GTIO.Framework.WebDriver.WebDriverFactory;
using static GTIO.Pages.Pages.Base.PageFactory;

namespace GTIO.Test.Tests
{
    [Category("Dashboard")]
    [TestFixture]
    public class DashboardPageTest : BaseTest
    {
        public DashboardPageTest(WebDriverType webDriverType, BrowserType browserType) : base(webDriverType, browserType)
        { }
        public DashboardPageTest() { }

        [SetUp]
        public void SetUpForTestClass()
        {
            Driver.SigninWith(TokenManager.TalentToken);
        }

        [Test]
        public void NavigateToProfilePage()
        {
            Dashboard.Open<DashboardPage>().GoToProfilePage();
            Assert.That(Profile.IsLoaded(), Is.True);
        }

        [Test]
        public void NavigateToJobWatchListPage()
        {
            Dashboard.Open<DashboardPage>().GoToJobsPage();
            Assert.That(Jobs.IsLoaded(), Is.True);
        }
    }
}
