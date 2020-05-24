using GTIO.Framework.DataModel;
using GTIO.Framework.Helper.DataDriven;
using GTIO.Framework.Services.IdentityAPI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTIO.Token
{
    public class TokenManager
    {
        public static JToken TalentToken { get; set; }
        public static JToken EmployerToken { get; set; }
        public static JToken RecruiterToken { get; set; }

        private static JToken GetTokenAs(Role role)
        {
            var users = JsonDataHelper.ToObject<List<User>>("Configuration\\credentials.json");
            var testUser = users.Where(user => user.Role == role.ToString()).SingleOrDefault();
            var tokenObject = IdentityAPI.GetToken(testUser.Email, testUser.Password);
            return tokenObject;
        }
        public static void InitializeToken()
        {
            TalentToken = GetTokenAs(Role.talent);
            EmployerToken = GetTokenAs(Role.employer);
            RecruiterToken = GetTokenAs(Role.recruiter);
        }
    }
}