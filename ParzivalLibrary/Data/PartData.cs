using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class PartData
    {
        public string id { get; set; } //"id": "32a3be17-bd27-4633-9aea-ddc7c360d7bb",
        public string part_no { get; set; } //"part_no": "180D0203963",
        public string part_description { get; set; } //"part_description": "AVSSH 0.5F G/B",
        public string part_kind { get; set; } //"part_kind": "AVSSH",
        public string part_size { get; set; } //"part_size": "0.5F",
        public string part_color { get; set; } //"part_color": "G/B",
        public bool is_status { get; set; } //"is_status": true,
        public bool sync { get; set; } //"sync": false,
        public DateTime created_at { get; set; } //"created_at": "2021-06-12T07:29:46.000000Z",
        public DateTime updated_at { get; set; } //"updated_at": "2021-06-12T11:10:04.000000Z"
    }

    public class LedgerData
    {
        public string id { get; set; }
        public PartData get_part_id { get; set; }
        public WhsData get_whs_id { get; set; }
        public PartVendorData get_vendor_id { get; set; }
        public PartTypeData get_part_type_id { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public bool is_status { get; set; }
        public bool sync { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
