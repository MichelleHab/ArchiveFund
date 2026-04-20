namespace ArchiveFund
{
    partial class DocumentTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentTypeForm));
            txtTypeName = new TextBox();
            lblTypeName = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtTypeName
            // 
            txtTypeName.BackColor = Color.Wheat;
            txtTypeName.Location = new Point(12, 38);
            txtTypeName.MaxLength = 100;
            txtTypeName.Multiline = true;
            txtTypeName.Name = "txtTypeName";
            txtTypeName.PlaceholderText = "Экзамен, зачет, лекция...";
            txtTypeName.Size = new Size(376, 97);
            txtTypeName.TabIndex = 3;
            // 
            // lblTypeName
            // 
            lblTypeName.AutoSize = true;
            lblTypeName.BackColor = Color.Transparent;
            lblTypeName.Location = new Point(109, 9);
            lblTypeName.Name = "lblTypeName";
            lblTypeName.Size = new Size(138, 21);
            lblTypeName.TabIndex = 2;
            lblTypeName.Text = "*Название типа:";
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.Wheat;
            btnSave.Location = new Point(281, 157);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 36);
            btnSave.TabIndex = 4;
            btnSave.Text = "Принять";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Wheat;
            btnCancel.Location = new Point(12, 157);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 36);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // DocumentTypeForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(400, 200);
            Controls.Add(lblTypeName);
            Controls.Add(txtTypeName);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Times New Roman", 13.8F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DocumentTypeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DocumentTypeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        public TextBox txtTypeName;
    }
}