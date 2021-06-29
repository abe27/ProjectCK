using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
                }
            }
        }
    }
}