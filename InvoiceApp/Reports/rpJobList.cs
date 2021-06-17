using DevExpress.XtraReports.UI;
using ParzivalLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using static ParzivalLibrary.Data.ReportData;

namespace InvoiceApp.Reports
{
    public partial class rpJobList : DevExpress.XtraReports.UI.XtraReport
    {
        public rpJobList()
        {
            InitializeComponent();
        }


        internal void InitData(List<InvoiceDetail> data)
        {
            int i = 0;
            if (data.Count > 0)
            {
                var r = data[i];
                prInvoice.Value = r.get_invoice_id.invoice_no;
                prRefNo.Value = r.get_invoice_id.system_no;
                prShipType.Value = r.get_order_id.get_order_id.get_ship_id.description;
                prWhs.Value = r.get_order_id.get_order_id.get_zone_id.zone_name;
                prAffCode.Value = r.get_order_id.get_plan_id.biac;
                prCustCode.Value = r.get_order_id.get_plan_id.bishpc;
                prCountry.Value = r.get_order_id.get_plan_id.bisafn;
                prEtd.Value = r.get_order_id.get_plan_id.etdtap;
                prFactory.Value = r.get_order_id.get_plan_id.factory;
                prGroupOrder.Value = r.get_order_id.get_order_id.group_no;
                prQrCode.Value = r.get_invoice_id.system_no;
                prPrintDate.Value = DateTime.Now;
            }

            List<JobListData> list = new List<JobListData>();
            double xqty = 0;
            double xctn = 0;
            data.ForEach(j => {
                xqty += j.get_order_id.balqty;
                xctn += (j.get_order_id.balqty/j.get_order_id.bistdp);
                list.Add(new JobListData()
                {
                    id = list.Count + 1,
                    partname = j.get_order_id.get_plan_id.partname,
                    orderno = j.get_order_id.get_plan_id.pono,
                    qty = j.get_order_id.get_plan_id.balqty,
                    ctn = (j.get_order_id.balqty/j.get_order_id.bistdp),
                    lotno = j.get_order_id.lotno
                });
            });
            prBalQty.Value = xqty;
            prTotal.Value = xctn;

            this.DataSource = list;
        }
    }
}
