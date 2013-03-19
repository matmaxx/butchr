namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  partial class BaseFormInside
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFormInside));
      this.pbBanner = new System.Windows.Forms.PictureBox();
      this.lblTitle = new System.Windows.Forms.Label();
      this.lblDescription = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
      this.SuspendLayout();
      // 
      // pbBanner
      // 
      this.pbBanner.BackColor = System.Drawing.SystemColors.Control;
      this.pbBanner.Image = global::Matmaxx.Butcher.Properties.Resources.wizard;
      resources.ApplyResources(this.pbBanner, "pbBanner");
      this.pbBanner.Name = "pbBanner";
      this.pbBanner.TabStop = false;
      // 
      // lblTitle
      // 
      resources.ApplyResources(this.lblTitle, "lblTitle");
      this.lblTitle.Name = "lblTitle";
      // 
      // lblDescription
      // 
      resources.ApplyResources(this.lblDescription, "lblDescription");
      this.lblDescription.Name = "lblDescription";
      // 
      // BaseFormInside
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblDescription);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.pbBanner);
      this.Name = "BaseFormInside";
      this.ShowInTaskbar = false;
      this.Controls.SetChildIndex(this.pbBanner, 0);
      this.Controls.SetChildIndex(this.lblTitle, 0);
      this.Controls.SetChildIndex(this.lblDescription, 0);
      ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pbBanner;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblDescription;


  }
}