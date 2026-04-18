using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveFund
{
    public partial class UserForm : Form
    {
        public UserForm(object[]? parameters = null)
        {
            InitializeComponent();
            if (parameters != null && parameters.Length == 5)
            {
                this.Text = "Администрирования: Изменение пользователя!";
                if (!string.IsNullOrEmpty(parameters[1].ToString()))
                    txtFIO.Text = parameters[1].ToString();
                cmbRole.Text = parameters[2].ToString();
                txtLogin.Text = parameters[3].ToString();
                txtPassword.Text = parameters[4].ToString();
            }
            else this.Text = "Администрирования: Добавление пользователя!";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbRole.Text))
            {
                MessageBox.Show("Не выбрана роль!");
                cmbRole.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                MessageBox.Show("Не введен логин!");
                txtLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Не введен пароль!");
                txtPassword.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
            => DialogResult = DialogResult.Cancel;
    }
}
