using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Matmaxx.Butchr.Application;
using Matmaxx.Butchr.Properties;

namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// Handles the conflict if a target file already exists on a copy or move operation.
  /// </summary>
  public partial class ExistingFileStrategyForm : Form
  {
    #region members
    /// <summary>
    /// local instance of the returning strategy.
    /// </summary>
    ImageManager.ExistingFileStrategy strategy = ImageManager.ExistingFileStrategy.None;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="ExistingFileStrategyForm"/> class.
    /// </summary>
    public ExistingFileStrategyForm()
    {
      InitializeComponent();
    }
    #endregion

    #region API
    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="source">The source file.</param>
    /// <param name="target">The target file.</param>
    /// <returns>
    /// The strategy to proceed with this and further files.
    /// </returns>
    public ImageManager.ExistingFileStrategy ShowDialog(string source,string target)
    {
      //try to set the source image
      TrySetImage(this.pbSource,source);
      //set the target image
      TrySetImage(this.pbTarget,target);
      //set the paths
      lblSourcePath.Text = String.Format(Resources.ExistingFileDialogSource,source);
      lblTargetPath.Text = String.Format(Resources.ExistingFileDialogTarget,target);
      //show the dialog
      //this.ShowDialog((IWin32Window)this.Tag);
      this.ShowDialog();
      //finally return the user's decision
      return strategy;
    }
    /// <summary>
    /// Failsafe try to load the image into the picturebox.
    /// $$$wl TODO: Test how .nef/.dng file behave in this situation.
    /// </summary>
    /// <param name="pictureBox">The picture box.</param>
    /// <param name="picture">The picture.</param>
    private void TrySetImage(PictureBox pictureBox, string picture)
    {
      try
      {
        //reset any old image
        pictureBox.Image = null;
        //try to display the image
        pictureBox.Image = Image.FromFile(picture);    
      }
      catch (Exception)
      {
        //image cannot be displayed, clean the picturebox
        pictureBox.Image = null;
        pictureBox.BackColor = Color.Black;
      }
    }
    #endregion

    #region event handler

    #region buttons
    /// <summary>
    /// Handles the Click event of the btnOverwrite control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnOverwrite_Click(object sender, EventArgs e)
    {
      //remember the strategy
      strategy = ImageManager.ExistingFileStrategy.OverwriteOnce;
      //force the end of the dialog
      this.Close();
    }
    /// <summary>
    /// Handles the Click event of the btnSkip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnSkip_Click(object sender, EventArgs e)
    {
      //remember the strategy
      strategy = ImageManager.ExistingFileStrategy.SkipOnce;
      //force the end of the dialog
      this.Close();
    }
    /// <summary>
    /// Handles the Click event of the btnOverwriteAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnOverwriteAll_Click(object sender, EventArgs e)
    {
      //remember the strategy
      strategy = ImageManager.ExistingFileStrategy.OverwriteAll;
      //force the end of the dialog
      this.Close();
    }
    /// <summary>
    /// Handles the Click event of the btnSkipAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnSkipAll_Click(object sender, EventArgs e)
    {
      //remember the strategy
      strategy = ImageManager.ExistingFileStrategy.SkipAll;
      //force the end of the dialog
      this.Close();
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnCancel_Click(object sender, EventArgs e)
    {
      //remember the strategy
      strategy = ImageManager.ExistingFileStrategy.Cancel;
      //force the end of the dialog
      this.Close();
    }
    #endregion

    private void ExistingFileStrategyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      pbSource.Image.Dispose();
      pbTarget.Image.Dispose();
      pbSource.Image = null;
      pbTarget.Image = null;
      pbSource.Dispose();
      pbTarget.Dispose();
    }

    #endregion


  }
}