using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Matmaxx.Butchr.Properties;

namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// The about dialog.
  /// </summary>
  partial class AboutForm : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AboutForm"/> class.
    /// </summary>
    public AboutForm()
    {
      //Designer stuff
      InitializeComponent();
      labelProductName.Text = string.Format("{0} {1}", Resources.ApplicationName, Butchr.Version);
      labelCompanyUrl.Text = "http://www.matmaxx.net";
      labelDescription.Text = string.Format("Copyright 2009-{0}{1}Matthias 'matmaxx' Weigel{1}{1}{1}These pixels are there {1}to get punished and butchred...", DateTime.Now.Year, Environment.NewLine);
    }

    private void AboutForm_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void AboutForm_KeyDown(object sender, KeyEventArgs e)
    {
      this.Close();
    }
  }
}
