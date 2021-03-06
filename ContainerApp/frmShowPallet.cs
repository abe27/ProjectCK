using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using ParzivalLibrary;
using ParzivalLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerApp
{
    public partial class frmShowPallet : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ContainerData __obj;
        public frmShowPallet(ContainerData obj)
        {
            InitializeComponent();
            this.__obj = obj;
            bbiEtd.EditValue = DateTime.Now;
        }

        public List<string> Get()
        {
            List<string> list = new List<string>();
            return list;
        }

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            gridInvoiceControl.DataSource = null;
            gridPalletControl.DataSource = null;

            // get invoice list
            InvoiceResponse __inv = InvoiceService.Get(bbiFactory.EditValue.ToString(), DateTime.Parse(bbiEtd.EditValue.ToString()), null);
            List<InvoiceData> obj = __inv.data.data;
            int x = 1;
            obj.ForEach(i => {
                i.seq = x;
                i.pl_count = i.get_pallet_list.Count;
                x++;
            });
            gridInvoiceControl.DataSource = obj;
            splashScreenManager1.CloseWaitForm();

            // load container detail
            ReloadContainer();
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reload();
        }

        private void bbiEtd_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void bbiFactory_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void gridInvoiceView_Click(object sender, EventArgs e)
        {
            gridPalletControl.DataSource = null;
            InvoiceData __inv = gridInvoiceView.GetFocusedRow() as InvoiceData;

            int x = 1;
            __inv.get_pallet_list.ForEach(i => {
                i.seq = x;
                i.pallet_no = $"1{i.pallet_prefix}{int.Parse(i.pallet_seq.ToString()).ToString("D3")}";
                i.pallet_diff = (i.pallet_limit-i.pallet_total);
                x++;
            });
            gridPalletControl.DataSource = __inv.get_pallet_list;
        }

        private void gridPalletView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                InvoicePallet obj = gridPalletView.GetFocusedRow() as InvoicePallet;
                if (obj != null)
                {
                    bbiSetToContainer.Caption = $"Send {obj.pallet_no} To Container";
                    ppAddToContainer.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
                }
            }
        }

        void ReloadContainer()
        {
            splashScreenManager1.ShowWaitForm();
            gridContainerPlControl.DataSource = null;

            ContainerDetailResponse __list = ContainerService.GetDetail(this.__obj.id);
            int x = 1;
            __list.data.data.ForEach(i => {
                i.seq = x;
                i.get_pallet_id.pallet_no = $"1{i.get_pallet_id.pallet_prefix}{int.Parse(i.get_pallet_id.pallet_seq.ToString()).ToString("D3")}";
                x++;
            });
            gridContainerPlControl.DataSource = __list.data.data;
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiSetToContainer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            InvoicePallet obj = gridPalletView.GetFocusedRow() as InvoicePallet;
            Console.WriteLine(obj);
            PostContainerDetail __body = new PostContainerDetail();
            __body.container_id = __obj.id;
            __body.pallet_id = obj.id;
            __body.loaded = false;
            __body.sync = false;
            bool x = ContainerService.CreateDetailt(__body);
            if (x)
            {
                splashScreenManager1.CloseWaitForm();
                // delete after remove
                gridPalletView.BeginUpdate();
                gridPalletView.DeleteSelectedRows();
                gridPalletView.EndUpdate();

                ReloadContainer();
                return;
            }
            MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดระหว่างการบันทึกข้อมูล", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bbiDelPl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ContianerDetailData obj = gridContainerPlView.GetFocusedRow() as ContianerDetailData;
            DialogResult r = MetroFramework.MetroMessageBox.Show(this, $"คุณต้องการที่จะลบข้อมูล {obj.get_pallet_id.pallet_no} ใช่หรือไม่?", "ยืนยันคำสั่ง", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                splashScreenManager1.ShowWaitForm();
                bool x = ContainerService.DeleteDetail(obj.id);
                if (x)
                {
                    splashScreenManager1.CloseWaitForm();
                    ReloadContainer();
                    return;
                }
            }

            try
            {
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception)
            {
            }

            MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดระหว่างการบันทึกข้อมูล", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridContainerPlView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                ContianerDetailData obj = gridContainerPlView.GetFocusedRow() as ContianerDetailData;
                bbiDelPl.Enabled = false;
                if (obj != null)
                {
                    bbiDelPl.Enabled = true;
                    bbiDelPl.Caption = $"Delete {obj.get_pallet_id.pallet_no}";
                    ppContainerMenu.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
                }
            }
        }

        private void bbiReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmContainerView frm = new frmContainerView(this.__obj);
            frm.ShowDialog();
        }
    }
}
