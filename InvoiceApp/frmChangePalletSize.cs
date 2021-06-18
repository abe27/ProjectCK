using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Windows.Forms;

namespace InvoiceApp
{
    public partial class frmChangePalletSize : DevExpress.XtraEditors.XtraUserControl
    {
        TextEdit __width;
        TextEdit __length;
        TextEdit __heigth;

        public frmChangePalletSize()
        {
            LayoutControl lc = new LayoutControl();
            __width = new TextEdit();
            __width.Text = "ความกว้าง";

            __length = new TextEdit();
            __length.Text = "ความยาว";

            __heigth = new TextEdit();
            __heigth.Text = "ความสูง";

            lc.Dock = DockStyle.Fill;

            lc.AddItem(String.Empty, __width).TextVisible = false;
            lc.AddItem(String.Empty, __length).TextVisible = false;
            lc.AddItem(String.Empty, __heigth).TextVisible = false;
            lc.Text = "ระบุขนาดของพาเลท ความกว้างxความยาวxความสูง";
            lc.BestFit();
            this.Controls.Add(lc);
            this.Dock = DockStyle.Top;
        }

        public string[] EditValue
        {
            get
            {
                return new string[3] { __width.EditValue?.ToString(), __length.EditValue?.ToString(), __heigth.EditValue?.ToString() };
            }
        }
    }
}
