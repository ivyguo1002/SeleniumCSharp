using GTIO.Framework.Helper.DataDriven;
using GTIO.Framework.DataModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GTIO.Test
{
    public class TestCaseData
    {
        public static IEnumerable<User> CredentialsExcel(string key)
        {
            var testUsers = ExcelDataHelper.ReadExcel<User>("TestData\\users.xlsx", "credentials");
            return testUsers.Where(user => user.Key == key);
        }

        public static IEnumerable<User> CredentialsJson(string key)
        {
            var testUsers = JsonDataHelper.ToObject<List<User>>("TestData\\users.json");
            return testUsers.Where(user => user.Key == key);
        }
    }
}
