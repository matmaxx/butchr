namespace Matmaxx.Butchr.UserInterface
{
  partial class AboutForm
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
      this.labelProductName = new System.Windows.Forms.Label();
      this.labelCompanyUrl = new System.Windows.Forms.Label();
      this.labelDescription = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // labelProductName
      // 
      this.labelProductName.AutoSize = true;
      this.labelProductName.BackColor = System.Drawing.Color.Transparent;
      this.labelProductName.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelProductName.Location = new System.Drawing.Point(119, 17);
      this.labelProductName.Name = "labelProductName";
      this.labelProductName.Size = new System.Drawing.Size(251, 29);
      this.labelProductName.TabIndex = 0;
      this.labelProductName.Text = "The butchr 1.0.0";
      this.labelProductName.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.labelProductName.Click += new System.EventHandler(this.AboutForm_Click);
      // 
      // labelCompanyUrl
      // 
      this.labelCompanyUrl.AutoSize = true;
      this.labelCompanyUrl.BackColor = System.Drawing.Color.Transparent;
      this.labelCompanyUrl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelCompanyUrl.Location = new System.Drawing.Point(151, 47);
      this.labelCompanyUrl.Name = "labelCompanyUrl";
      this.labelCompanyUrl.Size = new System.Drawing.Size(215, 18);
      this.labelCompanyUrl.TabIndex = 1;
      this.labelCompanyUrl.Text = "http://www.matmaxx.org";
      this.labelCompanyUrl.Click += new System.EventHandler(this.AboutForm_Click);
      // 
      // labelDescription
      // 
      this.labelDescription.BackColor = System.Drawing.Color.Transparent;
      this.labelDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelDescription.Location = new System.Drawing.Point(99, 75);
      this.labelDescription.Name = "labelDescription";
      this.labelDescription.Size = new System.Drawing.Size(296, 102);
      this.labelDescription.TabIndex = 2;
      this.labelDescription.Text = "These pixels were born to be{1}punished and butchred";
      this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.labelDescription.Click += new System.EventHandler(this.AboutForm_Click);
      // 
      // AboutForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.BackgroundImage = global::Matmaxx.Butchr.Properties.Resources.butchr_logo__400x200;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(382, 183);
      this.Controls.Add(this.labelDescription);
      this.Controls.Add(this.labelCompanyUrl);
      this.Controls.Add(this.labelProductName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutForm";
      this.Padding = new System.Windows.Forms.Padding(9);
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About";
      this.Click += new System.EventHandler(this.AboutForm_Click);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutForm_KeyDown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelProductName;
    private System.Windows.Forms.Label labelCompanyUrl;
    private System.Windows.Forms.Label labelDescription;


  }
}
