using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class BatchFileData
    {
        public string id {get;set;} //": "7aadb181-0d55-4bc8-89e3-a8185807d93d",
        //public string group_id { get; set; }//": "7660a0bf-d0eb-4ced-9f83-1312e93ed7f5",
        public string batch_id { get; set; }//": "075942",
        public string batch_file { get; set; }//": "OES.VCBI.32T4.SPL20210409203000.TXT",
        public string batch_url { get; set; }//": "/storage/gedi/20210612144757.OES.VCBI.32T4.SPL20210409203000.TXT",
        public string batch_path { get; set; }//": "public/gedi/20210612144757.OES.VCBI.32T4.SPL20210409203000.TXT",
        public int batch_size { get; set; }//": 205184,
        public DateTime batch_at { get; set; }//": "2021-06-12 14:47:57",
        public string is_download { get; set; }//": "1",
        public bool is_status { get; set; }//": true,
        public DateTime created_at { get; set; }//": "2021-06-12T07:47:57.000000Z",
        public DateTime updated_at { get; set; }//": "2021-06-12T07:47:57.000000Z",
        public BatchGroup get_group_id { get; set; }//
    }
}
