using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ParzivalLibrary;
using ParzivalLibrary.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InvoiceApp
{
    public partial class frmSetPallet : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        InvoiceData __obj;
        public frmSetPallet(InvoiceData obj)
        {
            InitializeComponent();
            this.__obj = obj;
            this.Text = $"Set Pallet Invoice {obj.invoice_no}";
            Reload();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        void ReloadPallet()
        {
            // get pallet detail
            InvoicePalletResponse list = InvoiceService.GetInvoicePallet(this.__obj.id);
            List<InvoicePallet> obj = list.data.data;
            List<InvoicePallet> data = new List<InvoicePallet>();
            double x = 1;
            obj.ForEach(i => {
                i.pallet_running = x;
                i.pallet_no = $"{i.pallet_prefix}" + int.Parse(i.pallet_seq.ToString()).ToString("D3");
                i.pallet_size = $"{i.pallet_width}X{i.pallet_length}X{i.pallet_height}";
                data.Add(i);
                x++;
            });
            gridPalletControl.DataSource = data;
        }

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            ReloadPallet();
            //get invoice detail
            InvoiceDetailResponse __inv_detail = InvoiceService.GetDetail(this.__obj.id);
            List<InvoiceDetail> __inv_data = new List<InvoiceDetail>();
            __inv_detail.data.data.ForEach(i => {
                i.get_order_id.ctn = int.Parse((i.get_order_id.balqty / i.get_order_id.bistdp).ToString());
                i.get_order_id.get_part_id.dimension = $"{i.get_order_id.get_plan_id.biwidt}x{i.get_order_id.get_plan_id.bileng}x{i.get_order_id.get_plan_id.bihigh}";
                __inv_data.Add(i);
            });


            gridPartControl.DataSource = __inv_data;

            splashScreenManager1.CloseWaitForm();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }

        private void gridPartView_DoubleClick(object sender, System.EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            gridPalleteDetailControl.DataSource = null;
            InvoiceDetail obj = gridPartView.GetFocusedRow() as InvoiceDetail;
            InvCartonReponse list = InvoiceService.GetInvoiceCarton(obj.id);
            {
                list.data.data.ForEach(i => {
                    if (i.get_pallet_id != null)
                    {
                        i.get_pallet_id.pallet_no = $"{i.get_pallet_id.pallet_prefix}" + int.Parse(i.get_pallet_id.pallet_seq.ToString()).ToString("D3");
                        i.get_pallet_id.pallet_size = $"{i.get_pallet_id.pallet_width}x{i.get_pallet_id.pallet_length}x{i.get_pallet_id.pallet_height}";
                    }
                });
                gridPalleteDetailControl.DataSource = list.data.data;
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void gridPartView_Click(object sender, System.EventArgs e)
        {
            gridPalleteDetailControl.DataSource = null;
        }

        private void gridPalletView_Click(object sender, System.EventArgs e)
        {
            gridPalleteDetailControl.DataSource = null;
        }

        private void gridPalletView_DoubleClick(object sender, System.EventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            //gridPalleteDetailControl.DataSource = null;
            //InvoiceDetail obj = gridPartView.GetFocusedRow() as InvoiceDetail;
            //InvCartonReponse list = InvoiceService.GetInvoiceCarton(obj.id);
            //{
            //    list.data.data.ForEach(i => {
            //        if (i.get_pallet_id != null)
            //        {
            //            i.get_pallet_id.pallet_no = $"{i.get_pallet_id.pallet_prefix}" + int.Parse(i.get_pallet_id.pallet_seq.ToString()).ToString("D3");
            //            i.get_pallet_id.pallet_size = $"{i.get_pallet_id.pallet_width}x{i.get_pallet_id.pallet_length}x{i.get_pallet_id.pallet_height}";
            //        }
            //    });
            //    gridPalleteDetailControl.DataSource = list.data.data;
            //}
            //splashScreenManager1.CloseWaitForm();
        }

        private void gridPalletView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                // check delete pallet
                List<InvoicePallet> data = gridPalletControl.DataSource as List<InvoicePallet>;
                int __count_pl = 0;
                bool is_select = false;
                data.ForEach(i => {
                    if (i.is_select)
                    {
                        __count_pl++;
                        is_select = true;
                    }
                });
                bbiDelPallet.Caption = $"Delete Pallet({__count_pl})";
                bbiDelPallet.Enabled = is_select;

                // check change limit
                InvoicePallet __inv_pl = gridPalletView.GetFocusedRow() as InvoicePallet;
                bbiChangeLimit.Caption = $"Change {__inv_pl.pallet_no} Limit";
                bbiChangePalletSize.Caption = $"Change {__inv_pl.pallet_no} Size";
                ppPalletEdit.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void bbiAddPallet_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAddNewPallet _dialog = new frmAddNewPallet();
            DialogResult r = XtraDialog.Show(this, _dialog, $"Add New Pallet", MessageBoxButtons.OKCancel, DevExpress.Utils.DefaultBoolean.True);
            if (r == DialogResult.OK)
            {
                List<InvoicePallet> data = gridPalletControl.DataSource as List<InvoicePallet>;
                string[] x = _dialog.EditValue;
                InvoicePallet __inv_pl = new InvoicePallet();
                __inv_pl.pallet_prefix = x[0];
                __inv_pl.pallet_seq = data.Count + 1;
                __inv_pl.pallet_total = 0;
                __inv_pl.pallet_limit = double.Parse(x[1]);
                __inv_pl.pallet_width = double.Parse(x[2]);
                __inv_pl.pallet_length = double.Parse(x[3]);
                __inv_pl.pallet_height = double.Parse(x[4]);
                bool __is_status = InvoiceService.CreatePallet(data[0].get_invoice_id.id,__inv_pl);
                if (__is_status)
                {
                    MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อมูลเสร็จแล้ว!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    splashScreenManager1.ShowWaitForm();
                    ReloadPallet();
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดกรุณาติดต่อผู้ดูแลระบบด้วย!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bbiChangeLimit_ItemClick(object sender, ItemClickEventArgs e)
        {
            InvoicePallet __inv_pl = gridPalletView.GetFocusedRow() as InvoicePallet;
            // initialize a new XtraInputBoxArgs instance 
            XtraInputBoxArgs args = new XtraInputBoxArgs();
            // set required Input Box options 
            args.Caption = $"Chang {__inv_pl.pallet_no} Limit";
            args.Prompt = "กรุณาระบุจำนวนที่ต้องการเปลี่ยนด้วย.\nPlease enter a new total limit.";
            args.DefaultButtonIndex = 0;
            // initialize a DateEdit editor with custom settings 
            TextEdit editor = new TextEdit();
            editor.EditValue = "0";
            args.Editor = editor;
            var result = XtraInputBox.Show(args);
            if (result is null)
            {
                return;
            }

            try
            {
                int x = int.Parse(result.ToString());
                __inv_pl.pallet_limit = x;
                bool __is_status = InvoiceService.UpdatePallet(__inv_pl);
                if (__is_status)
                {
                    MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อมูลเสร็จแล้ว!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    splashScreenManager1.ShowWaitForm();
                    //ReloadPallet();
                    gridPalletView.BeginUpdate();
                    gridPalletView.SetRowCellValue(gridPalletView.FocusedRowHandle,"gridColumn35", x);
                    gridPalletView.UpdateSummary();
                    gridPalletView.EndUpdate();
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดกรุณาติดต่อผู้ดูแลระบบด้วย!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch {
                MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุจำนวนให้ถูกต้องด้วย!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiDelPallet_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<InvoicePallet> data = gridPalletControl.DataSource as List<InvoicePallet>;
            int __count = 0;
            data.ForEach(i => {
                if (i.is_select)
                {
                    __count++;
                }
            });

            DialogResult r = MetroFramework.MetroMessageBox.Show(this, $"ยืนยันคำสั่งลบข้อมูลพาเลทตามจำนวน({__count})นี้ใช่หรือไม่!", "ข้อความแจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (r == DialogResult.Yes)
            {
                splashScreenManager1.ShowWaitForm();
                bool __is_status = false;
                data.ForEach(i => {
                    if (i.is_select)
                    {
                        __is_status = InvoiceService.DeletePallet(i.id);
                    }
                });
                splashScreenManager1.CloseWaitForm();
                if (__is_status)
                {
                    MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อมูลเสร็จแล้ว!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    splashScreenManager1.ShowWaitForm();
                    ReloadPallet();
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดกรุณาติดต่อผู้ดูแลระบบด้วย!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bbiChangePalletSize_ItemClick(object sender, ItemClickEventArgs e)
        {
            InvoicePallet __inv_pl = gridPalletView.GetFocusedRow() as InvoicePallet;
            // initialize a new XtraInputBoxArgs instance 
            frmChangePalletSize _dialog = new frmChangePalletSize();
            DialogResult result = XtraDialog.Show(_dialog, $"Chang Pallet {__inv_pl.pallet_no} Size.", MessageBoxButtons.OKCancel, DevExpress.Utils.DefaultBoolean.True);
            if (result == DialogResult.OK)
            {
                string[]  obj = _dialog.EditValue;
                System.Console.WriteLine(obj);
                try
                {
                    __inv_pl.pallet_width = int.Parse(obj[0]);
                    __inv_pl.pallet_length = int.Parse(obj[1]);
                    __inv_pl.pallet_height = int.Parse(obj[2]);
                    bool __is_status = InvoiceService.UpdatePallet(__inv_pl);
                    if (__is_status)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อมูลเสร็จแล้ว!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        splashScreenManager1.ShowWaitForm();
                        //ReloadPallet();
                        gridPalletView.BeginUpdate();
                        gridPalletView.SetRowCellValue(gridPalletView.FocusedRowHandle, "gridColumn34", $"{obj[0]}x{obj[1]}x{obj[2]}");
                        gridPalletView.EndUpdate();
                        splashScreenManager1.CloseWaitForm();
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดกรุณาติดต่อผู้ดูแลระบบด้วย!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาดกรุณาติดต่อผู้ดูแลระบบด้วย!", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}