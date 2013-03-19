namespace Matmaxx.Butchr.UserInterface
{
  partial class ImportOptionsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportOptionsForm));
      this.gbPaths = new System.Windows.Forms.GroupBox();
      this.chkTargetMatchesSourcePath = new System.Windows.Forms.CheckBox();
      this.btnTargetPath = new System.Windows.Forms.Button();
      this.txtTargetPath = new System.Windows.Forms.TextBox();
      this.lblTargetPath = new System.Windows.Forms.Label();
      this.btnSourcePath = new System.Windows.Forms.Button();
      this.txtSourcePath = new System.Windows.Forms.TextBox();
      this.lblSourcePath = new System.Windows.Forms.Label();
      this.gbImportOptions = new System.Windows.Forms.GroupBox();
      this.rbCopyFilesOnImport = new System.Windows.Forms.RadioButton();
      this.rbMoveFilesOnImport = new System.Windows.Forms.RadioButton();
      this.gbDistributeOptions = new System.Windows.Forms.GroupBox();
      this.rbCopyFilesOnDistribute = new System.Windows.Forms.RadioButton();
      this.rbMoveFilesOnDistribute = new System.Windows.Forms.RadioButton();
      this.btnImport = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.fbdSource = new System.Windows.Forms.FolderBrowserDialog();
      this.fbdTarget = new System.Windows.Forms.FolderBrowserDialog();
      this.epSource = new System.Windows.Forms.ErrorProvider(this.components);
      this.epTarget = new System.Windows.Forms.ErrorProvider(this.components);
      this.gbPaths.SuspendLayout();
      this.gbImportOptions.SuspendLayout();
      this.gbDistributeOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.epSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.epTarget)).BeginInit();
      this.SuspendLayout();
      // 
      // gbPaths
      // 
      this.gbPaths.Controls.Add(this.chkTargetMatchesSourcePath);
      this.gbPaths.Controls.Add(this.btnTargetPath);
      this.gbPaths.Controls.Add(this.txtTargetPath);
      this.gbPaths.Controls.Add(this.lblTargetPath);
      this.gbPaths.Controls.Add(this.btnSourcePath);
      this.gbPaths.Controls.Add(this.txtSourcePath);
      this.gbPaths.Controls.Add(this.lblSourcePath);
      this.gbPaths.Location = new System.Drawing.Point(12, 12);
      this.gbPaths.Name = "gbPaths";
      this.gbPaths.Size = new System.Drawing.Size(672, 109);
      this.gbPaths.TabIndex = 0;
      this.gbPaths.TabStop = false;
      this.gbPaths.Text = "Paths";
      // 
      // chkTargetMatchesSourcePath
      // 
      this.chkTargetMatchesSourcePath.AutoSize = true;
      this.chkTargetMatchesSourcePath.Location = new System.Drawing.Point(101, 51);
      this.chkTargetMatchesSourcePath.Name = "chkTargetMatchesSourcePath";
      this.chkTargetMatchesSourcePath.Size = new System.Drawing.Size(210, 17);
      this.chkTargetMatchesSourcePath.TabIndex = 6;
      this.chkTargetMatchesSourcePath.Text = "Target path is the same as source path";
      this.chkTargetMatchesSourcePath.UseVisualStyleBackColor = true;
      this.chkTargetMatchesSourcePath.CheckedChanged += new System.EventHandler(this.chkTargetMatchesSourcePath_CheckedChanged);
      // 
      // btnTargetPath
      // 
      this.btnTargetPath.Location = new System.Drawing.Point(622, 74);
      this.btnTargetPath.Name = "btnTargetPath";
      this.btnTargetPath.Size = new System.Drawing.Size(31, 20);
      this.btnTargetPath.TabIndex = 5;
      this.btnTargetPath.Text = "...";
      this.btnTargetPath.UseVisualStyleBackColor = true;
      this.btnTargetPath.Click += new System.EventHandler(this.btnTargetPath_Click);
      // 
      // txtTargetPath
      // 
      this.txtTargetPath.Location = new System.Drawing.Point(101, 74);
      this.txtTargetPath.Name = "txtTargetPath";
      this.txtTargetPath.Size = new System.Drawing.Size(515, 20);
      this.txtTargetPath.TabIndex = 4;
      // 
      // lblTargetPath
      // 
      this.lblTargetPath.AutoSize = true;
      this.lblTargetPath.Location = new System.Drawing.Point(6, 77);
      this.lblTargetPath.Name = "lblTargetPath";
      this.lblTargetPath.Size = new System.Drawing.Size(62, 13);
      this.lblTargetPath.TabIndex = 3;
      this.lblTargetPath.Text = "Target path";
      // 
      // btnSourcePath
      // 
      this.btnSourcePath.Location = new System.Drawing.Point(622, 25);
      this.btnSourcePath.Name = "btnSourcePath";
      this.btnSourcePath.Size = new System.Drawing.Size(31, 20);
      this.btnSourcePath.TabIndex = 2;
      this.btnSourcePath.Text = "...";
      this.btnSourcePath.UseVisualStyleBackColor = true;
      this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
      // 
      // txtSourcePath
      // 
      this.txtSourcePath.Location = new System.Drawing.Point(101, 25);
      this.txtSourcePath.Name = "txtSourcePath";
      this.txtSourcePath.Size = new System.Drawing.Size(515, 20);
      this.txtSourcePath.TabIndex = 1;
      // 
      // lblSourcePath
      // 
      this.lblSourcePath.AutoSize = true;
      this.lblSourcePath.Location = new System.Drawing.Point(6, 28);
      this.lblSourcePath.Name = "lblSourcePath";
      this.lblSourcePath.Size = new System.Drawing.Size(65, 13);
      this.lblSourcePath.TabIndex = 0;
      this.lblSourcePath.Text = "Source path";
      // 
      // gbImportOptions
      // 
      this.gbImportOptions.Controls.Add(this.rbCopyFilesOnImport);
      this.gbImportOptions.Controls.Add(this.rbMoveFilesOnImport);
      this.gbImportOptions.Location = new System.Drawing.Point(12, 127);
      this.gbImportOptions.Name = "gbImportOptions";
      this.gbImportOptions.Size = new System.Drawing.Size(333, 75);
      this.gbImportOptions.TabIndex = 1;
      this.gbImportOptions.TabStop = false;
      this.gbImportOptions.Text = "Import options";
      // 
      // rbCopyFilesOnImport
      // 
      this.rbCopyFilesOnImport.AutoSize = true;
      this.rbCopyFilesOnImport.Location = new System.Drawing.Point(9, 43);
      this.rbCopyFilesOnImport.Name = "rbCopyFilesOnImport";
      this.rbCopyFilesOnImport.Size = new System.Drawing.Size(116, 17);
      this.rbCopyFilesOnImport.TabIndex = 1;
      this.rbCopyFilesOnImport.TabStop = true;
      this.rbCopyFilesOnImport.Text = "Copy files on import";
      this.rbCopyFilesOnImport.UseVisualStyleBackColor = true;
      // 
      // rbMoveFilesOnImport
      // 
      this.rbMoveFilesOnImport.AutoSize = true;
      this.rbMoveFilesOnImport.Location = new System.Drawing.Point(9, 20);
      this.rbMoveFilesOnImport.Name = "rbMoveFilesOnImport";
      this.rbMoveFilesOnImport.Size = new System.Drawing.Size(119, 17);
      this.rbMoveFilesOnImport.TabIndex = 0;
      this.rbMoveFilesOnImport.TabStop = true;
      this.rbMoveFilesOnImport.Text = "Move files on import";
      this.rbMoveFilesOnImport.UseVisualStyleBackColor = true;
      // 
      // gbDistributeOptions
      // 
      this.gbDistributeOptions.Controls.Add(this.rbCopyFilesOnDistribute);
      this.gbDistributeOptions.Controls.Add(this.rbMoveFilesOnDistribute);
      this.gbDistributeOptions.Location = new System.Drawing.Point(351, 127);
      this.gbDistributeOptions.Name = "gbDistributeOptions";
      this.gbDistributeOptions.Size = new System.Drawing.Size(333, 75);
      this.gbDistributeOptions.TabIndex = 2;
      this.gbDistributeOptions.TabStop = false;
      this.gbDistributeOptions.Text = "Distribute options";
      // 
      // rbCopyFilesOnDistribute
      // 
      this.rbCopyFilesOnDistribute.AutoSize = true;
      this.rbCopyFilesOnDistribute.Location = new System.Drawing.Point(6, 42);
      this.rbCopyFilesOnDistribute.Name = "rbCopyFilesOnDistribute";
      this.rbCopyFilesOnDistribute.Size = new System.Drawing.Size(138, 17);
      this.rbCopyFilesOnDistribute.TabIndex = 3;
      this.rbCopyFilesOnDistribute.TabStop = true;
      this.rbCopyFilesOnDistribute.Text = "Copy files on distribution";
      this.rbCopyFilesOnDistribute.UseVisualStyleBackColor = true;
      // 
      // rbMoveFilesOnDistribute
      // 
      this.rbMoveFilesOnDistribute.AutoSize = true;
      this.rbMoveFilesOnDistribute.Location = new System.Drawing.Point(6, 19);
      this.rbMoveFilesOnDistribute.Name = "rbMoveFilesOnDistribute";
      this.rbMoveFilesOnDistribute.Size = new System.Drawing.Size(141, 17);
      this.rbMoveFilesOnDistribute.TabIndex = 2;
      this.rbMoveFilesOnDistribute.TabStop = true;
      this.rbMoveFilesOnDistribute.Text = "Move files on distribution";
      this.rbMoveFilesOnDistribute.UseVisualStyleBackColor = true;
      // 
      // btnImport
      // 
      this.btnImport.Location = new System.Drawing.Point(528, 208);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new System.Drawing.Size(75, 23);
      this.btnImport.TabIndex = 3;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(609, 208);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // fbdSource
      // 
      this.fbdSource.RootFolder = System.Environment.SpecialFolder.MyComputer;
      this.fbdSource.ShowNewFolderButton = false;
      // 
      // fbdTarget
      // 
      this.fbdTarget.RootFolder = System.Environment.SpecialFolder.MyComputer;
      // 
      // epSource
      // 
      this.epSource.ContainerControl = this;
      // 
      // epTarget
      // 
      this.epTarget.ContainerControl = this;
      // 
      // ImportOptionsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(696, 237);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnImport);
      this.Controls.Add(this.gbDistributeOptions);
      this.Controls.Add(this.gbImportOptions);
      this.Controls.Add(this.gbPaths);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ImportOptionsForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Import options";
      this.Load += new System.EventHandler(this.ImportOptionsForm_Load);
      this.gbPaths.ResumeLayout(false);
      this.gbPaths.PerformLayout();
      this.gbImportOptions.ResumeLayout(false);
      this.gbImportOptions.PerformLayout();
      this.gbDistributeOptions.ResumeLayout(false);
      this.gbDistributeOptions.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.epSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.epTarget)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox gbPaths;
    private System.Windows.Forms.Label lblSourcePath;
    private System.Windows.Forms.Button btnSourcePath;
    private System.Windows.Forms.TextBox txtSourcePath;
    private System.Windows.Forms.Button btnTargetPath;
    private System.Windows.Forms.TextBox txtTargetPath;
    private System.Windows.Forms.Label lblTargetPath;
    private System.Windows.Forms.CheckBox chkTargetMatchesSourcePath;
    private System.Windows.Forms.GroupBox gbImportOptions;
    private System.Windows.Forms.RadioButton rbCopyFilesOnImport;
    private System.Windows.Forms.RadioButton rbMoveFilesOnImport;
    private System.Windows.Forms.GroupBox gbDistributeOptions;
    private System.Windows.Forms.RadioButton rbCopyFilesOnDistribute;
    private System.Windows.Forms.RadioButton rbMoveFilesOnDistribute;
    private System.Windows.Forms.Button btnImport;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.FolderBrowserDialog fbdSource;
    private System.Windows.Forms.FolderBrowserDialog fbdTarget;
    private System.Windows.Forms.ErrorProvider epSource;
    private System.Windows.Forms.ErrorProvider epTarget;
  }
}