namespace InvoiceApp
{
    public partial class frmAddNewPallet : DevExpress.XtraEditors.XtraUserControl
    {
        public frmAddNewPallet()
        {
            InitializeComponent();
        }

        public string[] EditValue
        {
            get {
                return new string[5]{bbiType.EditValue.ToString(), bbiLimit.EditValue.ToString(), bbiWidth.EditValue.ToString(), bbiLength.EditValue.ToString(), bbiHeight.EditValue.ToString()};
            }
        }
    }
}
