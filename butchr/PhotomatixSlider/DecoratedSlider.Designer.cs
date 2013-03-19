namespace Matmaxx.Toolbox
{
  partial class DecoratedSlider
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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tbValue = new System.Windows.Forms.TrackBar();
      this.lblCaption = new System.Windows.Forms.Label();
      this.lblValueRaw = new System.Windows.Forms.Label();
      this.txtValuePhy = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.tbValue)).BeginInit();
      this.SuspendLayout();
      // 
      // tbValue
      // 
      this.tbValue.Location = new System.Drawing.Point(3, 19);
      this.tbValue.Name = "tbValue";
      this.tbValue.Size = new System.Drawing.Size(397, 45);
      this.tbValue.TabIndex = 0;
      this.tbValue.TabStop = false;
      this.tbValue.TickStyle = System.Windows.Forms.TickStyle.None;
      this.tbValue.Scroll += new System.EventHandler(this.tbValue_Scroll);
      // 
      // lblCaption
      // 
      this.lblCaption.AutoSize = true;
      this.lblCaption.Location = new System.Drawing.Point(12, 6);
      this.lblCaption.Name = "lblCaption";
      this.lblCaption.Size = new System.Drawing.Size(79, 13);
      this.lblCaption.TabIndex = 2;
      this.lblCaption.Text = "Enter a caption";
      // 
      // lblValueRaw
      // 
      this.lblValueRaw.AutoSize = true;
      this.lblValueRaw.Location = new System.Drawing.Point(183, 6);
      this.lblValueRaw.Name = "lblValueRaw";
      this.lblValueRaw.Size = new System.Drawing.Size(13, 13);
      this.lblValueRaw.TabIndex = 3;
      this.lblValueRaw.Text = "0";
      this.lblValueRaw.Visible = false;
      // 
      // txtValuePhy
      // 
      this.txtValuePhy.BackColor = System.Drawing.SystemColors.Control;
      this.txtValuePhy.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtValuePhy.Location = new System.Drawing.Point(328, 6);
      this.txtValuePhy.Name = "txtValuePhy";
      this.txtValuePhy.Size = new System.Drawing.Size(52, 13);
      this.txtValuePhy.TabIndex = 4;
      this.txtValuePhy.Text = "0";
      this.txtValuePhy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtValuePhy.Click += new System.EventHandler(this.txtValuePhy_Click);
      this.txtValuePhy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValuePhy_KeyDown);
      // 
      // DecoratedSlider
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtValuePhy);
      this.Controls.Add(this.lblValueRaw);
      this.Controls.Add(this.lblCaption);
      this.Controls.Add(this.tbValue);
      this.MaximumSize = new System.Drawing.Size(0, 45);
      this.MinimumSize = new System.Drawing.Size(200, 45);
      this.Name = "DecoratedSlider";
      this.Size = new System.Drawing.Size(200, 45);
      this.Load += new System.EventHandler(this.DecoratedSlider_Load);
      this.Resize += new System.EventHandler(this.DecoratedSlider_Resize);
      ((System.ComponentModel.ISupportInitialize)(this.tbValue)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TrackBar tbValue;
    private System.Windows.Forms.Label lblCaption;
    private System.Windows.Forms.Label lblValueRaw;
    private System.Windows.Forms.TextBox txtValuePhy;
  }
}
