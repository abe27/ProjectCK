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

namespace OrderApp
{
    public partial class frmCheckOrder : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCheckOrder()
        {
            InitializeComponent();
            bbiEtd.EditValue = DateTime.Now;
            //gridControl.DataSource = GetDataSource();
            //BindingList<Customer> dataSource = GetDataSource();
            //gridControl.DataSource = dataSource;
            //bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void frmCheckOrder_Load(object sender, EventArgs e)
        {

        }

        void GetCustomer(string etd)
        {
            CheckOrderResponse list = OrderService.GetGroupCustomer(etd);
            bbiCustomer.EditValue = "";
            repCustomer.DataSource = null;
            if (list.data != null)
            {
                repCustomer.DataSource = list.data.data;
            }
        }

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            gridControl.DataSource = null;
            bsiRecordsCount.Caption = "RECORDS : " + 0;
            string etd = DateTime.Parse(bbiEtd.EditValue.ToString()).ToString("yyyyMMdd");
            CheckOrderResponse list = OrderService.GetCheckOrder(bbiCustomer.EditValue,etd);
            if (list.data != null)
            {
                int x = 1;
                list.data.data.ForEach(i => {
                    i.seq = x;
                    x += 1;
                });
                gridControl.DataSource = list.data.data;
                bsiRecordsCount.Caption = "RECORDS : " + list.data.data.Count;
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiEtd_EditValueChanged(object sender, EventArgs e)
        {
            string etd = DateTime.Parse(bbiEtd.EditValue.ToString()).ToString("yyyyMMdd");
            GetCustomer(etd);
            Reload();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            string etd = DateTime.Parse(bbiEtd.EditValue.ToString()).ToString("yyyyMMdd");
            GetCustomer(etd);
            Reload();
        }

        private void bbiCustomer_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }
    }
}