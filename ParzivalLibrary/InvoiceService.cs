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
    public class InvoiceService
    {
        public static InvoiceRespone Get(DateTime? etd, bool? check_on_week)
        {
            string __link = $"{StaticVar.__rest_api}/api/v1/invoice/"+ etd?.ToString("yyyyMMdd") + "/get";
            if (check_on_week is null)
            {
                __link = $"{StaticVar.__rest_api}/api/v1/invoice/get";
            }
            else {
                if ((bool)check_on_week)
                {
                    __link = $"{StaticVar.__rest_api}/api/v1/invoice/between/" + etd?.ToString("yyyyMMdd") + "/";
                }
            }
            var client = new RestClient(__link);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer "+ StaticVar.__authen.token);
            IRestResponse response = client.Execute(request);
            InvoiceRespone obj = new InvoiceRespone();
            if (response.StatusCode.ToString() == "OK")
            {
                Console.WriteLine(response.Content);
                obj = JsonConvert.DeserializeObject<InvoiceRespone>(response.Content);
            }
            return obj;
        }
    }
}
