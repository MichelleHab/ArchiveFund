using System.Drawing.Drawing2D;

namespace ArchiveFund
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            label1 = new Label();
            label2 = new Label();
            button = new Button();
            textBoxForLogin = new TextBox();
            textBoxForPassword = new MaskedTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(296, 9);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 0;
            label1.Text = "Пароль:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.HighlightText;
            label2.Location = new Point(14, 9);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 0;
            label2.Text = "Логин:";
            // 
            // button
            // 
            button.Location = new Point(187, 125);
            button.Margin = new Padding(5, 4, 5, 4);
            button.Name = "button";
            button.Size = new Size(154, 49);
            button.TabIndex = 1;
            button.Text = "Вход";
            button.UseVisualStyleBackColor = true;
            button.Click += button1_Click;
            // 
            // textBoxForLogin
            // 
            textBoxForLogin.BackColor = Color.FromArgb(3, 44, 178);
            textBoxForLogin.ForeColor = Color.LightSalmon;
            textBoxForLogin.Location = new Point(14, 38);
            textBoxForLogin.Margin = new Padding(5, 4, 5, 4);
            textBoxForLogin.Name = "textBoxForLogin";
            textBoxForLogin.PlaceholderText = "Ivanov_II";
            textBoxForLogin.Size = new Size(216, 29);
            textBoxForLogin.TabIndex = 2;
            // 
            // textBoxForPassword
            // 
            textBoxForPassword.BackColor = Color.FromArgb(3, 44, 178);
            textBoxForPassword.ForeColor = Color.LightSalmon;
            textBoxForPassword.Location = new Point(296, 38);
            textBoxForPassword.Margin = new Padding(5, 4, 5, 4);
            textBoxForPassword.Name = "textBoxForPassword";
            textBoxForPassword.Size = new Size(216, 29);
            textBoxForPassword.TabIndex = 3;
            textBoxForPassword.UseSystemPasswordChar = true;
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(554, 187);
            Controls.Add(textBoxForPassword);
            Controls.Add(textBoxForLogin);
            Controls.Add(button);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "Authorization";
            Text = "Authorization";
            Load += Authorization_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button;
        private TextBox textBoxForLogin;
        private MaskedTextBox textBoxForPassword;
    }
}