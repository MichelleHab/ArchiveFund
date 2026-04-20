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
            printAllPersFiles = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
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
            mainMenu.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            contextMenu.SuspendLayout();
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
            mainMenu.Size = new Size(800, 29);
            mainMenu.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { exitMenuItem });
            fileMenu.Image = (Image)resources.GetObject("fileMenu.Image");
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(83, 25);
            fileMenu.Text = "Файл";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(132, 26);
            exitMenuItem.Text = "Выход";
            exitMenuItem.Click += ExitMenuItem_Click;
            // 
            // dataMenu
            // 
            dataMenu.DropDownItems.AddRange(new ToolStripItem[] { usersMenuItem, groupsMenuItem, boxesMenuItem });
            dataMenu.Image = (Image)resources.GetObject("dataMenu.Image");
            dataMenu.Name = "dataMenu";
            dataMenu.Size = new Size(104, 25);
            dataMenu.Text = "Данные";
            // 
            // usersMenuItem
            // 
            usersMenuItem.Name = "usersMenuItem";
            usersMenuItem.Size = new Size(191, 26);
            usersMenuItem.Text = "Пользователи";
            usersMenuItem.Visible = false;
            usersMenuItem.Click += UsersMenuItem_Click;
            // 
            // groupsMenuItem
            // 
            groupsMenuItem.Name = "groupsMenuItem";
            groupsMenuItem.Size = new Size(191, 26);
            groupsMenuItem.Text = "Группы";
            groupsMenuItem.Click += GroupsMenuItem_Click;
            // 
            // boxesMenuItem
            // 
            boxesMenuItem.Name = "boxesMenuItem";
            boxesMenuItem.Size = new Size(191, 26);
            boxesMenuItem.Text = "Коробки";
            boxesMenuItem.Click += BoxesMenuItem_Click;
            // 
            // studentDataMenu
            // 
            studentDataMenu.DropDownItems.AddRange(new ToolStripItem[] { StudentMenuItem, PersFilesMenuItem, DelPersFilesMenuItem, DocumentsMenuItem, DelDocumentsMenuItem });
            studentDataMenu.Image = (Image)resources.GetObject("studentDataMenu.Image");
            studentDataMenu.Name = "studentDataMenu";
            studentDataMenu.Size = new Size(120, 25);
            studentDataMenu.Text = "Студенты";
            // 
            // StudentMenuItem
            // 
            StudentMenuItem.Name = "StudentMenuItem";
            StudentMenuItem.Size = new Size(270, 26);
            StudentMenuItem.Text = "Студенты";
            StudentMenuItem.Click += StudentMenuItem_Click;
            // 
            // PersFilesMenuItem
            // 
            PersFilesMenuItem.Name = "PersFilesMenuItem";
            PersFilesMenuItem.Size = new Size(270, 26);
            PersFilesMenuItem.Text = "Персональные файлы";
            PersFilesMenuItem.Click += PersFilesMenuItem_Click;
            // 
            // DelPersFilesMenuItem
            // 
            DelPersFilesMenuItem.Name = "DelPersFilesMenuItem";
            DelPersFilesMenuItem.Size = new Size(270, 26);
            DelPersFilesMenuItem.Text = "Удаленные перс. файлы";
            DelPersFilesMenuItem.Click += DelPersFilesMenuItem_Click;
            // 
            // DocumentsMenuItem
            // 
            DocumentsMenuItem.Name = "DocumentsMenuItem";
            DocumentsMenuItem.Size = new Size(270, 26);
            DocumentsMenuItem.Text = "Документы работ";
            DocumentsMenuItem.Click += DocumentsMenuItem_Click;
            // 
            // DelDocumentsMenuItem
            // 
            DelDocumentsMenuItem.Name = "DelDocumentsMenuItem";
            DelDocumentsMenuItem.Size = new Size(270, 26);
            DelDocumentsMenuItem.Text = "Удаленные док. работ";
            DelDocumentsMenuItem.Click += DelDocumentsMenuItem_Click;
            // 
            // guideMenu
            // 
            guideMenu.DropDownItems.AddRange(new ToolStripItem[] { DocumentTypesMenuItem });
            guideMenu.Image = (Image)resources.GetObject("guideMenu.Image");
            guideMenu.Name = "guideMenu";
            guideMenu.Size = new Size(141, 25);
            guideMenu.Text = "Справочник";
            // 
            // DocumentTypesMenuItem
            // 
            DocumentTypesMenuItem.Name = "DocumentTypesMenuItem";
            DocumentTypesMenuItem.Size = new Size(225, 26);
            DocumentTypesMenuItem.Text = "Типы документов";
            DocumentTypesMenuItem.Click += DocumentTypesMenuItem_Click;
            // 
            // printMenu
            // 
            printMenu.DropDownItems.AddRange(new ToolStripItem[] { printAllPersFiles });
            printMenu.Image = (Image)resources.GetObject("printMenu.Image");
            printMenu.Name = "printMenu";
            printMenu.Size = new Size(98, 25);
            printMenu.Text = "Печать";
            // 
            // printAllPersFiles
            // 
            printAllPersFiles.Name = "printAllPersFiles";
            printAllPersFiles.Size = new Size(364, 26);
            printAllPersFiles.Text = "Получить все данные по студентам";
            printAllPersFiles.Click += printAllPersFiles_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(100, 200, 200, 200);
            statusStrip.Font = new Font("Times New Roman", 13.8F);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 574);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 26);
            statusStrip.TabIndex = 1;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(129, 21);
            statusLabel.Text = "Готов к работе";
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            grid.BackgroundColor = Color.Wheat;
            grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.ContextMenuStrip = contextMenu;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 13.8F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            grid.DefaultCellStyle = dataGridViewCellStyle1;
            grid.Location = new Point(12, 79);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ShowRowErrors = false;
            grid.Size = new Size(776, 446);
            grid.TabIndex = 2;
            grid.Visible = false;
            grid.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // contextMenu
            // 
            contextMenu.Font = new Font("Times New Roman", 13.8F);
            contextMenu.ImageScalingSize = new Size(20, 20);
            contextMenu.Items.AddRange(new ToolStripItem[] { contextAddItem, contextEditItem, contextDeleteItem, contextFilterItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(203, 108);
            // 
            // contextAddItem
            // 
            contextAddItem.Enabled = false;
            contextAddItem.Image = (Image)resources.GetObject("contextAddItem.Image");
            contextAddItem.Name = "contextAddItem";
            contextAddItem.Size = new Size(202, 26);
            contextAddItem.Text = "Добавить";
            contextAddItem.Click += BtnAdd_Click;
            // 
            // contextEditItem
            // 
            contextEditItem.Enabled = false;
            contextEditItem.Image = (Image)resources.GetObject("contextEditItem.Image");
            contextEditItem.Name = "contextEditItem";
            contextEditItem.Size = new Size(202, 26);
            contextEditItem.Text = "Редактировать";
            contextEditItem.Click += BtnEdit_Click;
            // 
            // contextDeleteItem
            // 
            contextDeleteItem.Enabled = false;
            contextDeleteItem.Image = (Image)resources.GetObject("contextDeleteItem.Image");
            contextDeleteItem.Name = "contextDeleteItem";
            contextDeleteItem.Size = new Size(202, 26);
            contextDeleteItem.Text = "Удалить";
            contextDeleteItem.Click += BtnDelete_Click;
            // 
            // contextFilterItem
            // 
            contextFilterItem.Enabled = false;
            contextFilterItem.Image = (Image)resources.GetObject("contextFilterItem.Image");
            contextFilterItem.Name = "contextFilterItem";
            contextFilterItem.Size = new Size(202, 26);
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
            lblSearch.Location = new Point(12, 44);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(65, 21);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Поиск:";
            // 
            // searchEngine
            // 
            searchEngine.BackColor = Color.Wheat;
            searchEngine.Location = new Point(83, 41);
            searchEngine.Margin = new Padding(0);
            searchEngine.Name = "searchEngine";
            searchEngine.PlaceholderText = "Search";
            searchEngine.Size = new Size(326, 29);
            searchEngine.TabIndex = 9;
            searchEngine.TextChanged += searchEngine_TextChanged;
            // 
            // MainForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 600);
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
        private ToolStripMenuItem printAllPersFiles;
    }
}
