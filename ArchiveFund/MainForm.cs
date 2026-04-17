using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Xceed.Words.NET;
namespace ArchiveFund
{
    public partial class MainForm : Form
    {
        private Role role;
        private string? login;
        public MainForm(Role? role = null, string? login = null)
        {
            InitializeComponent();
            if (role is null)
                this.role = Role.None;
            else this.role = role.Value;
            if (login is not null)
            {
                this.login = login;
                this.Text += " >- " + login + " <- ";
            }
            switch (this.role)
            {
                case Role.Admin:
                    usersMenuItem.Visible = true;
                    break;
                case Role.Manager: break;
                default: break;
            }
        }
        private bool flag_is_update = false;
        private void ShowTable()
        {
            contextFilterItem.Enabled = true;
            grid.DataSource = null;
            grid.Columns.Clear();
            if (currentTable is Table.None)
            {
                grid.Rows.Clear();
                contextFilterItem.Enabled = false;
                return;
            }
            var selects = getSelects();
            string? like = null;
            if (!string.IsNullOrEmpty(searchEngine.Text))
                like = $"Concat({getSelectsNotAs(selects)})" + " like ";
            var joins = getJoins();
            var tb = Sql.Query($"select {(selects is not null ? selects : "*")} " +
                $"from `{currentTable}` {(joins is not null ? joins : string.Empty)} " +
                $"{(like is not null ? "where" : string.Empty)} " +
                $"{(like is not null ? like + " @like" : string.Empty)} ",
                [new("@like", string.Concat("%", searchEngine.Text, "%"))]);

            grid.DataSource = tb;
            if (grid.ColumnCount > 0)
                grid.Columns[0].Visible = false;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (!flag_is_update && tb is not null)
                statusLabel.Text = "- получено " + tb.Rows.Count + " строк";
            else flag_is_update = false;

            ContextFilter.CreateFilterContextMenu(grid, contextFilterItem);
        }
        private Table currentTable = Table.None;
        public enum Table
        {
            None,
            Boxes,
            DeletedDocuments,
            DeletedStudentsPersFiles,
            Documents,
            DocumentTypes,
            Group,
            Student,
            StudentsPersFiles,
            User
        }
        private string? getSelects(Table? table = null)
        {
            table ??= this.currentTable;
            return table switch
            {
                Table.Boxes =>
                "box_id, box_name as 'Имя', " +
                "rack_number as 'Номер стеллажа', " +
                "shelf_number as 'Номер полки', " +
                "group_name as 'Группа', " +
                "type_name as 'Тип хранимых документов', " +
                "year_work as 'Год работы'",
                Table.DeletedDocuments =>
                "doc_id, document_subject as 'Тема', " +
                "start_data as 'Дата создания', " +
                "type_name as 'Тип', " +
                "Supervisor_full_name as 'Руководитель', " +
                "full_name as 'Студент', " +
                "box_name as 'Коробка с файлом'",
                Table.DeletedStudentsPersFiles =>
                "pers_file_id, deduction_year as 'Год отчисления', " +
                "reason as 'Причина отчисления', " +
                "admission_year as 'Год поступления', " +
                "full_name as 'Студент'",
                Table.Documents =>
                "doc_id, document_subject as 'Тема', " +
                "start_data as 'Дата создания', " +
                "type_name as 'Тип', " +
                "Supervisor_full_name as 'Руководитель', " +
                "full_name as 'Студент', " +
                "box_name as 'Коробка с файлом'",
                Table.DocumentTypes =>
                "type_id, type_name as 'Тема'",
                Table.Group =>
                "group_id, group_name as 'Имя группы', " +
                "formation_year as 'Год создания', " +
                "specialization as 'Специализация'",
                Table.Student =>
                "student_id, full_name as 'ФИО', " +
                "group_name as 'Группа'",
                Table.StudentsPersFiles =>
                "pers_file_id, deduction_year as 'Год отчисления', " +
                "reason as 'Причина отчисления', " +
                "admission_year as 'Год поступления', " +
                "full_name as 'Студент'",
                Table.User => "user_id, FIO, role, login, password",
                _ => null
            };
        }
        public static void LoadToComboBox(string value_id, string value_name, Table table, ComboBox cmb, string? where = null)
        {
            var tb = Sql.Query($"select `{value_id}`, {value_name} from `{table}` {where}");
            if (tb is null)
                return;
            DataRowCollection? Row = tb.Rows;
            var items = new List<object>();
            foreach (DataRow row in Row)
                items.Add(new { Id = row[0], Name = row[1] });
            cmb.DataSource = items;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "Id";
        }
        private string? getSelectsNotAs(string? select)
        {
            return (select is null) ? null :
                MyRegex().Replace(select, "");
        }
        private string? getJoins(Table? table = null)
        {
            table ??= this.currentTable;
            return table switch
            {
                Table.Boxes =>
                "left join `DocumentTypes` on `DocumentTypes`.type_id = `Boxes`.`type_id` " +
                "left join `Group` on `Group`.`group_id` = `Boxes`.`group_id`",
                Table.DeletedDocuments =>
                "left join `DocumentTypes` on `DocumentTypes`.type_id = `DeletedDocuments`.`type_id` " +
                "left join `Student` on `Student`.`student_id` = `DeletedDocuments`.`student_id` " +
                "left join `Boxes` on `Boxes`.`box_id` = `DeletedDocuments`.`box_id`",
                Table.DeletedStudentsPersFiles =>
                "left join `Student` on `Student`.`student_id` = `DeletedStudentsPersFiles`.`student_id`",
                Table.Documents =>
                "left join `DocumentTypes` on `DocumentTypes`.type_id = `Documents`.`type_id` " +
                "left join `Student` on `Student`.`student_id` = `Documents`.`student_id` " +
                "left join `Boxes` on `Boxes`.`box_id` = `Documents`.`box_id`",
                Table.Student =>
                "left join `Group` on `Group`.`group_id` = `Student`.`group_id`",
                Table.StudentsPersFiles =>
                "left join `Student` on `Student`.`student_id` = `StudentsPersFiles`.`student_id`",
                _ => null
            };
        }
        public enum Role
        {
            None,
            Admin,
            Manager
        }
        public static Role RoleParse(string role)
        {
            return role switch
            {
                "Admin" => Role.Admin,
                "Manager" => Role.Manager,
                _ => Role.None,
            };
        }
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.grid.RowCount > 0)
            {
                this.contextAddItem.Enabled = true;
                this.btnAdd.Enabled = true;
            }
            else
            {
                this.contextAddItem.Enabled = false;
                this.btnAdd.Enabled = false;
            }
            if (this.grid.SelectedRows.Count > 0)
            {
                if (this.grid.SelectedRows.Count is 1)
                {
                    this.contextEditItem.Enabled = true;
                    this.btnEdit.Enabled = true;
                }
                else
                {
                    this.contextEditItem.Enabled = false;
                    this.btnEdit.Enabled = false;
                }
                this.btnDelete.Enabled = true;
                this.contextDeleteItem.Enabled = true;
            }
            else
            {
                this.btnDelete.Enabled = false;
                this.contextDeleteItem.Enabled = false;
                this.contextEditItem.Enabled = false;
                this.btnEdit.Enabled = false;
            }
        }
        private void ExitMenuItem_Click(object sender, EventArgs e) => this.Close();
        private void UsersMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.User;
            ShowTable();
        }
        private void GroupsMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.Group;
            ShowTable();
        }
        private void BoxesMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.Boxes;
            ShowTable();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form form;
            switch (currentTable)
            {
                case Table.Boxes:
                    form = new BoxesForm();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("insert into `Boxes`(box_name, rack_number, " +
                        "shelf_number, group_id, type_id, year_work) " +
                        "values (@box_name, @rack_number, @shelf_number, " +
                        "@group_id, @type_id, @year_work)", [
                            new ("@box_name", !string.IsNullOrEmpty(((BoxesForm)form).txtName.Text) ? ((BoxesForm)form).txtName.Text : DBNull.Value),
                            new ("@rack_number", ((BoxesForm)form).numericRackNumber.Value > 0 ? ((BoxesForm) form).numericRackNumber.Value : DBNull.Value),
                            new ("@shelf_number", ((BoxesForm) form).numericShelfNumber.Value > 0 ? ((BoxesForm) form).numericShelfNumber.Value : DBNull.Value),
                            new ("@group_id", ((BoxesForm)form).cmbGroupId.SelectedValue ?? DBNull.Value),
                            new ("@type_id", ((BoxesForm)form).cmbTypeId.SelectedValue),
                            new ("@year_work", ((BoxesForm)form).noSaveDate.Checked ? ((BoxesForm)form).dtpYearWork.Value : DBNull.Value) ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.Documents or Table.DeletedDocuments:
                    form = new DocumentForm();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns($"insert into `{(((DocumentForm)form).flagIsDelete.Checked ?
                        Table.DeletedDocuments : Table.Documents)}`(document_subject, start_data, " +
                        "type_id, Supervisor_full_name, student_id, box_id) " +
                        "values (@document_subject, @start_data, @type_id, " +
                        "@Supervisor_full_name, @student_id, @box_id)", [
                            new MySqlParameter("@document_subject", ((DocumentForm)form).txtDocumentSubject.Text),
                            new MySqlParameter("@start_data", ((DocumentForm)form).dtpCreationYear.Value),
                            new MySqlParameter("@type_id", ((DocumentForm)form).comboBoxTypeId.SelectedValue),
                            new MySqlParameter("@Supervisor_full_name", string.IsNullOrEmpty(((DocumentForm)form).txtSupervisorFullName.Text) ? DBNull.Value : ((DocumentForm)form).txtSupervisorFullName.Text),
                            new MySqlParameter("@student_id", ((DocumentForm)form).comboBoxStudentId.SelectedValue),
                            new MySqlParameter("@box_id", ((DocumentForm)form).comboBoxBox_id.SelectedValue)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.DocumentTypes:
                    form = new DocumentTypeForm();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("insert into `DocumentTypes`(type_name) values (@type_name)",
                        [new MySqlParameter("@type_name", ((DocumentTypeForm)form).txtTypeName.Text)]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.Group:
                    form = new GroupForm();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("insert into `Group`(group_name, formation_year, specialization) " +
                        "values (@group_name, @formation_year, @specialization)", [
                            new MySqlParameter("@group_name", ((GroupForm)form).txtGroupName.Text),
                            new MySqlParameter("@formation_year", ((GroupForm)form).dtpFormationYear.Value),
                            new MySqlParameter("@specialization", ((GroupForm)form).txtSpecialization.Text)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.Student or Table.StudentsPersFiles or Table.DeletedStudentsPersFiles:
                    form = new StudentForm();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("insert into `Student`(full_name, group_id) values (@full_name, @group_id)", [
                        new MySqlParameter("@full_name", ((StudentForm)form).txtFullName.Text),
                        new MySqlParameter("@group_id", ((StudentForm)form).cmbGroupId.SelectedValue ?? DBNull.Value) ]))
                        MessageBoxForErrorsToShow();
                    var student_id = Sql.QueryOneReturn("select student_id from `Student` order by student_id desc limit 1");
                    if (!Sql.QueryNonReturns($"insert into `{(((StudentForm)form).checkBoxIsDelete.Checked ?
                        Table.DeletedStudentsPersFiles : Table.StudentsPersFiles)}`(admission_year, deduction_year, reason, student_id) " +
                        "values (@admission_year, @deduction_year, @reason, @student_id)", [
                            new MySqlParameter("@admission_year", ((StudentForm)form).dtpAdmissionYear.Value),
                            new MySqlParameter("@deduction_year", !((StudentForm)form).deductionNoSaveDate.Checked ? ((StudentForm)form).dtpDeductionYear.Value : DBNull.Value),
                            new MySqlParameter("@reason", string.IsNullOrEmpty(((StudentForm)form).txtReason.Text) ? DBNull.Value : ((StudentForm)form).txtReason.Text),
                            new MySqlParameter("@student_id", student_id) ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.User:
                    form = new UserForm();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("insert into `User`(FIO, role, login, password) " +
                        "values (@FIO, @role, @login, @password)", [
                            new MySqlParameter("@FIO", ((UserForm)form).txtFIO.Text),
                            new MySqlParameter("@role", ((UserForm)form).cmbRole.Text),
                            new MySqlParameter("@login", ((UserForm)form).txtLogin.Text),
                            new MySqlParameter("@password", ((UserForm)form).txtPassword.Text) ]))
                        MessageBoxForErrorsToShow();
                    break;
            }
            statusLabel.Text = "- Запись добавлена";
            flag_is_update = true;
            ShowTable();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Form form;
            var id = grid.SelectedRows[0].Cells[0].Value;
            switch (currentTable)
            {
                case Table.Boxes:
                    form = new BoxesForm(Sql.Query("select * from `Boxes` where box_id = @id",
                        [new("@id", id)]).Rows[0].ItemArray);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("update `Boxes` set box_name = @box_name, " +
                        "rack_number = @rack_number, shelf_number = @shelf_number, " +
                        "group_id = @group_id, type_id = @type_id, year_work = @year_work " +
                        "where box_id = @id",
                        [   new ("@id", id),
                            new ("@box_name", string.IsNullOrEmpty(((BoxesForm)form).txtName.Text) ? DBNull.Value : ((BoxesForm)form).txtName.Text),
                            new ("@rack_number", ((BoxesForm)form).numericRackNumber.Value > 0 ? ((BoxesForm)form).numericRackNumber.Value : DBNull.Value),
                            new ("@shelf_number", ((BoxesForm)form).numericShelfNumber.Value > 0 ? ((BoxesForm)form).numericShelfNumber.Value : DBNull.Value),
                            new ("@group_id", ((BoxesForm)form).cmbGroupId.SelectedValue ?? DBNull.Value),
                            new ("@type_id", ((BoxesForm)form).cmbTypeId.SelectedValue),
                            new ("@year_work", !((BoxesForm)form).noSaveDate.Checked ? ((BoxesForm)form).dtpYearWork.Value : DBNull.Value) ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.Documents or Table.DeletedDocuments:
                    form = new DocumentForm(Sql.Query($"select * from `{currentTable}` where doc_id = @id",
                        [new("@id", id)]).Rows[0].ItemArray, currentTable == Table.DeletedDocuments);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    Sql.QueryNonReturns($"delete from {currentTable} where doc_id = @id", [new("@id", id)]);
                    if (!Sql.QueryNonReturns($"insert into `{(((DocumentForm)form).flagIsDelete.Checked ?
                        Table.DeletedDocuments : Table.Documents)}`(document_subject, start_data, " +
                        "type_id, Supervisor_full_name, student_id, box_id) " +
                        "values (@document_subject, @start_data, @type_id, " +
                        "@Supervisor_full_name, @student_id, @box_id)", [
                            new MySqlParameter("@document_subject", ((DocumentForm)form).txtDocumentSubject.Text),
                            new MySqlParameter("@start_data", ((DocumentForm)form).dtpCreationYear.Value),
                            new MySqlParameter("@type_id", ((DocumentForm)form).comboBoxTypeId.SelectedValue),
                            new MySqlParameter("@Supervisor_full_name", string.IsNullOrEmpty(((DocumentForm)form).txtSupervisorFullName.Text) ? DBNull.Value : ((DocumentForm)form).txtSupervisorFullName.Text),
                            new MySqlParameter("@student_id", ((DocumentForm)form).comboBoxStudentId.SelectedValue),
                            new MySqlParameter("@box_id", ((DocumentForm)form).comboBoxBox_id.SelectedValue) ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.DocumentTypes:
                    form = new DocumentTypeForm(Sql.Query("select * from `DocumentTypes` where type_id = @id",
                    [new MySqlParameter("@id", id)]).Rows[0].ItemArray);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("update `DocumentTypes` set type_name = @type_name where type_id = @id", [
                            new MySqlParameter("@id", id),
                            new MySqlParameter("@type_name", ((DocumentTypeForm)form).txtTypeName.Text) ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.Group:
                    form = new GroupForm(Sql.Query("select * from `Group` where group_id = @id",
                    [new MySqlParameter("@id", id)]).Rows[0].ItemArray);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("update `Group` set group_name = @group_name, " +
                        "formation_year = @formation_year, specialization = @specialization " +
                        "where group_id = @id", [
                            new MySqlParameter("@id", id),
                            new MySqlParameter("@group_name", ((GroupForm)form).txtGroupName.Text),
                            new MySqlParameter("@formation_year", ((GroupForm)form).dtpFormationYear.Value),
                            new MySqlParameter("@specialization", ((GroupForm)form).txtSpecialization.Text) ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.Student or Table.StudentsPersFiles or Table.DeletedStudentsPersFiles:
                    object[] forStudents;
                    object[] forPersFiles;
                    Table persFiles = Table.StudentsPersFiles;
                    if (currentTable == Table.Student)
                    {
                        forStudents = Sql.Query("select * from `Student` where student_id = @id",
                    [new MySqlParameter("@id", id)]).Rows[0].ItemArray;
                        var tbPersFiles = Sql.Query("select * from `StudentsPersFiles` where student_id = @id",
                    [new MySqlParameter("@id", id)]);
                        if (tbPersFiles.Rows.Count == 0)
                        {
                            tbPersFiles = Sql.Query("select * from `DeletedStudentsPersFiles` where student_id = @id",
                            [new MySqlParameter("@id", id)]);
                            persFiles = Table.DeletedStudentsPersFiles;
                        }
                        forPersFiles = tbPersFiles.Rows[0].ItemArray;
                    }
                    else
                    {
                        persFiles = currentTable;
                        forPersFiles = Sql.Query($"select * from `{persFiles}` where pers_file_id = @id",
                    [new MySqlParameter("@id", id)]).Rows[0].ItemArray;
                        forStudents = Sql.Query($"select * from `Student` where student_id = @id",
                    [new MySqlParameter("@id", forPersFiles[4])]).Rows[0].ItemArray;
                    }
                    form = new StudentForm(forStudents, forPersFiles, persFiles == Table.DeletedStudentsPersFiles);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("update `Student` set full_name = @full_name, group_id = @group_id where student_id = @id", [
                            new MySqlParameter("@id", forStudents[0]),
                            new MySqlParameter("@full_name", ((StudentForm)form).txtFullName.Text),
                            new MySqlParameter("@group_id", ((StudentForm)form).cmbGroupId.SelectedValue ?? DBNull.Value) ]))
                        MessageBoxForErrorsToShow();
                    Sql.QueryNonReturns($"delete from {persFiles} where pers_file_id = @id", [new("@id", forPersFiles[0])]);
                    if (!Sql.QueryNonReturns($"insert into `{(((StudentForm)form).checkBoxIsDelete.Checked ?
                        Table.DeletedStudentsPersFiles : Table.StudentsPersFiles)}`(admission_year, deduction_year, reason, student_id) " +
                        "values (@admission_year, @deduction_year, @reason, @student_id)", [
                            new MySqlParameter("@admission_year", ((StudentForm)form).dtpAdmissionYear.Value),
                            new MySqlParameter("@deduction_year", !((StudentForm)form).deductionNoSaveDate.Checked ? ((StudentForm)form).dtpDeductionYear.Value : DBNull.Value),
                            new MySqlParameter("@reason", string.IsNullOrEmpty(((StudentForm)form).txtReason.Text) ? DBNull.Value : ((StudentForm)form).txtReason.Text),
                            new MySqlParameter("@student_id", forStudents[0]) ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Table.User:
                    form = new UserForm(Sql.Query("select * from `User` where user_id = @id",
                        [new MySqlParameter("@id", id)]).Rows[0].ItemArray);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns("update `User` set FIO = @FIO, role = @role, " +
                        "login = @login, password = @password where user_id = @id",
                        [
                            new MySqlParameter("@id", id),
                            new MySqlParameter("@FIO", ((UserForm)form).txtFIO.Text),
                            new MySqlParameter("@role", ((UserForm)form).cmbRole.Text),
                            new MySqlParameter("@login", ((UserForm)form).txtLogin.Text),
                            new MySqlParameter("@password", ((UserForm)form).txtPassword.Text)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
            }
            statusLabel.Text = "- Запись обновлена";
            flag_is_update = true;
            ShowTable();
        }
        private void MessageBoxForErrorsToShow()
            => MessageBox.Show("Ошибка записи данных!\nВозможные причины смотреть в руководстве пользователя", "Ошибка Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (currentTable is Table.None)
                return;
            else if (MessageBox.Show("Точно хотите удалить?", "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                is not DialogResult.OK)
                return;
            int num_return = grid.SelectedRows.Count;
            foreach (DataGridViewRow row in grid.SelectedRows)
                Sql.QueryNonReturns($"delete from `{currentTable}` " +
                    $"where {getSelects().Split(',')[0]} = @id",
                    [new("@id", row.Cells[0].Value)]);
            statusLabel.Text = "- Запись(и) удалена(ы) -> " + num_return + " строк";
            flag_is_update = true;
            ShowTable();
        }
        private void StudentMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.Student;
            ShowTable();
        }
        private void PersFilesMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.StudentsPersFiles;
            ShowTable();
        }
        private void DelPersFilesMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.DeletedStudentsPersFiles;
            ShowTable();
        }
        private void DocumentsMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.Documents;
            ShowTable();
        }
        private void DelDocumentsMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.DeletedDocuments;
            ShowTable();
        }
        private void DocumentTypesMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = Table.DocumentTypes;
            ShowTable();
        }
        private void searchEngine_TextChanged(object sender, EventArgs e) => ShowTable();
        [GeneratedRegex(@"\s+as\s+[^,]*")]
        private static partial Regex MyRegex();

        private void printAllPersFiles_Click(object sender, EventArgs e)
        {
            // 1. Подготавливаем данные (например, из базы данных или полей ввода)
            if (currentTable is not Table.Student and not Table.StudentsPersFiles and not Table.DeletedStudentsPersFiles || grid.CurrentRow is null)
            {
                return;
            }
            var id = grid.CurrentRow.Cells[0]?.Value?.ToString();
            if (currentTable == Table.Student)
            {

            }
            else
            {

            }
            var studentData = new Dictionary<string, string>
        {
            { "Specialty", "09.02.07 Информационные системы и программирование" },
            { "FormOfStudy", "Очная" },
            { "FileNumber", "123-УД/2026" },
            { "LastName", "Петров" },
            { "FirstName", "Алексей" },
            { "MiddleName", "Сергеевич" },
            { "StartDate", DateTime.Now.ToString("dd.MM.yyyy") },
            { "EndDate", DateTime.Now.AddYears(4).ToString("dd.MM.yyyy") },
            { "SheetCount", "25" },
            { "StorageYears", "50" }
        };

            // 2. Открываем диалог сохранения файла
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Документы Word (*.docx)|*.docx";
                saveDialog.Title = "Сохранить личное дело студента";
                saveDialog.FileName = $"Личное_дело_{studentData["LastName"]}.docx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 3. Генерируем документ
                        GenerateDocument(templatePath, saveDialog.FileName, studentData);

                        // 4. Предлагаем отправить на печать
                        DialogResult printResult = MessageBox.Show(
                            "Документ успешно создан.\nОтправить его на печать?",
                            "Печать",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (printResult == DialogResult.Yes)
                        {
                            PrintDocument(saveDialog.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при создании документа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private string templatePath = Path.Combine(Application.StartupPath, "Опись Личные_дела_студентов.DOCX");
        private void GenerateDocument(string templatePath, string outputPath, Dictionary<string, string> data)
        {
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException("Шаблон не найден: " + templatePath);
            }

            // Загружаем шаблон
            using (var doc = DocX.Load(templatePath))
            {
                // Проходим по всем параграфам и заменяем ключи вида {Key} на значения
                foreach (var paragraph in doc.Paragraphs)
                {
                    foreach (var kvp in data)
                    {
                        string key = $"{{{kvp.Key}}}"; // Формируем ключ {Specialty}
                        if (paragraph.Text.Contains(key))
                        {
                            paragraph.ReplaceText(key, kvp.Value);
                        }
                    }
                }

                // Сохраняем новый файл по пути, выбранному пользователем
                doc.SaveAs(outputPath);
            }
        }

        /// <summary>
        /// Открывает стандартный диалог печати Windows для файла
        /// </summary>
        private static void PrintDocument(string filePath)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo(filePath);
                info.Verb = "print"; // Команда печати
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                // Запуск процесса откроет окно печати ассоциированного приложения (Word)
                Process.Start(info);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось вызвать диалог печати: {ex.Message}\nПопробуйте открыть файл вручную.", "Ошибка печати", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Фоллбэк: просто открываем файл
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }
    }
}
