using OpenQA.Selenium;
using GTIO.Framework.DataModel;
using GTIO.Framework.Extensions;
using GTIO.Framework.Helper;
using static GTIO.Framework.WebDriver.WebDriverFactory;
using GTIO.Pages.Pages.Base;

namespace GTIO.Pages.Pages
{
    public class LoginPage : BasePage
    {
        public override string Title { get; set; } = "Login";
        private IWebElement EmailTextBox => Driver.Find(By.Id("email"));
        private IWebElement PasswordTextBox => Driver.Find(By.Id("password"));
        private IWebElement LoginBtn => Driver.Find(By.Id("btn_login"));


        public DashboardPage LoginAs(User user)
        {
            ReportHelper.LogTestStepInfo($"Log in as user Email: {user.Email} Password:{user.Password}");
            EmailTextBox.SendKeys(user.Email);
            PasswordTextBox.SendKeys(user.Password);
            LoginBtn.Click();
            return new DashboardPage();
        }
    }
}