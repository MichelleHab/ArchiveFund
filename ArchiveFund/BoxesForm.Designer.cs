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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoxesForm));
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
            lblRackNumber.BackColor = Color.Transparent;
            lblRackNumber.Location = new Point(12, 9);
            lblRackNumber.Name = "lblRackNumber";
            lblRackNumber.Size = new Size(176, 26);
            lblRackNumber.TabIndex = 2;
            lblRackNumber.Text = "Номер стеллажа:";
            // 
            // lblShelfNumber
            // 
            lblShelfNumber.AutoSize = true;
            lblShelfNumber.BackColor = Color.Transparent;
            lblShelfNumber.Location = new Point(12, 51);
            lblShelfNumber.Name = "lblShelfNumber";
            lblShelfNumber.Size = new Size(146, 26);
            lblShelfNumber.TabIndex = 4;
            lblShelfNumber.Text = "Номер полки:";
            // 
            // cmbGroupId
            // 
            cmbGroupId.BackColor = Color.Wheat;
            cmbGroupId.Location = new Point(216, 92);
            cmbGroupId.Name = "cmbGroupId";
            cmbGroupId.Size = new Size(291, 34);
            cmbGroupId.TabIndex = 7;
            // 
            // lblGroupId
            // 
            lblGroupId.AutoSize = true;
            lblGroupId.BackColor = Color.Transparent;
            lblGroupId.Location = new Point(12, 92);
            lblGroupId.Name = "lblGroupId";
            lblGroupId.Size = new Size(168, 26);
            lblGroupId.TabIndex = 6;
            lblGroupId.Text = "Целевая группа:";
            // 
            // cmbTypeId
            // 
            cmbTypeId.BackColor = Color.Wheat;
            cmbTypeId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeId.Location = new Point(216, 132);
            cmbTypeId.Name = "cmbTypeId";
            cmbTypeId.Size = new Size(291, 34);
            cmbTypeId.TabIndex = 9;
            // 
            // lblTypeId
            // 
            lblTypeId.AutoSize = true;
            lblTypeId.BackColor = Color.Transparent;
            lblTypeId.Location = new Point(14, 133);
            lblTypeId.Name = "lblTypeId";
            lblTypeId.Size = new Size(151, 26);
            lblTypeId.TabIndex = 8;
            lblTypeId.Text = "*Целевой тип:";
            // 
            // dtpYearWork
            // 
            dtpYearWork.CustomFormat = "yyyy";
            dtpYearWork.Enabled = false;
            dtpYearWork.Format = DateTimePickerFormat.Short;
            dtpYearWork.Location = new Point(154, 174);
            dtpYearWork.Name = "dtpYearWork";
            dtpYearWork.ShowUpDown = true;
            dtpYearWork.Size = new Size(250, 34);
            dtpYearWork.TabIndex = 11;
            // 
            // lblYearWork
            // 
            lblYearWork.AutoSize = true;
            lblYearWork.BackColor = Color.Transparent;
            lblYearWork.Location = new Point(14, 177);
            lblYearWork.Name = "lblYearWork";
            lblYearWork.Size = new Size(129, 26);
            lblYearWork.TabIndex = 10;
            lblYearWork.Text = "Год работы:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.Wheat;
            btnSave.Location = new Point(427, 225);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 36);
            btnSave.TabIndex = 12;
            btnSave.Text = "Принять";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Wheat;
            btnCancel.Location = new Point(12, 225);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 36);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // numericRackNumber
            // 
            numericRackNumber.BackColor = Color.Wheat;
            numericRackNumber.Location = new Point(216, 12);
            numericRackNumber.Name = "numericRackNumber";
            numericRackNumber.Size = new Size(120, 34);
            numericRackNumber.TabIndex = 14;
            // 
            // numericShelfNumber
            // 
            numericShelfNumber.BackColor = Color.Wheat;
            numericShelfNumber.Location = new Point(216, 52);
            numericShelfNumber.Name = "numericShelfNumber";
            numericShelfNumber.Size = new Size(120, 34);
            numericShelfNumber.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(359, 12);
            label1.Name = "label1";
            label1.Size = new Size(59, 26);
            label1.TabIndex = 15;
            label1.Text = "Имя:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.Wheat;
            txtName.Location = new Point(359, 46);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Box:1-1";
            txtName.Size = new Size(148, 34);
            txtName.TabIndex = 16;
            txtName.GotFocus += TxtName_GotFocus;
            // 
            // noSaveDate
            // 
            noSaveDate.AutoSize = true;
            noSaveDate.BackColor = Color.Transparent;
            noSaveDate.Checked = true;
            noSaveDate.CheckState = CheckState.Checked;
            noSaveDate.Location = new Point(410, 168);
            noSaveDate.Name = "noSaveDate";
            noSaveDate.Size = new Size(131, 56);
            noSaveDate.TabIndex = 17;
            noSaveDate.Text = "Не\nсохранять";
            noSaveDate.UseVisualStyleBackColor = false;
            noSaveDate.CheckedChanged += saveDate_CheckedChanged;
            // 
            // BoxesForm
            // 
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(546, 273);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
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