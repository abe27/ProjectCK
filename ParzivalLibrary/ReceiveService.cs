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
    public class ReceiveService
    {
        public static ReceiveEntResponse Get(DateTime? etd)
        {
            string __link;
            if (etd is null)
            {
                __link = $"{StaticVar.__rest_api}/api/v1/receive/ent/get";
            }
            else
            {
                string d = etd?.ToString("yyyy-MM-dd");
                __link = $"{StaticVar.__rest_api}/api/v1/receive/ent/{d}/get";
            }

            var client = new RestClient(__link);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + StaticVar.__authen.token);
            IRestResponse response = client.Execute(request);
            ReceiveEntResponse obj = new ReceiveEntResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                Console.WriteLine(response.Content);
                obj = JsonConvert.DeserializeObject<ReceiveEntResponse>(response.Content);
            }
            return obj;
        }

        public static ReceiveEntResponse Update(ReceiveData obj)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/receive/ent/{obj.id}/edit");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", "Bearer " + StaticVar.__authen.token);
            request.AddParameter("batch_id", obj.get_batch_id.id);
            request.AddParameter("tag_id", obj.get_tag_id.title);
            request.AddParameter("receive_date", obj.receive_date.ToString("yyyy-MM-dd"));
            request.AddParameter("receive_no", obj.receive_no);
            request.AddParameter("receive_status", obj.receive_status);
            request.AddParameter("sync", "0");
            request.AddParameter("is_status", "1");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            ReceiveEntResponse res = new ReceiveEntResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                res = JsonConvert.DeserializeObject<ReceiveEntResponse>(response.Content);
            }
            return res;
        }

        public static ReceiveDetailResponse GetDetail(ReceiveData obj)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/receive/detail/{obj.id}/get");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + StaticVar.__authen.token);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            ReceiveDetailResponse res = new ReceiveDetailResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                res = JsonConvert.DeserializeObject<ReceiveDetailResponse>(response.Content);
            }
            return res;
        }
    }
}
