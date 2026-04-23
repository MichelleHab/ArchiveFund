using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
namespace ArchiveFund
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            this.Text = "Авторизация";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxForLogin.Text))
            {
                MessageBox.Show("Не введен логин!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxForLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxForPassword.Text))
            {
                MessageBox.Show("Не введен пароль!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxForPassword.Focus();
                return;
            }
            var tb = Sql.Query("select * from user where login = @login", [new("@login", textBoxForLogin.Text.Trim())]);
            if (tb is null)
                return;
            if (tb.Rows.Count is not 1)
            {
                MessageBox.Show("Данный логин не найден!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb.Rows[0]["password"].ToString() != Sql.QueryOneReturn("select sha2(@pass, 512)", [new("@pass", textBoxForPassword.Text.Trim()?.ToString())])?.ToString())
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Hide();
            new MainForm(MainForm.RoleParse(tb.Rows[0]["role"].ToString() ?? string.Empty), tb.Rows[0]["login"].ToString(), tb.Rows[0]["FIO"].ToString()).ShowDialog(this);
            this.Close();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            using LinearGradientBrush skyBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, button.Height),
                ColorTranslator.FromHtml("#D0FEFD"),
                ColorTranslator.FromHtml("#011227"));
            Bitmap bitmap = new(button.Width, button.Height);
            using Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(skyBrush, 0, 0, button.Width, button.Height);
            button.BackgroundImage = bitmap;
        }
    }
}
