using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudApp
{
    public partial class frmAuth : MetroFramework.Forms.MetroForm
    {
        public frmAuth()
        {
            InitializeComponent();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void bbiLogin_Click(object sender, EventArgs e)
        {
            string __txt_email = txtusername.Text;
            string __txt_password = txtpassword.Text;

            if (__txt_email == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุชื่อผู้ใช้งานด้วย\nPlease enter your username.", "ข้อความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (IsValidEmail(__txt_email) is false)
            {
                MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุข้อมูลให้ถูกต้องด้วย!\nInvalid email format specified.", "ข้อความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (__txt_password == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "กรุณาระบุรหัสผ่านด้วย\nPlease enter your password.", "ข้อความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                // hide auth form
                this.Hide();
                this.ShowIcon = false;

                // call main form
                frmMain frm = new frmMain();
                frm.ShowDialog();

                //  after close main form.
                this.Show();
                this.ShowIcon = true;
            }
        }
    }
}
