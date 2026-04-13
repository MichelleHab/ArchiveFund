namespace ArchiveFund
{
    partial class GroupForm
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
            txtGroupName = new TextBox();
            lblGroupName = new Label();
            dtpFormationYear = new DateTimePicker();
            lblFormationYear = new Label();
            txtSpecialization = new TextBox();
            lblSpecialization = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtGroupName
            // 
            txtGroupName.Location = new Point(185, 25);
            txtGroupName.MaxLength = 100;
            txtGroupName.Name = "txtGroupName";
            txtGroupName.Size = new Size(196, 29);
            txtGroupName.TabIndex = 3;
            // 
            // lblGroupName
            // 
            lblGroupName.AutoSize = true;
            lblGroupName.Location = new Point(12, 28);
            lblGroupName.Name = "lblGroupName";
            lblGroupName.Size = new Size(153, 21);
            lblGroupName.TabIndex = 2;
            lblGroupName.Text = "Название группы:";
            // 
            // dtpFormationYear
            // 
            dtpFormationYear.CustomFormat = "yyyy";
            dtpFormationYear.Format = DateTimePickerFormat.Short;
            dtpFormationYear.Location = new Point(185, 69);
            dtpFormationYear.Name = "dtpFormationYear";
            dtpFormationYear.ShowUpDown = true;
            dtpFormationYear.Size = new Size(196, 29);
            dtpFormationYear.TabIndex = 5;
            // 
            // lblFormationYear
            // 
            lblFormationYear.AutoSize = true;
            lblFormationYear.Location = new Point(12, 75);
            lblFormationYear.Name = "lblFormationYear";
            lblFormationYear.Size = new Size(167, 21);
            lblFormationYear.TabIndex = 4;
            lblFormationYear.Text = "Год формирования:";
            // 
            // txtSpecialization
            // 
            txtSpecialization.Location = new Point(185, 115);
            txtSpecialization.MaxLength = 255;
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.Size = new Size(197, 29);
            txtSpecialization.TabIndex = 7;
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.Location = new Point(12, 118);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(137, 21);
            lblSpecialization.TabIndex = 6;
            lblSpecialization.Text = "Специализация:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(278, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 36);
            btnSave.TabIndex = 8;
            btnSave.Text = "Принять";
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(12, 192);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 36);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.Click += BtnCancel_Click;
            // 
            // GroupForm
            // 
            AutoSize = true;
            ClientSize = new Size(394, 240);
            Controls.Add(lblGroupName);
            Controls.Add(txtGroupName);
            Controls.Add(lblFormationYear);
            Controls.Add(dtpFormationYear);
            Controls.Add(lblSpecialization);
            Controls.Add(txtSpecialization);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Times New Roman", 13.8F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GroupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GroupForm";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label lblFormationYear;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        public TextBox txtGroupName;
        public DateTimePicker dtpFormationYear;
        public TextBox txtSpecialization;
    }
}