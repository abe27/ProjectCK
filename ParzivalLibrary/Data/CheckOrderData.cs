using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class CheckOrderData
    {
        public string id { get; set; } //": "342179fd-816f-49c8-b0f6-d0d8135d578f",
        public int seq { get; set; } //": 34,
        public string factory { get; set; } //": "AW",
        public string affcode { get; set; } //": "32DE",
        public string custcode { get; set; } //": "32DE",
        public string custname { get; set; } //": "YEV-TV",
        public string shipment { get; set; } //": "B",
        public DateTime etdtap { get; set; } //": "2021-06-24",
        public string orderno { get; set; } //": "TT1073",
        public string partno { get; set; } //": "180D0203949",
        public string partname { get; set; } //": "AVSSH 0.5F W/L",
        public string lotno { get; set; } //": "VT216069",
        public int ctn { get; set; } //": "3",
        public string file_gedi { get; set; } //": "b6a90d82-d002-4448-bd7a-702018acf292",
        public bool found_data { get; set; } //": true,
        public string is_confirm { get; set; } //": false,
        public string is_check_again { get; set; } //": false,
        public bool sync { get; set; } //": true,
        public DateTime created_at { get; set; } //": "2021-06-21T02:04:57.000000Z",
        public DateTime updated_at { get; set; } //": "2021-06-21T02:04:57.000000Z"
    }

    public class CheckOrderObj : HttpResponseData
    {
        public List<CheckOrderData> data { get; set; }
    }

    public class CheckOrderResponse
    {
        public bool success { get; set; }
        public CheckOrderObj data { get; set; }
    }
}
