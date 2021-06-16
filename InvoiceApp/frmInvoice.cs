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
        public InvoiceRespone GetDataSource() => InvoiceService.Get();

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            InvoiceRespone dataSource = GetDataSource();
            gridControl.DataSource = dataSource.data.data;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.data.data.Count;
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            InvoiceData obj = gridView.GetFocusedRow() as InvoiceData;
            Console.WriteLine(obj);
        }

        private void bbiEtdDate_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void bbiOnWeek_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Reload();
        }
    }
}