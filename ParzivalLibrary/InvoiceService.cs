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
        public static InvoiceResponse Get(DateTime? etd, bool? check_on_week)
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
            InvoiceResponse obj = new InvoiceResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                Console.WriteLine(response.Content);
                obj = JsonConvert.DeserializeObject<InvoiceResponse>(response.Content);
            }
            return obj;
        }

        public static InvoiceDetailResponse GetDetail(string inv_id)
        {
            InvoiceDetailResponse obj = new InvoiceDetailResponse();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{inv_id}/detail");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<InvoiceDetailResponse>(response.Content);
            }
            Console.WriteLine(response.Content);
            return obj;
        }

        public static InvoiceResponse ChangeInvoiceNo(string inv_no, string new_inv)
        {
            InvoiceResponse obj = new InvoiceResponse();
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
                obj = JsonConvert.DeserializeObject<InvoiceResponse>(response.Content);
            }
            return obj;
        }

        public static InvCartonReponse GetInvoiceCarton(string id)
        {
            InvCartonReponse obj = new InvCartonReponse();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{id}/carton");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<InvCartonReponse>(response.Content);
            }
            return obj;
        }

        public static InvoicePalletResponse GetInvoicePallet(string id)
        {
            InvoicePalletResponse obj = new InvoicePalletResponse();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{id}/pallet");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request); Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<InvoicePalletResponse>(response.Content);
            }
            return obj;
        }

        public static bool CreatePallet(string id, InvoicePallet data)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{id}/pallet");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("pallet_prefix", data.pallet_prefix);
            request.AddParameter("pallet_seq", data.pallet_seq);
            request.AddParameter("pallet_total", data.pallet_total);
            request.AddParameter("pallet_limit", data.pallet_limit);
            request.AddParameter("pallet_width", data.pallet_width);
            request.AddParameter("pallet_length", data.pallet_length);
            request.AddParameter("pallet_height", data.pallet_height);
            request.AddParameter("is_status", data.is_status);
            IRestResponse response = client.Execute(request);
            bool is_status = false;
            if (response.StatusCode.ToString() == "OK")
            {
                is_status = true;
            }
            Console.WriteLine(response.Content);
            return is_status;
        }

        public static bool UpdatePallet(InvoicePallet data)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{data.id}/pallet");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("pallet_prefix", data.pallet_prefix);
            request.AddParameter("pallet_seq", data.pallet_seq);
            request.AddParameter("pallet_total", data.pallet_total);
            request.AddParameter("pallet_limit", data.pallet_limit);
            request.AddParameter("pallet_width", data.pallet_width);
            request.AddParameter("pallet_length", data.pallet_length);
            request.AddParameter("pallet_height", data.pallet_height);
            request.AddParameter("is_status", data.is_status);
            IRestResponse response = client.Execute(request);
            bool is_status = false;
            if (response.StatusCode.ToString() == "OK")
            {
                is_status = true;
            }
            Console.WriteLine(response.Content);
            return is_status;
        }

        public static bool DeletePallet(string id)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{id}/pallet");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            bool is_status = false;
            if (response.StatusCode.ToString() == "OK")
            {
                is_status = true;
            }
            Console.WriteLine(response.Content);
            return is_status;
        }

        public static InvoiceResponse UpdateInvoiceEtd(string inv_id, string order_id, DateTime etd)
        {
            InvoiceResponse obj = new InvoiceResponse();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{order_id}/{inv_id}/etd");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("etd_date", etd.ToString("yyyy-MM-dd"));
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<InvoiceResponse>(response.Content);
            }
            return obj;
        }

        public static InvoiceResponse UpdateInvoiceShip(string inv_id, string order_id, string ship_id)
        {
            InvoiceResponse obj = new InvoiceResponse();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{order_id}/{inv_id}/ship");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("ship_id", (ship_id).ToUpper());
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<InvoiceResponse>(response.Content);
            }
            return obj;
        }

        public static InvoiceResponse UpdateInvoiceContainer(string inv_no, string container_title)
        {
            InvoiceResponse obj = new InvoiceResponse();
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/invoice/{inv_no}/container");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("container_id", (container_title).ToUpper());
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.StatusCode.ToString() == "OK")
            {
                obj = JsonConvert.DeserializeObject<InvoiceResponse>(response.Content);
            }
            return obj;
        }
    }
}
