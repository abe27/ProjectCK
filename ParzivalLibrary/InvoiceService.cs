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

        public static InvoiceDetailRespone GetDetail(string inv_id)
        {
            InvoiceDetailRespone obj = new InvoiceDetailRespone();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{inv_id}/detail");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<InvoiceDetailRespone>(response.Content);
            }
            Console.WriteLine(response.Content);
            return obj;
        }

        public static InvoiceRespone ChangeInvoiceNo(string inv_no, string new_inv)
        {
            InvoiceRespone obj = new InvoiceRespone();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{inv_no}/no");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("invoice_no", (new_inv).ToUpper());
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<InvoiceRespone>(response.Content);
            }
            return obj;
        }
    }
}
