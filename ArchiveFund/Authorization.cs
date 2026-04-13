using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                MessageBox.Show("Не введен логин!", "Ошибка авторизации");
                textBoxForLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxForPassword.Text))
            {
                MessageBox.Show("Не введен пароль!", "Ошибка авторизации");
                textBoxForPassword.Focus();
                return;
            }
            var tb = Sql.Query("select * from user where login = @login", [ new("@login", textBoxForLogin.Text.Trim()) ]);
            if (tb is null)
                return;
            if (tb.Rows.Count is not 1)
            {
                MessageBox.Show("Данный логин не найден!", "Ошибка авторизации");
                return;
            }
            if (tb.Rows[0]["password"].ToString() != textBoxForPassword.Text.Trim())
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации");
                return;
            }
            this.Hide();
            new MainForm(MainForm.RoleParse(tb.Rows[0]["role"].ToString()), tb.Rows[0]["login"].ToString()).ShowDialog(this);
            this.Close();
        }
    }
}
