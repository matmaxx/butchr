using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Matmaxx.Butchr.Properties;

namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// Form to query the autogroup settings from the user
  /// </summary>
  public partial class AutoGroupSettingsForm : Form
  {
    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoGroupSettingsForm"/> class.
    /// </summary>
    public AutoGroupSettingsForm()
    {
      //designer stuff
      InitializeComponent();
      //update from the settings
      nudAutogroupInterval.Value = Settings.Default.AutogroupMinimumInterval;
    }
    #endregion
    
    #region API
    /// <summary>
    /// Shows this form as a dialog.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <returns>
    /// 	<c>true</c> if the dialog was completed, <c>false</c> if it was cancelled.
    /// </returns>
    public bool AutoGroupSettingsDialog(IWin32Window owner)
    {
      //local result 
      bool result = false;
      //show and evaluate the dialog
      if(this.ShowDialog(owner).Equals(DialogResult.OK))
      {
        //this is the only case of a positive result
        result = true;
      }
      //finally return a result
      return result;
    }
    #endregion

    #region event handling
    /// <summary>
    /// Handles the Click event of the btnStartAutogroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnStartAutogroup_Click(object sender, EventArgs e)
    {
      //pressing this button means ok
      this.DialogResult = DialogResult.OK;
    }
    #endregion
  }
}
