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
        }

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.CloseWaitForm();
        }

        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                ppAddPallet.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
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
                List<string> x = frm.Get();
                Console.WriteLine(x);
            }
        }

        private void bbiDeletePallet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reload();
        }
    }
}
