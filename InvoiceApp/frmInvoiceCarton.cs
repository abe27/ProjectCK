using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ParzivalLibrary;
using ParzivalLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceApp
{
    public partial class frmInvoiceCarton : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        InvoiceDetail __obj;
        public frmInvoiceCarton(InvoiceDetail obj)
        {
            InitializeComponent();
            this.__obj = obj;
            this.Text = $"Show Carton From {this.__obj.get_order_id.get_plan_id.partno}";
            Reload();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            gridControl.DataSource = null;
            InvCartonReponse list = InvoiceService.GetInvoiceCarton(this.__obj.id);
            gridControl.DataSource = list.data.data;
            bsiRecordsCount.Caption = "RECORDS : " + list.data.data.Count;
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }
    }
}