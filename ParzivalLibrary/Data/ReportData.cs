using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzivalLibrary.Data
{
    public class ReportData
    {
        public class JobListData
        { 
            public int id { get; set; }
            public string partname { get; set; }
            public string orderno { get; set; }
            public double qty { get; set; }
            public double ctn { get; set; }
            public string lotno { get; set; }
            public string shelve { get; set; }
            public string plno { get; set; }
            public int total { get; set; }
            public string is_found { get; set; }
        }
    }
}
