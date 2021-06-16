using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class CustomerData
    {
        public string id { get;set;}//"id": "628f04f3-da53-4fb6-8274-3e73329485e4",
        public string aff_code { get;set;}//"aff_code": "32BF",
        public string cust_code { get;set;}//"cust_code": "32BF",
        public string cust_name { get;set;}//"cust_name": "TJYCD",
        public bool is_status { get;set;}//"is_status": true,
        public DateTime created_at { get;set;}//"created_at": "2021-06-12T07:29:20.000000Z",
        public DateTime updated_at { get; set; }//"updated_at": "2021-06-12T07:29:20.000000Z"
    }

    public class CustomerAddressData
    { 
        public string id { get; set; } //"id": "e11d4b43-daa3-43c5-beca-42ed47d94bb1",
        public string cust_name { get; set; } //"cust_name": "32BF",
        public string company { get; set; } //"company": "TIANJIN YAZAKI AUTOMOTIVE PARTS CO.,LTD",
        public string address { get; set; } //"address": "NO.138 DONGTING ROAD, TIANJIN ECONOMIC-TECHNOLOGICAL DEVELOPMENT AREA TIANJIN CHINA YANG YONG HUI",
        public bool sync { get; set; } //"sync": true,
        public bool is_status { get; set; } //"is_status": true,
        public DateTime created_at { get; set; } //"created_at": "2021-06-12T07:29:21.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-12T07:29:21.000000Z"
    }

    public class ProfileData
    {
        public string id { get; set; } //"id": "42fbb227-2fbb-4e92-b15b-8e7e53eed80b",
        public List<User> get_user_id { get; set; } //"user_id": "f3993a93-3d10-4d0f-8d9d-a32989fdf28f",
        public List<WhsData> get_whs_id { get; set; } //"whs_id": "834ca815-33ae-4f39-be7b-f9443da39a3c",
        public List<AgencyData> get_agency_id { get; set; } //"agency_id": null,
        public List<DepartmentData> get_department_id { get; set; } //"department_id": null,
        public string emp_code { get; set; } //"emp_code": "CHIRAPORN",
        public string first_name { get; set; } //"first_name": "Chiraporn",
        public string last_name { get; set; } //"last_name": null,
        public string user_status { get; set; } //"user_status": "USER",
        public DateTime? birth_day { get; set; } //"birth_day": null,
        public string mobile_no { get; set; } //"mobile_no": null,
        public string tel_no { get; set; } //"tel_no": null,
        public string avatars { get; set; } //"avatars": null,
        public bool is_status { get; set; } //"is_status": true,
        public DateTime created_at { get; set; } //"created_at": "2021-06-12T07:32:26.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-12T07:32:26.000000Z"
    }

    public class TerritoryData
    { 
        public string id { get; set; } //"id": "3a9b4bdd-bcd1-42e8-bb7c-c7bb849ba1db",
        public string prefixt { get; set; } //"prefix": "TT",
        public bool ship_air { get; set; } //"ship_air": true,
        public bool ship_boat { get; set; } //"ship_boat": true,
        public bool ship_truck { get; set; } //"ship_truck": true,
        public bool by_pallet { get; set; } //"by_pallet": true,
        public bool new_seq { get; set; } //"new_seq": true,
        public bool weight_limit { get; set; } //"weight_limit": false,
        public int weight_limit_total { get; set; } //"weight_limit_total": 0,
        public bool sync { get; set; } //"sync": false,
        public bool is_status { get; set; } //"is_status": false,
        public DateTime created_at { get; set; } //"created_at": "2021-06-12T07:32:27.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-12T07:32:27.000000Z",
        public ProfileData get_user_id { get; set; } //"get_user_id": 
        public CustomerData get_customer_id { get; set; } //"get_customer_id": 
        public CustomerAddressData get_address_id { get; set; } //"get_address_id": 
        public TagData get_tag_id { get; set; } //"get_tag_id": 
        public OrderGroupData get_group_id { get; set; } //"get_group_id": 
    }
}
