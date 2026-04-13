using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveFund
{
    public partial class DocumentTypeForm : Form
    {
        public DocumentTypeForm(object[]? parameters = null)
        {
            InitializeComponent();
            if (parameters != null && parameters.Length == 2)
            {
                this.Text = "Изменение типа документа!";
                txtTypeName.Text = parameters[1].ToString();
            }
            else this.Text = "Добавление типа документа!";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTypeName.Text))
            {
                MessageBox.Show("Не введено название типа документа!");
                txtTypeName.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
            => DialogResult = DialogResult.Cancel;
    }
}
