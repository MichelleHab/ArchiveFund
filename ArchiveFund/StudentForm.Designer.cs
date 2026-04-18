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
            txtFullName.Location = new Point(177, 6);
            txtFullName.MaxLength = 100;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(340, 29);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(12, 9);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(138, 21);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "*ФИО студента:";
            // 
            // cmbGroupId
            // 
            cmbGroupId.Location = new Point(177, 48);
            cmbGroupId.Name = "cmbGroupId";
            cmbGroupId.Size = new Size(340, 28);
            cmbGroupId.TabIndex = 5;
            // 
            // lblGroupId
            // 
            lblGroupId.AutoSize = true;
            lblGroupId.Location = new Point(12, 51);
            lblGroupId.Name = "lblGroupId";
            lblGroupId.Size = new Size(71, 21);
            lblGroupId.TabIndex = 4;
            lblGroupId.Text = "Группа:";
            // 
            // dtpAdmissionYear
            // 
            dtpAdmissionYear.CustomFormat = "yyyy";
            dtpAdmissionYear.Format = DateTimePickerFormat.Short;
            dtpAdmissionYear.Location = new Point(177, 88);
            dtpAdmissionYear.Name = "dtpAdmissionYear";
            dtpAdmissionYear.ShowUpDown = true;
            dtpAdmissionYear.Size = new Size(340, 29);
            dtpAdmissionYear.TabIndex = 9;
            // 
            // lblAdmissionYear
            // 
            lblAdmissionYear.AutoSize = true;
            lblAdmissionYear.Location = new Point(12, 94);
            lblAdmissionYear.Name = "lblAdmissionYear";
            lblAdmissionYear.Size = new Size(158, 21);
            lblAdmissionYear.TabIndex = 8;
            lblAdmissionYear.Text = "*Год поступления:";
            // 
            // dtpDeductionYear
            // 
            dtpDeductionYear.CustomFormat = "yyyy";
            dtpDeductionYear.Enabled = false;
            dtpDeductionYear.Format = DateTimePickerFormat.Short;
            dtpDeductionYear.Location = new Point(177, 137);
            dtpDeductionYear.Name = "dtpDeductionYear";
            dtpDeductionYear.ShowUpDown = true;
            dtpDeductionYear.Size = new Size(240, 29);
            dtpDeductionYear.TabIndex = 11;
            // 
            // lblDeductionYear
            // 
            lblDeductionYear.AutoSize = true;
            lblDeductionYear.Location = new Point(12, 143);
            lblDeductionYear.Name = "lblDeductionYear";
            lblDeductionYear.Size = new Size(103, 21);
            lblDeductionYear.TabIndex = 10;
            lblDeductionYear.Text = "Год вычета:";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(12, 243);
            txtReason.MaxLength = 100;
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(505, 117);
            txtReason.TabIndex = 13;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(12, 214);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(146, 21);
            lblReason.TabIndex = 12;
            lblReason.Text = "Причина вычета:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(392, 376);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(125, 36);
            btnSave.TabIndex = 14;
            btnSave.Text = "Сохранить";
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(12, 376);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 36);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Отмена";
            btnCancel.Click += BtnCancel_Click;
            // 
            // checkBoxIsDelete
            // 
            checkBoxIsDelete.AutoSize = true;
            checkBoxIsDelete.Location = new Point(12, 176);
            checkBoxIsDelete.Name = "checkBoxIsDelete";
            checkBoxIsDelete.Size = new Size(213, 25);
            checkBoxIsDelete.TabIndex = 16;
            checkBoxIsDelete.Text = "Студента в удаленные?";
            checkBoxIsDelete.UseVisualStyleBackColor = true;
            // 
            // deductionNoSaveDate
            // 
            deductionNoSaveDate.AutoSize = true;
            deductionNoSaveDate.Checked = true;
            deductionNoSaveDate.CheckState = CheckState.Checked;
            deductionNoSaveDate.Location = new Point(423, 131);
            deductionNoSaveDate.Name = "deductionNoSaveDate";
            deductionNoSaveDate.Size = new Size(111, 46);
            deductionNoSaveDate.TabIndex = 18;
            deductionNoSaveDate.Text = "Не\nсохранять";
            deductionNoSaveDate.UseVisualStyleBackColor = true;
            deductionNoSaveDate.CheckedChanged += DeductionNoSaveDate_CheckedChanged;
            // 
            // StudentForm
            // 
            ClientSize = new Size(529, 424);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
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