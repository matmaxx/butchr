namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// 
  /// </summary>
  partial class PublishControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublishControl));
      XPTable.Models.DataSourceColumnBinder dataSourceColumnBinder1 = new XPTable.Models.DataSourceColumnBinder();
      XPTable.Renderers.DragDropRenderer dragDropRenderer1 = new XPTable.Renderers.DragDropRenderer();
      this.SplitVertical = new System.Windows.Forms.SplitContainer();
      this.PublishTree = new System.Windows.Forms.TreeView();
      this.treeIcons = new System.Windows.Forms.ImageList(this.components);
      this.InfoTabs = new System.Windows.Forms.TabControl();
      this.ProviderTab = new System.Windows.Forms.TabPage();
      this.ProviderTable = new XPTable.Models.Table();
      this.ProviderColumnModel = new XPTable.Models.ColumnModel();
      this.ProviderTableModel = new XPTable.Models.TableModel();
      this.CommonTab = new System.Windows.Forms.TabPage();
      this.gbImageMetadata = new System.Windows.Forms.GroupBox();
      this.btnSelectGeotagFromMap = new System.Windows.Forms.Button();
      this.btnSelectTagsFromList = new System.Windows.Forms.Button();
      this.lblTitle = new System.Windows.Forms.Label();
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.rbCommonGerman = new System.Windows.Forms.RadioButton();
      this.lblDescription = new System.Windows.Forms.Label();
      this.rbCommonEnglish = new System.Windows.Forms.RadioButton();
      this.lblGeotag = new System.Windows.Forms.Label();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.txtTags = new System.Windows.Forms.TextBox();
      this.txtGeotag = new System.Windows.Forms.TextBox();
      this.lblTags = new System.Windows.Forms.Label();
      this.gbPaths = new System.Windows.Forms.GroupBox();
      this.btnJpgNet = new System.Windows.Forms.Button();
      this.btnJpgFull = new System.Windows.Forms.Button();
      this.btnTiffFull = new System.Windows.Forms.Button();
      this.txtPathJpgNet = new System.Windows.Forms.TextBox();
      this.lblPathJpgNet = new System.Windows.Forms.Label();
      this.txtPathTiff = new System.Windows.Forms.TextBox();
      this.lblPathTiff = new System.Windows.Forms.Label();
      this.lblPathJpgFull = new System.Windows.Forms.Label();
      this.txtPathJpgFull = new System.Windows.Forms.TextBox();
      this.SplitVertical.Panel1.SuspendLayout();
      this.SplitVertical.Panel2.SuspendLayout();
      this.SplitVertical.SuspendLayout();
      this.InfoTabs.SuspendLayout();
      this.ProviderTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ProviderTable)).BeginInit();
      this.CommonTab.SuspendLayout();
      this.gbImageMetadata.SuspendLayout();
      this.gbPaths.SuspendLayout();
      this.SuspendLayout();
      // 
      // SplitVertical
      // 
      this.SplitVertical.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitVertical.Location = new System.Drawing.Point(0, 0);
      this.SplitVertical.Name = "SplitVertical";
      // 
      // SplitVertical.Panel1
      // 
      this.SplitVertical.Panel1.Controls.Add(this.PublishTree);
      // 
      // SplitVertical.Panel2
      // 
      this.SplitVertical.Panel2.Controls.Add(this.InfoTabs);
      this.SplitVertical.Size = new System.Drawing.Size(890, 581);
      this.SplitVertical.SplitterDistance = 296;
      this.SplitVertical.TabIndex = 0;
      // 
      // PublishTree
      // 
      this.PublishTree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PublishTree.ImageIndex = 0;
      this.PublishTree.ImageList = this.treeIcons;
      this.PublishTree.Location = new System.Drawing.Point(0, 0);
      this.PublishTree.Name = "PublishTree";
      this.PublishTree.SelectedImageIndex = 0;
      this.PublishTree.Size = new System.Drawing.Size(296, 581);
      this.PublishTree.TabIndex = 0;
      this.PublishTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CatalogTree_AfterSelect);
      // 
      // treeIcons
      // 
      this.treeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeIcons.ImageStream")));
      this.treeIcons.TransparentColor = System.Drawing.Color.Transparent;
      this.treeIcons.Images.SetKeyName(0, "book.png");
      this.treeIcons.Images.SetKeyName(1, "cup.png");
      this.treeIcons.Images.SetKeyName(2, "picture.png");
      this.treeIcons.Images.SetKeyName(3, "picture_edit.png");
      this.treeIcons.Images.SetKeyName(4, "application_cascade.png");
      this.treeIcons.Images.SetKeyName(5, "application_home.png");
      // 
      // InfoTabs
      // 
      this.InfoTabs.Controls.Add(this.ProviderTab);
      this.InfoTabs.Controls.Add(this.CommonTab);
      this.InfoTabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.InfoTabs.Location = new System.Drawing.Point(0, 0);
      this.InfoTabs.Name = "InfoTabs";
      this.InfoTabs.SelectedIndex = 0;
      this.InfoTabs.Size = new System.Drawing.Size(590, 581);
      this.InfoTabs.TabIndex = 0;
      this.InfoTabs.SelectedIndexChanged += new System.EventHandler(this.InfoTabs_SelectedIndexChanged);
      // 
      // ProviderTab
      // 
      this.ProviderTab.Controls.Add(this.ProviderTable);
      this.ProviderTab.Location = new System.Drawing.Point(4, 22);
      this.ProviderTab.Name = "ProviderTab";
      this.ProviderTab.Padding = new System.Windows.Forms.Padding(3);
      this.ProviderTab.Size = new System.Drawing.Size(582, 555);
      this.ProviderTab.TabIndex = 1;
      this.ProviderTab.Text = "Provider specific information";
      this.ProviderTab.ToolTipText = "Provider specific Information about the selected image";
      this.ProviderTab.UseVisualStyleBackColor = true;
      // 
      // ProviderTable
      // 
      this.ProviderTable.BorderColor = System.Drawing.Color.Black;
      this.ProviderTable.ColumnModel = this.ProviderColumnModel;
      this.ProviderTable.DataMember = null;
      this.ProviderTable.DataSourceColumnBinder = dataSourceColumnBinder1;
      this.ProviderTable.Dock = System.Windows.Forms.DockStyle.Fill;
      dragDropRenderer1.ForeColor = System.Drawing.Color.Red;
      this.ProviderTable.DragDropRenderer = dragDropRenderer1;
      this.ProviderTable.Location = new System.Drawing.Point(3, 3);
      this.ProviderTable.Name = "ProviderTable";
      this.ProviderTable.NoItemsText = "Please select an image to display its provider specific information in this table" +
          ".";
      this.ProviderTable.Size = new System.Drawing.Size(576, 549);
      this.ProviderTable.TabIndex = 0;
      this.ProviderTable.TableModel = this.ProviderTableModel;
      this.ProviderTable.UnfocusedBorderColor = System.Drawing.Color.Black;
      // 
      // CommonTab
      // 
      this.CommonTab.Controls.Add(this.gbImageMetadata);
      this.CommonTab.Controls.Add(this.gbPaths);
      this.CommonTab.Location = new System.Drawing.Point(4, 22);
      this.CommonTab.Name = "CommonTab";
      this.CommonTab.Padding = new System.Windows.Forms.Padding(3);
      this.CommonTab.Size = new System.Drawing.Size(582, 555);
      this.CommonTab.TabIndex = 0;
      this.CommonTab.Text = "Common information";
      this.CommonTab.ToolTipText = "Common information about the selected image";
      this.CommonTab.UseVisualStyleBackColor = true;
      // 
      // gbImageMetadata
      // 
      this.gbImageMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.gbImageMetadata.Controls.Add(this.btnSelectGeotagFromMap);
      this.gbImageMetadata.Controls.Add(this.btnSelectTagsFromList);
      this.gbImageMetadata.Controls.Add(this.lblTitle);
      this.gbImageMetadata.Controls.Add(this.txtTitle);
      this.gbImageMetadata.Controls.Add(this.rbCommonGerman);
      this.gbImageMetadata.Controls.Add(this.lblDescription);
      this.gbImageMetadata.Controls.Add(this.rbCommonEnglish);
      this.gbImageMetadata.Controls.Add(this.lblGeotag);
      this.gbImageMetadata.Controls.Add(this.txtDescription);
      this.gbImageMetadata.Controls.Add(this.txtTags);
      this.gbImageMetadata.Controls.Add(this.txtGeotag);
      this.gbImageMetadata.Controls.Add(this.lblTags);
      this.gbImageMetadata.Location = new System.Drawing.Point(9, 130);
      this.gbImageMetadata.MinimumSize = new System.Drawing.Size(570, 224);
      this.gbImageMetadata.Name = "gbImageMetadata";
      this.gbImageMetadata.Size = new System.Drawing.Size(570, 419);
      this.gbImageMetadata.TabIndex = 17;
      this.gbImageMetadata.TabStop = false;
      this.gbImageMetadata.Text = "Image metadata";
      // 
      // btnSelectGeotagFromMap
      // 
      this.btnSelectGeotagFromMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSelectGeotagFromMap.Location = new System.Drawing.Point(532, 94);
      this.btnSelectGeotagFromMap.Name = "btnSelectGeotagFromMap";
      this.btnSelectGeotagFromMap.Size = new System.Drawing.Size(27, 20);
      this.btnSelectGeotagFromMap.TabIndex = 20;
      this.btnSelectGeotagFromMap.Text = "...";
      this.btnSelectGeotagFromMap.UseVisualStyleBackColor = true;
      // 
      // btnSelectTagsFromList
      // 
      this.btnSelectTagsFromList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSelectTagsFromList.Location = new System.Drawing.Point(532, 68);
      this.btnSelectTagsFromList.Name = "btnSelectTagsFromList";
      this.btnSelectTagsFromList.Size = new System.Drawing.Size(27, 20);
      this.btnSelectTagsFromList.TabIndex = 19;
      this.btnSelectTagsFromList.Text = "...";
      this.btnSelectTagsFromList.UseVisualStyleBackColor = true;
      // 
      // lblTitle
      // 
      this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTitle.AutoSize = true;
      this.lblTitle.Location = new System.Drawing.Point(7, 45);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(27, 13);
      this.lblTitle.TabIndex = 3;
      this.lblTitle.Text = "Title";
      // 
      // txtTitle
      // 
      this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.txtTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
      this.txtTitle.Location = new System.Drawing.Point(79, 42);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.Size = new System.Drawing.Size(485, 20);
      this.txtTitle.TabIndex = 2;
      // 
      // rbCommonGerman
      // 
      this.rbCommonGerman.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.rbCommonGerman.AutoSize = true;
      this.rbCommonGerman.Location = new System.Drawing.Point(483, 19);
      this.rbCommonGerman.Name = "rbCommonGerman";
      this.rbCommonGerman.Size = new System.Drawing.Size(62, 17);
      this.rbCommonGerman.TabIndex = 1;
      this.rbCommonGerman.Text = "German";
      this.rbCommonGerman.UseVisualStyleBackColor = true;
      // 
      // lblDescription
      // 
      this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDescription.AutoSize = true;
      this.lblDescription.Location = new System.Drawing.Point(7, 123);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(60, 13);
      this.lblDescription.TabIndex = 7;
      this.lblDescription.Text = "Description";
      // 
      // rbCommonEnglish
      // 
      this.rbCommonEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.rbCommonEnglish.AutoSize = true;
      this.rbCommonEnglish.Checked = true;
      this.rbCommonEnglish.Location = new System.Drawing.Point(418, 19);
      this.rbCommonEnglish.Name = "rbCommonEnglish";
      this.rbCommonEnglish.Size = new System.Drawing.Size(59, 17);
      this.rbCommonEnglish.TabIndex = 0;
      this.rbCommonEnglish.TabStop = true;
      this.rbCommonEnglish.Text = "English";
      this.rbCommonEnglish.UseVisualStyleBackColor = true;
      this.rbCommonEnglish.CheckedChanged += new System.EventHandler(this.rbLanguage_CheckedChanged);
      // 
      // lblGeotag
      // 
      this.lblGeotag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblGeotag.AutoSize = true;
      this.lblGeotag.Location = new System.Drawing.Point(7, 97);
      this.lblGeotag.Name = "lblGeotag";
      this.lblGeotag.Size = new System.Drawing.Size(42, 13);
      this.lblGeotag.TabIndex = 9;
      this.lblGeotag.Text = "Geotag";
      // 
      // txtDescription
      // 
      this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDescription.Location = new System.Drawing.Point(79, 120);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new System.Drawing.Size(485, 293);
      this.txtDescription.TabIndex = 6;
      // 
      // txtTags
      // 
      this.txtTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTags.Location = new System.Drawing.Point(79, 68);
      this.txtTags.Name = "txtTags";
      this.txtTags.Size = new System.Drawing.Size(447, 20);
      this.txtTags.TabIndex = 4;
      // 
      // txtGeotag
      // 
      this.txtGeotag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtGeotag.Location = new System.Drawing.Point(79, 94);
      this.txtGeotag.Name = "txtGeotag";
      this.txtGeotag.Size = new System.Drawing.Size(447, 20);
      this.txtGeotag.TabIndex = 8;
      // 
      // lblTags
      // 
      this.lblTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTags.AutoSize = true;
      this.lblTags.Location = new System.Drawing.Point(7, 71);
      this.lblTags.Name = "lblTags";
      this.lblTags.Size = new System.Drawing.Size(31, 13);
      this.lblTags.TabIndex = 5;
      this.lblTags.Text = "Tags";
      // 
      // gbPaths
      // 
      this.gbPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.gbPaths.Controls.Add(this.btnJpgNet);
      this.gbPaths.Controls.Add(this.btnJpgFull);
      this.gbPaths.Controls.Add(this.btnTiffFull);
      this.gbPaths.Controls.Add(this.txtPathJpgNet);
      this.gbPaths.Controls.Add(this.lblPathJpgNet);
      this.gbPaths.Controls.Add(this.txtPathTiff);
      this.gbPaths.Controls.Add(this.lblPathTiff);
      this.gbPaths.Controls.Add(this.lblPathJpgFull);
      this.gbPaths.Controls.Add(this.txtPathJpgFull);
      this.gbPaths.Location = new System.Drawing.Point(9, 6);
      this.gbPaths.MinimumSize = new System.Drawing.Size(570, 118);
      this.gbPaths.Name = "gbPaths";
      this.gbPaths.Size = new System.Drawing.Size(570, 118);
      this.gbPaths.TabIndex = 16;
      this.gbPaths.TabStop = false;
      this.gbPaths.Text = "Paths";
      // 
      // btnJpgNet
      // 
      this.btnJpgNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnJpgNet.Location = new System.Drawing.Point(532, 78);
      this.btnJpgNet.Name = "btnJpgNet";
      this.btnJpgNet.Size = new System.Drawing.Size(27, 20);
      this.btnJpgNet.TabIndex = 18;
      this.btnJpgNet.Text = "...";
      this.btnJpgNet.UseVisualStyleBackColor = true;
      // 
      // btnJpgFull
      // 
      this.btnJpgFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnJpgFull.Location = new System.Drawing.Point(532, 53);
      this.btnJpgFull.Name = "btnJpgFull";
      this.btnJpgFull.Size = new System.Drawing.Size(27, 20);
      this.btnJpgFull.TabIndex = 17;
      this.btnJpgFull.Text = "...";
      this.btnJpgFull.UseVisualStyleBackColor = true;
      // 
      // btnTiffFull
      // 
      this.btnTiffFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTiffFull.Location = new System.Drawing.Point(532, 27);
      this.btnTiffFull.Name = "btnTiffFull";
      this.btnTiffFull.Size = new System.Drawing.Size(27, 20);
      this.btnTiffFull.TabIndex = 16;
      this.btnTiffFull.Text = "...";
      this.btnTiffFull.UseVisualStyleBackColor = true;
      // 
      // txtPathJpgNet
      // 
      this.txtPathJpgNet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPathJpgNet.Location = new System.Drawing.Point(79, 79);
      this.txtPathJpgNet.Name = "txtPathJpgNet";
      this.txtPathJpgNet.Size = new System.Drawing.Size(447, 20);
      this.txtPathJpgNet.TabIndex = 14;
      // 
      // lblPathJpgNet
      // 
      this.lblPathJpgNet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPathJpgNet.AutoSize = true;
      this.lblPathJpgNet.Location = new System.Drawing.Point(7, 82);
      this.lblPathJpgNet.Name = "lblPathJpgNet";
      this.lblPathJpgNet.Size = new System.Drawing.Size(59, 13);
      this.lblPathJpgNet.TabIndex = 15;
      this.lblPathJpgNet.Text = "jpg internet";
      // 
      // txtPathTiff
      // 
      this.txtPathTiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPathTiff.Location = new System.Drawing.Point(79, 28);
      this.txtPathTiff.Name = "txtPathTiff";
      this.txtPathTiff.Size = new System.Drawing.Size(447, 20);
      this.txtPathTiff.TabIndex = 10;
      // 
      // lblPathTiff
      // 
      this.lblPathTiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPathTiff.AutoSize = true;
      this.lblPathTiff.Location = new System.Drawing.Point(7, 31);
      this.lblPathTiff.Name = "lblPathTiff";
      this.lblPathTiff.Size = new System.Drawing.Size(52, 13);
      this.lblPathTiff.TabIndex = 11;
      this.lblPathTiff.Text = "tiff fullsize";
      // 
      // lblPathJpgFull
      // 
      this.lblPathJpgFull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPathJpgFull.AutoSize = true;
      this.lblPathJpgFull.Location = new System.Drawing.Point(7, 57);
      this.lblPathJpgFull.Name = "lblPathJpgFull";
      this.lblPathJpgFull.Size = new System.Drawing.Size(55, 13);
      this.lblPathJpgFull.TabIndex = 13;
      this.lblPathJpgFull.Text = "jpg fullsize";
      // 
      // txtPathJpgFull
      // 
      this.txtPathJpgFull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPathJpgFull.Location = new System.Drawing.Point(79, 54);
      this.txtPathJpgFull.Name = "txtPathJpgFull";
      this.txtPathJpgFull.Size = new System.Drawing.Size(447, 20);
      this.txtPathJpgFull.TabIndex = 12;
      // 
      // PublishControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.Controls.Add(this.SplitVertical);
      this.Name = "PublishControl";
      this.Size = new System.Drawing.Size(890, 581);
      this.SplitVertical.Panel1.ResumeLayout(false);
      this.SplitVertical.Panel2.ResumeLayout(false);
      this.SplitVertical.ResumeLayout(false);
      this.InfoTabs.ResumeLayout(false);
      this.ProviderTab.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ProviderTable)).EndInit();
      this.CommonTab.ResumeLayout(false);
      this.gbImageMetadata.ResumeLayout(false);
      this.gbImageMetadata.PerformLayout();
      this.gbPaths.ResumeLayout(false);
      this.gbPaths.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer SplitVertical;
    private System.Windows.Forms.TreeView PublishTree;
    private System.Windows.Forms.TabControl InfoTabs;
    private System.Windows.Forms.TabPage CommonTab;
    private System.Windows.Forms.TabPage ProviderTab;
    private XPTable.Models.Table ProviderTable;
    private XPTable.Models.ColumnModel ProviderColumnModel;
    private XPTable.Models.TableModel ProviderTableModel;
    private System.Windows.Forms.RadioButton rbCommonEnglish;
    private System.Windows.Forms.RadioButton rbCommonGerman;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label lblTags;
    private System.Windows.Forms.TextBox txtTags;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.GroupBox gbPaths;
    private System.Windows.Forms.TextBox txtPathJpgNet;
    private System.Windows.Forms.Label lblPathJpgNet;
    private System.Windows.Forms.TextBox txtPathTiff;
    private System.Windows.Forms.Label lblPathTiff;
    private System.Windows.Forms.Label lblPathJpgFull;
    private System.Windows.Forms.TextBox txtPathJpgFull;
    private System.Windows.Forms.Label lblGeotag;
    private System.Windows.Forms.TextBox txtGeotag;
    private System.Windows.Forms.Button btnJpgNet;
    private System.Windows.Forms.Button btnJpgFull;
    private System.Windows.Forms.Button btnTiffFull;
    private System.Windows.Forms.GroupBox gbImageMetadata;
    private System.Windows.Forms.Button btnSelectGeotagFromMap;
    private System.Windows.Forms.Button btnSelectTagsFromList;
    private System.Windows.Forms.ImageList treeIcons;
  }
}
