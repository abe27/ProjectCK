using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using InvoiceApp;
using OrderApp;
using ReceiveApp;
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

namespace CloudApp
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            //gridControl.DataSource = GetDataSource();
            //BindingList<Customer> dataSource = GetDataSource();
            //gridControl.DataSource = dataSource;
            //bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            //gridControl.ShowRibbonPrintPreview();
        }
        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult r = MetroFramework.MetroMessageBox.Show(this, "คุณต้องการที่จะปิดโปรแกรมนี้ใช่หรือไม่?\nDo you want to close this program?", "ข้อความแจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (r == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }

        private void bbiInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            // get invoice form
            frmInvoice frm = new frmInvoice();
            frm.Show();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult r = MetroFramework.MetroMessageBox.Show(this, "คุณต้องการที่จะปิดโปรแกรมนี้ใช่หรือไม่?\nDo you want to close this program?", "ข้อความแจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (r == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }

        private void bbiOrderPlaning_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmOrderPlan frm = new frmOrderPlan();
            frm.Show();
        }

        private void bbiOrderEnties_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmOrderEnt frm = new frmOrderEnt();
            frm.Show();
        }

        private void bbiCheckOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCheckOrder frm = new frmCheckOrder();
            frm.Show();
        }

        private void bbiReceiveResult_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmReceive frm = new frmReceive();
            frm.ShowDialog();
        }

        private void bbiAddIcam_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiLoading_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiDownload_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiUpload_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}