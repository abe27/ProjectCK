using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using InvoiceApp;
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

namespace CloudApp
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            gridControl.DataSource = GetDataSource();
            BindingList<Customer> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public BindingList<Customer> GetDataSource()
        {
            BindingList<Customer> result = new BindingList<Customer>();
            result.Add(new Customer()
            {
                ID = 1,
                Name = "ACME",
                Address = "2525 E El Segundo Blvd",
                City = "El Segundo",
                State = "CA",
                ZipCode = "90245",
                Phone = "(310) 536-0611"
            });
            result.Add(new Customer()
            {
                ID = 2,
                Name = "Electronics Depot",
                Address = "2455 Paces Ferry Road NW",
                City = "Atlanta",
                State = "GA",
                ZipCode = "30339",
                Phone = "(800) 595-3232"
            });
            return result;
        }
        public class Customer
        {
            [Key, Display(AutoGenerateField = false)]
            public int ID { get; set; }
            [Required]
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
            public string Phone { get; set; }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult r = MetroFramework.MetroMessageBox.Show(this, "คุณต้องการที่จะปิดโปรแกรมนี้ใช่หรือไม่?\nDo you want to close this program?", "ข้อความแจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (r == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }

        private void bbiInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            // get invoice form
            frmInvoice frm = new frmInvoice();
            frm.Show();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult r = MetroFramework.MetroMessageBox.Show(this, "คุณต้องการที่จะปิดโปรแกรมนี้ใช่หรือไม่?\nDo you want to close this program?", "ข้อความแจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}