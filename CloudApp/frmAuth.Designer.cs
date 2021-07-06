
namespace CloudApp
{
    partial class frmAuth
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuth));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtremember = new MetroFramework.Controls.MetroRadioButton();
            this.bbiLogin = new MetroFramework.Controls.MetroButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bbiPass = new MetroFramework.Controls.MetroTextBox();
            this.txtusername = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bbiSwitchTest = new MetroFramework.Controls.MetroToggle();
            this.bbiUserName = new MetroFramework.Controls.MetroComboBox();
            this.splLoading = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::CloudApp.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(115, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(348, 28);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = " Warehouse Management System ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Cascadia Code ExtraLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(97, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(422, 20);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "โปรแกรมระบบจัดการคลังสินค้า รองรับการรับ-จ่ายสินค้าแบบ Realtime";
            // 
            // txtremember
            // 
            this.txtremember.AutoSize = true;
            this.txtremember.Checked = true;
            this.txtremember.Location = new System.Drawing.Point(280, 270);
            this.txtremember.Name = "txtremember";
            this.txtremember.Size = new System.Drawing.Size(104, 15);
            this.txtremember.TabIndex = 4;
            this.txtremember.TabStop = true;
            this.txtremember.Text = "Remember Me!";
            this.txtremember.UseSelectable = true;
            // 
            // bbiLogin
            // 
            this.bbiLogin.AutoSize = true;
            this.bbiLogin.BackColor = System.Drawing.Color.White;
            this.bbiLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bbiLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bbiLogin.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.bbiLogin.ForeColor = System.Drawing.Color.White;
            this.bbiLogin.Location = new System.Drawing.Point(280, 295);
            this.bbiLogin.Name = "bbiLogin";
            this.bbiLogin.Size = new System.Drawing.Size(270, 35);
            this.bbiLogin.TabIndex = 5;
            this.bbiLogin.Text = "LOGIN";
            this.bbiLogin.UseSelectable = true;
            this.bbiLogin.UseStyleColors = true;
            this.bbiLogin.Click += new System.EventHandler(this.bbiLogin_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CloudApp.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(360, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // bbiPass
            // 
            // 
            // 
            // 
            this.bbiPass.CustomButton.Image = null;
            this.bbiPass.CustomButton.Location = new System.Drawing.Point(244, 2);
            this.bbiPass.CustomButton.Name = "";
            this.bbiPass.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.bbiPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.bbiPass.CustomButton.TabIndex = 1;
            this.bbiPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bbiPass.CustomButton.UseSelectable = true;
            this.bbiPass.CustomButton.Visible = false;
            this.bbiPass.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.bbiPass.Icon = global::CloudApp.Properties.Resources.icons8_lock_16;
            this.bbiPass.Lines = new string[] {
        "ADSads123"};
            this.bbiPass.Location = new System.Drawing.Point(280, 228);
            this.bbiPass.MaxLength = 32767;
            this.bbiPass.Name = "bbiPass";
            this.bbiPass.PasswordChar = '●';
            this.bbiPass.PromptText = "PASSWORD";
            this.bbiPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bbiPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bbiPass.SelectedText = "";
            this.bbiPass.SelectionLength = 0;
            this.bbiPass.SelectionStart = 0;
            this.bbiPass.ShortcutsEnabled = true;
            this.bbiPass.ShowClearButton = true;
            this.bbiPass.Size = new System.Drawing.Size(270, 28);
            this.bbiPass.TabIndex = 3;
            this.bbiPass.Text = "ADSads123";
            this.bbiPass.UseSelectable = true;
            this.bbiPass.UseStyleColors = true;
            this.bbiPass.UseSystemPasswordChar = true;
            this.bbiPass.WaterMark = "PASSWORD";
            this.bbiPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bbiPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.bbiPass.WithError = true;
            // 
            // txtusername
            // 
            this.txtusername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtusername.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            // 
            // 
            // 
            this.txtusername.CustomButton.Image = null;
            this.txtusername.CustomButton.Location = new System.Drawing.Point(-3, 2);
            this.txtusername.CustomButton.Name = "";
            this.txtusername.CustomButton.Size = new System.Drawing.Size(0, 0);
            this.txtusername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtusername.CustomButton.TabIndex = 1;
            this.txtusername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtusername.CustomButton.UseSelectable = true;
            this.txtusername.CustomButton.Visible = false;
            this.txtusername.DisplayIcon = true;
            this.txtusername.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtusername.Icon = global::CloudApp.Properties.Resources.icons8_user_16;
            this.txtusername.Lines = new string[] {
        "krumii.it@gmail.com"};
            this.txtusername.Location = new System.Drawing.Point(22, 302);
            this.txtusername.MaxLength = 32767;
            this.txtusername.Name = "txtusername";
            this.txtusername.PasswordChar = '\0';
            this.txtusername.PromptText = "E-MAIL";
            this.txtusername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtusername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtusername.SelectedText = "";
            this.txtusername.SelectionLength = 0;
            this.txtusername.SelectionStart = 0;
            this.txtusername.ShortcutsEnabled = true;
            this.txtusername.ShowClearButton = true;
            this.txtusername.Size = new System.Drawing.Size(0, 0);
            this.txtusername.TabIndex = 2;
            this.txtusername.Text = "krumii.it@gmail.com";
            this.txtusername.UseSelectable = true;
            this.txtusername.UseStyleColors = true;
            this.txtusername.Visible = false;
            this.txtusername.WaterMark = "E-MAIL";
            this.txtusername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtusername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtusername.WithError = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::CloudApp.Properties.Resources.main;
            this.pictureBox1.Location = new System.Drawing.Point(22, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 236);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bbiSwitchTest
            // 
            this.bbiSwitchTest.AutoSize = true;
            this.bbiSwitchTest.Location = new System.Drawing.Point(470, 268);
            this.bbiSwitchTest.Name = "bbiSwitchTest";
            this.bbiSwitchTest.Size = new System.Drawing.Size(80, 17);
            this.bbiSwitchTest.TabIndex = 7;
            this.bbiSwitchTest.Text = "Off";
            this.bbiSwitchTest.UseSelectable = true;
            this.bbiSwitchTest.CheckedChanged += new System.EventHandler(this.bbiSwitchTest_CheckedChanged);
            // 
            // bbiUserName
            // 
            this.bbiUserName.DisplayFocus = true;
            this.bbiUserName.DisplayMember = "name";
            this.bbiUserName.FormattingEnabled = true;
            this.bbiUserName.ItemHeight = 23;
            this.bbiUserName.Location = new System.Drawing.Point(280, 190);
            this.bbiUserName.Name = "bbiUserName";
            this.bbiUserName.Size = new System.Drawing.Size(270, 29);
            this.bbiUserName.TabIndex = 8;
            this.bbiUserName.UseSelectable = true;
            this.bbiUserName.ValueMember = "name";
            // 
            // splLoading
            // 
            this.splLoading.ClosingDelay = 500;
            // 
            // frmAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 351);
            this.Controls.Add(this.bbiUserName);
            this.Controls.Add(this.bbiSwitchTest);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.bbiLogin);
            this.Controls.Add(this.txtremember);
            this.Controls.Add(this.bbiPass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Gray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAuth";
            this.Resizable = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private MetroFramework.Controls.MetroTextBox txtusername;
        private MetroFramework.Controls.MetroTextBox bbiPass;
        private MetroFramework.Controls.MetroRadioButton txtremember;
        private MetroFramework.Controls.MetroButton bbiLogin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private MetroFramework.Controls.MetroToggle bbiSwitchTest;
        private MetroFramework.Controls.MetroComboBox bbiUserName;
        private DevExpress.XtraSplashScreen.SplashScreenManager splLoading;
    }
}