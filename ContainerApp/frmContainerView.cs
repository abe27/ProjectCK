using ContainerApp.Reports;
using DevExpress.XtraEditors;
using ParzivalLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerApp
{
    public partial class frmContainerView : DevExpress.XtraEditors.XtraForm
    {
        public frmContainerView(ContainerData __obj)
        {
            InitializeComponent();

            this.Text = $"BOOKING REPORT {__obj.container_no.ToString().ToUpper()}";
            rpBookingReport rp = new rpBookingReport();
            foreach (DevExpress.XtraReports.Parameters.Parameter i in rp.Parameters)
            {
                i.Visible = false;
            }
            rp.initData(__obj);
            rp.PaperKind = System.Drawing.Printing.PaperKind.A4;
            //rp.Margins.Left = 1;
            //rp.Margins.Right = 3;
            //rp.Margins.Top = 10;
            //rp.Margins.Bottom = 10;
            documentViewer1.DocumentSource = rp;
            rp.CreateDocument();
        }
    }
}