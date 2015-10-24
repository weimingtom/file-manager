﻿namespace homework
{
    partial class DocumentManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("All Documents");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Recently Added");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Recently Read");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Favorites");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Author(s)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Unsorted");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Folder3");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Folder2", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Folder4");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Custom Directories", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutDocumentManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSimpleSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.buttonSimpleSearch = new System.Windows.Forms.Button();
            this.buttonCreateFolder = new System.Windows.Forms.Button();
            this.treeViewDirs = new System.Windows.Forms.TreeView();
            this.listViewDocs = new System.Windows.Forms.ListView();
            this.favorite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.added = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.doi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAdvancedSearch = new System.Windows.Forms.Button();
            this.Notes = new System.Windows.Forms.TabPage();
            this.Details = new System.Windows.Forms.TabPage();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.labelTags = new System.Windows.Forms.Label();
            this.checkBoxFavourite = new System.Windows.Forms.CheckBox();
            this.buttonMove = new System.Windows.Forms.Button();
            this.labelFavorite = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelAdded = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxDOI = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelDOI = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonAddDictionary = new System.Windows.Forms.Button();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.contextMenuStripDocList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPathValue = new System.Windows.Forms.Label();
            this.labelAddedValue = new System.Windows.Forms.Label();
            this.labelSizeValue = new System.Windows.Forms.Label();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.Notes.SuspendLayout();
            this.Details.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.contextMenuStripDocList.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.addDictionaryToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addFileToolStripMenuItem.Text = "Add File";
            // 
            // addDictionaryToolStripMenuItem
            // 
            this.addDictionaryToolStripMenuItem.Name = "addDictionaryToolStripMenuItem";
            this.addDictionaryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addDictionaryToolStripMenuItem.Text = "Add Dictionary";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(982, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutDocumentManagerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutDocumentManagerToolStripMenuItem
            // 
            this.aboutDocumentManagerToolStripMenuItem.Name = "aboutDocumentManagerToolStripMenuItem";
            this.aboutDocumentManagerToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.aboutDocumentManagerToolStripMenuItem.Text = "About Document Manager";
            // 
            // textBoxSimpleSearch
            // 
            this.textBoxSimpleSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSimpleSearch.Location = new System.Drawing.Point(682, 26);
            this.textBoxSimpleSearch.Name = "textBoxSimpleSearch";
            this.textBoxSimpleSearch.Size = new System.Drawing.Size(132, 20);
            this.textBoxSimpleSearch.TabIndex = 2;
            // 
            // labelSearch
            // 
            this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(598, 30);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(78, 13);
            this.labelSearch.TabIndex = 3;
            this.labelSearch.Text = "Simple Search:";
            // 
            // buttonSimpleSearch
            // 
            this.buttonSimpleSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSimpleSearch.Location = new System.Drawing.Point(820, 25);
            this.buttonSimpleSearch.Name = "buttonSimpleSearch";
            this.buttonSimpleSearch.Size = new System.Drawing.Size(31, 23);
            this.buttonSimpleSearch.TabIndex = 4;
            this.buttonSimpleSearch.Text = "OK";
            this.buttonSimpleSearch.UseVisualStyleBackColor = true;
            // 
            // buttonCreateFolder
            // 
            this.buttonCreateFolder.Location = new System.Drawing.Point(12, 54);
            this.buttonCreateFolder.Name = "buttonCreateFolder";
            this.buttonCreateFolder.Size = new System.Drawing.Size(93, 23);
            this.buttonCreateFolder.TabIndex = 4;
            this.buttonCreateFolder.Text = "Create Folder";
            this.buttonCreateFolder.UseVisualStyleBackColor = true;
            // 
            // treeViewDirs
            // 
            this.treeViewDirs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewDirs.HideSelection = false;
            this.treeViewDirs.Location = new System.Drawing.Point(12, 86);
            this.treeViewDirs.Name = "treeViewDirs";
            treeNode1.Name = "AllDocuments";
            treeNode1.Text = "All Documents";
            treeNode2.Name = "RecentlyAdded";
            treeNode2.Text = "Recently Added";
            treeNode3.Name = "RecentlyRead";
            treeNode3.Text = "Recently Read";
            treeNode4.Name = "Favorites";
            treeNode4.Text = "Favorites";
            treeNode5.Name = "Authors";
            treeNode5.Text = "Author(s)";
            treeNode6.Name = "Unsorted";
            treeNode6.Text = "Unsorted";
            treeNode7.Name = "Folder3";
            treeNode7.Text = "Folder3";
            treeNode8.Name = "Folder2";
            treeNode8.Text = "Folder2";
            treeNode9.Name = "Folder4";
            treeNode9.Text = "Folder4";
            treeNode10.Name = "CustomDirs";
            treeNode10.Text = "Custom Directories";
            this.treeViewDirs.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode10});
            this.treeViewDirs.Size = new System.Drawing.Size(208, 377);
            this.treeViewDirs.TabIndex = 1;
            this.treeViewDirs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDirs_AfterSelect);
            // 
            // listViewDocs
            // 
            this.listViewDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDocs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.favorite,
            this.type,
            this.title,
            this.author,
            this.year,
            this.doi,
            this.added});
            this.listViewDocs.FullRowSelect = true;
            this.listViewDocs.Location = new System.Drawing.Point(229, 49);
            this.listViewDocs.Name = "listViewDocs";
            this.listViewDocs.Size = new System.Drawing.Size(441, 414);
            this.listViewDocs.TabIndex = 1;
            this.listViewDocs.UseCompatibleStateImageBehavior = false;
            this.listViewDocs.View = System.Windows.Forms.View.Details;
            this.listViewDocs.Click += new System.EventHandler(this.listViewDocs_Click);
            this.listViewDocs.DoubleClick += new System.EventHandler(this.listViewDocs_DoubleClick);
            this.listViewDocs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDocs_MouseClick);
            // 
            // favorite
            // 
            this.favorite.Text = "Favorite";
            // 
            // type
            // 
            this.type.Text = "Type";
            // 
            // title
            // 
            this.title.Text = "Title";
            // 
            // author
            // 
            this.author.Text = "Author(s)";
            // 
            // year
            // 
            this.year.Text = "Year";
            // 
            // added
            // 
            this.added.Text = "Added";
            // 
            // doi
            // 
            this.doi.Text = "DOI";
            // 
            // buttonAdvancedSearch
            // 
            this.buttonAdvancedSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdvancedSearch.Location = new System.Drawing.Point(857, 24);
            this.buttonAdvancedSearch.Name = "buttonAdvancedSearch";
            this.buttonAdvancedSearch.Size = new System.Drawing.Size(113, 23);
            this.buttonAdvancedSearch.TabIndex = 8;
            this.buttonAdvancedSearch.Text = "Advanced Search";
            this.buttonAdvancedSearch.UseVisualStyleBackColor = true;
            // 
            // Notes
            // 
            this.Notes.Controls.Add(this.textBoxNotes);
            this.Notes.Location = new System.Drawing.Point(4, 22);
            this.Notes.Name = "Notes";
            this.Notes.Padding = new System.Windows.Forms.Padding(3);
            this.Notes.Size = new System.Drawing.Size(290, 385);
            this.Notes.TabIndex = 1;
            this.Notes.Text = "Notes";
            this.Notes.UseVisualStyleBackColor = true;
            // 
            // Details
            // 
            this.Details.Controls.Add(this.labelSizeValue);
            this.Details.Controls.Add(this.labelAddedValue);
            this.Details.Controls.Add(this.labelPathValue);
            this.Details.Controls.Add(this.textBoxTags);
            this.Details.Controls.Add(this.labelTags);
            this.Details.Controls.Add(this.checkBoxFavourite);
            this.Details.Controls.Add(this.buttonMove);
            this.Details.Controls.Add(this.labelFavorite);
            this.Details.Controls.Add(this.labelSize);
            this.Details.Controls.Add(this.labelPath);
            this.Details.Controls.Add(this.labelAdded);
            this.Details.Controls.Add(this.buttonEdit);
            this.Details.Controls.Add(this.textBoxDOI);
            this.Details.Controls.Add(this.textBoxYear);
            this.Details.Controls.Add(this.textBoxAuthor);
            this.Details.Controls.Add(this.textBoxTitle);
            this.Details.Controls.Add(this.labelDOI);
            this.Details.Controls.Add(this.labelYear);
            this.Details.Controls.Add(this.labelAuthor);
            this.Details.Controls.Add(this.labelTitle);
            this.Details.Location = new System.Drawing.Point(4, 22);
            this.Details.Name = "Details";
            this.Details.Padding = new System.Windows.Forms.Padding(3);
            this.Details.Size = new System.Drawing.Size(286, 388);
            this.Details.TabIndex = 0;
            this.Details.Text = "Details";
            this.Details.UseVisualStyleBackColor = true;
            // 
            // textBoxTags
            // 
            this.textBoxTags.Location = new System.Drawing.Point(67, 134);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.ReadOnly = true;
            this.textBoxTags.Size = new System.Drawing.Size(207, 20);
            this.textBoxTags.TabIndex = 24;
            // 
            // labelTags
            // 
            this.labelTags.AutoSize = true;
            this.labelTags.Location = new System.Drawing.Point(6, 137);
            this.labelTags.Name = "labelTags";
            this.labelTags.Size = new System.Drawing.Size(34, 13);
            this.labelTags.TabIndex = 23;
            this.labelTags.Text = "Tags:";
            // 
            // checkBoxFavourite
            // 
            this.checkBoxFavourite.AutoSize = true;
            this.checkBoxFavourite.Enabled = false;
            this.checkBoxFavourite.Location = new System.Drawing.Point(67, 253);
            this.checkBoxFavourite.Name = "checkBoxFavourite";
            this.checkBoxFavourite.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFavourite.TabIndex = 22;
            this.checkBoxFavourite.UseVisualStyleBackColor = true;
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(134, 296);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 21;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            // 
            // labelFavorite
            // 
            this.labelFavorite.AutoSize = true;
            this.labelFavorite.Location = new System.Drawing.Point(6, 253);
            this.labelFavorite.Name = "labelFavorite";
            this.labelFavorite.Size = new System.Drawing.Size(48, 13);
            this.labelFavorite.TabIndex = 20;
            this.labelFavorite.Text = "Favorite:";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(6, 166);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(30, 13);
            this.labelSize.TabIndex = 19;
            this.labelSize.Text = "Size:";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(6, 224);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(35, 13);
            this.labelPath.TabIndex = 18;
            this.labelPath.Text = "Path: ";
            // 
            // labelAdded
            // 
            this.labelAdded.AutoSize = true;
            this.labelAdded.Location = new System.Drawing.Point(6, 195);
            this.labelAdded.Name = "labelAdded";
            this.labelAdded.Size = new System.Drawing.Size(41, 13);
            this.labelAdded.TabIndex = 17;
            this.labelAdded.Text = "Added:";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(43, 296);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 16;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // textBoxDOI
            // 
            this.textBoxDOI.Location = new System.Drawing.Point(67, 105);
            this.textBoxDOI.Name = "textBoxDOI";
            this.textBoxDOI.ReadOnly = true;
            this.textBoxDOI.Size = new System.Drawing.Size(207, 20);
            this.textBoxDOI.TabIndex = 11;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(67, 76);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.ReadOnly = true;
            this.textBoxYear.Size = new System.Drawing.Size(207, 20);
            this.textBoxYear.TabIndex = 9;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(67, 47);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.ReadOnly = true;
            this.textBoxAuthor.Size = new System.Drawing.Size(207, 20);
            this.textBoxAuthor.TabIndex = 8;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(67, 18);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(207, 20);
            this.textBoxTitle.TabIndex = 7;
            // 
            // labelDOI
            // 
            this.labelDOI.AutoSize = true;
            this.labelDOI.Location = new System.Drawing.Point(6, 108);
            this.labelDOI.Name = "labelDOI";
            this.labelDOI.Size = new System.Drawing.Size(29, 13);
            this.labelDOI.TabIndex = 5;
            this.labelDOI.Text = "DOI:";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(6, 79);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(35, 13);
            this.labelYear.TabIndex = 3;
            this.labelYear.Text = "Year: ";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(6, 50);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(55, 13);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Author(s): ";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(6, 21);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(33, 13);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Title: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Details);
            this.tabControl1.Controls.Add(this.Notes);
            this.tabControl1.Location = new System.Drawing.Point(676, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(294, 414);
            this.tabControl1.TabIndex = 1;
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(12, 25);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(93, 23);
            this.buttonAddFile.TabIndex = 9;
            this.buttonAddFile.Text = "Add File";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonAddDictionary
            // 
            this.buttonAddDictionary.Location = new System.Drawing.Point(111, 25);
            this.buttonAddDictionary.Name = "buttonAddDictionary";
            this.buttonAddDictionary.Size = new System.Drawing.Size(90, 23);
            this.buttonAddDictionary.TabIndex = 10;
            this.buttonAddDictionary.Text = "Add Dictionary";
            this.buttonAddDictionary.UseVisualStyleBackColor = true;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(6, 6);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNotes.Size = new System.Drawing.Size(278, 373);
            this.textBoxNotes.TabIndex = 0;
            // 
            // contextMenuStripDocList
            // 
            this.contextMenuStripDocList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripDocList.Name = "contextMenuStripDocList";
            this.contextMenuStripDocList.Size = new System.Drawing.Size(118, 70);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.moveToolStripMenuItem.Text = "Move";
            // 
            // labelPathValue
            // 
            this.labelPathValue.AutoSize = true;
            this.labelPathValue.Location = new System.Drawing.Point(64, 224);
            this.labelPathValue.Name = "labelPathValue";
            this.labelPathValue.Size = new System.Drawing.Size(0, 13);
            this.labelPathValue.TabIndex = 25;
            // 
            // labelAddedValue
            // 
            this.labelAddedValue.AutoSize = true;
            this.labelAddedValue.Location = new System.Drawing.Point(64, 195);
            this.labelAddedValue.Name = "labelAddedValue";
            this.labelAddedValue.Size = new System.Drawing.Size(0, 13);
            this.labelAddedValue.TabIndex = 26;
            // 
            // labelSizeValue
            // 
            this.labelSizeValue.AutoSize = true;
            this.labelSizeValue.Location = new System.Drawing.Point(64, 166);
            this.labelSizeValue.Name = "labelSizeValue";
            this.labelSizeValue.Size = new System.Drawing.Size(0, 13);
            this.labelSizeValue.TabIndex = 27;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // DocumentManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 473);
            this.Controls.Add(this.listViewDocs);
            this.Controls.Add(this.buttonCreateFolder);
            this.Controls.Add(this.treeViewDirs);
            this.Controls.Add(this.buttonAddDictionary);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.buttonAdvancedSearch);
            this.Controls.Add(this.buttonSimpleSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.textBoxSimpleSearch);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(998, 511);
            this.Name = "DocumentManager";
            this.Text = "DocumentManager";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.Notes.ResumeLayout(false);
            this.Notes.PerformLayout();
            this.Details.ResumeLayout(false);
            this.Details.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStripDocList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDictionaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.TextBox textBoxSimpleSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonSimpleSearch;
        private System.Windows.Forms.ListView listViewDocs;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.TreeView treeViewDirs;
        private System.Windows.Forms.ColumnHeader author;
        private System.Windows.Forms.ColumnHeader year;
        private System.Windows.Forms.ColumnHeader added;
        private System.Windows.Forms.ColumnHeader doi;
        private System.Windows.Forms.Button buttonCreateFolder;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.Button buttonAdvancedSearch;
        private System.Windows.Forms.TabPage Notes;
        private System.Windows.Forms.TabPage Details;
        private System.Windows.Forms.CheckBox checkBoxFavourite;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Label labelFavorite;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelAdded;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxDOI;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelDOI;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label labelTags;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonAddDictionary;
        private System.Windows.Forms.ColumnHeader favorite;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutDocumentManagerToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDocList;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.Label labelSizeValue;
        private System.Windows.Forms.Label labelAddedValue;
        private System.Windows.Forms.Label labelPathValue;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}
