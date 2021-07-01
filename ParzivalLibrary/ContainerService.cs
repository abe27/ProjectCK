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
    public class ContainerService
    {
        public static ContainerResponse Get(DateTime etd)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/container/{etd.ToString("yyyyMMdd")}/get");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            ContainerResponse x = new ContainerResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                x = JsonConvert.DeserializeObject<ContainerResponse>(response.Content);
            }
            return x;
        }

        public static ContainerDetailResponse GetDetail(string id)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/container/{id}/show");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            ContainerDetailResponse x = new ContainerDetailResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                x = JsonConvert.DeserializeObject<ContainerDetailResponse>(response.Content);
            }
            return x;
        }

        public static bool Create(ContainerData __body)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/container/store");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("container_no", __body.container_no);
            request.AddParameter("seal_no", __body.seal_no);
            request.AddParameter("sizes", __body.sizes);
            request.AddParameter("release_days", __body.release_days);
            request.AddParameter("release_date", __body.release_date.ToString("yyyy-MM-dd"));
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

        public static bool Update(ContainerData __body)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/container/{__body.id}/update");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("container_no", __body.container_no);
            request.AddParameter("seal_no", __body.seal_no);
            request.AddParameter("sizes", __body.sizes);
            request.AddParameter("release_days", __body.release_days);
            request.AddParameter("release_date", __body.release_date.ToString("yyyy-MM-dd"));
            request.AddParameter("loaded", __body.loaded);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            bool x = false;
            if (response.StatusCode.ToString() == "OK")
            {
                x = true;
            }
            return x;
        }

        public static bool CreateDetailt(PostContainerDetail __body)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/container/detail");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("container_id", __body.container_id);
            request.AddParameter("pallet_id", __body.pallet_id);
            request.AddParameter("loaded", __body.loaded);
            request.AddParameter("sync", __body.sync);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            bool x = false;
            if (response.StatusCode.ToString() == "OK")
            {
                x = true;
            }
            return x;
        }

        public static bool DeleteDetail(string id)
        {
            var client = new RestClient($"{StaticVar.__rest_api}/api/v1/container/{id}/delete");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {StaticVar.__authen.token}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
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
