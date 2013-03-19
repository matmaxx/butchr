namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  partial class StepFolderSelectionForm
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
      this.fbdSource = new System.Windows.Forms.FolderBrowserDialog();
      this.fbdTarget = new System.Windows.Forms.FolderBrowserDialog();
      this.lblSource = new System.Windows.Forms.Label();
      this.txtSource = new System.Windows.Forms.TextBox();
      this.btnSource = new System.Windows.Forms.Button();
      this.lblTarget = new System.Windows.Forms.Label();
      this.txtTarget = new System.Windows.Forms.TextBox();
      this.btnTarget = new System.Windows.Forms.Button();
      this.SuspendLayout();
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
      // lblSource
      // 
      this.lblSource.AutoSize = true;
      this.lblSource.Location = new System.Drawing.Point(22, 172);
      this.lblSource.Name = "lblSource";
      this.lblSource.Size = new System.Drawing.Size(75, 13);
      this.lblSource.TabIndex = 9;
      this.lblSource.Text = "lblSource.Text";
      // 
      // txtSource
      // 
      this.txtSource.Location = new System.Drawing.Point(116, 169);
      this.txtSource.Name = "txtSource";
      this.txtSource.Size = new System.Drawing.Size(406, 20);
      this.txtSource.TabIndex = 10;
      this.txtSource.TextChanged += new System.EventHandler(this.txtPaths_TextChanged);
      // 
      // btnSource
      // 
      this.btnSource.Location = new System.Drawing.Point(528, 169);
      this.btnSource.Name = "btnSource";
      this.btnSource.Size = new System.Drawing.Size(29, 20);
      this.btnSource.TabIndex = 11;
      this.btnSource.Text = "...";
      this.btnSource.UseVisualStyleBackColor = true;
      this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
      // 
      // lblTarget
      // 
      this.lblTarget.AutoSize = true;
      this.lblTarget.Location = new System.Drawing.Point(22, 198);
      this.lblTarget.Name = "lblTarget";
      this.lblTarget.Size = new System.Drawing.Size(72, 13);
      this.lblTarget.TabIndex = 9;
      this.lblTarget.Text = "lblTarget.Text";
      // 
      // txtTarget
      // 
      this.txtTarget.Location = new System.Drawing.Point(116, 195);
      this.txtTarget.Name = "txtTarget";
      this.txtTarget.Size = new System.Drawing.Size(406, 20);
      this.txtTarget.TabIndex = 10;
      this.txtTarget.TextChanged += new System.EventHandler(this.txtPaths_TextChanged);
      // 
      // btnTarget
      // 
      this.btnTarget.Location = new System.Drawing.Point(528, 195);
      this.btnTarget.Name = "btnTarget";
      this.btnTarget.Size = new System.Drawing.Size(29, 20);
      this.btnTarget.TabIndex = 11;
      this.btnTarget.Text = "...";
      this.btnTarget.UseVisualStyleBackColor = true;
      this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
      // 
      // StepFolderSelectionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(644, 486);
      this.Controls.Add(this.txtSource);
      this.Controls.Add(this.txtTarget);
      this.Controls.Add(this.lblTarget);
      this.Controls.Add(this.lblSource);
      this.Controls.Add(this.btnTarget);
      this.Controls.Add(this.btnSource);
      this.Name = "StepFolderSelectionForm";
      this.Text = "StepFolderSelectionForm";
      this.Load += new System.EventHandler(this.StepFolderSelectionForm_Load);
      this.Controls.SetChildIndex(this.btnSource, 0);
      this.Controls.SetChildIndex(this.btnTarget, 0);
      this.Controls.SetChildIndex(this.lblSource, 0);
      this.Controls.SetChildIndex(this.lblTarget, 0);
      this.Controls.SetChildIndex(this.txtTarget, 0);
      this.Controls.SetChildIndex(this.txtSource, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.FolderBrowserDialog fbdSource;
    private System.Windows.Forms.FolderBrowserDialog fbdTarget;
    private System.Windows.Forms.Label lblSource;
    private System.Windows.Forms.TextBox txtSource;
    private System.Windows.Forms.Button btnSource;
    private System.Windows.Forms.Label lblTarget;
    private System.Windows.Forms.TextBox txtTarget;
    private System.Windows.Forms.Button btnTarget;

  }
}