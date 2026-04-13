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
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            grid = new DataGridView();
            contextMenu = new ContextMenuStrip(components);
            contextAddItem = new ToolStripMenuItem();
            contextEditItem = new ToolStripMenuItem();
            contextDeleteItem = new ToolStripMenuItem();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            searchEngine = new TextBox();
            contextFilterItem = new ToolStripMenuItem();
            mainMenu.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Font = new Font("Times New Roman", 13.8F);
            mainMenu.ImageScalingSize = new Size(20, 20);
            mainMenu.Items.AddRange(new ToolStripItem[] { fileMenu, dataMenu, studentDataMenu, guideMenu });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(800, 34);
            mainMenu.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { exitMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(77, 30);
            fileMenu.Text = "Файл";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(160, 30);
            exitMenuItem.Text = "Выход";
            exitMenuItem.Click += ExitMenuItem_Click;
            // 
            // dataMenu
            // 
            dataMenu.DropDownItems.AddRange(new ToolStripItem[] { usersMenuItem, groupsMenuItem, boxesMenuItem });
            dataMenu.Name = "dataMenu";
            dataMenu.Size = new Size(101, 30);
            dataMenu.Text = "Данные";
            // 
            // usersMenuItem
            // 
            usersMenuItem.Name = "usersMenuItem";
            usersMenuItem.Size = new Size(230, 30);
            usersMenuItem.Text = "Пользователи";
            usersMenuItem.Visible = false;
            usersMenuItem.Click += UsersMenuItem_Click;
            // 
            // groupsMenuItem
            // 
            groupsMenuItem.Name = "groupsMenuItem";
            groupsMenuItem.Size = new Size(230, 30);
            groupsMenuItem.Text = "Группы";
            groupsMenuItem.Click += GroupsMenuItem_Click;
            // 
            // boxesMenuItem
            // 
            boxesMenuItem.Name = "boxesMenuItem";
            boxesMenuItem.Size = new Size(230, 30);
            boxesMenuItem.Text = "Коробки";
            boxesMenuItem.Click += BoxesMenuItem_Click;
            // 
            // studentDataMenu
            // 
            studentDataMenu.DropDownItems.AddRange(new ToolStripItem[] { StudentMenuItem, PersFilesMenuItem, DelPersFilesMenuItem, DocumentsMenuItem, DelDocumentsMenuItem });
            studentDataMenu.Name = "studentDataMenu";
            studentDataMenu.Size = new Size(120, 30);
            studentDataMenu.Text = "Студенты";
            // 
            // StudentMenuItem
            // 
            StudentMenuItem.Name = "StudentMenuItem";
            StudentMenuItem.Size = new Size(328, 30);
            StudentMenuItem.Text = "Студенты";
            StudentMenuItem.Click += StudentMenuItem_Click;
            // 
            // PersFilesMenuItem
            // 
            PersFilesMenuItem.Name = "PersFilesMenuItem";
            PersFilesMenuItem.Size = new Size(328, 30);
            PersFilesMenuItem.Text = "Персональные файлы";
            PersFilesMenuItem.Click += PersFilesMenuItem_Click;
            // 
            // DelPersFilesMenuItem
            // 
            DelPersFilesMenuItem.Name = "DelPersFilesMenuItem";
            DelPersFilesMenuItem.Size = new Size(328, 30);
            DelPersFilesMenuItem.Text = "Удаленные перс. файлы";
            DelPersFilesMenuItem.Click += DelPersFilesMenuItem_Click;
            // 
            // DocumentsMenuItem
            // 
            DocumentsMenuItem.Name = "DocumentsMenuItem";
            DocumentsMenuItem.Size = new Size(328, 30);
            DocumentsMenuItem.Text = "Документы работ";
            DocumentsMenuItem.Click += DocumentsMenuItem_Click;
            // 
            // DelDocumentsMenuItem
            // 
            DelDocumentsMenuItem.Name = "DelDocumentsMenuItem";
            DelDocumentsMenuItem.Size = new Size(328, 30);
            DelDocumentsMenuItem.Text = "Удаленные док. работ";
            DelDocumentsMenuItem.Click += DelDocumentsMenuItem_Click;
            // 
            // guideMenu
            // 
            guideMenu.DropDownItems.AddRange(new ToolStripItem[] { DocumentTypesMenuItem });
            guideMenu.Name = "guideMenu";
            guideMenu.Size = new Size(144, 30);
            guideMenu.Text = "Справочник";
            // 
            // DocumentTypesMenuItem
            // 
            DocumentTypesMenuItem.Name = "DocumentTypesMenuItem";
            DocumentTypesMenuItem.Size = new Size(272, 30);
            DocumentTypesMenuItem.Text = "Типы документов";
            DocumentTypesMenuItem.Click += DocumentTypesMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Font = new Font("Times New Roman", 13.8F);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
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
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
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
            grid.Location = new Point(12, 125);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ShowRowErrors = false;
            grid.Size = new Size(776, 400);
            grid.TabIndex = 2;
            grid.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // contextMenu
            // 
            contextMenu.Font = new Font("Times New Roman", 13.8F);
            contextMenu.ImageScalingSize = new Size(20, 20);
            contextMenu.Items.AddRange(new ToolStripItem[] { contextAddItem, contextEditItem, contextDeleteItem, contextFilterItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(227, 152);
            // 
            // contextAddItem
            // 
            contextAddItem.Enabled = false;
            contextAddItem.Name = "contextAddItem";
            contextAddItem.Size = new Size(226, 30);
            contextAddItem.Text = "Добавить";
            contextAddItem.Click += BtnAdd_Click;
            // 
            // contextEditItem
            // 
            contextEditItem.Enabled = false;
            contextEditItem.Name = "contextEditItem";
            contextEditItem.Size = new Size(226, 30);
            contextEditItem.Text = "Редактировать";
            contextEditItem.Click += BtnEdit_Click;
            // 
            // contextDeleteItem
            // 
            contextDeleteItem.Enabled = false;
            contextDeleteItem.Name = "contextDeleteItem";
            contextDeleteItem.Size = new Size(226, 30);
            contextDeleteItem.Text = "Удалить";
            contextDeleteItem.Click += BtnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Enabled = false;
            btnAdd.Location = new Point(397, 533);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 36);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.AutoSize = true;
            btnEdit.Enabled = false;
            btnEdit.Location = new Point(518, 533);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(164, 36);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Редактировать";
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(688, 533);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 36);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить";
            btnDelete.Click += BtnDelete_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 74);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 26);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Поиск:";
            // 
            // searchEngine
            // 
            searchEngine.Location = new Point(107, 71);
            searchEngine.Name = "searchEngine";
            searchEngine.Size = new Size(205, 34);
            searchEngine.TabIndex = 9;
            searchEngine.TextChanged += searchEngine_TextChanged;
            // 
            // contextFilterItem
            // 
            contextFilterItem.Enabled = false;
            contextFilterItem.Name = "contextFilterItem";
            contextFilterItem.Size = new Size(226, 30);
            contextFilterItem.Text = "Фильтр";
            // 
            // MainForm
            // 
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
    }
}
