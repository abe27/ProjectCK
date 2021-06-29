using ParzivalLibrary.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary
{
    public class ContainerService
    {
        public bool Create()
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/container/store");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("container_no", "CN103232");
            request.AddParameter("seal_no", "SE001");
            request.AddParameter("sizes", "40F");
            request.AddParameter("release_days", "Mon");
            request.AddParameter("release_date", "2021-06-29 15:00:00");
            request.AddParameter("loaded", "0");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            bool x = false;
            if (response.StatusCode.ToString() == "OK")
            {
                x = true;
            }
            return x;
        }
    }
}
