using AventStack.ExtentReports.Configuration;
using GTIO.Framework.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTIO.Framework.Services.IdentityAPI
{
    public class IdentityAPI
    {
        public static JToken GetToken(string userEmail, string userPassword)
        {
            var client = new RestClient(ConfigManager.Settings.Test.IdentityAPI);
            var request = new RestRequest("/api/auth/signin", Method.POST);
            request.AddJsonBody(new
            {
                email = userEmail,
                password = userPassword
            });

            var response = client.Execute(request);
            return JObject.Parse(response.Content)["token"];
        }
    }
}