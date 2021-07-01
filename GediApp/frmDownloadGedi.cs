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
    }
}