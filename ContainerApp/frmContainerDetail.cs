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
    public partial class frmContainerDetail : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ContainerData __obj;
        public frmContainerDetail(ContainerData obj)
        {
            InitializeComponent();
            this.Text = $"Container {obj.container_no} Detail";
            this.__obj = obj;
            bbiContainerNo.EditValue = obj.container_no;
            bbiSealNo.EditValue = obj.seal_no;
            bbiSize.EditValue = obj.sizes;
            //bbiReleaseDay.EditValue = obj.release_days;
            bbiReleaseDate.EditValue = obj.release_date;
            Reload();
        }

        void Reload()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
            }
            catch (Exception)
            {
            }
            gridControl.DataSource = null;
            ContainerDetailResponse __list = ContainerService.GetDetail(this.__obj.id);
            int x = 1;
            __list.data.data.ForEach(i => {
                i.seq = x;
                i.get_pallet_id.pallet_no = $"1{i.get_pallet_id.pallet_prefix}{int.Parse(i.get_pallet_id.pallet_seq.ToString()).ToString("D3")}";
                x++;
            });
            gridControl.DataSource = __list.data.data;
            splashScreenManager1.CloseWaitForm();
        }

        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            ContianerDetailData obj = gridView.GetFocusedRow() as ContianerDetailData;
            bbiDeletePallet.Enabled = false;
            bbiDeletePallet.Caption = $"Delete Pallete";
            if (e.Button.ToString() == "Right")
            {
                if (obj != null)
                {
                    bbiDeletePallet.Enabled = true;
                    bbiDeletePallet.Caption = $"Delete {obj.get_pallet_id.pallet_no}";
                    ppAddPallet.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
                }
            }
        }

        private void bbiReleaseDate_DateTimeChanged(object sender, EventArgs e)
        {
            bbiReleaseDay.EditValue = (DateTime.Parse(bbiReleaseDate.EditValue.ToString()).DayOfWeek).ToString().Substring(0, 3);
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            this.__obj.container_no = bbiContainerNo.EditValue.ToString();
            this.__obj.seal_no = bbiSealNo.EditValue.ToString();
            this.__obj.sizes = bbiSize.EditValue.ToString();
            this.__obj.release_days = bbiReleaseDay.EditValue.ToString();
            this.__obj.release_date = DateTime.Parse(bbiReleaseDate.EditValue.ToString());
            bool _update = ContainerService.Update(this.__obj);
            if (_update)
            {
                splashScreenManager1.CloseWaitForm();
                MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อทมูลเสร็จแล้ว", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
                return;
            }

            try
            {
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception)
            {
            }

            MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดระหว่างการบันทึกข้อมูล", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void bbiAddNewPallet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmShowPallet frm = new frmShowPallet(this.__obj);
            frm.ShowDialog();
            if (frm.Get() != null)
            {
                Reload();
            }
        }

        private void bbiDeletePallet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ContianerDetailData obj = gridView.GetFocusedRow() as ContianerDetailData;
            if (obj != null)
            {
                DialogResult r = MetroFramework.MetroMessageBox.Show(this, $"คุณต้องการที่จะลบข้อมูล {obj.get_pallet_id.pallet_no} ใช่หรือไม่?", "ยืนยันคำสั่ง", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    splashScreenManager1.ShowWaitForm();
                    bool x = ContainerService.DeleteDetail(obj.id);
                    if (x)
                    {
                        Reload();
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
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reload();
        }

        private void bbiPrintReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmContainerView frm = new frmContainerView(this.__obj);
            frm.ShowDialog();
        }
    }
}
