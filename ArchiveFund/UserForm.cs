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
        private bool is_update = false;
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
                //txtPassword.Text = parameters[4].ToString();
                is_update = true;
            }
            else this.Text = "Администрирования: Добавление пользователя!";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("Не выбрана роль!");
                cmbRole.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Не введен логин!");
                txtLogin.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || is_update)
            {
                MessageBox.Show("Не введен пароль!");
                txtPassword.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
            => DialogResult = DialogResult.Cancel;

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "SQL файлы (*.sql)|*.sql",
                Title = "Выберите место сохранения резервной копии",
                FileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите создать резервную копию?\n\nПуть сохранения: {saveDialog.FileName}",
                    "Подтверждение создания резервной копии",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = Sql.ExportToFile(saveDialog.FileName);

                    if (success)
                    {
                        MessageBox.Show(
                            "Резервная копия успешно создана!",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Произошла ошибка при создании резервной копии.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "SQL файлы (*.sql)|*.sql",
                Title = "Выберите файл резервной копии для восстановления"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите восстановить базу данных из выбранной копии?\n\nФайл: {openDialog.FileName}\n\nВнимание: все текущие данные могут быть перезаписаны!",
                    "Подтверждение восстановления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = Sql.ImportFromFile(openDialog.FileName);

                    if (success)
                    {
                        MessageBox.Show(
                            "Восстановление завершено успешно!",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Произошла ошибка при восстановлении базы данных.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
