using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class InvoicePallet
    {
        public string id { get; set; }
        public InvoiceData get_invoice_id { get; set; }
        public string pallet_prefix { get; set; }
        public double pallet_running { get; set; }
        public double pallet_seq { get; set; }

        public double pallet_total { get; set; }
        public double pallet_limit { get; set; }
        public double pallet_width { get; set; }
        public double pallet_length { get; set; }
        public double pallet_height { get; set; }
        public string pallet_out { get; set; }
        public string pallet_status { get; set; }
        public string pallet_no { get; set; }
        public string pallet_size { get; set; }
        public bool sync { get; set; }
        public bool is_status { get; set; }
        public bool is_select { get; set; }
        public DateTime created_at { get; set; }//"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; }//"updated_at": "2021-06-15T03:51:59.000000Z",
    }

    public class InvPallet : HttpResponseData
    {
        public List<InvoicePallet> data { get; set; }
    }

    public class InvoicePalletResponse
    {
        public bool success { get; set; }
        public InvPallet data { get; set; }
    }
}
