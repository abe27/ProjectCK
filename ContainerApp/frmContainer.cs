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

namespace ContainerApp
{
    public partial class frmContainer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmContainer()
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
            ContainerResponse list = ContainerService.Get(DateTime.Parse(bbiEtd.EditValue.ToString()));
            int x = 1;
            list.data.data.ForEach(i => {
                i.container_seq = x;
                i.pl_count = i.get_detail.Count;
                x++;
            });
            gridControl.DataSource = list.data.data;
            bsiRecordsCount.Caption = "RECORDS : " + list.data.data.Count;
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAddNewContainer frm = new frmAddNewContainer();
            DialogResult r = XtraDialog.Show(frm, "Add Container", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                object[] x = frm.Get();
                if (x[0] is null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุข้อมูล\nContainer No ด้วย", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bbiNew_ItemClick(sender, e);
                }
                else if (x[1] is null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุข้อมูล\nSeal No ด้วย", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bbiNew_ItemClick(sender, e);
                }
                else if (x[2] is null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุข้อมูล\nSize ด้วย", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bbiNew_ItemClick(sender, e);
                }
                else if (x[3] is null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุข้อมูล\nวันปล่อยตู้ด้วย", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bbiNew_ItemClick(sender, e);
                }
                else if (x[4] is null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุข้อมูล\nวันที่ปล่อยตู้ด้วย", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bbiNew_ItemClick(sender, e);
                }
                else
                {
                    // post data
                    ContainerData __body = new ContainerData();
                    __body.container_no = (x[0]).ToString().ToUpper();
                    __body.seal_no = (x[1]).ToString().ToUpper();
                    __body.sizes = (x[2]).ToString().ToUpper();
                    __body.release_days = (x[3]).ToString();
                    __body.release_date = DateTime.Parse((x[4]).ToString());
                    bool res = ContainerService.Create(__body);
                    if (res is false)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาด\nไม่สามารถบันทึกข้อมูลได้!", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อมูลเสร็จแล้ว", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reload();
                }
            }
        }

        private void bbiEtd_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ContainerData obj = gridView.GetFocusedRow() as ContainerData;
            if (obj != null)
            {
                frmContainerDetail frm = new frmContainerDetail(obj);
                frm.ShowDialog();
                Reload();
            }
        }

        private void bbiPrintReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ContainerData obj = gridView.GetFocusedRow() as ContainerData;
            if (obj != null)
            {
                frmContainerView frm = new frmContainerView(obj);
                frm.ShowDialog();
            }
        }

        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                ContainerData obj = gridView.GetFocusedRow() as ContainerData;
                bbiPrintReport.Enabled = false;
                if (obj != null)
                {
                    bbiPrintReport.Enabled = true;
                    bbiPrintReport.Caption = $"Print {obj.container_no} Report";
                    ppPrintMenu.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
                }
            }
        }
    }
}