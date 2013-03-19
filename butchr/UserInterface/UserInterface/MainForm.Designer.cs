namespace Matmaxx.Butcher.UserInterface
{
  partial class MainForm
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
      if(disposing && (components != null))
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.status = new System.Windows.Forms.StatusStrip();
      this.menu = new System.Windows.Forms.MenuStrip();
      this.toolbar = new System.Windows.Forms.ToolStrip();
      this.splitter = new System.Windows.Forms.SplitContainer();
      this.tree = new System.Windows.Forms.TreeView();
      this.images = new System.Windows.Forms.ImageList(this.components);
      this.list = new System.Windows.Forms.ListView();
      this.splitter.Panel1.SuspendLayout();
      this.splitter.Panel2.SuspendLayout();
      this.splitter.SuspendLayout();
      this.SuspendLayout();
      // 
      // status
      // 
      this.status.Location = new System.Drawing.Point(0, 678);
      this.status.Name = "status";
      this.status.Size = new System.Drawing.Size(878, 22);
      this.status.TabIndex = 0;
      this.status.Text = "statusStrip1";
      // 
      // menu
      // 
      this.menu.Location = new System.Drawing.Point(0, 0);
      this.menu.Name = "menu";
      this.menu.Size = new System.Drawing.Size(878, 24);
      this.menu.TabIndex = 1;
      this.menu.Text = "menuStrip1";
      // 
      // toolbar
      // 
      this.toolbar.Location = new System.Drawing.Point(0, 24);
      this.toolbar.Name = "toolbar";
      this.toolbar.Size = new System.Drawing.Size(878, 25);
      this.toolbar.TabIndex = 2;
      this.toolbar.Text = "toolStrip1";
      // 
      // splitter
      // 
      this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitter.Location = new System.Drawing.Point(0, 49);
      this.splitter.Name = "splitter";
      // 
      // splitter.Panel1
      // 
      this.splitter.Panel1.Controls.Add(this.tree);
      // 
      // splitter.Panel2
      // 
      this.splitter.Panel2.Controls.Add(this.list);
      this.splitter.Size = new System.Drawing.Size(878, 629);
      this.splitter.SplitterDistance = 292;
      this.splitter.TabIndex = 3;
      // 
      // tree
      // 
      this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tree.ImageIndex = 0;
      this.tree.ImageList = this.images;
      this.tree.Location = new System.Drawing.Point(0, 0);
      this.tree.Name = "tree";
      this.tree.SelectedImageIndex = 0;
      this.tree.Size = new System.Drawing.Size(292, 629);
      this.tree.TabIndex = 0;
      this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
      // 
      // images
      // 
      this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
      this.images.TransparentColor = System.Drawing.Color.Transparent;
      this.images.Images.SetKeyName(0, "computer.png");
      this.images.Images.SetKeyName(1, "camera.png");
      this.images.Images.SetKeyName(2, "folder.png");
      this.images.Images.SetKeyName(3, "folder_go.png");
      this.images.Images.SetKeyName(4, "page_white.png");
      this.images.Images.SetKeyName(5, "drive.png");
      this.images.Images.SetKeyName(6, "drive_go.png");
      this.images.Images.SetKeyName(7, "drive_cd.png");
      this.images.Images.SetKeyName(8, "drive_network.png");
      // 
      // list
      // 
      this.list.Dock = System.Windows.Forms.DockStyle.Fill;
      this.list.Location = new System.Drawing.Point(0, 0);
      this.list.Name = "list";
      this.list.OwnerDraw = true;
      this.list.Size = new System.Drawing.Size(582, 629);
      this.list.TabIndex = 0;
      this.list.TileSize = new System.Drawing.Size(100, 100);
      this.list.UseCompatibleStateImageBehavior = false;
      this.list.View = System.Windows.Forms.View.Tile;
      this.list.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.list_DrawItem);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(878, 700);
      this.Controls.Add(this.splitter);
      this.Controls.Add(this.toolbar);
      this.Controls.Add(this.status);
      this.Controls.Add(this.menu);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menu;
      this.Name = "MainForm";
      this.Text = "Butcher";
      this.splitter.Panel1.ResumeLayout(false);
      this.splitter.Panel2.ResumeLayout(false);
      this.splitter.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip status;
    private System.Windows.Forms.MenuStrip menu;
    private System.Windows.Forms.ToolStrip toolbar;
    private System.Windows.Forms.SplitContainer splitter;
    private System.Windows.Forms.TreeView tree;
    private System.Windows.Forms.ListView list;
    private System.Windows.Forms.ImageList images;

  }
}

