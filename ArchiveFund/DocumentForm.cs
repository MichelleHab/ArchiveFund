using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveFund
{
    public partial class DocumentForm : Form
    {
        public DocumentForm(object[]? parameters = null, bool isDelete = false)
        {
            InitializeComponent();
            MainForm.LoadToComboBox("type_id", "`type_name`", MainForm.Table.DocumentTypes, comboBoxTypeId);
            MainForm.LoadToComboBox("student_id", "`full_name`", MainForm.Table.Student, comboBoxStudentId);
            MainForm.LoadToComboBox("box_id", "Concat_ws('', 'id:', `box_id`, '->', `box_name`)", MainForm.Table.Boxes, comboBoxBox_id);
            if (parameters != null && parameters.Length >= 7)
            {
                flagIsDelete.Checked = isDelete;
                this.Text = "Изменение документа!";
                txtDocumentSubject.Text = parameters[1].ToString();
                dtpCreationYear.Value = Convert.ToDateTime(parameters[2]);
                foreach (var item in comboBoxTypeId.Items)
                {
                    var prop = item.GetType().GetProperty("Id");
                    if (prop != null && prop?.GetValue(item)?.ToString() == parameters[3].ToString())
                    {
                        comboBoxTypeId.SelectedItem = item;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(parameters[4].ToString()))
                    txtSupervisorFullName.Text = parameters[4].ToString();
                if (!string.IsNullOrEmpty(parameters[5].ToString()))
                {
                    foreach (var item in comboBoxStudentId.Items)
                    {
                        var prop = item.GetType().GetProperty("Id");
                        if (prop != null && prop?.GetValue(item)?.ToString() == parameters[5].ToString())
                        {
                            comboBoxStudentId.SelectedItem = item;
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(parameters[6].ToString()))
                {
                    foreach (var item in comboBoxBox_id.Items)
                    {
                        var prop = item.GetType().GetProperty("Id");
                        if (prop != null && prop?.GetValue(item)?.ToString() == parameters[6].ToString())
                        {
                            comboBoxBox_id.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            else this.Text = "Добавление документа!";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDocumentSubject.Text))
            {
                MessageBox.Show("Не введена тема документа!");
                txtDocumentSubject.Focus();
                return;
            }
            if (comboBoxTypeId.SelectedValue == null)
            {
                MessageBox.Show("Не выбран тип документа!");
                comboBoxTypeId.Focus();
                return;
            }
            if (comboBoxStudentId.SelectedValue == null)
            {
                MessageBox.Show("Не выбран студент!");
                comboBoxStudentId.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }
        private void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
