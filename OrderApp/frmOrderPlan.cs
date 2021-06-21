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
    public partial class frmOrderPlan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmOrderPlan()
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

        void ReloadCustomer(object __txt_etd)
        {
            resCustomer.DataSource = null;
            DateTime etd = DateTime.Parse(__txt_etd.ToString());
            OrderPlanResponse list = OrderService.GetCustomer(bbiFactory.EditValue.ToString(),etd.ToString("yyyy-MM-dd"));
            if (list.data != null)
            {
                Console.WriteLine(list.data.data);
                resCustomer.DataSource = list.data.data;
            }
        }

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            var __txt_cust_id = bbiCustomer.EditValue;
            var __txt_like_pono = bbiPono.EditValue;

            gridControl.DataSource = null;
            bsiRecordsCount.Caption = "RECORDS : " + 0;

            DateTime etd = DateTime.Parse(bbiEtd.EditValue.ToString());
            OrderPlanResponse list = OrderService.GetPoWithCustomer(bbiFactory.EditValue.ToString(), etd.ToString("yyyy-MM-dd"), __txt_cust_id, __txt_like_pono);
            if (list.data != null)
            {
                list.data.data.ForEach(i => {
                    i.ctn = (i.balqty/i.bistdp); 
                });
                gridControl.DataSource = list.data.data;
                bsiRecordsCount.Caption = "RECORDS : " + list.data.data.Count;
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiEtd_EditValueChanged(object sender, EventArgs e)
        {
            // Get Customer
            var __txt_etd = bbiEtd.EditValue;
            ReloadCustomer(__txt_etd);
            Reload();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }

        private void bbiCustomer_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void bbiFactory_EditValueChanged(object sender, EventArgs e)
        {
            var __txt_etd = bbiEtd.EditValue;
            ReloadCustomer(__txt_etd);
            Reload();
        }
    }
}