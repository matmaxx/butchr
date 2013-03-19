namespace Matmaxx.Butchr.UserInterface
{
  partial class ExistingFileStrategyForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExistingFileStrategyForm));
      this.btnOverwrite = new System.Windows.Forms.Button();
      this.btnSkip = new System.Windows.Forms.Button();
      this.btnOverwriteAll = new System.Windows.Forms.Button();
      this.btnSkipAll = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.pbSource = new System.Windows.Forms.PictureBox();
      this.pbTarget = new System.Windows.Forms.PictureBox();
      this.lblSourceImage = new System.Windows.Forms.Label();
      this.lblTargetImage = new System.Windows.Forms.Label();
      this.lblSourcePath = new System.Windows.Forms.Label();
      this.lblTargetPath = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.gbText = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).BeginInit();
      this.gbText.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOverwrite
      // 
      resources.ApplyResources(this.btnOverwrite, "btnOverwrite");
      this.btnOverwrite.Name = "btnOverwrite";
      this.btnOverwrite.UseVisualStyleBackColor = true;
      this.btnOverwrite.Click += new System.EventHandler(this.btnOverwrite_Click);
      // 
      // btnSkip
      // 
      resources.ApplyResources(this.btnSkip, "btnSkip");
      this.btnSkip.Name = "btnSkip";
      this.btnSkip.UseVisualStyleBackColor = true;
      this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
      // 
      // btnOverwriteAll
      // 
      resources.ApplyResources(this.btnOverwriteAll, "btnOverwriteAll");
      this.btnOverwriteAll.Name = "btnOverwriteAll";
      this.btnOverwriteAll.UseVisualStyleBackColor = true;
      this.btnOverwriteAll.Click += new System.EventHandler(this.btnOverwriteAll_Click);
      // 
      // btnSkipAll
      // 
      resources.ApplyResources(this.btnSkipAll, "btnSkipAll");
      this.btnSkipAll.Name = "btnSkipAll";
      this.btnSkipAll.UseVisualStyleBackColor = true;
      this.btnSkipAll.Click += new System.EventHandler(this.btnSkipAll_Click);
      // 
      // btnCancel
      // 
      resources.ApplyResources(this.btnCancel, "btnCancel");
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // pbSource
      // 
      resources.ApplyResources(this.pbSource, "pbSource");
      this.pbSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pbSource.Name = "pbSource";
      this.pbSource.TabStop = false;
      // 
      // pbTarget
      // 
      resources.ApplyResources(this.pbTarget, "pbTarget");
      this.pbTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pbTarget.Name = "pbTarget";
      this.pbTarget.TabStop = false;
      // 
      // lblSourceImage
      // 
      resources.ApplyResources(this.lblSourceImage, "lblSourceImage");
      this.lblSourceImage.Name = "lblSourceImage";
      // 
      // lblTargetImage
      // 
      resources.ApplyResources(this.lblTargetImage, "lblTargetImage");
      this.lblTargetImage.Name = "lblTargetImage";
      // 
      // lblSourcePath
      // 
      resources.ApplyResources(this.lblSourcePath, "lblSourcePath");
      this.lblSourcePath.Name = "lblSourcePath";
      // 
      // lblTargetPath
      // 
      resources.ApplyResources(this.lblTargetPath, "lblTargetPath");
      this.lblTargetPath.Name = "lblTargetPath";
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // gbText
      // 
      this.gbText.Controls.Add(this.label1);
      this.gbText.Controls.Add(this.lblSourcePath);
      this.gbText.Controls.Add(this.lblTargetPath);
      resources.ApplyResources(this.gbText, "gbText");
      this.gbText.Name = "gbText";
      this.gbText.TabStop = false;
      // 
      // ExistingFileStrategyForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.gbText);
      this.Controls.Add(this.lblTargetImage);
      this.Controls.Add(this.lblSourceImage);
      this.Controls.Add(this.pbTarget);
      this.Controls.Add(this.pbSource);
      this.Controls.Add(this.btnOverwriteAll);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSkipAll);
      this.Controls.Add(this.btnSkip);
      this.Controls.Add(this.btnOverwrite);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ExistingFileStrategyForm";
      this.ShowIcon = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExistingFileStrategyForm_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).EndInit();
      this.gbText.ResumeLayout(false);
      this.gbText.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOverwrite;
    private System.Windows.Forms.Button btnSkip;
    private System.Windows.Forms.Button btnOverwriteAll;
    private System.Windows.Forms.Button btnSkipAll;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.PictureBox pbSource;
    private System.Windows.Forms.PictureBox pbTarget;
    private System.Windows.Forms.Label lblSourceImage;
    private System.Windows.Forms.Label lblTargetImage;
    private System.Windows.Forms.Label lblSourcePath;
    private System.Windows.Forms.Label lblTargetPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox gbText;
  }
}