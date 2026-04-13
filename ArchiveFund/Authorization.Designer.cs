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
            label1.Location = new Point(296, 9);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(88, 26);
            label1.TabIndex = 0;
            label1.Text = "Пароль:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 9);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 26);
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
            textBoxForLogin.Location = new Point(14, 38);
            textBoxForLogin.Margin = new Padding(5, 4, 5, 4);
            textBoxForLogin.Name = "textBoxForLogin";
            textBoxForLogin.Size = new Size(216, 34);
            textBoxForLogin.TabIndex = 2;
            // 
            // textBoxForPassword
            // 
            textBoxForPassword.Location = new Point(296, 38);
            textBoxForPassword.Margin = new Padding(5, 4, 5, 4);
            textBoxForPassword.Name = "textBoxForPassword";
            textBoxForPassword.Size = new Size(216, 34);
            textBoxForPassword.TabIndex = 3;
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(13F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 187);
            Controls.Add(textBoxForPassword);
            Controls.Add(textBoxForLogin);
            Controls.Add(button);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "Authorization";
            Text = "Authorization";
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