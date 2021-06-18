using DevExpress.XtraEditors;
using InvoiceApp.Reports;
using ParzivalLibrary;
using ParzivalLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceApp
{
    public partial class frmJobListPreview : DevExpress.XtraEditors.XtraForm
    {
        string __inv_id;
        public frmJobListPreview(string inv_id)
        {
            InitializeComponent();
            splashScreenManager1.ShowWaitForm();
            this.Text = $"Print Job List {inv_id}";
            this.__inv_id = inv_id;
            InvoiceDetailResponse list = InvoiceService.GetDetail(inv_id);
            rpJobList rp = new rpJobList();
            foreach (DevExpress.XtraReports.Parameters.Parameter i in rp.Parameters)
            {
                i.Visible = false;
            }
            rp.InitData(list.data.data);
            rp.PrinterName = "Print Job List";
            documentViewer1.DocumentSource = rp;
            rp.PaperKind = System.Drawing.Printing.PaperKind.A4;
            rp.Margins.Right = 1;
            rp.Margins.Top = 7;
            rp.CreateDocument();
            splashScreenManager1.CloseWaitForm();
        }
    }
}