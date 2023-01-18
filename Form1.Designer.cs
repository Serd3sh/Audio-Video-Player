namespace AudioVideoPlayer
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.TopMenu = new System.Windows.Forms.MenuStrip();
			this.MenuFileSection = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadFilesButton = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuQueueSection = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearQueueButton = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuHistorySection = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearHistoryButton = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.QueueBox = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.QueueList = new System.Windows.Forms.CheckedListBox();
			this.ContextMenu_Queue = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MoveUpSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.MoveDownSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.QueueDeselectSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.QueueSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.HistoryList = new System.Windows.Forms.CheckedListBox();
			this.ContextMenu_History = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.LoadToQueueSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.HistoryDeselectSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.HistorySelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.VideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.CurrentPlay = new System.Windows.Forms.Label();
			this.PlayButton = new System.Windows.Forms.Button();
			this.PreviousButton = new System.Windows.Forms.Button();
			this.BackRewindButton = new System.Windows.Forms.Button();
			this.FrontRewindButton = new System.Windows.Forms.Button();
			this.NextButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.VolumeLabel = new System.Windows.Forms.Label();
			this.VolumeInput = new System.Windows.Forms.TextBox();
			this.TopMenu.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.QueueBox.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.ContextMenu_Queue.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.ContextMenu_History.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// TopMenu
			// 
			this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileSection,
            this.MenuQueueSection,
            this.MenuHistorySection});
			this.TopMenu.Location = new System.Drawing.Point(0, 0);
			this.TopMenu.Name = "TopMenu";
			this.TopMenu.Size = new System.Drawing.Size(884, 24);
			this.TopMenu.TabIndex = 0;
			this.TopMenu.Text = "menuStrip1";
			// 
			// MenuFileSection
			// 
			this.MenuFileSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFilesButton});
			this.MenuFileSection.Name = "MenuFileSection";
			this.MenuFileSection.Size = new System.Drawing.Size(48, 20);
			this.MenuFileSection.Text = "Файл";
			// 
			// LoadFilesButton
			// 
			this.LoadFilesButton.Name = "LoadFilesButton";
			this.LoadFilesButton.Size = new System.Drawing.Size(194, 22);
			this.LoadFilesButton.Text = "Загрузить в очередь...";
			// 
			// MenuQueueSection
			// 
			this.MenuQueueSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearQueueButton});
			this.MenuQueueSection.Name = "MenuQueueSection";
			this.MenuQueueSection.Size = new System.Drawing.Size(66, 20);
			this.MenuQueueSection.Text = "Очередь";
			// 
			// ClearQueueButton
			// 
			this.ClearQueueButton.Name = "ClearQueueButton";
			this.ClearQueueButton.Size = new System.Drawing.Size(126, 22);
			this.ClearQueueButton.Text = "Очистить";
			// 
			// MenuHistorySection
			// 
			this.MenuHistorySection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearHistoryButton});
			this.MenuHistorySection.Name = "MenuHistorySection";
			this.MenuHistorySection.Size = new System.Drawing.Size(66, 20);
			this.MenuHistorySection.Text = "История";
			// 
			// ClearHistoryButton
			// 
			this.ClearHistoryButton.Name = "ClearHistoryButton";
			this.ClearHistoryButton.Size = new System.Drawing.Size(126, 22);
			this.ClearHistoryButton.Text = "Очистить";
			// 
			// OpenFile
			// 
			this.OpenFile.Filter = "Медиа|*.wav;*.mp3;*midi;*.ogg;*.avi;*.mpeg;*.wmv;*.mov;*.webm;*.mp4|Аудио|*.wav;*" +
    ".mp3;*midi;*.ogg|Видео|*.avi;*.mpeg;*.wmv;*.mov;*.webm;*.mp4";
			this.OpenFile.Multiselect = true;
			this.OpenFile.SupportMultiDottedExtensions = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.Controls.Add(this.QueueBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 437);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// QueueBox
			// 
			this.QueueBox.Controls.Add(this.tabControl1);
			this.QueueBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.QueueBox.Location = new System.Drawing.Point(621, 3);
			this.QueueBox.Name = "QueueBox";
			this.QueueBox.Size = new System.Drawing.Size(260, 431);
			this.QueueBox.TabIndex = 0;
			this.QueueBox.TabStop = false;
			this.QueueBox.Text = "Списки";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(254, 412);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.QueueList);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(246, 386);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Очередь";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// QueueList
			// 
			this.QueueList.CheckOnClick = true;
			this.QueueList.ContextMenuStrip = this.ContextMenu_Queue;
			this.QueueList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.QueueList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
			this.QueueList.Location = new System.Drawing.Point(3, 3);
			this.QueueList.Name = "QueueList";
			this.QueueList.ScrollAlwaysVisible = true;
			this.QueueList.Size = new System.Drawing.Size(240, 380);
			this.QueueList.TabIndex = 0;
			// 
			// ContextMenu_Queue
			// 
			this.ContextMenu_Queue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoveUpSelected,
            this.MoveDownSelected,
            this.QueueDeselectSelected,
            this.QueueSelectAll});
			this.ContextMenu_Queue.Name = "ContextMenu_Queue";
			this.ContextMenu_Queue.Size = new System.Drawing.Size(192, 92);
			// 
			// MoveUpSelected
			// 
			this.MoveUpSelected.Name = "MoveUpSelected";
			this.MoveUpSelected.Size = new System.Drawing.Size(191, 22);
			this.MoveUpSelected.Text = "Поднять наверх";
			// 
			// MoveDownSelected
			// 
			this.MoveDownSelected.Name = "MoveDownSelected";
			this.MoveDownSelected.Size = new System.Drawing.Size(191, 22);
			this.MoveDownSelected.Text = "Спустить вниз";
			// 
			// QueueDeselectSelected
			// 
			this.QueueDeselectSelected.Name = "QueueDeselectSelected";
			this.QueueDeselectSelected.Size = new System.Drawing.Size(191, 22);
			this.QueueDeselectSelected.Text = "Отменить выделение";
			// 
			// QueueSelectAll
			// 
			this.QueueSelectAll.Name = "QueueSelectAll";
			this.QueueSelectAll.Size = new System.Drawing.Size(191, 22);
			this.QueueSelectAll.Text = "Выделить все";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.HistoryList);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(246, 386);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "История";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// HistoryList
			// 
			this.HistoryList.CheckOnClick = true;
			this.HistoryList.ContextMenuStrip = this.ContextMenu_History;
			this.HistoryList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HistoryList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
			this.HistoryList.Location = new System.Drawing.Point(3, 3);
			this.HistoryList.Name = "HistoryList";
			this.HistoryList.ScrollAlwaysVisible = true;
			this.HistoryList.Size = new System.Drawing.Size(240, 380);
			this.HistoryList.TabIndex = 1;
			// 
			// ContextMenu_History
			// 
			this.ContextMenu_History.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadToQueueSelected,
            this.HistoryDeselectSelected,
            this.HistorySelectAll});
			this.ContextMenu_History.Name = "ContextMenu_History";
			this.ContextMenu_History.Size = new System.Drawing.Size(251, 70);
			// 
			// LoadToQueueSelected
			// 
			this.LoadToQueueSelected.Name = "LoadToQueueSelected";
			this.LoadToQueueSelected.Size = new System.Drawing.Size(250, 22);
			this.LoadToQueueSelected.Text = "Загрузить выбранное в очередь";
			// 
			// HistoryDeselectSelected
			// 
			this.HistoryDeselectSelected.Name = "HistoryDeselectSelected";
			this.HistoryDeselectSelected.Size = new System.Drawing.Size(250, 22);
			this.HistoryDeselectSelected.Text = "Отменить выделение";
			// 
			// HistorySelectAll
			// 
			this.HistorySelectAll.Name = "HistorySelectAll";
			this.HistorySelectAll.Size = new System.Drawing.Size(250, 22);
			this.HistorySelectAll.Text = "Выделить все";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(612, 431);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.VideoPlayer);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(606, 325);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Видео плеер";
			// 
			// VideoPlayer
			// 
			this.VideoPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VideoPlayer.Enabled = true;
			this.VideoPlayer.Location = new System.Drawing.Point(3, 16);
			this.VideoPlayer.Name = "VideoPlayer";
			this.VideoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VideoPlayer.OcxState")));
			this.VideoPlayer.Size = new System.Drawing.Size(600, 306);
			this.VideoPlayer.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tableLayoutPanel3);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(3, 334);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(606, 94);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Аудио плеер";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 6;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel3.Controls.Add(this.CurrentPlay, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.PlayButton, 2, 1);
			this.tableLayoutPanel3.Controls.Add(this.PreviousButton, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.BackRewindButton, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.FrontRewindButton, 3, 1);
			this.tableLayoutPanel3.Controls.Add(this.NextButton, 4, 1);
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 5, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(600, 75);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// CurrentPlay
			// 
			this.CurrentPlay.AutoSize = true;
			this.tableLayoutPanel3.SetColumnSpan(this.CurrentPlay, 6);
			this.CurrentPlay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CurrentPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CurrentPlay.Location = new System.Drawing.Point(3, 0);
			this.CurrentPlay.Name = "CurrentPlay";
			this.CurrentPlay.Size = new System.Drawing.Size(594, 22);
			this.CurrentPlay.TabIndex = 2;
			this.CurrentPlay.Text = "/ Ничего /";
			this.CurrentPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CurrentPlay.Click += new System.EventHandler(this.CurrentPlay_Click);
			// 
			// PlayButton
			// 
			this.PlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlayButton.Location = new System.Drawing.Point(203, 27);
			this.PlayButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(94, 43);
			this.PlayButton.TabIndex = 1;
			this.PlayButton.Text = "Воспроизвести";
			this.PlayButton.UseVisualStyleBackColor = true;
			// 
			// PreviousButton
			// 
			this.PreviousButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PreviousButton.Location = new System.Drawing.Point(3, 27);
			this.PreviousButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.PreviousButton.Name = "PreviousButton";
			this.PreviousButton.Size = new System.Drawing.Size(94, 43);
			this.PreviousButton.TabIndex = 2;
			this.PreviousButton.Text = "Предыдущий файл";
			this.PreviousButton.UseVisualStyleBackColor = true;
			// 
			// BackRewindButton
			// 
			this.BackRewindButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BackRewindButton.Location = new System.Drawing.Point(103, 27);
			this.BackRewindButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.BackRewindButton.Name = "BackRewindButton";
			this.BackRewindButton.Size = new System.Drawing.Size(94, 43);
			this.BackRewindButton.TabIndex = 3;
			this.BackRewindButton.Text = "-5сек";
			this.BackRewindButton.UseVisualStyleBackColor = true;
			// 
			// FrontRewindButton
			// 
			this.FrontRewindButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FrontRewindButton.Location = new System.Drawing.Point(303, 27);
			this.FrontRewindButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.FrontRewindButton.Name = "FrontRewindButton";
			this.FrontRewindButton.Size = new System.Drawing.Size(94, 43);
			this.FrontRewindButton.TabIndex = 4;
			this.FrontRewindButton.Text = "+5сек";
			this.FrontRewindButton.UseVisualStyleBackColor = true;
			// 
			// NextButton
			// 
			this.NextButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NextButton.Location = new System.Drawing.Point(403, 27);
			this.NextButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(94, 43);
			this.NextButton.TabIndex = 5;
			this.NextButton.Text = "Следующий файл";
			this.NextButton.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Controls.Add(this.VolumeLabel, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.VolumeInput, 0, 1);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(503, 27);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(94, 43);
			this.tableLayoutPanel4.TabIndex = 6;
			// 
			// VolumeLabel
			// 
			this.VolumeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.VolumeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VolumeLabel.Location = new System.Drawing.Point(0, 0);
			this.VolumeLabel.Margin = new System.Windows.Forms.Padding(0);
			this.VolumeLabel.Name = "VolumeLabel";
			this.VolumeLabel.Size = new System.Drawing.Size(94, 21);
			this.VolumeLabel.TabIndex = 0;
			this.VolumeLabel.Text = "Звук(%)";
			this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// VolumeInput
			// 
			this.VolumeInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.VolumeInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VolumeInput.Location = new System.Drawing.Point(0, 21);
			this.VolumeInput.Margin = new System.Windows.Forms.Padding(0);
			this.VolumeInput.MaxLength = 3;
			this.VolumeInput.Name = "VolumeInput";
			this.VolumeInput.Size = new System.Drawing.Size(94, 20);
			this.VolumeInput.TabIndex = 1;
			this.VolumeInput.Text = "100";
			this.VolumeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 461);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.TopMenu);
			this.MainMenuStrip = this.TopMenu;
			this.MinimumSize = new System.Drawing.Size(750, 500);
			this.Name = "MainWindow";
			this.Text = "Плеер";
			this.TopMenu.ResumeLayout(false);
			this.TopMenu.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.QueueBox.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ContextMenu_Queue.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ContextMenu_History.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSection;
        private System.Windows.Forms.ToolStripMenuItem MenuQueueSection;
        private System.Windows.Forms.ToolStripMenuItem MenuHistorySection;
        public System.Windows.Forms.ToolStripMenuItem LoadFilesButton;
        public System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox QueueBox;
        public System.Windows.Forms.CheckedListBox QueueList;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label VolumeLabel;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.CheckedListBox HistoryList;
		private System.Windows.Forms.ContextMenuStrip ContextMenu_Queue;
		public System.Windows.Forms.ToolStripMenuItem MoveUpSelected;
		public System.Windows.Forms.ToolStripMenuItem MoveDownSelected;
		public AxWMPLib.AxWindowsMediaPlayer VideoPlayer;
		public System.Windows.Forms.Button PlayButton;
		public System.Windows.Forms.Button PreviousButton;
		public System.Windows.Forms.Button BackRewindButton;
		public System.Windows.Forms.Button FrontRewindButton;
		public System.Windows.Forms.Button NextButton;
		public System.Windows.Forms.TextBox VolumeInput;
		public System.Windows.Forms.Label CurrentPlay;
		public System.Windows.Forms.ToolStripMenuItem QueueDeselectSelected;
		public System.Windows.Forms.ToolStripMenuItem ClearQueueButton;
		public System.Windows.Forms.ToolStripMenuItem ClearHistoryButton;
		private System.Windows.Forms.ContextMenuStrip ContextMenu_History;
		public System.Windows.Forms.ToolStripMenuItem LoadToQueueSelected;
		public System.Windows.Forms.ToolStripMenuItem QueueSelectAll;
		public System.Windows.Forms.ToolStripMenuItem HistoryDeselectSelected;
		public System.Windows.Forms.ToolStripMenuItem HistorySelectAll;
	}
}

