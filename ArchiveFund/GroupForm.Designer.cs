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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupForm));
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
            txtGroupName.BackColor = Color.Wheat;
            txtGroupName.Location = new Point(201, 25);
            txtGroupName.MaxLength = 100;
            txtGroupName.Name = "txtGroupName";
            txtGroupName.PlaceholderText = "Гр-1а";
            txtGroupName.Size = new Size(181, 29);
            txtGroupName.TabIndex = 3;
            // 
            // lblGroupName
            // 
            lblGroupName.AutoSize = true;
            lblGroupName.BackColor = Color.Transparent;
            lblGroupName.Location = new Point(12, 28);
            lblGroupName.Name = "lblGroupName";
            lblGroupName.Size = new Size(162, 21);
            lblGroupName.TabIndex = 2;
            lblGroupName.Text = "*Название группы:";
            // 
            // dtpFormationYear
            // 
            dtpFormationYear.CustomFormat = "yyyy";
            dtpFormationYear.Format = DateTimePickerFormat.Short;
            dtpFormationYear.Location = new Point(201, 69);
            dtpFormationYear.Name = "dtpFormationYear";
            dtpFormationYear.ShowUpDown = true;
            dtpFormationYear.Size = new Size(180, 29);
            dtpFormationYear.TabIndex = 5;
            // 
            // lblFormationYear
            // 
            lblFormationYear.AutoSize = true;
            lblFormationYear.BackColor = Color.Transparent;
            lblFormationYear.Location = new Point(12, 75);
            lblFormationYear.Name = "lblFormationYear";
            lblFormationYear.Size = new Size(176, 21);
            lblFormationYear.TabIndex = 4;
            lblFormationYear.Text = "*Год формирования:";
            // 
            // txtSpecialization
            // 
            txtSpecialization.BackColor = Color.Wheat;
            txtSpecialization.Location = new Point(201, 115);
            txtSpecialization.MaxLength = 255;
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.PlaceholderText = "01.01.01 Обучение...";
            txtSpecialization.Size = new Size(181, 29);
            txtSpecialization.TabIndex = 7;
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.BackColor = Color.Transparent;
            lblSpecialization.Location = new Point(12, 118);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(146, 21);
            lblSpecialization.TabIndex = 6;
            lblSpecialization.Text = "*Специализация:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.Wheat;
            btnSave.Location = new Point(278, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 36);
            btnSave.TabIndex = 8;
            btnSave.Text = "Принять";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Wheat;
            btnCancel.Location = new Point(12, 192);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 36);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // GroupForm
            // 
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
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