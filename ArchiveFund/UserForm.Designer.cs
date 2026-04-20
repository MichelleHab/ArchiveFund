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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
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
            btnBackup = new Button();
            btnRestore = new Button();
            SuspendLayout();
            // 
            // txtFIO
            // 
            txtFIO.BackColor = Color.Wheat;
            txtFIO.Location = new Point(107, 25);
            txtFIO.MaxLength = 150;
            txtFIO.Name = "txtFIO";
            txtFIO.PlaceholderText = "Иванов Ива Иванович";
            txtFIO.Size = new Size(250, 29);
            txtFIO.TabIndex = 3;
            // 
            // lblFIO
            // 
            lblFIO.AutoSize = true;
            lblFIO.BackColor = Color.Transparent;
            lblFIO.Location = new Point(12, 28);
            lblFIO.Name = "lblFIO";
            lblFIO.Size = new Size(55, 21);
            lblFIO.TabIndex = 2;
            lblFIO.Text = "ФИО:";
            // 
            // cmbRole
            // 
            cmbRole.BackColor = Color.Wheat;
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
            lblRole.BackColor = Color.Transparent;
            lblRole.Location = new Point(12, 69);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(62, 21);
            lblRole.TabIndex = 4;
            lblRole.Text = "*Роль:";
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.Wheat;
            txtLogin.Location = new Point(107, 109);
            txtLogin.MaxLength = 50;
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Ivanov_II";
            txtLogin.Size = new Size(250, 29);
            txtLogin.TabIndex = 7;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.BackColor = Color.Transparent;
            lblLogin.Location = new Point(12, 112);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(74, 21);
            lblLogin.TabIndex = 6;
            lblLogin.Text = "*Логин:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.Wheat;
            txtPassword.Location = new Point(107, 156);
            txtPassword.MaxLength = 50;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "????????????";
            txtPassword.Size = new Size(250, 29);
            txtPassword.TabIndex = 9;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Location = new Point(12, 159);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(82, 21);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "*Пароль:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.Wheat;
            btnSave.Location = new Point(391, 207);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 31);
            btnSave.TabIndex = 10;
            btnSave.Text = "Принять";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Wheat;
            btnCancel.Location = new Point(12, 207);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 31);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.Wheat;
            btnBackup.Location = new Point(363, 23);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(145, 71);
            btnBackup.TabIndex = 12;
            btnBackup.Text = "Создать резервную копию";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.Wheat;
            btnRestore.Location = new Point(363, 114);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(145, 71);
            btnRestore.TabIndex = 12;
            btnRestore.Text = "Восстановить резервную копию";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // UserForm
            // 
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(510, 250);
            Controls.Add(btnRestore);
            Controls.Add(btnBackup);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button btnBackup;
        private Button btnRestore;
    }
}