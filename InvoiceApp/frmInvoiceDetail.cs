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
        public frmInvoiceDetail(InvoiceData obj)
        {
            InitializeComponent();
            __obj = obj;
            this.Text = $"Invoice Detail({obj.system_no})";
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
            frmJobListPreview frm = new frmJobListPreview(this.__obj.id);
            frm.ShowDialog();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            InvoiceDetail __body = gridView.GetFocusedRow() as InvoiceDetail;
            frmInvoiceCarton frm = new frmInvoiceCarton(__body);
            frm.ShowDialog();
        }
    }
}