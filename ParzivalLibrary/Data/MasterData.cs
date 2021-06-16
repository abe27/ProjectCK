using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class StaticVar
    {
        public static string __rest_api = "http://127.0.0.1:8000";
        public static AuthData __authen { get; internal set; }
    }
    public class HttpResponeData
    {
        public int current_page { get; set; }
        public string first_page_url { get; set; } //"first_page_url": "http://127.0.0.1:8000/api/v1/invoice/get?page=1",
        public int from { get; set; } //"from": 1,
        public int last_page { get; set; } //"last_page": 2,
        public string last_page_url { get; set; } //"last_page_url": "http://127.0.0.1:8000/api/v1/invoice/get?page=2",
        public List<LinkData> links { get; set; } //"links": [],
        public string next_page_url { get; set; } //"next_page_url": "http://127.0.0.1:8000/api/v1/invoice/get?page=2",
        public string path { get; set; } //"path": "http://127.0.0.1:8000/api/v1/invoice/get",
        public int per_page { get; set; } //"per_page": 15,
        public string prev_page_url { get; set; } //"prev_page_url": null,
        public int to { get; set; } //"to": 15,
        public int total { get; set; } //"total": 24
    }

    public class LinkData
    {
        public string url { get; set; }
        public string label { get; set; }
        public bool active { get; set; }
    }

    public class MasterData
    {
        public string id { get; set; }//"id": "7660a0bf-d0eb-4ced-9f83-1312e93ed7f5",
        public string title { get; set; }//"title": "ORDERPLAN",
        public string description { get; set; }//"description": "",
        public bool is_status { get; set; }//"is_status": true,
        public DateTime created_at { get; set; }//"created_at": "2021-06-12T07:29:20.000000Z",
        public DateTime updated_at { get; set; }//"updated_at": "2021-06-12T07:29:20.000000Z"
    }

    public class BatchGroup : MasterData { }

    public class ContainerType : MasterData { }

    public class User : AuthData { }
    public class ShipData : MasterData { }
    public class WhsData : MasterData { }
    public class TagData : MasterData { }
    public class AgencyData : MasterData { }
    public class DepartmentData : MasterData { }

    public class ZoneData
    { 
        public string id { get; set; } //"id": "c1f2a451-b1d7-4a4b-acb8-8abba5b88f18",
        public TagData get_tag_id { get; set; } //"tag_id": "01edb1ef-a69b-40f1-8371-332246b65389",
        public string zone_name { get; set; } //"zone_name": "CK1",
        public int zone_id { get; set; } //"zone_id": 1,
        public string description { get; set; } //"description": null,
        public bool is_status { get; set; } //"is_status": true,
        public DateTime created_at { get; set; } //"created_at": "2021-06-12T07:29:20.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-12T07:29:20.000000Z"
    }
    
    public class OrderGroupData
    {
        public string id { get; set; } //"id": "d87b6790-8a61-4f92-a32a-35ea7189196f",
        public string title { get; set; } //"title": "E",
        public string description { get; set; } //"description": "3 End chars.",
        public bool is_all { get; set; } //"is_all": false,
        public bool is_first { get; set; } //"is_first": false,
        public bool is_end { get; set; } //"is_end": true,
        public bool is_status { get; set; } //"is_status": true,
        public DateTime created_at { get; set; } //"created_at": "2021-06-12T07:29:21.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-12T07:29:21.000000Z"
    }
}
