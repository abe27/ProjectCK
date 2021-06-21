using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class OrderPlan
    {
        public string id { get; set; } //"id": "7b1b6286-c285-4445-b670-347150251972",
        public BatchFileData get_gedi_id { get; set; } //"gedi_id": "7aadb181-0d55-4bc8-89e3-a8185807d93d",
        public int seq { get; set; } //"seq": 17,
        public string vendor { get; set; } //"vendor": "AW",
        public double cd { get; set; } //"cd": "10",
        public string unit { get; set; } //"unit": "COIL",
        public string whs { get; set; } //"whs": "AW",
        public string tagrp { get; set; } //"tagrp": "C",
        public string factory { get; set; } //"factory": "AW",
        public string sortg1 { get; set; } //"sortg1": "PONO",
        public string sortg2 { get; set; } //"sortg2": "PARTTYPE",
        public string sortg3 { get; set; } //"sortg3": "PARTNO",
        public string plantype { get; set; } //"plantype": "ORDERPLAN",
        public string orderid { get; set; } //"orderid": "TT21073BMW",
        public string pono { get; set; } //"pono": "TT21073BMW",
        public string recid { get; set; } //"recid": "BI00",
        public string biac { get; set; } //"biac": "32BF",
        public string shiptype { get; set; } //"shiptype": "B",
        public DateTime etdtap { get; set; } //"etdtap": "2021-06-01",
        public string partno { get; set; } //"partno": "180D0203963",
        public string partname { get; set; } //"partname": "AVSSH 0.5F G/B",
        public string pc { get; set; } //"pc": "C",
        public string commercial { get; set; } //"commercial": "C",
        public string sampleflg { get; set; } //"sampleflg": "N",
        public int orderorgi { get; set; } //"orderorgi": 1500,
        public int orderround { get; set; } //"orderround": 1500,
        public string firmflg { get; set; } //"firmflg": "F",
        public string shippedflg { get; set; } //"shippedflg": "N",
        public double shippedqty { get; set; } //"shippedqty": "0.0",
        public DateTime ordermonth { get; set; } //"ordermonth": "2021-07-01",
        public double balqty { get; set; } //"balqty": "1500",
        public string bidrfl { get; set; } //"bidrfl": "N",
        public string deleteflg { get; set; } //"deleteflg": "N",
        public string ordertype { get; set; } //"ordertype": "M",
        public string reasoncd { get; set; } //"reasoncd": "",
        public string upddte { get; set; } //"upddte": "2021-04-09",
        public string updtime { get; set; } //"updtime": "09:58:17",
        public string carriercode { get; set; } //"carriercode": "",
        public int bioabt { get; set; } //"bioabt": 1,
        public string bicomd { get; set; } //"bicomd": "W",
        public double bistdp { get; set; } //"bistdp": "1500",
        public double binewt { get; set; } //"binewt": "6890",
        public double bigrwt { get; set; } //"bigrwt": "0",
        public string bishpc { get; set; } //"bishpc": "32BF",
        public string biivpx { get; set; } //"biivpx": "TT",
        public string bisafn { get; set; } //"bisafn": "TJY",
        public double biwidt { get; set; } //"biwidt": "0",
        public double bihigh { get; set; } //"bihigh": "0",
        public double bileng { get; set; } //"bileng": "0",
        public string lotno { get; set; } //"lotno": "NB315023",
        public int minimum { get; set; } //"minimum": 0,
        public int maximum { get; set; } //"maximum": 0,
        public string picshelfbin { get; set; } //"picshelfbin": "PNON",
        public string stkshelfbin { get; set; } //"stkshelfbin": "SNON",
        public string ovsshelfbin { get; set; } //"ovsshelfbin": "ONON",
        public int picshelfbasicqty { get; set; } //"picshelfbasicqty": 0,
        public int outerpcs { get; set; } //"outerpcs": 0,
        public int allocateqty { get; set; } //"allocateqty": 0,
        public double ctn { get; set; } //"ctn": 0,
        public bool sync { get; set; } //"sync": true,
        public DateTime created_at { get; set; } //"created_at": "2021-06-12T07:47:57.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-12T11:10:04.000000Z"
    }

    public class OrderPlanObj : HttpResponseData
    {
        public List<OrderPlan> data { get; set; }
    }

    public class OrderPlanResponse
    {
        public bool success { get; set; }
        public OrderPlanObj data { get; set; }
    }

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

    public class OrderDetail
    { 
        public string id { get; set; } //"id": "ce86bd80-8d3f-4ea0-9535-635b7a3d902b",
        public OrderPlan get_plan_id { get; set; } //"plan_id": "7b1b6286-c285-4445-b670-347150251972",
        public OrderData get_order_id { get; set; } //"order_id": "e14c4362-4601-4b6a-a042-df84aa4735a5",
        public ReviseData get_revise_id { get; set; } //"revise_id": "3a5514fc-c34b-4ba8-bc7d-30b7470f910f",
        public LedgerData get_part_id { get; set; } //"part_id": "4ea831da-970f-4d32-8283-1ca32a1f0bb7",
        public UnitData get_unit_id { get; set; } //"unit_id": "4f05af93-7c5a-4082-b734-7b9df57468f5",
        public string pono { get; set; } //"pono": "TT21073BMW",
        public string sampleflg { get; set; } //"sampleflg": "N",
        public double orderorgi { get; set; } //"orderorgi": "1500",
        public double orderround { get; set; } //"orderround": "1500",
        public string firmflg { get; set; } //"firmflg": "F",
        public string shippedflg { get; set; } //"shippedflg": "N",
        public double shippedqty { get; set; } //"shippedqty": "0",
        public DateTime ordermonth { get; set; } //"ordermonth": "2021-07-01",
        public double balqty { get; set; } //"balqty": "1500",
        public double ctn { get; set; } //"ctn": "1500",
        public string bidrfl { get; set; } //"bidrfl": "N",
        public string deleteflg { get; set; } //"deleteflg": "N",
        public string reasoncd { get; set; } //"reasoncd": "",
        public string carriercode { get; set; } //"carriercode": "",
        public double bistdp { get; set; } //"bistdp": "1500",
        public double binewt { get; set; } //"binewt": "6890",
        public double bigrwt { get; set; } //"bigrwt": "0",
        public double biwidt { get; set; } //"biwidt": "0",
        public double bihigh { get; set; } //"bihigh": "0",
        public double bileng { get; set; } //"bileng": "0",
        public string lotno { get; set; } //"lotno": "NB315023",
        public bool sync { get; set; } //"sync": false,
        public bool is_status { get; set; } //"is_status": true,
        public DateTime created_at { get; set; } //"created_at": "2021-06-15T03:30:08.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-15T03:30:08.000000Z",
    }
}
