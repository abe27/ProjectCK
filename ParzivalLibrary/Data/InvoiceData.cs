using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class InvoiceData
    {
        public string id { get; set; }//"id": "91dae58f-6648-4cd2-8820-662ae2b3eefe",
        public string invoice_no { get; set; }//"invoice_no": "TWTT10001B",
        public string system_no { get; set; }//"system_no": "ATT-20210615-0001",
        public string vessel { get; set; }//"vessel": "",
        public string payment { get; set; }//"payment": "",
        public string zone_code { get; set; }//"zone_code": "TWTT10001B",
        public string ship_from { get; set; }//"ship_from": "",
        public string ship_to { get; set; }//"ship_to": "",
        public string via { get; set; }//"via": "",
        public string test { get; set; }//"title": "000",
        public string note_1 { get; set; }//"note_1": "",
        public string note_2 { get; set; }//"note_2": "",
        public string note_3 { get; set; }//"note_3": "",
        public string ctn_total { get; set; }//"ctn_total": "11",
        public string tap_flg { get; set; }//"tap_flg": "",
        public string resend_gedi { get; set; }//"resend_gedi": "-",
        public string send_gedi { get; set; }//"send_gedi": false,
        public string inv_type { get; set; }//"inv_type": "-",
        public string inv_status { get; set; }//"inv_status": "-",
        public string sync { get; set; }//"sync": "0",
        public DateTime created_at { get; set; }//"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; }//"updated_at": "2021-06-15T03:51:59.000000Z",
        public OrderData get_order_id { get; set; }//"get_order_id": [],
        public ContainerType get_container_type_id { get; set; }//"get_container_type_id": ,
        public User get_register_id { get; set; }//"get_register_id": []
    }

    public class InvObj : HttpResponseData
    {
        public List<InvoiceData> data { get; set; }
    }

    public class InvMessage
    {
        public string invoice_no { get; set; }
    }

    public class InvoiceResponse
    {
        public bool success { get; set; }
        public InvObj data { get; set; }
        public InvMessage message { get; set; }
    }

    public class InvDetail : HttpResponseData
    {
        public List<InvoiceDetail> data { get; set; }
    }

    public class InvoiceDetailResponse
    {
        public bool success { get; set; }
        public InvDetail data { get; set; }
    }

    public class InvoiceDetail
    {
        public string id { get; set; } //"id": "519e2687-a0d6-4064-9c73-67e45523eaae",
        public InvoiceData get_invoice_id { get; set; } //"invoice_id": "91dae58f-6648-4cd2-8820-662ae2b3eefe",
        public OrderDetail get_order_id { get; set; } //"order_id": "ce86bd80-8d3f-4ea0-9535-635b7a3d902b",
        public string set_pallet { get; set; } //"set_pallet": "0",
        public bool sync { get; set; } //"sync": false,
        public bool is_status { get; set; } //"is_status": true,
        public DateTime created_at { get; set; } //"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-15T03:51:59.000000Z",
    }
}
