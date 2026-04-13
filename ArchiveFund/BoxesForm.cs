using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ArchiveFund
{
    public partial class BoxesForm : Form
    {
        public BoxesForm(object[]? parameters = null)
        {
            InitializeComponent();
            MainForm.LoadToComboBox("group_id", "`group_name`", MainForm.Table.Group, cmbGroupId);
            MainForm.LoadToComboBox("type_id", "`type_name`", MainForm.Table.DocumentTypes, cmbTypeId);
            if (parameters is not null && parameters.Length == 7)
            {
                this.Text = "Изменение коробки!";
                if (!string.IsNullOrEmpty(parameters[1]?.ToString()))
                    txtName.Text = parameters[1].ToString();
                if (!string.IsNullOrEmpty(parameters[2]?.ToString()))
                    numericRackNumber.Value = Convert.ToInt32(parameters[2]);
                if (!string.IsNullOrEmpty(parameters[3]?.ToString()))
                    numericShelfNumber.Value = Convert.ToInt32(parameters[3]);
                if (!string.IsNullOrEmpty(parameters[4]?.ToString()))
                {
                    foreach (var item in cmbGroupId.Items)
                    {
                        var prop = item.GetType().GetProperty("Id");
                        if (prop != null && prop.GetValue(item).ToString() == parameters[4].ToString())
                        {
                            cmbGroupId.SelectedItem = item;
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(parameters[5]?.ToString()))
                {
                    foreach (var item in cmbTypeId.Items)
                    {
                        var prop = item.GetType().GetProperty("Id");
                        if (prop != null && prop.GetValue(item).ToString() == parameters[5].ToString())
                        {
                            cmbTypeId.SelectedItem = item;
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(parameters[6]?.ToString()))
                {
                    noSaveDate.Checked = false;
                    dtpYearWork.Value = DateTime.Parse(parameters[6].ToString());
                }
            }
            else this.Text = "Добавление коробки!";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbTypeId.Text))
            {
                MessageBox.Show("Не введен тип! Пожалуйста выберите из предложенных.");
                cmbTypeId.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }
        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void saveDate_CheckedChanged(object sender, EventArgs e)
            => dtpYearWork.Enabled = !noSaveDate.Checked;
        private void TxtName_GotFocus(object sender, EventArgs e)
        {
            if (numericRackNumber.Value > 0 && numericRackNumber.Value > 0 && txtName.Text.Length == 0)
                txtName.Text = "Box:" + numericRackNumber.Value.ToString() + "-" + numericShelfNumber.Value.ToString();
        }
    }
}
