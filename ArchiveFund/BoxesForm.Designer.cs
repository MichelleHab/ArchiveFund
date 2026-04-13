namespace ArchiveFund
{
    partial class BoxesForm
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
            lblRackNumber = new Label();
            lblShelfNumber = new Label();
            cmbGroupId = new ComboBox();
            lblGroupId = new Label();
            cmbTypeId = new ComboBox();
            lblTypeId = new Label();
            dtpYearWork = new DateTimePicker();
            lblYearWork = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            numericRackNumber = new NumericUpDown();
            numericShelfNumber = new NumericUpDown();
            label1 = new Label();
            txtName = new TextBox();
            noSaveDate = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericRackNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericShelfNumber).BeginInit();
            SuspendLayout();
            // 
            // lblRackNumber
            // 
            lblRackNumber.AutoSize = true;
            lblRackNumber.Location = new Point(12, 9);
            lblRackNumber.Name = "lblRackNumber";
            lblRackNumber.Size = new Size(144, 21);
            lblRackNumber.TabIndex = 2;
            lblRackNumber.Text = "Номер стеллажа:";
            // 
            // lblShelfNumber
            // 
            lblShelfNumber.AutoSize = true;
            lblShelfNumber.Location = new Point(12, 51);
            lblShelfNumber.Name = "lblShelfNumber";
            lblShelfNumber.Size = new Size(120, 21);
            lblShelfNumber.TabIndex = 4;
            lblShelfNumber.Text = "Номер полки:";
            // 
            // cmbGroupId
            // 
            cmbGroupId.Location = new Point(188, 89);
            cmbGroupId.Name = "cmbGroupId";
            cmbGroupId.Size = new Size(291, 28);
            cmbGroupId.TabIndex = 7;
            // 
            // lblGroupId
            // 
            lblGroupId.AutoSize = true;
            lblGroupId.Location = new Point(12, 92);
            lblGroupId.Name = "lblGroupId";
            lblGroupId.Size = new Size(138, 21);
            lblGroupId.TabIndex = 6;
            lblGroupId.Text = "Целевая группа:";
            // 
            // cmbTypeId
            // 
            cmbTypeId.Location = new Point(188, 129);
            cmbTypeId.Name = "cmbTypeId";
            cmbTypeId.Size = new Size(291, 28);
            cmbTypeId.TabIndex = 9;
            // 
            // lblTypeId
            // 
            lblTypeId.AutoSize = true;
            lblTypeId.Location = new Point(14, 133);
            lblTypeId.Name = "lblTypeId";
            lblTypeId.Size = new Size(114, 21);
            lblTypeId.TabIndex = 8;
            lblTypeId.Text = "Целевой тип:";
            // 
            // dtpYearWork
            // 
            dtpYearWork.CustomFormat = "yyyy";
            dtpYearWork.Enabled = false;
            dtpYearWork.Format = DateTimePickerFormat.Short;
            dtpYearWork.Location = new Point(126, 171);
            dtpYearWork.Name = "dtpYearWork";
            dtpYearWork.ShowUpDown = true;
            dtpYearWork.Size = new Size(250, 29);
            dtpYearWork.TabIndex = 11;
            // 
            // lblYearWork
            // 
            lblYearWork.AutoSize = true;
            lblYearWork.Location = new Point(14, 177);
            lblYearWork.Name = "lblYearWork";
            lblYearWork.Size = new Size(106, 21);
            lblYearWork.TabIndex = 10;
            lblYearWork.Text = "Год работы:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(372, 225);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 36);
            btnSave.TabIndex = 12;
            btnSave.Text = "Принять";
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(12, 225);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 36);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Отмена";
            btnCancel.Click += BtnCancel_Click;
            // 
            // numericRackNumber
            // 
            numericRackNumber.Location = new Point(188, 9);
            numericRackNumber.Name = "numericRackNumber";
            numericRackNumber.Size = new Size(120, 29);
            numericRackNumber.TabIndex = 14;
            // 
            // numericShelfNumber
            // 
            numericShelfNumber.Location = new Point(188, 49);
            numericShelfNumber.Name = "numericShelfNumber";
            numericShelfNumber.Size = new Size(120, 29);
            numericShelfNumber.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(331, 9);
            label1.Name = "label1";
            label1.Size = new Size(48, 21);
            label1.TabIndex = 15;
            label1.Text = "Имя:";
            // 
            // txtName
            // 
            txtName.Location = new Point(331, 43);
            txtName.Name = "txtName";
            txtName.Size = new Size(148, 29);
            txtName.TabIndex = 16;
            txtName.GotFocus += TxtName_GotFocus;
            // 
            // saveDate
            // 
            noSaveDate.AutoSize = true;
            noSaveDate.Checked = true;
            noSaveDate.CheckState = CheckState.Checked;
            noSaveDate.Location = new Point(382, 165);
            noSaveDate.Name = "saveDate";
            noSaveDate.Size = new Size(111, 46);
            noSaveDate.TabIndex = 17;
            noSaveDate.Text = "Не\nсохранять";
            noSaveDate.UseVisualStyleBackColor = true;
            noSaveDate.CheckedChanged += saveDate_CheckedChanged;
            // 
            // BoxesForm
            // 
            AutoSize = true;
            ClientSize = new Size(491, 273);
            Controls.Add(noSaveDate);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(numericShelfNumber);
            Controls.Add(numericRackNumber);
            Controls.Add(lblRackNumber);
            Controls.Add(lblShelfNumber);
            Controls.Add(lblGroupId);
            Controls.Add(cmbGroupId);
            Controls.Add(lblTypeId);
            Controls.Add(cmbTypeId);
            Controls.Add(lblYearWork);
            Controls.Add(dtpYearWork);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Times New Roman", 13.8F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BoxesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BoxesForm";
            ((System.ComponentModel.ISupportInitialize)numericRackNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericShelfNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label lblRackNumber;
        private System.Windows.Forms.Label lblShelfNumber;
        private System.Windows.Forms.Label lblGroupId;
        private System.Windows.Forms.Label lblTypeId;
        private System.Windows.Forms.Label lblYearWork;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Label label1;
        public ComboBox cmbGroupId;
        public ComboBox cmbTypeId;
        public DateTimePicker dtpYearWork;
        public NumericUpDown numericRackNumber;
        public NumericUpDown numericShelfNumber;
        public TextBox txtName;
        public CheckBox noSaveDate;
    }
}