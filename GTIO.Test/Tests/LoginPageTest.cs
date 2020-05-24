using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using GTIO.Framework.WebDriver;
using GTIO.Framework.DataModel;
using GTIO.Test;
using GTIO.Test.Tests.Base;
using GTIO.Pages.Pages;
using static GTIO.Pages.Pages.Base.PageFactory;
using static GTIO.Framework.AppliTools.EyesFactory;
using static GTIO.Framework.WebDriver.WebDriverFactory;
using System.Drawing;

namespace GTIO.Test.Tests
{
    //[TestFixture(WebDriverType.Remote, BrowserType.Chrome)]
    //[TestFixture(WebDriverType.Remote, BrowserType.Firefox)]
    [Category("Regression")]
    [Category("Account")]
    [TestFixture]
    public class LoginPageTest : BaseTest
    {
        public LoginPageTest() { }
        public LoginPageTest(WebDriverType webDriverType, BrowserType browserType) : base(webDriverType, browserType) { }

        [Test]
        [Category("Valid")]
        [Category("Login")]
        [Description("Validate that user logs into system with valid credential successfully")]
        [TestCaseSource(typeof(TestCaseData), "CredentialsJson", new object[] { "valid" })]
        public void LoginWithValidCredential(User user)
        {
            Eyes.Open(Driver, APP_NAME, TestContext.CurrentContext.Test.Name, new Size(800, 600));

            Login.Open<LoginPage>().LoginAs(user);

            Eyes.CheckWindow("Login");
            Assert.That(Dashboard.IsLoaded(), Is.True, "Valid User should been logged into system and navigated to Dashboard Page");
        }

        [Test]
        [Description("Validate that user fails to log into system with invalid credential")]
        [TestCaseSource(typeof(TestCaseData), "CredentialsJson", new object[] { "invalid" })]
        public void LoginWithInvalidCredential(User user)
        {
            Login.Open<LoginPage>().LoginAs(user);
            Assert.That(Dashboard.IsLoaded(), Is.False, "Invalid User should receive the error message");
        }

        [Test]
        [TestCaseSource(typeof(TestCaseData), "CredentialsExcel", new object[] { "valid" })]
        [Description("Check Excel Data Reader")]
        public void LoginAs(User user)
        {
            Login.Open<LoginPage>().LoginAs(user);
            Assert.That(Dashboard.IsLoaded(), Is.True, "Valid User should been logged into system and navigated to Dashboard Page");
        }
    }
}