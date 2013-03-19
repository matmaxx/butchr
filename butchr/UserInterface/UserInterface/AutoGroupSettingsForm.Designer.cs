namespace Matmaxx.Butchr.UserInterface
{
  partial class AutoGroupSettingsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGroupSettingsForm));
      this.nudAutogroupInterval = new System.Windows.Forms.NumericUpDown();
      this.lblSeconds = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.btnStartAutogroup = new System.Windows.Forms.Button();
      this.gbAutogroupInterval = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.nudAutogroupInterval)).BeginInit();
      this.gbAutogroupInterval.SuspendLayout();
      this.SuspendLayout();
      // 
      // nudAutogroupInterval
      // 
      this.nudAutogroupInterval.Location = new System.Drawing.Point(9, 78);
      this.nudAutogroupInterval.Name = "nudAutogroupInterval";
      this.nudAutogroupInterval.Size = new System.Drawing.Size(101, 20);
      this.nudAutogroupInterval.TabIndex = 0;
      this.nudAutogroupInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // lblSeconds
      // 
      this.lblSeconds.AutoSize = true;
      this.lblSeconds.Location = new System.Drawing.Point(116, 80);
      this.lblSeconds.Name = "lblSeconds";
      this.lblSeconds.Size = new System.Drawing.Size(47, 13);
      this.lblSeconds.TabIndex = 1;
      this.lblSeconds.Text = "seconds";
      // 
      // label1
      // 
      this.label1.AutoEllipsis = true;
      this.label1.Location = new System.Drawing.Point(6, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(159, 59);
      this.label1.TabIndex = 2;
      this.label1.Text = "Please specifiy the maximum timespan in seconds between two shots in order to be " +
          "treated as one series of brackets.";
      // 
      // btnStartAutogroup
      // 
      this.btnStartAutogroup.Location = new System.Drawing.Point(10, 127);
      this.btnStartAutogroup.Name = "btnStartAutogroup";
      this.btnStartAutogroup.Size = new System.Drawing.Size(169, 26);
      this.btnStartAutogroup.TabIndex = 3;
      this.btnStartAutogroup.Text = "Start autogroup";
      this.btnStartAutogroup.UseVisualStyleBackColor = true;
      this.btnStartAutogroup.Click += new System.EventHandler(this.btnStartAutogroup_Click);
      // 
      // gbAutogroupInterval
      // 
      this.gbAutogroupInterval.Controls.Add(this.label1);
      this.gbAutogroupInterval.Controls.Add(this.nudAutogroupInterval);
      this.gbAutogroupInterval.Controls.Add(this.lblSeconds);
      this.gbAutogroupInterval.Location = new System.Drawing.Point(10, 12);
      this.gbAutogroupInterval.Name = "gbAutogroupInterval";
      this.gbAutogroupInterval.Size = new System.Drawing.Size(169, 109);
      this.gbAutogroupInterval.TabIndex = 4;
      this.gbAutogroupInterval.TabStop = false;
      // 
      // AutoGroupSettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(189, 161);
      this.Controls.Add(this.gbAutogroupInterval);
      this.Controls.Add(this.btnStartAutogroup);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AutoGroupSettingsForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Autogroup settings";
      ((System.ComponentModel.ISupportInitialize)(this.nudAutogroupInterval)).EndInit();
      this.gbAutogroupInterval.ResumeLayout(false);
      this.gbAutogroupInterval.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NumericUpDown nudAutogroupInterval;
    private System.Windows.Forms.Label lblSeconds;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnStartAutogroup;
    private System.Windows.Forms.GroupBox gbAutogroupInterval;
  }
}