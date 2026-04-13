namespace ArchiveFund
{
    partial class UserForm
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
            txtFIO = new TextBox();
            lblFIO = new Label();
            cmbRole = new ComboBox();
            lblRole = new Label();
            txtLogin = new TextBox();
            lblLogin = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtFIO
            // 
            txtFIO.Location = new Point(107, 25);
            txtFIO.MaxLength = 150;
            txtFIO.Name = "txtFIO";
            txtFIO.Size = new Size(250, 29);
            txtFIO.TabIndex = 3;
            // 
            // lblFIO
            // 
            lblFIO.AutoSize = true;
            lblFIO.Location = new Point(12, 28);
            lblFIO.Name = "lblFIO";
            lblFIO.Size = new Size(55, 21);
            lblFIO.TabIndex = 2;
            lblFIO.Text = "ФИО:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "Admin", "Employer" });
            cmbRole.Location = new Point(107, 66);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(250, 28);
            cmbRole.TabIndex = 5;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(12, 69);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(53, 21);
            lblRole.TabIndex = 4;
            lblRole.Text = "Роль:";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(107, 109);
            txtLogin.MaxLength = 50;
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 29);
            txtLogin.TabIndex = 7;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(12, 112);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(65, 21);
            lblLogin.TabIndex = 6;
            lblLogin.Text = "Логин:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(107, 156);
            txtPassword.MaxLength = 50;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 29);
            txtPassword.TabIndex = 9;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 159);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 21);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Пароль:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(265, 207);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 31);
            btnSave.TabIndex = 10;
            btnSave.Text = "Принять";
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(12, 207);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 31);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.Click += BtnCancel_Click;
            // 
            // UserForm
            // 
            AutoSize = true;
            ClientSize = new Size(384, 250);
            Controls.Add(lblFIO);
            Controls.Add(txtFIO);
            Controls.Add(lblRole);
            Controls.Add(cmbRole);
            Controls.Add(lblLogin);
            Controls.Add(txtLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Times New Roman", 13.8F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserForm";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        public System.Windows.Forms.TextBox txtFIO;
        private System.Windows.Forms.Label lblFIO;
        public System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        public System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblLogin;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}