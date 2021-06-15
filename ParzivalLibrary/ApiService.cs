using Newtonsoft.Json;
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
        private readonly object __rest_api = "http://127.0.0.1:8000";

        public AuthData GetToken(string __username, string __passwd)
        {
            var client = new RestClient($"{__rest_api}/api/v1/login");
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
            }
            return obj;
        }
    }
}
