using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class ContainerData
    {
        public string id { get; set; }
        public int container_seq { get; set; }
        public string container_no { get; set; }
        public string seal_no { get; set; }
        public string sizes { get; set; }
        public string release_days { get; set; }
        public DateTime release_date { get; set; }
        public string loaded { get; set; }
        public bool sync { get; set; }
        public int pl_count { get; set; }
        public List<ContianerDetailData> get_detail { get; set; }
        public DateTime created_at { get; set; }//"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; }//"updated_at": "2021-06-15T03:51:59.000000Z",
    }

    public class ContainerObj : HttpResponseData
    {
        public List<ContainerData> data { get; set; }
    }

    public class ContainerResponse
    {
        public bool success { get; set; }
        public ContainerObj data { get; set; }
        public object message { get; set; }
    }

    public class ContianerDetailData
    {
        public string id { get; set; }
        public int seq { get; set; }
        public ContainerData get_container_id { get; set; }
        public List<InvoicePallet> get_pallet_id { get; set; }
        public bool loaded { get; set; }
        public bool sync { get; set; }
        public DateTime created_at { get; set; }//"created_at": "2021-06-15T03:51:59.000000Z",
        public DateTime updated_at { get; set; }//"updated_at": "2021-06-15T03:51:59.000000Z",
    }

    public class PostContainerDetail
    {
        public string container_id { get; set; }
        public string pallet_id { get; set; }
        public bool loaded { get; set; }
        public bool sync { get; set; }
    }
}
