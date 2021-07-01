using DevExpress.XtraReports.UI;
using ParzivalLibrary;
using ParzivalLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace ContainerApp.Reports
{
    public partial class rpBookingReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rpBookingReport()
        {
            InitializeComponent();
        }

        internal void initData(ContainerData obj)
        {
            List<BookingData> list = new List<BookingData>();
            ContainerDetailResponse __list = ContainerService.GetDetail(obj.id);
            __list.data.data.ForEach(i => {
                list.Add(new BookingData()
                {
                    plno = $"1{i.get_pallet_id.pallet_prefix}{int.Parse(i.get_pallet_id.pallet_seq.ToString()).ToString("D3")}",
                    ploutno = i.get_pallet_id.pallet_out,
                    invoiceno = i.get_pallet_id.get_invoice_id.invoice_no,
                    customer = i.get_pallet_id.get_invoice_id.get_order_id.get_customer_id.get_customer_id.cust_name,
                    orderno = i.get_pallet_id.get_invoice_id.get_order_id.group_no,
                });
            });

            this.DataSource = list;
            if (list.Count > 0)
            {
                pPrintDate.Value = DateTime.Now;
                pQrCode.Value = $"|{obj.container_no}|{(obj.release_date).ToString("ddMMyyyy")}";
                pCustname.Value = null;
                pSize.Value = obj.sizes;
                pContainerNumber.Value = obj.container_no;
                pEtdDate.Value = obj.release_date;
            }
        }

        public class BookingData
        {
            public string plno { get; set; }
            public string ploutno { get; set; }
            public string invoiceno { get; set; }
            public string customer { get; set; }
            public string orderno { get; set; }
        }
    }
}
