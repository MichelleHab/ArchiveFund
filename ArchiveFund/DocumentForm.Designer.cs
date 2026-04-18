namespace ArchiveFund
{
    partial class DocumentForm
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
            txtDocumentSubject = new TextBox();
            lblDocumentSubject = new Label();
            lblTypeId = new Label();
            txtSupervisorFullName = new TextBox();
            lblSupervisorFullName = new Label();
            lblStudentId = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            comboBoxTypeId = new ComboBox();
            comboBoxStudentId = new ComboBox();
            flagIsDelete = new CheckBox();
            lblCreationYear = new Label();
            dtpCreationYear = new DateTimePicker();
            lblBox_id = new Label();
            comboBoxBox_id = new ComboBox();
            SuspendLayout();
            // 
            // txtDocumentSubject
            // 
            txtDocumentSubject.Location = new Point(201, 22);
            txtDocumentSubject.Multiline = true;
            txtDocumentSubject.Name = "txtDocumentSubject";
            txtDocumentSubject.Size = new Size(251, 75);
            txtDocumentSubject.TabIndex = 3;
            // 
            // lblDocumentSubject
            // 
            lblDocumentSubject.AutoSize = true;
            lblDocumentSubject.Location = new Point(20, 22);
            lblDocumentSubject.Name = "lblDocumentSubject";
            lblDocumentSubject.Size = new Size(151, 21);
            lblDocumentSubject.TabIndex = 2;
            lblDocumentSubject.Text = "*Тема документа:";
            // 
            // lblTypeId
            // 
            lblTypeId.AutoSize = true;
            lblTypeId.Location = new Point(20, 169);
            lblTypeId.Name = "lblTypeId";
            lblTypeId.Size = new Size(144, 21);
            lblTypeId.TabIndex = 4;
            lblTypeId.Text = "*Тип документа:";
            // 
            // txtSupervisorFullName
            // 
            txtSupervisorFullName.Location = new Point(252, 217);
            txtSupervisorFullName.Name = "txtSupervisorFullName";
            txtSupervisorFullName.Size = new Size(200, 29);
            txtSupervisorFullName.TabIndex = 7;
            // 
            // lblSupervisorFullName
            // 
            lblSupervisorFullName.AutoSize = true;
            lblSupervisorFullName.Location = new Point(20, 220);
            lblSupervisorFullName.Name = "lblSupervisorFullName";
            lblSupervisorFullName.Size = new Size(169, 21);
            lblSupervisorFullName.TabIndex = 6;
            lblSupervisorFullName.Text = "ФИО руководителя:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(20, 270);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(88, 21);
            lblStudentId.TabIndex = 8;
            lblStudentId.Text = "*Студент:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(328, 360);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 38);
            btnSave.TabIndex = 10;
            btnSave.Text = "Принять";
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 38);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.Click += BtnCancel_Click;
            // 
            // comboBoxTypeId
            // 
            comboBoxTypeId.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTypeId.FormattingEnabled = true;
            comboBoxTypeId.Location = new Point(252, 166);
            comboBoxTypeId.Name = "comboBoxTypeId";
            comboBoxTypeId.Size = new Size(200, 28);
            comboBoxTypeId.TabIndex = 12;
            // 
            // comboBoxStudentId
            // 
            comboBoxStudentId.FormattingEnabled = true;
            comboBoxStudentId.Location = new Point(252, 267);
            comboBoxStudentId.Name = "comboBoxStudentId";
            comboBoxStudentId.Size = new Size(200, 28);
            comboBoxStudentId.TabIndex = 12;
            // 
            // flagIsDelete
            // 
            flagIsDelete.AutoSize = true;
            flagIsDelete.Location = new Point(20, 51);
            flagIsDelete.Name = "flagIsDelete";
            flagIsDelete.Size = new Size(117, 46);
            flagIsDelete.TabIndex = 13;
            flagIsDelete.Text = "Удаленный\nдокумент?";
            flagIsDelete.UseVisualStyleBackColor = true;
            // 
            // lblCreationYear
            // 
            lblCreationYear.AutoSize = true;
            lblCreationYear.Location = new Point(21, 120);
            lblCreationYear.Name = "lblCreationYear";
            lblCreationYear.Size = new Size(130, 21);
            lblCreationYear.TabIndex = 14;
            lblCreationYear.Text = "*Год создания:";
            // 
            // dtpCreationYear
            // 
            dtpCreationYear.CustomFormat = "yyyy";
            dtpCreationYear.Format = DateTimePickerFormat.Short;
            dtpCreationYear.Location = new Point(252, 114);
            dtpCreationYear.Name = "dtpCreationYear";
            dtpCreationYear.ShowUpDown = true;
            dtpCreationYear.Size = new Size(200, 29);
            dtpCreationYear.TabIndex = 15;
            // 
            // lblBox_id
            // 
            lblBox_id.AutoSize = true;
            lblBox_id.Location = new Point(21, 314);
            lblBox_id.Name = "lblBox_id";
            lblBox_id.Size = new Size(162, 21);
            lblBox_id.TabIndex = 16;
            lblBox_id.Text = "Коробка хранения:";
            // 
            // comboBoxBox_id
            // 
            comboBoxBox_id.FormattingEnabled = true;
            comboBoxBox_id.Location = new Point(252, 311);
            comboBoxBox_id.Name = "comboBoxBox_id";
            comboBoxBox_id.Size = new Size(200, 28);
            comboBoxBox_id.TabIndex = 12;
            // 
            // DocumentForm
            // 
            ClientSize = new Size(481, 410);
            Controls.Add(lblBox_id);
            Controls.Add(lblCreationYear);
            Controls.Add(dtpCreationYear);
            Controls.Add(flagIsDelete);
            Controls.Add(comboBoxBox_id);
            Controls.Add(comboBoxStudentId);
            Controls.Add(comboBoxTypeId);
            Controls.Add(lblDocumentSubject);
            Controls.Add(txtDocumentSubject);
            Controls.Add(lblTypeId);
            Controls.Add(lblSupervisorFullName);
            Controls.Add(txtSupervisorFullName);
            Controls.Add(lblStudentId);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Times New Roman", 13.8F);
            Name = "DocumentForm";
            Text = "DocumentForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDocumentSubject;
        private System.Windows.Forms.Label lblTypeId;
        private System.Windows.Forms.Label lblSupervisorFullName;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Label lblCreationYear;
        private Label lblBox_id;
        public TextBox txtSupervisorFullName;
        public ComboBox comboBoxTypeId;
        public ComboBox comboBoxStudentId;
        public CheckBox flagIsDelete;
        public ComboBox comboBoxBox_id;
        public TextBox txtDocumentSubject;
        public DateTimePicker dtpCreationYear;
    }
}