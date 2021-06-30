using DevExpress.XtraEditors;
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
    public partial class frmAddNewContainer : DevExpress.XtraEditors.XtraUserControl
    {
        public frmAddNewContainer()
        {
            InitializeComponent();
            bbiReleaseDate.EditValue = DateTime.Now;
            bbiSize.EditValue = "40FT";
        }

        public object[] Get()
        {
            object[] txt = new object[] { bbiContainerNo.EditValue, bbiSealNo.EditValue, bbiSize.EditValue, bbiReleaseDay.EditValue, bbiReleaseDate.EditValue };
            return txt;
        }

        private void bbiReleaseDate_EditValueChanged(object sender, EventArgs e)
        {
            bbiReleaseDay.EditValue = (DateTime.Parse(bbiReleaseDate.EditValue.ToString()).DayOfWeek).ToString().Substring(0, 3);
        }
    }
}
