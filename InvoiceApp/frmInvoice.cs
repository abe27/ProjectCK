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
    public partial class frmInvoice : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmInvoice()
        {
            InitializeComponent();
            bbiEtdDate.EditValue = DateTime.Now;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public InvoiceResponse GetDataSource() => InvoiceService.Get(DateTime.Parse(bbiEtdDate.EditValue.ToString()), bbiOnWeek.Checked);

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            InvoiceResponse dataSource = GetDataSource();
            gridControl.DataSource = dataSource.data.data;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.data.data.Count;
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            InvoiceResponse dataSource = InvoiceService.Get(null, null);
            gridControl.DataSource = dataSource.data.data;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.data.data.Count;
            splashScreenManager1.CloseWaitForm();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            InvoiceData obj = gridView.GetFocusedRow() as InvoiceData;
            frmInvoiceDetail frm = new frmInvoiceDetail(obj);
            frm.ShowDialog();
            Reload();
        }

        private void bbiEtdDate_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void bbiOnWeek_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Reload();
        }

        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }
    }
}