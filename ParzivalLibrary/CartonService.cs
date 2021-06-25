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
    public class CartonService
    {
        public static CartonDataResponse Get(ReceiveDetailData __rec)
        {
            CartonDataResponse obj = new CartonDataResponse();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/carton/{__rec.id}/get");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + StaticVar.__authen.token);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            { 
                obj = JsonConvert.DeserializeObject<CartonDataResponse>(response.Content);
            }
            return obj;
        }
    }
}
