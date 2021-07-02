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
    public class GediService
    {
        public static BatchFileResponse Get(string is_status, DateTime dateTime)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/batch/download/{is_status}/{dateTime.ToString("yyyyMMdd")}/get");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            BatchFileResponse obj = new BatchFileResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<BatchFileResponse>(response.Content);
            }
            return obj;
        }

        public static bool Update(string id, string is_download, string is_status)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/batch/download/{id}/update");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}"); 
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("is_download", is_download);
            request.AddParameter("is_status", is_status);
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
