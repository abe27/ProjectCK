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

namespace ReceiveApp
{
    public partial class frmReceiveDetail : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ReceiveData __rec;
        public frmReceiveDetail(ReceiveData obj)
        {
            InitializeComponent();
            this.__rec = obj;
            this.Text = $"{obj.receive_no} Receive Detail";
            Reload();
        }


        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        void Reload()
        {
            splashScreenManager1.ShowWaitForm();
            gridCartonControl.DataSource = null;
            gridControl.DataSource = null;
            ReceiveDetailResponse list = ReceiveService.GetDetail(this.__rec);
            if (list.data != null)
            {
                int x = 1;
                list.data.data.ForEach(i => {
                    i.seq = x;
                    i.plan_diff = (i.plan_ctn-i.rec_ctn);
                    x++;
                });
                gridControl.DataSource = list.data.data;
            }
            splashScreenManager1.CloseWaitForm();
        }


        private void gridView_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            gridCartonControl.DataSource = null;
            ReceiveDetailData __list = gridView.GetFocusedRow() as ReceiveDetailData;
            CartonDataResponse list = CartonService.Get(__list);
            if (list.data != null)
            {
                int x = 1;
                list.data.data.ForEach(i =>
                {
                    i.seq = x;
                    i.partno = __list.get_part_id.get_part_id.part_no;
                    i.partname = __list.get_part_id.get_part_id.part_description;
                    x++;
                });
                gridCartonControl.DataSource = list.data.data;
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reload();
        }
    }
}