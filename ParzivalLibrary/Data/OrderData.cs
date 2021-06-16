using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class OrderData
    {
        public string id { get; set; }//"id": "e14c4362-4601-4b6a-a042-df84aa4735a5",
        public DateTime etd_date { get;set;}//"etd_date": "2021-06-01",
        public string group_no { get;set;}//"group_no": "BMW",
        public string pc { get;set;}//"pc": "C",
        public string commercial { get;set;}//"commercial": "C",
        public int bioabt { get;set;}//"bioabt": 1,
        public string ordertype { get;set;}//"ordertype": "M",
        public string bicomd { get;set;}//"bicomd": "W",
        public string biivpx { get;set;}//"biivpx": "TT",
        public string is_type { get;set;}//"is_type": "N",
        public bool is_split { get;set;}//"is_split": false,
        public bool is_check_agian { get;set;}//"is_check_agian": false,
        public bool sync { get;set;}//"sync": false,
        public string is_status { get;set;}//"is_status": "0",
        public DateTime created_at { get;set;}//"created_at": "2021-06-15T03:30:08.000000Z",
        public DateTime updated_at { get;set;}//"updated_at": "2021-06-15T03:30:10.000000Z",
        public BatchFileData get_gedi_id { get;set;}//"gedi_id": "7aadb181-0d55-4bc8-89e3-a8185807d93d",
        public TerritoryData get_customer_id { get;set;}//"customer_id": "3a9b4bdd-bcd1-42e8-bb7c-c7bb849ba1db",
        public ZoneData get_zone_id { get;set;}//"zone_id": "c1f2a451-b1d7-4a4b-acb8-8abba5b88f18",
        public ShipData get_ship_id { get;set;}//"ship_id": "c3100b8a-edec-4e52-8972-54181afa0e23",
    }
}
