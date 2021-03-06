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
    public class OrderService
    {
        public static OrderPlanResponse GetCustomer(string fac, string etd)
        {
            OrderPlanResponse obj = new OrderPlanResponse();
            string __hname = $"{StaticVar.__rest_api}/api/v1/order/plan/{fac}/{etd}/customer";
            if (etd is null)
            {
                __hname = $"{StaticVar.__rest_api}/api/v1/order/plan/{fac}/get";
            }
            var client = new RestClient(__hname);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + StaticVar.__authen.token); IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<OrderPlanResponse>(response.Content);
            }
            return obj;
        }

        public static OrderPlanResponse GetPoWithCustomer(string fac, string etd, object customer, object po)
        {
            #pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (customer == "")
            #pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
            {
                customer = null;
            }
            OrderPlanResponse obj = new OrderPlanResponse();
            string __hname;
            if (customer is null && po is null)
            {
                __hname = $"{StaticVar.__rest_api}/api/v1/order/plan/{fac}/{etd}/get";
            }
            else if (customer != null && po is null)
            {
                __hname = $"{StaticVar.__rest_api}/api/v1/order/plan/{fac}/{etd}/{customer.ToString()}/get";
            }
            else if (customer is null && po != null)
            {
                __hname = $"{StaticVar.__rest_api}/api/v1/order/plan/{fac}/{etd}/{po.ToString()}/get";
            }
            else
            {
                __hname = $"{StaticVar.__rest_api}/api/v1/order/plan/{fac}/{etd}/{customer.ToString()}/{po.ToString()}/get";
            }

            var client = new RestClient(__hname);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + StaticVar.__authen.token); 
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<OrderPlanResponse>(response.Content);
            }
            return obj;
        }

        public static CheckOrderResponse GetGroupCustomer(string etd)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/order/check/{etd}/group");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + StaticVar.__authen.token);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            CheckOrderResponse obj = new CheckOrderResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<CheckOrderResponse>(response.Content);
            }
            return obj;
        }

        public static CheckOrderResponse GetCheckOrder(object custname, string etd)
        {
            string client_ip;
            if (etd != null && custname is null)
            {
                client_ip = $"{StaticVar.__rest_api}/api/v1/order/check/{etd}/etd";
            }
            else if (etd != null && custname != null)
            {
                client_ip = $"{StaticVar.__rest_api}/api/v1/order/check/{etd}/{custname.ToString()}/get";
            }
            else if (etd is null && custname != null)
            {
                client_ip = $"{StaticVar.__rest_api}/api/v1/order/check/{custname.ToString()}/customer";
            }
            else
            {
                client_ip = $"{StaticVar.__rest_api}/api/v1/order/check/true/get";
            }

            var client = new RestClient(client_ip);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + StaticVar.__authen.token);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            CheckOrderResponse obj = new CheckOrderResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<CheckOrderResponse>(response.Content);
            }
            return obj;
        }
    }
}
