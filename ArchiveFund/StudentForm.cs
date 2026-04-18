using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveFund
{
    public partial class StudentForm : Form
    {
        public StudentForm(object[]? parameters_student = null, object[]? parameters_persFile = null, bool isDelete = false)
        {
            InitializeComponent();
            this.Text = "Добавление студента/персональных данных!";
            /*string? where = null;
            if (parameters_student is not null 
                && parameters_student.Length == 3 
                && string.IsNullOrEmpty(parameters_student[2].ToString()))
                where = $"where group_id in (select group_id from `Student` where student_id = )";*/
            MainForm.LoadToComboBox("group_id", "`group_name`", MainForm.Table.Group, cmbGroupId);
            if (parameters_student is not null && parameters_student.Length == 3)
            {
                checkBoxIsDelete.Checked = isDelete;
                this.Text = "Изменение студента/персональных данных!";
                txtFullName.Text = parameters_student[1].ToString();
                foreach (var item in cmbGroupId.Items)
                {
                    var prop = item.GetType().GetProperty("Id");
                    if (prop != null && prop?.GetValue(item)?.ToString() == parameters_student[2].ToString())
                    {
                        cmbGroupId.SelectedItem = item;
                        break;
                    }
                }
                if (parameters_persFile is not null && parameters_persFile.Length == 5)
                {
                    if (!string.IsNullOrEmpty(parameters_persFile[1].ToString()))
                    {
                        deductionNoSaveDate.Checked = false;
                        dtpDeductionYear.Value = Convert.ToDateTime(parameters_persFile[1]);
                    }
                    if (!string.IsNullOrEmpty(parameters_persFile[2].ToString())) 
                        txtReason.Text = parameters_persFile[2].ToString();
                    dtpAdmissionYear.Value = Convert.ToDateTime(parameters_persFile[3]);
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Не введено ФИО студента!");
                txtFullName.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
            => DialogResult = DialogResult.Cancel;
        private void DeductionNoSaveDate_CheckedChanged(object sender, EventArgs e)
            => dtpDeductionYear.Enabled = !deductionNoSaveDate.Checked;
    }
}
