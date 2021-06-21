using Newtonsoft.Json;
using ParzivalLibrary.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary
{
    public class ApiService
    {
        public static AuthData GetToken(string __username, string __passwd)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("email", __username);
            request.AddParameter("password", __passwd);
            IRestResponse response = client.Execute(request);
            AuthData obj = new AuthData();
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<AuthData>(response.Content);
                // adsign variable
                StaticVar.__authen = obj;
            }
            return obj;
        }

        public static ProfileData Profile()
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/profile");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            ProfileData obj = new ProfileData();
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<ProfileData>(response.Content);
            }
            return obj;
        }

        public static bool LogOut()
        {
            bool __logout_status = false;
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/logout");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                __logout_status = true;
            }
            return __logout_status;
        }
    }
}
