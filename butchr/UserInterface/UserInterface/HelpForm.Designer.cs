namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// template form to display help screens on each operation
  /// </summary>
  partial class HelpForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
      this.rtbContent = new System.Windows.Forms.RichTextBox();
      this.chkShowNextTime = new System.Windows.Forms.CheckBox();
      this.btnClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // rtbContent
      // 
      this.rtbContent.BackColor = System.Drawing.SystemColors.Info;
      this.rtbContent.Dock = System.Windows.Forms.DockStyle.Top;
      this.rtbContent.Location = new System.Drawing.Point(0, 0);
      this.rtbContent.Name = "rtbContent";
      this.rtbContent.ReadOnly = true;
      this.rtbContent.Size = new System.Drawing.Size(633, 435);
      this.rtbContent.TabIndex = 0;
      this.rtbContent.Text = "";
      // 
      // chkShowNextTime
      // 
      this.chkShowNextTime.AutoSize = true;
      this.chkShowNextTime.Location = new System.Drawing.Point(12, 460);
      this.chkShowNextTime.Name = "chkShowNextTime";
      this.chkShowNextTime.Size = new System.Drawing.Size(117, 17);
      this.chkShowNextTime.TabIndex = 1;
      this.chkShowNextTime.Text = "Show this next time";
      this.chkShowNextTime.UseVisualStyleBackColor = true;
      // 
      // btnClose
      // 
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(357, 451);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(264, 33);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "Close help screen";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // HelpForm
      // 
      this.AcceptButton = this.btnClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(633, 496);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.chkShowNextTime);
      this.Controls.Add(this.rtbContent);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "HelpForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Help";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtbContent;
    private System.Windows.Forms.CheckBox chkShowNextTime;
    private System.Windows.Forms.Button btnClose;
  }
}