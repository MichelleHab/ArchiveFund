namespace ArchiveFund
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            mainMenu = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            dataMenu = new ToolStripMenuItem();
            usersMenuItem = new ToolStripMenuItem();
            groupsMenuItem = new ToolStripMenuItem();
            boxesMenuItem = new ToolStripMenuItem();
            studentDataMenu = new ToolStripMenuItem();
            StudentMenuItem = new ToolStripMenuItem();
            PersFilesMenuItem = new ToolStripMenuItem();
            DelPersFilesMenuItem = new ToolStripMenuItem();
            DocumentsMenuItem = new ToolStripMenuItem();
            DelDocumentsMenuItem = new ToolStripMenuItem();
            guideMenu = new ToolStripMenuItem();
            DocumentTypesMenuItem = new ToolStripMenuItem();
            printMenu = new ToolStripMenuItem();
            printPersFiles = new ToolStripMenuItem();
            ptintDiplomaWorks = new ToolStripMenuItem();
            printNavigationFile = new ToolStripMenuItem();
            MenuItemGeneratePrint = new ToolStripMenuItem();
            MenuItemClearPrint = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            MenuItemAddDocumentPrint = new ToolStripMenuItem();
            MenuItemAddStudentsPrint = new ToolStripMenuItem();
            MenuItemAddGroupPrint = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            StatusLabelDateTime = new ToolStripStatusLabel();
            grid = new DataGridView();
            contextMenu = new ContextMenuStrip(components);
            contextAddItem = new ToolStripMenuItem();
            contextEditItem = new ToolStripMenuItem();
            contextDeleteItem = new ToolStripMenuItem();
            contextFilterItem = new ToolStripMenuItem();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            searchEngine = new TextBox();
            toolStrip = new ToolStrip();
            toolStripAdd = new ToolStripButton();
            toolStripEdit = new ToolStripButton();
            toolStripDelete = new ToolStripButton();
            DateTimeTimer = new System.Windows.Forms.Timer(components);
            mainMenu.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            contextMenu.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.BackColor = Color.FromArgb(100, 200, 200, 200);
            mainMenu.Font = new Font("Times New Roman", 13.8F);
            mainMenu.ImageScalingSize = new Size(20, 20);
            mainMenu.Items.AddRange(new ToolStripItem[] { fileMenu, dataMenu, studentDataMenu, guideMenu, printMenu });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(800, 34);
            mainMenu.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { exitMenuItem });
            fileMenu.Image = (Image)resources.GetObject("fileMenu.Image");
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(97, 30);
            fileMenu.Text = "Файл";
            // 
            // exitMenuItem
            // 
            exitMenuItem.BackColor = Color.LightCoral;
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(160, 30);
            exitMenuItem.Text = "Выход";
            exitMenuItem.Click += ExitMenuItem_Click;
            // 
            // dataMenu
            // 
            dataMenu.DropDownItems.AddRange(new ToolStripItem[] { usersMenuItem, groupsMenuItem, boxesMenuItem });
            dataMenu.Image = (Image)resources.GetObject("dataMenu.Image");
            dataMenu.Name = "dataMenu";
            dataMenu.Size = new Size(121, 30);
            dataMenu.Text = "Данные";
            // 
            // usersMenuItem
            // 
            usersMenuItem.BackColor = Color.LightCoral;
            usersMenuItem.Name = "usersMenuItem";
            usersMenuItem.Size = new Size(230, 30);
            usersMenuItem.Text = "Пользователи";
            usersMenuItem.Visible = false;
            usersMenuItem.Click += UsersMenuItem_Click;
            // 
            // groupsMenuItem
            // 
            groupsMenuItem.BackColor = Color.LightCoral;
            groupsMenuItem.Name = "groupsMenuItem";
            groupsMenuItem.Size = new Size(230, 30);
            groupsMenuItem.Text = "Группы";
            groupsMenuItem.Click += GroupsMenuItem_Click;
            // 
            // boxesMenuItem
            // 
            boxesMenuItem.BackColor = Color.LightCoral;
            boxesMenuItem.Name = "boxesMenuItem";
            boxesMenuItem.Size = new Size(230, 30);
            boxesMenuItem.Text = "Коробки";
            boxesMenuItem.Click += BoxesMenuItem_Click;
            // 
            // studentDataMenu
            // 
            studentDataMenu.DropDownItems.AddRange(new ToolStripItem[] { StudentMenuItem, PersFilesMenuItem, DelPersFilesMenuItem, DocumentsMenuItem, DelDocumentsMenuItem });
            studentDataMenu.Image = (Image)resources.GetObject("studentDataMenu.Image");
            studentDataMenu.Name = "studentDataMenu";
            studentDataMenu.Size = new Size(140, 30);
            studentDataMenu.Text = "Студенты";
            // 
            // StudentMenuItem
            // 
            StudentMenuItem.BackColor = Color.LightCoral;
            StudentMenuItem.Name = "StudentMenuItem";
            StudentMenuItem.Size = new Size(328, 30);
            StudentMenuItem.Text = "Студенты";
            StudentMenuItem.Click += StudentMenuItem_Click;
            // 
            // PersFilesMenuItem
            // 
            PersFilesMenuItem.BackColor = Color.LightCoral;
            PersFilesMenuItem.Name = "PersFilesMenuItem";
            PersFilesMenuItem.Size = new Size(328, 30);
            PersFilesMenuItem.Text = "Персональные файлы";
            PersFilesMenuItem.Click += PersFilesMenuItem_Click;
            // 
            // DelPersFilesMenuItem
            // 
            DelPersFilesMenuItem.BackColor = Color.LightCoral;
            DelPersFilesMenuItem.Name = "DelPersFilesMenuItem";
            DelPersFilesMenuItem.Size = new Size(328, 30);
            DelPersFilesMenuItem.Text = "Удаленные перс. файлы";
            DelPersFilesMenuItem.Click += DelPersFilesMenuItem_Click;
            // 
            // DocumentsMenuItem
            // 
            DocumentsMenuItem.BackColor = Color.LightCoral;
            DocumentsMenuItem.Name = "DocumentsMenuItem";
            DocumentsMenuItem.Size = new Size(328, 30);
            DocumentsMenuItem.Text = "Документы работ";
            DocumentsMenuItem.Click += DocumentsMenuItem_Click;
            // 
            // DelDocumentsMenuItem
            // 
            DelDocumentsMenuItem.BackColor = Color.LightCoral;
            DelDocumentsMenuItem.Name = "DelDocumentsMenuItem";
            DelDocumentsMenuItem.Size = new Size(328, 30);
            DelDocumentsMenuItem.Text = "Удаленные док. работ";
            DelDocumentsMenuItem.Click += DelDocumentsMenuItem_Click;
            // 
            // guideMenu
            // 
            guideMenu.DropDownItems.AddRange(new ToolStripItem[] { DocumentTypesMenuItem });
            guideMenu.Image = (Image)resources.GetObject("guideMenu.Image");
            guideMenu.Name = "guideMenu";
            guideMenu.Size = new Size(164, 30);
            guideMenu.Text = "Справочник";
            // 
            // DocumentTypesMenuItem
            // 
            DocumentTypesMenuItem.BackColor = Color.LightCoral;
            DocumentTypesMenuItem.Name = "DocumentTypesMenuItem";
            DocumentTypesMenuItem.Size = new Size(272, 30);
            DocumentTypesMenuItem.Text = "Типы документов";
            DocumentTypesMenuItem.Click += DocumentTypesMenuItem_Click;
            // 
            // printMenu
            // 
            printMenu.DropDownItems.AddRange(new ToolStripItem[] { printPersFiles, ptintDiplomaWorks, printNavigationFile });
            printMenu.Image = (Image)resources.GetObject("printMenu.Image");
            printMenu.Name = "printMenu";
            printMenu.Size = new Size(99, 25);
            printMenu.Text = "Печати";
            // 
            // printPersFiles
            // 
            printPersFiles.BackColor = Color.LightCoral;
            printPersFiles.Name = "printPersFiles";
            printPersFiles.Size = new Size(456, 46);
            printPersFiles.Text = "Получить данные по выбранному студенту";
            printPersFiles.Click += printPersFiles_Click;
            // 
            // ptintDiplomaWorks
            // 
            ptintDiplomaWorks.BackColor = Color.LightCoral;
            ptintDiplomaWorks.Name = "ptintDiplomaWorks";
            ptintDiplomaWorks.Size = new Size(456, 46);
            ptintDiplomaWorks.Text = "Получить опись по (не удаленным)\nдипломным работам выбранной группы ";
            ptintDiplomaWorks.Click += ptintDiplomaWorks_Click;
            // 
            // printNavigationFile
            // 
            printNavigationFile.BackColor = Color.LightCoral;
            printNavigationFile.DropDownItems.AddRange(new ToolStripItem[] { MenuItemGeneratePrint, MenuItemClearPrint, toolStripSeparator1, MenuItemAddDocumentPrint, MenuItemAddStudentsPrint, MenuItemAddGroupPrint });
            printNavigationFile.Name = "printNavigationFile";
            printNavigationFile.Size = new Size(456, 46);
            printNavigationFile.Text = "Составление файла(docx) навигации по архиву";
            printNavigationFile.DropDownOpening += printNavigationFile_DropDownOpening;
            // 
            // MenuItemGeneratePrint
            // 
            MenuItemGeneratePrint.BackColor = Color.LightCoral;
            MenuItemGeneratePrint.Name = "MenuItemGeneratePrint";
            MenuItemGeneratePrint.Size = new Size(388, 26);
            MenuItemGeneratePrint.Text = "Сгенерировать";
            MenuItemGeneratePrint.Click += MenuItemGeneratePrint_Click;
            // 
            // MenuItemClearPrint
            // 
            MenuItemClearPrint.BackColor = Color.LightCoral;
            MenuItemClearPrint.Name = "MenuItemClearPrint";
            MenuItemClearPrint.Size = new Size(388, 26);
            MenuItemClearPrint.Text = "Отчистить документ";
            MenuItemClearPrint.Click += MenuItemClearPrint_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.BackColor = Color.LightCoral;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(385, 6);
            // 
            // MenuItemAddDocumentPrint
            // 
            MenuItemAddDocumentPrint.BackColor = Color.LightCoral;
            MenuItemAddDocumentPrint.Name = "MenuItemAddDocumentPrint";
            MenuItemAddDocumentPrint.Size = new Size(388, 26);
            MenuItemAddDocumentPrint.Text = "Добавить выбранный документ";
            MenuItemAddDocumentPrint.Click += MenuItemAddDocumentPrint_Click;
            // 
            // MenuItemAddStudentsPrint
            // 
            MenuItemAddStudentsPrint.BackColor = Color.LightCoral;
            MenuItemAddStudentsPrint.Name = "MenuItemAddStudentsPrint";
            MenuItemAddStudentsPrint.Size = new Size(388, 26);
            MenuItemAddStudentsPrint.Text = "- все документы выбранного студента";
            MenuItemAddStudentsPrint.Click += MenuItemAddStudentsPrint_Click;
            // 
            // MenuItemAddGroupPrint
            // 
            MenuItemAddGroupPrint.BackColor = Color.LightCoral;
            MenuItemAddGroupPrint.Name = "MenuItemAddGroupPrint";
            MenuItemAddGroupPrint.Size = new Size(388, 26);
            MenuItemAddGroupPrint.Text = "- выбранной группы";
            MenuItemAddGroupPrint.Click += MenuItemAddGroupPrint_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(100, 200, 200, 200);
            statusStrip.Font = new Font("Times New Roman", 13.8F);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, StatusLabelDateTime });
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip.Location = new Point(0, 568);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 32);
            statusStrip.TabIndex = 1;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(157, 26);
            statusLabel.Text = "Готов к работе";
            // 
            // StatusLabelDateTime
            // 
            StatusLabelDateTime.Alignment = ToolStripItemAlignment.Right;
            StatusLabelDateTime.Name = "StatusLabelDateTime";
            StatusLabelDateTime.Size = new Size(48, 26);
            StatusLabelDateTime.Text = "null";
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            grid.BackgroundColor = Color.Wheat;
            grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Peru;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 13.8F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.ContextMenuStrip = contextMenu;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.SandyBrown;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 13.8F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            grid.DefaultCellStyle = dataGridViewCellStyle2;
            grid.EnableHeadersVisualStyles = false;
            grid.Location = new Point(12, 122);
            grid.Name = "grid";
            grid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new Font("Times New Roman", 13.8F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = Color.Salmon;
            grid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ShowRowErrors = false;
            grid.Size = new Size(776, 403);
            grid.TabIndex = 2;
            grid.Visible = false;
            grid.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // contextMenu
            // 
            contextMenu.BackColor = Color.LightCoral;
            contextMenu.Font = new Font("Times New Roman", 13.8F);
            contextMenu.ImageScalingSize = new Size(20, 20);
            contextMenu.Items.AddRange(new ToolStripItem[] { contextAddItem, contextEditItem, contextDeleteItem, contextFilterItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(231, 124);
            // 
            // contextAddItem
            // 
            contextAddItem.Enabled = false;
            contextAddItem.Image = (Image)resources.GetObject("contextAddItem.Image");
            contextAddItem.Name = "contextAddItem";
            contextAddItem.Size = new Size(230, 30);
            contextAddItem.Text = "Добавить";
            contextAddItem.Click += BtnAdd_Click;
            // 
            // contextEditItem
            // 
            contextEditItem.Enabled = false;
            contextEditItem.Image = (Image)resources.GetObject("contextEditItem.Image");
            contextEditItem.Name = "contextEditItem";
            contextEditItem.Size = new Size(230, 30);
            contextEditItem.Text = "Редактировать";
            contextEditItem.Click += BtnEdit_Click;
            // 
            // contextDeleteItem
            // 
            contextDeleteItem.Enabled = false;
            contextDeleteItem.Image = (Image)resources.GetObject("contextDeleteItem.Image");
            contextDeleteItem.Name = "contextDeleteItem";
            contextDeleteItem.Size = new Size(230, 30);
            contextDeleteItem.Text = "Удалить";
            contextDeleteItem.Click += BtnDelete_Click;
            // 
            // contextFilterItem
            // 
            contextFilterItem.Enabled = false;
            contextFilterItem.Image = (Image)resources.GetObject("contextFilterItem.Image");
            contextFilterItem.Name = "contextFilterItem";
            contextFilterItem.Size = new Size(230, 30);
            contextFilterItem.Text = "Фильтр";
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.BackColor = Color.Wheat;
            btnAdd.Enabled = false;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(378, 533);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 36);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.AutoSize = true;
            btnEdit.BackColor = Color.Wheat;
            btnEdit.Enabled = false;
            btnEdit.Location = new Point(518, 533);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(164, 36);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.BackColor = Color.Wheat;
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(688, 533);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 36);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = Color.Transparent;
            lblSearch.Location = new Point(12, 81);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 26);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Поиск:";
            // 
            // searchEngine
            // 
            searchEngine.BackColor = Color.Wheat;
            searchEngine.Location = new Point(83, 78);
            searchEngine.Margin = new Padding(0);
            searchEngine.Name = "searchEngine";
            searchEngine.PlaceholderText = "Search";
            searchEngine.Size = new Size(326, 34);
            searchEngine.TabIndex = 9;
            searchEngine.TextChanged += searchEngine_TextChanged;
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.FromArgb(100, 200, 200, 200);
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripAdd, toolStripEdit, toolStripDelete });
            toolStrip.Location = new Point(0, 34);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 27);
            toolStrip.TabIndex = 10;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripAdd
            // 
            toolStripAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripAdd.Enabled = false;
            toolStripAdd.Image = (Image)resources.GetObject("toolStripAdd.Image");
            toolStripAdd.ImageTransparentColor = Color.Magenta;
            toolStripAdd.Name = "toolStripAdd";
            toolStripAdd.Size = new Size(24, 24);
            toolStripAdd.Text = "toolStripButton1";
            toolStripAdd.Click += BtnAdd_Click;
            // 
            // toolStripEdit
            // 
            toolStripEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripEdit.Enabled = false;
            toolStripEdit.Image = (Image)resources.GetObject("toolStripEdit.Image");
            toolStripEdit.ImageTransparentColor = Color.Magenta;
            toolStripEdit.Name = "toolStripEdit";
            toolStripEdit.Size = new Size(24, 24);
            toolStripEdit.Text = "toolStripButton2";
            toolStripEdit.Click += BtnEdit_Click;
            // 
            // toolStripDelete
            // 
            toolStripDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDelete.Enabled = false;
            toolStripDelete.Image = (Image)resources.GetObject("toolStripDelete.Image");
            toolStripDelete.ImageTransparentColor = Color.Magenta;
            toolStripDelete.Name = "toolStripDelete";
            toolStripDelete.Size = new Size(24, 24);
            toolStripDelete.Text = "toolStripButton3";
            toolStripDelete.Click += BtnDelete_Click;
            // 
            // DateTimeTimer
            // 
            DateTimeTimer.Enabled = true;
            DateTimeTimer.Interval = 1000;
            DateTimeTimer.Tick += DateTimeTimer_Tick;
            // 
            // MainForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 600);
            Controls.Add(toolStrip);
            Controls.Add(searchEngine);
            Controls.Add(lblSearch);
            Controls.Add(mainMenu);
            Controls.Add(statusStrip);
            Controls.Add(grid);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Font = new Font("Times New Roman", 13.8F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Архивный фонд — Главная";
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            contextMenu.ResumeLayout(false);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        // Элементы управления
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataMenu;
        private System.Windows.Forms.ToolStripMenuItem groupsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxesMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextAddItem;
        private System.Windows.Forms.ToolStripMenuItem contextEditItem;
        private System.Windows.Forms.ToolStripMenuItem contextDeleteItem;
        private ToolStripMenuItem usersMenuItem;
        private ToolStripMenuItem guideMenu;
        private ToolStripMenuItem DocumentTypesMenuItem;
        private ToolStripMenuItem studentDataMenu;
        private ToolStripMenuItem StudentMenuItem;
        private ToolStripMenuItem PersFilesMenuItem;
        private ToolStripMenuItem DelPersFilesMenuItem;
        private ToolStripMenuItem DocumentsMenuItem;
        private ToolStripMenuItem DelDocumentsMenuItem;
        private Label lblSearch;
        private TextBox searchEngine;
        private ToolStripMenuItem contextFilterItem;
        private ToolStripMenuItem printMenu;
        private ToolStripMenuItem printPersFiles;
        private ToolStrip toolStrip;
        private ToolStripButton toolStripAdd;
        private ToolStripButton toolStripEdit;
        private ToolStripButton toolStripDelete;
        private ToolStripStatusLabel StatusLabelDateTime;
        private System.Windows.Forms.Timer DateTimeTimer;
        private ToolStripMenuItem ptintDiplomaWorks;
        private ToolStripMenuItem printNavigationFile;
        private ToolStripMenuItem MenuItemGeneratePrint;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem MenuItemAddDocumentPrint;
        private ToolStripMenuItem MenuItemAddStudentsPrint;
        private ToolStripMenuItem MenuItemAddGroupPrint;
        private ToolStripMenuItem MenuItemClearPrint;
    }
}
