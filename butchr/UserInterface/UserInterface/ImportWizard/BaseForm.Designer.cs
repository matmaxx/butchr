namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  partial class BaseForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
      this.AbortButtonInternal = new System.Windows.Forms.Button();
      this.NextButtonInternal = new System.Windows.Forms.Button();
      this.BackButtonInternal = new System.Windows.Forms.Button();
      this.pnlButtons = new System.Windows.Forms.Panel();
      this.pnlButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // AbortButtonInternal
      // 
      resources.ApplyResources(this.AbortButtonInternal, "AbortButtonInternal");
      this.AbortButtonInternal.Name = "AbortButtonInternal";
      this.AbortButtonInternal.UseVisualStyleBackColor = true;
      this.AbortButtonInternal.Click += new System.EventHandler(this.AbortButton_Click);
      // 
      // NextButtonInternal
      // 
      resources.ApplyResources(this.NextButtonInternal, "NextButtonInternal");
      this.NextButtonInternal.Name = "NextButtonInternal";
      this.NextButtonInternal.UseVisualStyleBackColor = true;
      this.NextButtonInternal.Click += new System.EventHandler(this.NextButton_Click);
      // 
      // BackButtonInternal
      // 
      resources.ApplyResources(this.BackButtonInternal, "BackButtonInternal");
      this.BackButtonInternal.Name = "BackButtonInternal";
      this.BackButtonInternal.UseVisualStyleBackColor = true;
      this.BackButtonInternal.Click += new System.EventHandler(this.BackButton_Click);
      // 
      // pnlButtons
      // 
      this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
      this.pnlButtons.Controls.Add(this.BackButtonInternal);
      this.pnlButtons.Controls.Add(this.AbortButtonInternal);
      this.pnlButtons.Controls.Add(this.NextButtonInternal);
      resources.ApplyResources(this.pnlButtons, "pnlButtons");
      this.pnlButtons.Name = "pnlButtons";
      // 
      // BaseForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ControlBox = false;
      this.Controls.Add(this.pnlButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "BaseForm";
      this.pnlButtons.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button AbortButtonInternal;
    private System.Windows.Forms.Button NextButtonInternal;
    private System.Windows.Forms.Button BackButtonInternal;
    private System.Windows.Forms.Panel pnlButtons;


  }
}