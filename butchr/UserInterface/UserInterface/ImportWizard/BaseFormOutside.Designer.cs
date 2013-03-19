namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  partial class BaseFormOutside
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFormOutside));
      this.btnNext = new System.Windows.Forms.Button();
      this.btnBack = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.pbOutside = new System.Windows.Forms.PictureBox();
      this.lblDescription = new System.Windows.Forms.Label();
      this.lblTitle = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pbOutside)).BeginInit();
      this.SuspendLayout();
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
      // pbOutside
      // 
      this.pbOutside.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pbOutside.Image = global::Matmaxx.Butcher.Properties.Resources.GenericCar;
      resources.ApplyResources(this.pbOutside, "pbOutside");
      this.pbOutside.Name = "pbOutside";
      this.pbOutside.TabStop = false;
      // 
      // lblDescription
      // 
      resources.ApplyResources(this.lblDescription, "lblDescription");
      this.lblDescription.Name = "lblDescription";
      // 
      // lblTitle
      // 
      resources.ApplyResources(this.lblTitle, "lblTitle");
      this.lblTitle.Name = "lblTitle";
      // 
      // BaseFormOutside
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblDescription);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.pbOutside);
      this.Name = "BaseFormOutside";
      this.ShowInTaskbar = false;
      this.Controls.SetChildIndex(this.pbOutside, 0);
      this.Controls.SetChildIndex(this.lblTitle, 0);
      this.Controls.SetChildIndex(this.lblDescription, 0);
      ((System.ComponentModel.ISupportInitialize)(this.pbOutside)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.PictureBox pbOutside;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Label lblTitle;
  }
}