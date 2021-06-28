using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSpellChecker.Parser;
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

namespace ReceiveApp
{
    public partial class frmReceive : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmReceive()
        {
            InitializeComponent();
            bbiReceiveDate.EditValue = DateTime.Now;
            //gridControl.DataSource = GetDataSource();
            //BindingList<Customer> dataSource = GetDataSource();
            //gridControl.DataSource = dataSource;
            //bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
        }

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            DateTime etd = DateTime.Parse(bbiReceiveDate.EditValue.ToString());
            bbiReSync.Enabled = false;
            bbiReSync.Caption = $"Reset Sync";
            gridControl.DataSource = null;
            bsiRecordsCount.Caption = "RECORDS : " + 0;
            ReceiveEntResponse list = ReceiveService.Get(etd);
            if (list.data != null)
            {
                int x = 1;
                list.data.data.ForEach(i => {
                    decimal pln = 0;
                    decimal rec_ctn = 0;

                    i.seq = x;
                    i.get_receive_detail.ForEach(y => {
                        pln += y.plan_ctn;
                        rec_ctn += y.rec_ctn;
                    });

                    i.receive_plan = pln;
                    i.receive_rec = rec_ctn;
                    i.receive_diff = pln - rec_ctn;
                    x++;
                });
                gridControl.DataSource = list.data.data;
                bsiRecordsCount.Caption = "RECORDS : " + list.data.data.Count;
            }
            splashScreenManager1.CloseWaitForm();
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }

        private void bbiReSync_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReceiveData obj = gridView.GetFocusedRow() as ReceiveData;
            DialogResult r = MetroFramework.MetroMessageBox.Show(this, $"คุณต้องการ\nที่จะโหลดข้อมูล {obj.receive_no} ใหม่ใช่หรือไม่?", "ข้อความแจ้งเตือน!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                ReceiveEntResponse list = ReceiveService.Update(obj);
                if (list.success is false)
                {
                    MetroFramework.MetroMessageBox.Show(this, $"บันทึกข้อมูลเสร็จแล้ว\nระบบกำลังจะโหลดข้อมูล {obj.receive_no} อีกครั้ง", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reload();
                }
            }
        }

        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                ReceiveData obj = gridView.GetFocusedRow() as ReceiveData;
                bbiReSync.Enabled = true;
                bbiReSync.Caption = $"Sync {obj.receive_no} Agian!";
                ppReceiveMenu.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
            }
            else
            {
                bbiReSync.Enabled = false;
                bbiReSync.Caption = $"Reset Sync";
            }
        }

        private void bbiReceiveDate_EditValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ReceiveData obj = gridView.GetFocusedRow() as ReceiveData;
            frmReceiveDetail frm = new frmReceiveDetail(obj);
            frm.ShowDialog();
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName.ToString())
                {
                    case "receive_diff":
                        switch (e.DisplayText.ToString())
                        {
                            case "0":
                                e.DisplayText = "";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }
    }
}