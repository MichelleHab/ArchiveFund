using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveFund
{
    public partial class GroupForm : Form
    {
        public GroupForm(object[]? parameters = null)
        {
            InitializeComponent();
            if (parameters != null && parameters.Length == 4)
            {
                this.Text = "Изменение группы!";
                txtGroupName.Text = parameters[1].ToString();
                dtpFormationYear.Value = Convert.ToDateTime(parameters[2]);
                cmbSpecialization.Text = parameters[3].ToString();
            }
            else this.Text = "Добавление группы!";
            MainForm.LoadToComboBox("specialization", MainForm.Table.Group, cmbSpecialization);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroupName.Text))
            {
                MessageBox.Show("Не введено название группы!");
                txtGroupName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbSpecialization.Text))
            {
                MessageBox.Show("Не введена специализация!");
                cmbSpecialization.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
            => DialogResult = DialogResult.Cancel;
    }
}
