namespace ArchiveFund
{
    partial class StudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            txtFullName = new TextBox();
            lblFullName = new Label();
            cmbGroupId = new ComboBox();
            lblGroupId = new Label();
            dtpAdmissionYear = new DateTimePicker();
            lblAdmissionYear = new Label();
            dtpDeductionYear = new DateTimePicker();
            lblDeductionYear = new Label();
            txtReason = new TextBox();
            lblReason = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            checkBoxIsDelete = new CheckBox();
            deductionNoSaveDate = new CheckBox();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.Wheat;
            txtFullName.Location = new Point(214, 6);
            txtFullName.MaxLength = 100;
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Иванов Ива Иванович";
            txtFullName.Size = new Size(340, 34);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Location = new Point(12, 9);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(170, 26);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "*ФИО студента:";
            // 
            // cmbGroupId
            // 
            cmbGroupId.BackColor = Color.Wheat;
            cmbGroupId.Location = new Point(214, 51);
            cmbGroupId.Name = "cmbGroupId";
            cmbGroupId.Size = new Size(340, 34);
            cmbGroupId.TabIndex = 5;
            // 
            // lblGroupId
            // 
            lblGroupId.AutoSize = true;
            lblGroupId.BackColor = Color.Transparent;
            lblGroupId.Location = new Point(12, 51);
            lblGroupId.Name = "lblGroupId";
            lblGroupId.Size = new Size(87, 26);
            lblGroupId.TabIndex = 4;
            lblGroupId.Text = "Группа:";
            // 
            // dtpAdmissionYear
            // 
            dtpAdmissionYear.CustomFormat = "yyyy";
            dtpAdmissionYear.Format = DateTimePickerFormat.Short;
            dtpAdmissionYear.Location = new Point(214, 91);
            dtpAdmissionYear.Name = "dtpAdmissionYear";
            dtpAdmissionYear.ShowUpDown = true;
            dtpAdmissionYear.Size = new Size(340, 34);
            dtpAdmissionYear.TabIndex = 9;
            // 
            // lblAdmissionYear
            // 
            lblAdmissionYear.AutoSize = true;
            lblAdmissionYear.BackColor = Color.Transparent;
            lblAdmissionYear.Location = new Point(12, 94);
            lblAdmissionYear.Name = "lblAdmissionYear";
            lblAdmissionYear.Size = new Size(194, 26);
            lblAdmissionYear.TabIndex = 8;
            lblAdmissionYear.Text = "*Год поступления:";
            // 
            // dtpDeductionYear
            // 
            dtpDeductionYear.CustomFormat = "yyyy";
            dtpDeductionYear.Enabled = false;
            dtpDeductionYear.Format = DateTimePickerFormat.Short;
            dtpDeductionYear.Location = new Point(214, 137);
            dtpDeductionYear.Name = "dtpDeductionYear";
            dtpDeductionYear.ShowUpDown = true;
            dtpDeductionYear.Size = new Size(240, 34);
            dtpDeductionYear.TabIndex = 11;
            // 
            // lblDeductionYear
            // 
            lblDeductionYear.AutoSize = true;
            lblDeductionYear.BackColor = Color.Transparent;
            lblDeductionYear.Location = new Point(12, 143);
            lblDeductionYear.Name = "lblDeductionYear";
            lblDeductionYear.Size = new Size(126, 26);
            lblDeductionYear.TabIndex = 10;
            lblDeductionYear.Text = "Год вычета:";
            // 
            // txtReason
            // 
            txtReason.BackColor = Color.Wheat;
            txtReason.Location = new Point(12, 243);
            txtReason.MaxLength = 100;
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.PlaceholderText = "Завершил или Отчислен по причине...";
            txtReason.Size = new Size(505, 117);
            txtReason.TabIndex = 13;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.BackColor = Color.Transparent;
            lblReason.Location = new Point(12, 214);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(177, 26);
            lblReason.TabIndex = 12;
            lblReason.Text = "Причина вычета:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.Wheat;
            btnSave.Location = new Point(461, 376);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(125, 36);
            btnSave.TabIndex = 14;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Wheat;
            btnCancel.Location = new Point(12, 376);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 36);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // checkBoxIsDelete
            // 
            checkBoxIsDelete.AutoSize = true;
            checkBoxIsDelete.BackColor = Color.Transparent;
            checkBoxIsDelete.Location = new Point(12, 176);
            checkBoxIsDelete.Name = "checkBoxIsDelete";
            checkBoxIsDelete.Size = new Size(258, 30);
            checkBoxIsDelete.TabIndex = 16;
            checkBoxIsDelete.Text = "Студента в удаленные?";
            checkBoxIsDelete.UseVisualStyleBackColor = false;
            // 
            // deductionNoSaveDate
            // 
            deductionNoSaveDate.AutoSize = true;
            deductionNoSaveDate.BackColor = Color.Transparent;
            deductionNoSaveDate.Checked = true;
            deductionNoSaveDate.CheckState = CheckState.Checked;
            deductionNoSaveDate.Location = new Point(460, 131);
            deductionNoSaveDate.Name = "deductionNoSaveDate";
            deductionNoSaveDate.Size = new Size(131, 56);
            deductionNoSaveDate.TabIndex = 18;
            deductionNoSaveDate.Text = "Не\nсохранять";
            deductionNoSaveDate.UseVisualStyleBackColor = false;
            deductionNoSaveDate.CheckedChanged += DeductionNoSaveDate_CheckedChanged;
            // 
            // StudentForm
            // 
            BackColor = Color.Wheat;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(598, 424);
            Controls.Add(deductionNoSaveDate);
            Controls.Add(checkBoxIsDelete);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblGroupId);
            Controls.Add(cmbGroupId);
            Controls.Add(lblAdmissionYear);
            Controls.Add(dtpAdmissionYear);
            Controls.Add(lblDeductionYear);
            Controls.Add(dtpDeductionYear);
            Controls.Add(lblReason);
            Controls.Add(txtReason);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Times New Roman", 13.8F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактирование студента и личного дела";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblGroupId;
        private System.Windows.Forms.Label lblAdmissionYear;
        private System.Windows.Forms.Label lblDeductionYear;
        private System.Windows.Forms.Label lblReason;

        // Кнопки
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        public CheckBox deductionNoSaveDate;
        public TextBox txtFullName;
        public ComboBox cmbGroupId;
        public DateTimePicker dtpAdmissionYear;
        public DateTimePicker dtpDeductionYear;
        public TextBox txtReason;
        public CheckBox checkBoxIsDelete;
    }
}