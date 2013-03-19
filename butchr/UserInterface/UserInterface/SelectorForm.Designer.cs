namespace Matmaxx.Butchr.UserInterface
{
  partial class SelectorForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorForm));
      this.tscMain = new System.Windows.Forms.ToolStripContainer();
      this.splitHorizontal = new System.Windows.Forms.SplitContainer();
      this.importModule = new System.Windows.Forms.ListView();
      this.cmsImages = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.groupSelectedImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ungroupSelectedImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.splitVertical = new System.Windows.Forms.SplitContainer();
      this.tblLog = new XPTable.Models.Table();
      this.cmLog = new XPTable.Models.ColumnModel();
      this.tmLog = new XPTable.Models.TableModel();
      this.tblExif = new XPTable.Models.Table();
      this.cmExif = new XPTable.Models.ColumnModel();
      this.tmExif = new XPTable.Models.TableModel();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.tsInputModule = new System.Windows.Forms.ToolStrip();
      this.tsbImportModule = new System.Windows.Forms.ToolStripButton();
      this.tsbPublishModule = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbImport = new System.Windows.Forms.ToolStripButton();
      this.tsbAutogroupImages = new System.Windows.Forms.ToolStripButton();
      this.tsbDistribute = new System.Windows.Forms.ToolStripButton();
      this.tsbScratchbatch = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbGroupSelected = new System.Windows.Forms.ToolStripButton();
      this.tsbUngroupSelected = new System.Windows.Forms.ToolStripButton();
      this.tsbRemoveAllGroups = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbThumbSizeIncrease = new System.Windows.Forms.ToolStripButton();
      this.tsbThumbSizeDecrease = new System.Windows.Forms.ToolStripButton();
      this.tsbToggleLogVisibility = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.msMain = new System.Windows.Forms.MenuStrip();
      this.miFile = new System.Windows.Forms.ToolStripMenuItem();
      this.miImport = new System.Windows.Forms.ToolStripMenuItem();
      this.miDistribute = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.miScratchbatch = new System.Windows.Forms.ToolStripMenuItem();
      this.miExit = new System.Windows.Forms.ToolStripMenuItem();
      this.tsbAutogroup = new System.Windows.Forms.ToolStripMenuItem();
      this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.miGroupSelected = new System.Windows.Forms.ToolStripMenuItem();
      this.miUngroupSelected = new System.Windows.Forms.ToolStripMenuItem();
      this.miRemoveAllGroups = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.miRawFormat = new System.Windows.Forms.ToolStripMenuItem();
      this.tscbRawFormats = new System.Windows.Forms.ToolStripComboBox();
      this.miView = new System.Windows.Forms.ToolStripMenuItem();
      this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
      this.miDebugIncThumbSize = new System.Windows.Forms.ToolStripMenuItem();
      this.miDebugDecThumbSize = new System.Windows.Forms.ToolStripMenuItem();
      this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.miHelpContents = new System.Windows.Forms.ToolStripMenuItem();
      this.miHelpPhotomatixCommandline = new System.Windows.Forms.ToolStripMenuItem();
      this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.miHelpResetContextActivations = new System.Windows.Forms.ToolStripMenuItem();
      this.miDebug = new System.Windows.Forms.ToolStripMenuItem();
      this.fbdScratch = new System.Windows.Forms.FolderBrowserDialog();
      this.publishModule = new Matmaxx.Butchr.UserInterface.PublishControl();
      this.tscMain.ContentPanel.SuspendLayout();
      this.tscMain.TopToolStripPanel.SuspendLayout();
      this.tscMain.SuspendLayout();
      this.splitHorizontal.Panel1.SuspendLayout();
      this.splitHorizontal.Panel2.SuspendLayout();
      this.splitHorizontal.SuspendLayout();
      this.cmsImages.SuspendLayout();
      this.splitVertical.Panel1.SuspendLayout();
      this.splitVertical.Panel2.SuspendLayout();
      this.splitVertical.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tblLog)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tblExif)).BeginInit();
      this.tsInputModule.SuspendLayout();
      this.msMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // tscMain
      // 
      // 
      // tscMain.ContentPanel
      // 
      this.tscMain.ContentPanel.Controls.Add(this.splitHorizontal);
      resources.ApplyResources(this.tscMain.ContentPanel, "tscMain.ContentPanel");
      resources.ApplyResources(this.tscMain, "tscMain");
      this.tscMain.Name = "tscMain";
      // 
      // tscMain.TopToolStripPanel
      // 
      this.tscMain.TopToolStripPanel.Controls.Add(this.tsInputModule);
      // 
      // splitHorizontal
      // 
      this.splitHorizontal.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::Matmaxx.Butchr.Properties.Settings.Default, "SplitHorizontalDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      resources.ApplyResources(this.splitHorizontal, "splitHorizontal");
      this.splitHorizontal.Name = "splitHorizontal";
      // 
      // splitHorizontal.Panel1
      // 
      this.splitHorizontal.Panel1.Controls.Add(this.publishModule);
      this.splitHorizontal.Panel1.Controls.Add(this.importModule);
      // 
      // splitHorizontal.Panel2
      // 
      this.splitHorizontal.Panel2.Controls.Add(this.splitVertical);
      this.splitHorizontal.Panel2.Controls.Add(this.splitter1);
      this.splitHorizontal.SplitterDistance = global::Matmaxx.Butchr.Properties.Settings.Default.SplitHorizontalDistance;
      this.splitHorizontal.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitHorizontal_SplitterMoved);
      // 
      // importModule
      // 
      this.importModule.BackColor = System.Drawing.Color.Black;
      this.importModule.ContextMenuStrip = this.cmsImages;
      this.importModule.GridLines = true;
      resources.ApplyResources(this.importModule, "importModule");
      this.importModule.Name = "importModule";
      this.importModule.OwnerDraw = true;
      this.importModule.TileSize = new System.Drawing.Size(150, 150);
      this.importModule.UseCompatibleStateImageBehavior = false;
      this.importModule.View = System.Windows.Forms.View.Tile;
      this.importModule.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.list_DrawItem);
      this.importModule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.list_MouseUp);
      // 
      // cmsImages
      // 
      this.cmsImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupSelectedImagesToolStripMenuItem,
            this.ungroupSelectedImagesToolStripMenuItem});
      this.cmsImages.Name = "cmsImages";
      resources.ApplyResources(this.cmsImages, "cmsImages");
      // 
      // groupSelectedImagesToolStripMenuItem
      // 
      this.groupSelectedImagesToolStripMenuItem.Image = global::Matmaxx.Butchr.Properties.Resources.link;
      this.groupSelectedImagesToolStripMenuItem.Name = "groupSelectedImagesToolStripMenuItem";
      resources.ApplyResources(this.groupSelectedImagesToolStripMenuItem, "groupSelectedImagesToolStripMenuItem");
      this.groupSelectedImagesToolStripMenuItem.Click += new System.EventHandler(this.groupSelectedImagesToolStripMenuItem_Click);
      // 
      // ungroupSelectedImagesToolStripMenuItem
      // 
      this.ungroupSelectedImagesToolStripMenuItem.Image = global::Matmaxx.Butchr.Properties.Resources.link_break;
      this.ungroupSelectedImagesToolStripMenuItem.Name = "ungroupSelectedImagesToolStripMenuItem";
      resources.ApplyResources(this.ungroupSelectedImagesToolStripMenuItem, "ungroupSelectedImagesToolStripMenuItem");
      this.ungroupSelectedImagesToolStripMenuItem.Click += new System.EventHandler(this.ungroupSelectedImagesToolStripMenuItem_Click);
      // 
      // splitVertical
      // 
      resources.ApplyResources(this.splitVertical, "splitVertical");
      this.splitVertical.Name = "splitVertical";
      // 
      // splitVertical.Panel1
      // 
      this.splitVertical.Panel1.Controls.Add(this.tblLog);
      // 
      // splitVertical.Panel2
      // 
      this.splitVertical.Panel2.Controls.Add(this.tblExif);
      // 
      // tblLog
      // 
      this.tblLog.ColumnModel = this.cmLog;
      resources.ApplyResources(this.tblLog, "tblLog");
      this.tblLog.MinimumSize = new System.Drawing.Size(0, 300);
      this.tblLog.Name = "tblLog";
      this.tblLog.NoItemsText = "Some stupid log text";
      this.tblLog.TableModel = this.tmLog;
      // 
      // tblExif
      // 
      this.tblExif.AlternatingRowColor = System.Drawing.Color.WhiteSmoke;
      this.tblExif.ColumnModel = this.cmExif;
      this.tblExif.CustomEditKey = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                  | System.Windows.Forms.Keys.Shift)
                  | System.Windows.Forms.Keys.F5)));
      resources.ApplyResources(this.tblExif, "tblExif");
      this.tblExif.EditStartAction = XPTable.Editors.EditStartAction.CustomKey;
      this.tblExif.FullRowSelect = true;
      this.tblExif.GridLines = XPTable.Models.GridLines.Both;
      this.tblExif.Name = "tblExif";
      this.tblExif.NoItemsText = "Select a single image to display its exif data.";
      this.tblExif.TableModel = this.tmExif;
      // 
      // splitter1
      // 
      resources.ApplyResources(this.splitter1, "splitter1");
      this.splitter1.Name = "splitter1";
      this.splitter1.TabStop = false;
      // 
      // tsInputModule
      // 
      resources.ApplyResources(this.tsInputModule, "tsInputModule");
      this.tsInputModule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbImportModule,
            this.tsbPublishModule,
            this.toolStripSeparator8,
            this.tsbImport,
            this.tsbAutogroupImages,
            this.tsbDistribute,
            this.tsbScratchbatch,
            this.toolStripSeparator1,
            this.tsbGroupSelected,
            this.tsbUngroupSelected,
            this.tsbRemoveAllGroups,
            this.toolStripSeparator7,
            this.tsbThumbSizeIncrease,
            this.tsbThumbSizeDecrease,
            this.tsbToggleLogVisibility});
      this.tsInputModule.Name = "tsInputModule";
      // 
      // tsbImportModule
      // 
      this.tsbImportModule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbImportModule.Image = global::Matmaxx.Butchr.Properties.Resources.mod_input;
      resources.ApplyResources(this.tsbImportModule, "tsbImportModule");
      this.tsbImportModule.Name = "tsbImportModule";
      this.tsbImportModule.Click += new System.EventHandler(this.tsbImportModule_Click);
      // 
      // tsbPublishModule
      // 
      this.tsbPublishModule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbPublishModule.Image = global::Matmaxx.Butchr.Properties.Resources.mod_output;
      resources.ApplyResources(this.tsbPublishModule, "tsbPublishModule");
      this.tsbPublishModule.Name = "tsbPublishModule";
      this.tsbPublishModule.Click += new System.EventHandler(this.tsbPublishModule_Click);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
      // 
      // tsbImport
      // 
      this.tsbImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbImport.Image = global::Matmaxx.Butchr.Properties.Resources.pictures;
      resources.ApplyResources(this.tsbImport, "tsbImport");
      this.tsbImport.Name = "tsbImport";
      this.tsbImport.Click += new System.EventHandler(this.tsiImport_Click);
      // 
      // tsbAutogroupImages
      // 
      this.tsbAutogroupImages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbAutogroupImages.Image = global::Matmaxx.Butchr.Properties.Resources.wand;
      resources.ApplyResources(this.tsbAutogroupImages, "tsbAutogroupImages");
      this.tsbAutogroupImages.Name = "tsbAutogroupImages";
      this.tsbAutogroupImages.Click += new System.EventHandler(this.tsbAutogroup_Click);
      // 
      // tsbDistribute
      // 
      this.tsbDistribute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbDistribute.Image = global::Matmaxx.Butchr.Properties.Resources.chart_organisation;
      resources.ApplyResources(this.tsbDistribute, "tsbDistribute");
      this.tsbDistribute.Name = "tsbDistribute";
      this.tsbDistribute.Click += new System.EventHandler(this.tsiDistribute_Click);
      // 
      // tsbScratchbatch
      // 
      this.tsbScratchbatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbScratchbatch.Image = global::Matmaxx.Butchr.Properties.Resources.pencil;
      resources.ApplyResources(this.tsbScratchbatch, "tsbScratchbatch");
      this.tsbScratchbatch.Name = "tsbScratchbatch";
      this.tsbScratchbatch.Click += new System.EventHandler(this.tsiScratchbatch_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // tsbGroupSelected
      // 
      this.tsbGroupSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbGroupSelected.Image = global::Matmaxx.Butchr.Properties.Resources.link;
      resources.ApplyResources(this.tsbGroupSelected, "tsbGroupSelected");
      this.tsbGroupSelected.Name = "tsbGroupSelected";
      this.tsbGroupSelected.Click += new System.EventHandler(this.tsiGroupSelected_Click);
      // 
      // tsbUngroupSelected
      // 
      this.tsbUngroupSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbUngroupSelected.Image = global::Matmaxx.Butchr.Properties.Resources.link_break;
      resources.ApplyResources(this.tsbUngroupSelected, "tsbUngroupSelected");
      this.tsbUngroupSelected.Name = "tsbUngroupSelected";
      this.tsbUngroupSelected.Click += new System.EventHandler(this.tsiUngroupSelected_Click);
      // 
      // tsbRemoveAllGroups
      // 
      this.tsbRemoveAllGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbRemoveAllGroups.Image = global::Matmaxx.Butchr.Properties.Resources.link_delete;
      resources.ApplyResources(this.tsbRemoveAllGroups, "tsbRemoveAllGroups");
      this.tsbRemoveAllGroups.Name = "tsbRemoveAllGroups";
      this.tsbRemoveAllGroups.Click += new System.EventHandler(this.tsiRemoveAllGroups_Click);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
      // 
      // tsbThumbSizeIncrease
      // 
      this.tsbThumbSizeIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbThumbSizeIncrease.Image = global::Matmaxx.Butchr.Properties.Resources.arrow_out;
      resources.ApplyResources(this.tsbThumbSizeIncrease, "tsbThumbSizeIncrease");
      this.tsbThumbSizeIncrease.Name = "tsbThumbSizeIncrease";
      this.tsbThumbSizeIncrease.Click += new System.EventHandler(this.tsiIncThumbSize_Click);
      // 
      // tsbThumbSizeDecrease
      // 
      this.tsbThumbSizeDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbThumbSizeDecrease.Image = global::Matmaxx.Butchr.Properties.Resources.arrow_in;
      resources.ApplyResources(this.tsbThumbSizeDecrease, "tsbThumbSizeDecrease");
      this.tsbThumbSizeDecrease.Name = "tsbThumbSizeDecrease";
      this.tsbThumbSizeDecrease.Click += new System.EventHandler(this.tsiDecThumbSize_Click);
      // 
      // tsbToggleLogVisibility
      // 
      this.tsbToggleLogVisibility.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbToggleLogVisibility.Image = global::Matmaxx.Butchr.Properties.Resources.application_split;
      resources.ApplyResources(this.tsbToggleLogVisibility, "tsbToggleLogVisibility");
      this.tsbToggleLogVisibility.Name = "tsbToggleLogVisibility";
      this.tsbToggleLogVisibility.Click += new System.EventHandler(this.tsiToggleLogVisibility_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = global::Matmaxx.Butchr.Properties.Resources.arrow_refresh;
      resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Click += new System.EventHandler(this.tsiRefresh_Click);
      // 
      // msMain
      // 
      this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miView,
            this.miHelp,
            this.miDebug});
      resources.ApplyResources(this.msMain, "msMain");
      this.msMain.Name = "msMain";
      // 
      // miFile
      // 
      this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImport,
            this.miDistribute,
            this.toolStripSeparator3,
            this.miScratchbatch,
            this.toolStripSeparator2,
            this.miExit,
            this.tsbAutogroup});
      this.miFile.Name = "miFile";
      resources.ApplyResources(this.miFile, "miFile");
      // 
      // miImport
      // 
      this.miImport.Image = global::Matmaxx.Butchr.Properties.Resources.pictures;
      this.miImport.Name = "miImport";
      resources.ApplyResources(this.miImport, "miImport");
      this.miImport.Click += new System.EventHandler(this.tsiImport_Click);
      // 
      // miDistribute
      // 
      this.miDistribute.Image = global::Matmaxx.Butchr.Properties.Resources.chart_organisation;
      this.miDistribute.Name = "miDistribute";
      resources.ApplyResources(this.miDistribute, "miDistribute");
      this.miDistribute.Click += new System.EventHandler(this.tsiDistribute_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
      // 
      // miScratchbatch
      // 
      this.miScratchbatch.Image = global::Matmaxx.Butchr.Properties.Resources.pencil;
      this.miScratchbatch.Name = "miScratchbatch";
      resources.ApplyResources(this.miScratchbatch, "miScratchbatch");
      this.miScratchbatch.Click += new System.EventHandler(this.tsiScratchbatch_Click);
      // 
      // miExit
      // 
      this.miExit.Image = global::Matmaxx.Butchr.Properties.Resources.door_in;
      this.miExit.Name = "miExit";
      resources.ApplyResources(this.miExit, "miExit");
      this.miExit.Click += new System.EventHandler(this.tsiExit_Click);
      // 
      // tsbAutogroup
      // 
      this.tsbAutogroup.Image = global::Matmaxx.Butchr.Properties.Resources.wand;
      this.tsbAutogroup.Name = "tsbAutogroup";
      resources.ApplyResources(this.tsbAutogroup, "tsbAutogroup");
      this.tsbAutogroup.Click += new System.EventHandler(this.tsbAutogroup_Click);
      // 
      // miEdit
      // 
      this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGroupSelected,
            this.miUngroupSelected,
            this.miRemoveAllGroups,
            this.toolStripSeparator4,
            this.miRawFormat,
            this.tscbRawFormats});
      this.miEdit.Name = "miEdit";
      resources.ApplyResources(this.miEdit, "miEdit");
      // 
      // miGroupSelected
      // 
      this.miGroupSelected.Image = global::Matmaxx.Butchr.Properties.Resources.link;
      this.miGroupSelected.Name = "miGroupSelected";
      resources.ApplyResources(this.miGroupSelected, "miGroupSelected");
      this.miGroupSelected.Click += new System.EventHandler(this.tsiGroupSelected_Click);
      // 
      // miUngroupSelected
      // 
      this.miUngroupSelected.Image = global::Matmaxx.Butchr.Properties.Resources.link_break;
      this.miUngroupSelected.Name = "miUngroupSelected";
      resources.ApplyResources(this.miUngroupSelected, "miUngroupSelected");
      this.miUngroupSelected.Click += new System.EventHandler(this.tsiUngroupSelected_Click);
      // 
      // miRemoveAllGroups
      // 
      this.miRemoveAllGroups.Image = global::Matmaxx.Butchr.Properties.Resources.link_delete;
      this.miRemoveAllGroups.Name = "miRemoveAllGroups";
      resources.ApplyResources(this.miRemoveAllGroups, "miRemoveAllGroups");
      this.miRemoveAllGroups.Click += new System.EventHandler(this.tsiRemoveAllGroups_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
      // 
      // miRawFormat
      // 
      resources.ApplyResources(this.miRawFormat, "miRawFormat");
      this.miRawFormat.Name = "miRawFormat";
      // 
      // tscbRawFormats
      // 
      this.tscbRawFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.tscbRawFormats.Name = "tscbRawFormats";
      resources.ApplyResources(this.tscbRawFormats, "tscbRawFormats");
      this.tscbRawFormats.SelectedIndexChanged += new System.EventHandler(this.tscbRawFormats_SelectedIndexChanged);
      // 
      // miView
      // 
      this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.miDebugIncThumbSize,
            this.miDebugDecThumbSize});
      this.miView.Name = "miView";
      resources.ApplyResources(this.miView, "miView");
      // 
      // miRefresh
      // 
      this.miRefresh.Image = global::Matmaxx.Butchr.Properties.Resources.arrow_refresh;
      this.miRefresh.Name = "miRefresh";
      resources.ApplyResources(this.miRefresh, "miRefresh");
      this.miRefresh.Click += new System.EventHandler(this.tsiRefresh_Click);
      // 
      // miDebugIncThumbSize
      // 
      this.miDebugIncThumbSize.Image = global::Matmaxx.Butchr.Properties.Resources.arrow_out;
      this.miDebugIncThumbSize.Name = "miDebugIncThumbSize";
      resources.ApplyResources(this.miDebugIncThumbSize, "miDebugIncThumbSize");
      this.miDebugIncThumbSize.Click += new System.EventHandler(this.tsiIncThumbSize_Click);
      // 
      // miDebugDecThumbSize
      // 
      this.miDebugDecThumbSize.Image = global::Matmaxx.Butchr.Properties.Resources.arrow_in;
      this.miDebugDecThumbSize.Name = "miDebugDecThumbSize";
      resources.ApplyResources(this.miDebugDecThumbSize, "miDebugDecThumbSize");
      this.miDebugDecThumbSize.Click += new System.EventHandler(this.tsiDecThumbSize_Click);
      // 
      // miHelp
      // 
      this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpContents,
            this.miHelpPhotomatixCommandline,
            this.miHelpAbout,
            this.miHelpResetContextActivations});
      this.miHelp.Name = "miHelp";
      resources.ApplyResources(this.miHelp, "miHelp");
      // 
      // miHelpContents
      // 
      this.miHelpContents.Image = global::Matmaxx.Butchr.Properties.Resources.help;
      this.miHelpContents.Name = "miHelpContents";
      resources.ApplyResources(this.miHelpContents, "miHelpContents");
      this.miHelpContents.Click += new System.EventHandler(this.tsiHelpContents_Click);
      // 
      // miHelpPhotomatixCommandline
      // 
      this.miHelpPhotomatixCommandline.Image = global::Matmaxx.Butchr.Properties.Resources.photo;
      this.miHelpPhotomatixCommandline.Name = "miHelpPhotomatixCommandline";
      resources.ApplyResources(this.miHelpPhotomatixCommandline, "miHelpPhotomatixCommandline");
      this.miHelpPhotomatixCommandline.Click += new System.EventHandler(this.tsiPhotomatixCommandline_Click);
      // 
      // miHelpAbout
      // 
      this.miHelpAbout.Image = global::Matmaxx.Butchr.Properties.Resources.information;
      this.miHelpAbout.Name = "miHelpAbout";
      resources.ApplyResources(this.miHelpAbout, "miHelpAbout");
      this.miHelpAbout.Click += new System.EventHandler(this.tsiHelpAbout_Click);
      // 
      // miHelpResetContextActivations
      // 
      this.miHelpResetContextActivations.Name = "miHelpResetContextActivations";
      resources.ApplyResources(this.miHelpResetContextActivations, "miHelpResetContextActivations");
      this.miHelpResetContextActivations.Click += new System.EventHandler(this.miHelpResetContextActivations_Click);
      // 
      // miDebug
      // 
      this.miDebug.Name = "miDebug";
      resources.ApplyResources(this.miDebug, "miDebug");
      // 
      // publishModule
      // 
      this.publishModule.BackColor = System.Drawing.SystemColors.Control;
      resources.ApplyResources(this.publishModule, "publishModule");
      this.publishModule.Name = "publishModule";
      // 
      // SelectorForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tscMain);
      this.Controls.Add(this.msMain);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Matmaxx.Butchr.Properties.Settings.Default, "SelectorFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.DoubleBuffered = true;
      this.KeyPreview = true;
      this.Location = global::Matmaxx.Butchr.Properties.Settings.Default.SelectorFormLocation;
      this.MainMenuStrip = this.msMain;
      this.Name = "SelectorForm";
      this.Load += new System.EventHandler(this.SelectorForm_Load);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectorForm_FormClosing);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectorForm_KeyDown);
      this.ResizeEnd += new System.EventHandler(this.SelectorForm_ResizeEnd);
      this.tscMain.ContentPanel.ResumeLayout(false);
      this.tscMain.TopToolStripPanel.ResumeLayout(false);
      this.tscMain.TopToolStripPanel.PerformLayout();
      this.tscMain.ResumeLayout(false);
      this.tscMain.PerformLayout();
      this.splitHorizontal.Panel1.ResumeLayout(false);
      this.splitHorizontal.Panel2.ResumeLayout(false);
      this.splitHorizontal.ResumeLayout(false);
      this.cmsImages.ResumeLayout(false);
      this.splitVertical.Panel1.ResumeLayout(false);
      this.splitVertical.Panel2.ResumeLayout(false);
      this.splitVertical.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.tblLog)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tblExif)).EndInit();
      this.tsInputModule.ResumeLayout(false);
      this.tsInputModule.PerformLayout();
      this.msMain.ResumeLayout(false);
      this.msMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView importModule;
    private System.Windows.Forms.SplitContainer splitHorizontal;
    private XPTable.Models.Table tblLog;
    private XPTable.Models.TableModel tmLog;
    private XPTable.Models.ColumnModel cmLog;
    private System.Windows.Forms.ContextMenuStrip cmsImages;
    private System.Windows.Forms.ToolStripMenuItem groupSelectedImagesToolStripMenuItem;
    private System.Windows.Forms.MenuStrip msMain;
    private System.Windows.Forms.ToolStripMenuItem miFile;
    private System.Windows.Forms.ToolStripMenuItem miEdit;
    private System.Windows.Forms.ToolStripMenuItem miView;
    private System.Windows.Forms.ToolStripMenuItem miHelp;
    private System.Windows.Forms.ToolStripMenuItem miImport;
    private System.Windows.Forms.ToolStripMenuItem miDistribute;
    private System.Windows.Forms.ToolStripMenuItem miExit;
    private System.Windows.Forms.ToolStripMenuItem miGroupSelected;
    private System.Windows.Forms.ToolStripMenuItem miRemoveAllGroups;
    private System.Windows.Forms.ToolStripMenuItem miRefresh;
    private System.Windows.Forms.ToolStripMenuItem miHelpContents;
    private System.Windows.Forms.ToolStripMenuItem miHelpPhotomatixCommandline;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem miScratchbatch;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripComboBox tscbRawFormats;
    private System.Windows.Forms.ToolStripMenuItem miRawFormat;
    private System.Windows.Forms.ToolStripMenuItem miUngroupSelected;
    private System.Windows.Forms.ToolStrip tsInputModule;
    private System.Windows.Forms.ToolStripButton tsbImport;
    private System.Windows.Forms.ToolStripButton tsbDistribute;
    private System.Windows.Forms.ToolStripButton tsbScratchbatch;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripButton tsbGroupSelected;
    private System.Windows.Forms.ToolStripContainer tscMain;
    private System.Windows.Forms.ToolStripButton tsbUngroupSelected;
    private System.Windows.Forms.ToolStripButton tsbRemoveAllGroups;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.ToolStripMenuItem miDebug;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripButton tsbThumbSizeDecrease;
    private System.Windows.Forms.ToolStripButton tsbThumbSizeIncrease;
    private System.Windows.Forms.ToolStripMenuItem miDebugIncThumbSize;
    private System.Windows.Forms.ToolStripMenuItem miDebugDecThumbSize;
    private System.Windows.Forms.ToolStripButton tsbToggleLogVisibility;
    private System.Windows.Forms.FolderBrowserDialog fbdScratch;
    private System.Windows.Forms.ToolStripButton tsbAutogroupImages;
    private System.Windows.Forms.ToolStripMenuItem tsbAutogroup;
    private System.Windows.Forms.ToolStripMenuItem miHelpResetContextActivations;
    private System.Windows.Forms.ToolStripMenuItem ungroupSelectedImagesToolStripMenuItem;
    private System.Windows.Forms.SplitContainer splitVertical;
    private System.Windows.Forms.Splitter splitter1;
    private XPTable.Models.Table tblExif;
    private XPTable.Models.ColumnModel cmExif;
    private XPTable.Models.TableModel tmExif;
    private System.Windows.Forms.ToolStripButton tsbImportModule;
    private System.Windows.Forms.ToolStripButton tsbPublishModule;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private PublishControl publishModule;
  }
}