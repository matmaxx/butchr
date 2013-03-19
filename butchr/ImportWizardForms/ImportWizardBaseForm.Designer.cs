namespace Matmaxx.Butcher.ImportWizardForms
{
  partial class ImportWizardBaseForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportWizardBaseForm));
      this.splitHorizontal = new System.Windows.Forms.SplitContainer();
      this.splitVertical = new System.Windows.Forms.SplitContainer();
      this.pbBanner = new System.Windows.Forms.PictureBox();
      this.btnNext = new System.Windows.Forms.Button();
      this.btnBack = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.splitHorizontal.Panel1.SuspendLayout();
      this.splitHorizontal.Panel2.SuspendLayout();
      this.splitHorizontal.SuspendLayout();
      this.splitVertical.Panel1.SuspendLayout();
      this.splitVertical.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
      this.SuspendLayout();
      // 
      // splitHorizontal
      // 
      resources.ApplyResources(this.splitHorizontal, "splitHorizontal");
      this.splitHorizontal.Name = "splitHorizontal";
      // 
      // splitHorizontal.Panel1
      // 
      this.splitHorizontal.Panel1.Controls.Add(this.splitVertical);
      // 
      // splitHorizontal.Panel2
      // 
      this.splitHorizontal.Panel2.Controls.Add(this.btnCancel);
      this.splitHorizontal.Panel2.Controls.Add(this.btnBack);
      this.splitHorizontal.Panel2.Controls.Add(this.btnNext);
      // 
      // splitVertical
      // 
      resources.ApplyResources(this.splitVertical, "splitVertical");
      this.splitVertical.Name = "splitVertical";
      // 
      // splitVertical.Panel1
      // 
      this.splitVertical.Panel1.Controls.Add(this.pbBanner);
      // 
      // pbBanner
      // 
      resources.ApplyResources(this.pbBanner, "pbBanner");
      this.pbBanner.Image = global::Matmaxx.Butcher.ImportWizardForms.Properties.Resources.GenericCar;
      this.pbBanner.Name = "pbBanner";
      this.pbBanner.TabStop = false;
      // 
      // btnNext
      // 
      resources.ApplyResources(this.btnNext, "btnNext");
      this.btnNext.Name = "btnNext";
      this.btnNext.UseVisualStyleBackColor = true;
      // 
      // btnBack
      // 
      resources.ApplyResources(this.btnBack, "btnBack");
      this.btnBack.Name = "btnBack";
      this.btnBack.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      resources.ApplyResources(this.btnCancel, "btnCancel");
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // ImportWizardBaseForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ControlBox = false;
      this.Controls.Add(this.splitHorizontal);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ImportWizardBaseForm";
      this.splitHorizontal.Panel1.ResumeLayout(false);
      this.splitHorizontal.Panel2.ResumeLayout(false);
      this.splitHorizontal.ResumeLayout(false);
      this.splitVertical.Panel1.ResumeLayout(false);
      this.splitVertical.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pbBanner;
    private System.Windows.Forms.SplitContainer splitHorizontal;
    private System.Windows.Forms.SplitContainer splitVertical;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnBack;
  }
}