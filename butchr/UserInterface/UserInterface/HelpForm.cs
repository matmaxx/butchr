using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Matmaxx.Butchr.Properties;

namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// template form to display help screens on each operation
  /// </summary>
  public partial class HelpForm : Form
  {
    #region members
    /// <summary>
    /// The private singleton instace
    /// </summary>
    private static HelpForm instance;
    /// <summary>
    /// Gets the singleton instance.
    /// </summary>
    public static HelpForm Instance 
    { 
      get
      {
        //check if the singleton instance is already created
        if(null == instance)
        {
          //it is not, so create is now
          instance = new HelpForm();
        }
        //return a reference the instance
        return instance;
      }
    }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="HelpForm"/> class.
    /// </summary>
    private HelpForm()
    {
      //designer stuff
      InitializeComponent();
    }
    #endregion

    #region API
    /// <summary>
    /// Shows the help.
    /// </summary>
    /// <param name="owner">The owner window.</param>
    /// <param name="title">The title.</param>
    /// <param name="content">The content.</param>
    /// <param name="enableShowNextTime">if set to <c>true</c> the 'show next time' checkbox is enabled.</param>
    /// <returns>
    /// 	<c>true</c> if the dialog shall be displayed next time, <c>false</c> otherwise.
    /// </returns>
    public bool ShowHelp(IWin32Window owner,string title,string content,bool enableShowNextTime)
    {
      //local result
      bool result = true;
      //set the title of the dialog
      this.Text = title;
      //set the content of the file
      rtbContent.Text = content;
      //always activate the checkbox
      chkShowNextTime.Checked = true;
      //set the enabled state of the checkbox
      chkShowNextTime.Enabled = enableShowNextTime;
      //show this instance of the form as a dialog
      this.ShowDialog(owner);
      //the result is evaluated from the state of the checkbox after closing the form
      result = chkShowNextTime.Checked;
      //finally return a result
      return result;
    }
    #endregion

    #region event handling
    /// <summary>
    /// Handles the Click event of the btnClose control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnClose_Click(object sender, EventArgs e)
    {
      //close this form
      this.Close();
    }
    #endregion
  }
}
