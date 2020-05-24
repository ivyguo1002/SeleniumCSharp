using API.TalentAPI;
using GTIO.Framework.DataModel;
using GTIO.Framework.WebDriver;
using GTIO.Pages.Pages;
using GTIO.Test.Tests.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static GTIO.Pages.Pages.Base.PageFactory;

namespace GTIO.Test.Tests
{
    [TestFixture]
    public class ProfilePageTest : BaseTest
    {
        public ProfilePage ProfilePage { get; set; }
        public ProfilePageTest(WebDriverType webDriverType, BrowserType browserType) : base(webDriverType, browserType)
        { }
        public ProfilePageTest(){}

        [TearDown]
        public void TearDownForEveryMethod()
        {
            TalentAPI.ResetProfile();
        }

        [Test]
        public void AddNewSkill()
        {
            //IdentityAPI.SigninAs(Role.talent);
            ProfilePage.Open();
            var skill = new Skill();
            ProfilePage.Skills.AddNewSkill(skill);
            Assert.IsTrue(ProfilePage.Skills.IsAdded(skill));
        }

        [Test]
        public void DeleteSkill()
        {
            //IdentityAPI.SigninAs(Role.talent);
            //var skill = new Skill();
            //TalentAPI.PostSkill(skill);
            //ProfilePage.Open();
            //ProfilePage.Skills.DeleteSkill(skill);
            //Assert.IsTrue(ProfilePage.Skills.IsDeleted(skill));
        }


    }
}
