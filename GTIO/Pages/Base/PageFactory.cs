using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow.EnvironmentAccess;

namespace GTIO.Pages.Pages.Base
{
    public static class PageFactory
    {
        [ThreadStatic]
        public static LoginPage Login;
        [ThreadStatic]
        public static DashboardPage Dashboard;
        [ThreadStatic]
        public static ProfilePage Profile;
        [ThreadStatic]
        public static JobsPage Jobs;

        public static void InitPages()
        {
            Login = new LoginPage();
            Dashboard = new DashboardPage();
            Profile = new ProfilePage();
            Jobs = new JobsPage();

        }

    }
}
