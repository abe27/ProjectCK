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
    public partial class frmInvoiceDetail : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        InvoiceData __obj = new InvoiceData();
        bool __status_change = false;
        bool __status_change_etd = false;
        bool __status_change_shipment = false;
        bool __status_change_container = false;
        public frmInvoiceDetail(InvoiceData obj)
        {
            InitializeComponent();
            __obj = obj;
            this.Text = $"Invoice Detail({obj.system_no})";
            __status_change = false;
            __status_change_etd = false;
            __status_change_shipment = false;
            __status_change_container = false;
            bbiContainerType.Enabled = __status_change_container;
            bbiInvoiceDate.Enabled = __status_change_etd;
            bbiShipMent.Enabled = __status_change_shipment;

            Reload();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        public InvoiceDetailResponse GetDataSource() => InvoiceService.GetDetail(this.__obj.id);

        void Reload()
        {
            gridControl.DataSource = null;
            splashScreenManager1.ShowWaitForm();

            InvoiceDetailResponse dataSource = GetDataSource();
            dataSource.data.data.ForEach(i => {
                i.get_order_id.ctn = (i.get_order_id.balqty/i.get_order_id.bistdp);
            });
            gridControl.DataSource = dataSource.data.data;

            // add variable
            bbiInvoiceNo.EditValue = dataSource.data.data[0].get_invoice_id.invoice_no;
            bbiInvoiceDate.EditValue = dataSource.data.data[0].get_order_id.get_order_id.etd_date;
            bbiShipToCode.EditValue = dataSource.data.data[0].get_order_id.get_plan_id.biac;
            bbiBillToCode.EditValue = dataSource.data.data[0].get_order_id.get_plan_id.bishpc;
            bbiCountry.EditValue = dataSource.data.data[0].get_order_id.get_plan_id.bisafn;
            bbiShipMent.EditValue = dataSource.data.data[0].get_order_id.get_plan_id.shiptype;
            bbiPC.EditValue = dataSource.data.data[0].get_order_id.get_plan_id.pc;
            bbiCommercial.EditValue = dataSource.data.data[0].get_order_id.get_plan_id.commercial;
            bbiVessel.EditValue = dataSource.data.data[0].get_invoice_id.vessel;
            bbiTitle.EditValue = "000";
            bbiPaymentTerm.EditValue = "-";
            bbiZoneCode.EditValue = dataSource.data.data[0].get_invoice_id.invoice_no;
            bbiShipFrom.EditValue = dataSource.data.data[0].get_invoice_id.ship_from;
            bbiShipTo.EditValue = dataSource.data.data[0].get_invoice_id.ship_to;
            bbiVia.EditValue = dataSource.data.data[0].get_invoice_id.via;
            bbiRefNo.EditValue = dataSource.data.data[0].get_invoice_id.system_no;
            bbiNote1.EditValue = dataSource.data.data[0].get_invoice_id.note_1;
            bbiNote2.EditValue = dataSource.data.data[0].get_invoice_id.note_2;
            bbiNote3.EditValue = dataSource.data.data[0].get_invoice_id.note_3;
            bbiCartonTotal.EditValue = dataSource.data.data[0].get_invoice_id.ctn_total;
            bbiTapTylFlag.EditValue = dataSource.data.data[0].get_invoice_id.tap_flg;
            bbiContainerType.EditValue = dataSource.data.data[0].get_invoice_id.get_container_type_id.title;
            bbiRegisterDate.EditValue = dataSource.data.data[0].get_invoice_id.updated_at;
            bbiResgistTime.EditValue = dataSource.data.data[0].get_invoice_id.updated_at;

            // set gross and net weight
            bbiGrossWeight.EditValue = string.Format("{0:n0}", dataSource.data.data[0].get_order_id.bigrwt);
            bbiNetWeight.EditValue = string.Format("{0:n0}", dataSource.data.data[0].get_order_id.binewt);

            bsiRecordsCount.Caption = "RECORDS : " + dataSource.data.data.Count;
            splashScreenManager1.CloseWaitForm();
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //switch (e.Column.Caption.ToString())
            //{
            //    case "CTN.":
            //        e.DisplayText = e.Value;
            //        break;
            //    default:
            //        break;
            //}
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }

        private void smbEdit_Click(object sender, EventArgs e)
        {
            // initialize a new XtraInputBoxArgs instance 
            XtraInputBoxArgs args = new XtraInputBoxArgs();
            // set required Input Box options 
            args.Caption = "Chang Invoice No.";
            args.Prompt = "กรุณาระบุเลขที่ Invoice ด้วย.\nPlease enter a new Invoice No.";
            args.DefaultButtonIndex = 0;
            // initialize a DateEdit editor with custom settings 
            TextEdit editor = new TextEdit();
            editor.Text = this.__obj.invoice_no;
            args.Editor = editor;
            var result = XtraInputBox.Show(args);
            if (result is null)
            {
                return;
            }

            // change new Invoice
            InvoiceResponse x = InvoiceService.ChangeInvoiceNo(this.__obj.id, result.ToString());
            if (x.success)
            {
                MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อมูลเรียบร้อยแล้ว.", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
            }
            else {
                MetroFramework.MetroMessageBox.Show(this, "กรูณาระบุเลขที่ Invoice ให้ถูกต้องด้วย.", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiSetPallet_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSetPallet frm = new frmSetPallet(this.__obj);
            frm.ShowDialog();
        }

        private void bbiSendGEDI_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiPrintJoblist_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (__status_change)
            {
                DialogResult r = MetroFramework.MetroMessageBox.Show(this, "คุณยังไม่ได้ทำการบันทึกข้อมูลเลย\nคุณต้องการที่จะบันทึกข้อมูลก่อนหรือไม่?", "ข้อความแจ้งเตือน!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    bbiNew_ItemClick(sender, e);
                }
            }
            frmJobListPreview frm = new frmJobListPreview(this.__obj.id);
            frm.ShowDialog();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            InvoiceDetail __body = gridView.GetFocusedRow() as InvoiceDetail;
            frmInvoiceCarton frm = new frmInvoiceCarton(__body);
            frm.ShowDialog();
        }

        void __status_change_on_change()
        {
            bbiNew.Enabled = __status_change;
            bbiNew.Caption = "Save";
            if (__status_change)
            {
                bbiNew.Enabled = __status_change;
                bbiNew.Caption = "*Save";
            }
        }

        private void bbiInvoiceDate_Properties_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (__status_change)
            {
                if (__status_change_container is true && __status_change_etd is true && __status_change_shipment is true)
                {
                    MetroFramework.MetroMessageBox.Show(this, "ขอ อภัย ระบบไม่สามารถแก้ไขข้อมูลทั้งหมดได้\nกรุณาแก้ไขข้อมูลที่ละส่วนด้วย", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    __status_change_container = false;
                    __status_change_etd = false;
                    __status_change_shipment = false;
                    // set enable 
                    bbiInvoiceDate.Enabled = __status_change_etd;
                    bbiShipMent.Enabled = __status_change_shipment;
                    bbiContainerType.Enabled = __status_change_container;
                    return;
                }
                else if (__status_change_etd)
                {
                    Console.WriteLine("update etd");
                    Console.WriteLine(__obj.get_order_id.etd_date);
                    InvoiceResponse __inv = InvoiceService.UpdateInvoiceEtd(__obj.id, __obj.get_order_id.id, DateTime.Parse(bbiInvoiceDate.EditValue.ToString()));
                    if (__inv.success is false)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาด\nกรุณาติดต่อผู้กูแลระบบด่วน!", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (__status_change_shipment)
                {
                    Console.WriteLine("update all __status_change_shipment");
                    Console.WriteLine(__obj.get_order_id.get_ship_id.title);
                    InvoiceResponse __inv = InvoiceService.UpdateInvoiceShip(__obj.id, __obj.get_order_id.id, bbiShipMent.EditValue.ToString());
                    if (__inv.success is false)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาด\nกรุณาติดต่อผู้กูแลระบบด่วน!", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (__status_change_container)
                {
                    Console.WriteLine("update container");
                    Console.WriteLine(__obj.get_container_type_id.title);
                    InvoiceResponse __inv = InvoiceService.UpdateInvoiceContainer(__obj.id, bbiContainerType.EditValue.ToString());
                    if (__inv.success is false)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "เกิดข้อผิดพลาด\nกรุณาติดต่อผู้กูแลระบบด่วน!", "ข้อความแจ้งเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MetroFramework.MetroMessageBox.Show(this, "บันทึกข้อมูลเสร็จแล้ว", "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                __status_change = false;
                __status_change_container = false;
                __status_change_etd = false;
                __status_change_shipment = false;
                // set enable 
                bbiInvoiceDate.Enabled = __status_change_etd;
                bbiShipMent.Enabled = __status_change_shipment;
                bbiContainerType.Enabled = __status_change_container;
                Reload();
            }
        }

        private void bbiShipMent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //__status_change = true;
            //__status_change_shipment = true;
            //__status_change_on_change();
        }

        private void bbiContainerType_EditValueChanged(object sender, EventArgs e)
        {
            //__status_change = true;
            //__status_change_container = true;
            //__status_change_on_change();
        }

        
        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                ppEdit.ShowPopup(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void bbiChangeEtd_ItemClick(object sender, ItemClickEventArgs e)
        {
            __status_change = true;
            __status_change_etd = !__status_change_etd;
            bbiInvoiceDate.Enabled = __status_change_etd;
        }

        private void bbichangeShipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            __status_change = true;
            __status_change_shipment = !__status_change_shipment;
            bbiShipMent.Enabled = __status_change_shipment;
        }

        private void bbiChangeContainer_ItemClick(object sender, ItemClickEventArgs e)
        {
            __status_change = true;
            __status_change_container = !__status_change_container;
            bbiContainerType.Enabled = __status_change_container;
        }

        private void bbiAddItem_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiChangeInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            smbEdit_Click(sender, e);
        }

        private void bbiNote1_EditValueChanged(object sender, EventArgs e)
        {
            //__status_change = true;
        }

        private void bbiNote2_EditValueChanged(object sender, EventArgs e)
        {
            //__status_change = true;
        }

        private void bbiNote3_EditValueChanged(object sender, EventArgs e)
        {
            //__status_change = true;
        }

        private void frmInvoiceDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (__status_change)
            {
                DialogResult r = MetroFramework.MetroMessageBox.Show(this, "คุณยังไม่ได้ทำการบันทึกข้อมูลเลย\nคุณต้องการที่จะบันทึกข้อมูลก่อนหรือไม่?", "ข้อความแจ้งเตือน!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    bbiNew_ItemClick(sender, null);
                }
            }
        }
    }
}