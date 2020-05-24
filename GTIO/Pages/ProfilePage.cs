using OpenQA.Selenium;
using GTIO.Pages.Pages.ProfilePageSections;
using GTIO.Pages.Pages.Base;

namespace GTIO.Pages.Pages
{
    public class ProfilePage : BasePage
    {
        public override string Title { get; set; } = "Profile";
        public override string Url { get; set; } = "/profile";

        public Skills Skills { get; set; }

        //public ProfilePage() : base()
        //{
        //    Skills = new Skills();
        //}
    }
}