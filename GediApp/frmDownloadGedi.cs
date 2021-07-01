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

namespace GediApp
{
    public partial class frmDownloadGedi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDownloadGedi()
        {
            InitializeComponent();
            bbiEtd.EditValue = DateTime.Now;
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        
        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            gridControl.DataSource = null;
            string is_status = "0";
            if (bbiDownload.Checked)
            {
                is_status = "1";
            }
            BatchFileResponse list = GediService.Get(is_status, DateTime.Parse(bbiEtd.EditValue.ToString()));

            int x = 1;
            list.data.data.ForEach(i => {
                i.seq = x;
                x++;
            });

            gridControl.DataSource = list.data.data;
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiEtd_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void bbiDownload_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Reload();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }

        private void bbiReDownload_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            BatchFileData obj = gridView.GetFocusedRow() as BatchFileData;
            bool x = GediService.Update(obj.id, "0", "1");
            if (x is false)
            {
                splashScreenManager1.CloseWaitForm();
                MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดกรุณาติดต่อผู้ดูแลระบบด้วย!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception)
            {
            }

            MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อมูลเสร็จแล้ว!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reload();
        }

        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            bbiReDownload.Caption = $"Re-Download";
            bbiReDownload.Enabled = false;
            if (e.Button.ToString() == "Right")
            {
                BatchFileData obj = gridView.GetFocusedRow() as BatchFileData;
                if (obj != null)
                {
                    bbiReDownload.Enabled = true;
                    bbiReDownload.Caption = $"Re-Download {obj.batch_file.ToString().Substring(0, 20)}....";
                    ppGediMenu.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
                }
            }
        }
    }
}