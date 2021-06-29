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
            bbiSize.EditValue = "40F";
            bbiReleaseDay.EditValue = (DateTime.Now.DayOfWeek).ToString().Substring(0, 3);
        }

        public object[] Get()
        {
            object[] txt = new object[] { bbiContainerNo.EditValue, bbiSealNo.EditValue, bbiSize.EditValue, bbiReleaseDay.EditValue, bbiReleaseDate.EditValue };
            return txt;
        }
    }
}
