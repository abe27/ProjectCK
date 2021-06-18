using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class InvoiceCartonData
    {
        public string id { get; set; } //"id": "47f201d5-3496-4bd1-974e-f004cdfd7039",
        public InvoiceDetail get_part_id { get; set; } //"part_id": "191e9d05-1f55-4655-ab93-61c8f701e791",
        public InvoicePallet get_pallet_id { get; set; } //"pallet_id": null,
        public CartonData get_serial_id { get; set; } //"serial_id": null,
        public int seq { get; set; } //"seq": 1,
        public string carton_seq { get; set; } //"carton_seq": "C210606080",
        public double qty { get; set; } //"qty": "2000",
        public double weight { get; set; } //"weight": "0",
        public string carton_status { get; set; } //"carton_status": "-",
        public bool is_printed { get; set; } //"is_printed": false,
        public bool is_status { get; set; } //"is_status": true,
        public bool sync { get; set; } //"sync": false,
        public DateTime created_at { get; set; } //"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-15T03:51:59.000000Z"
    }

    public class InvCarton : HttpResponseData
    {
        public List<InvoiceCartonData> data { get; set; }
    }

    public class InvCartonReponse
    {
        public bool success { get; set; }
        public InvCarton data { get; set; }
    }
}
