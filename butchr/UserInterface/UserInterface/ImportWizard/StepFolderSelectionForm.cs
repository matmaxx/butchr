using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  /// <summary>
  /// Form for wizard step: Source and target folder selection.
  /// </summary>
  public partial class StepFolderSelectionForm : Matmaxx.Butcher.UserInterface.ImportWizard.BaseFormInside
  {
    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="StepFolderSelectionForm"/> class.
    /// </summary>
    public StepFolderSelectionForm()
    {
      //designer stuff
      InitializeComponent();
      //initialize the user interface
      InitializeUserInterface();
    }
    /// <summary>
    /// Initializes the user interface.
    /// </summary>
    private void InitializeUserInterface()
    {
      //update the form caption
      this.Text = Properties.Resources.WizardFormText;
      //update title and description
      Title = Properties.Resources.WizardFolderSelectionTitle;
      Description = Properties.Resources.WizardFolderSelectionDescription;
      //update the folder labels
      lblSource.Text = Properties.Resources.WizardFolderSelectionSourceLabel;
      lblTarget.Text = Properties.Resources.WizardFolderSelectionTargetLabel;
    }
    #endregion

    #region event handler
    /// <summary>
    /// Handles the Load event of the StepFolderSelectionForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void StepFolderSelectionForm_Load(object sender, EventArgs e)
    {
      //check if there was a valid source folder selected before
      if(
          (String.Empty != Properties.Settings.Default.LastSourceFolder) &&
          (Directory.Exists(Properties.Settings.Default.LastSourceFolder))
        )
      {
        //start in the last used folder
        txtSource.Text = Properties.Settings.Default.LastSourceFolder;
      }
      else
      {
        //clear the textbox
        txtSource.Text = string.Empty;
      }
      //check if there was a valid target folder selected before
      if(
          (String.Empty != Properties.Settings.Default.LastTargetFolder) &&
          (Directory.Exists(Properties.Settings.Default.LastTargetFolder))
        )
      {
        //start in the last used folder
        txtTarget.Text = Properties.Settings.Default.LastTargetFolder;
      }
      else
      {
        //clear the textbox
        txtTarget.Text = string.Empty;
      }
    }
    /// <summary>
    /// Handles the Click event of the btnSource control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnSource_Click(object sender, EventArgs e)
    {
      //show the folder-browser-dialog to select an existing folder
      if(SelectSourceFolder())
      {
        //update the textbox
        txtSource.Text = fbdSource.SelectedPath;
      }
    }
    /// <summary>
    /// Handles the Click event of the btnTarget control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnTarget_Click(object sender, EventArgs e)
    {
      //show the folder-browser-dialog to select an existing folder
      if(SelectTargetFolder())
      {
        //update the textbox
        txtTarget.Text = fbdTarget.SelectedPath;
      }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtSource control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void txtPaths_TextChanged(object sender, EventArgs e)
    {
      //allow advancing only if all paths are valid
      if(ValidateInput())
      {
        Data.SourcePath = txtSource.Text.Trim();
        Data.TargetPath = txtTarget.Text.Trim();
      }
    }
    #endregion

    #region helper functions
    /// <summary>
    /// Selects the target folder.
    /// </summary>
    /// <returns><c>true</c> if the selection was successful,<c>false</c> otherwise.</returns>
    private bool SelectSourceFolder()
    {
      //local result
      bool retval = false;
      //check if a folder was already selected in a previous session
      if(
          (String.Empty != Properties.Settings.Default.LastSourceFolder) &&
          (Directory.Exists(Properties.Settings.Default.LastSourceFolder))
        )
      {
        //start in the last used folder
        fbdSource.SelectedPath = Properties.Settings.Default.LastSourceFolder;
      }
      else
      {
        //start at the rootfolder
        fbdSource.SelectedPath = fbdSource.RootFolder.ToString();
      }
      //set the description text
      fbdSource.Description = Properties.Resources.WizardFolderSelectionFbdSourceDescription;
      //show the dialog
      DialogResult result = fbdSource.ShowDialog();
      //check if the user pressed ok
      if (result == DialogResult.OK)
      {
        //check if the folder contains images
        if (ImportImageManager.GetDisplayableImages(fbdSource.SelectedPath).Count > 0)
        {
          //backup the new path
          Properties.Settings.Default.LastSourceFolder = fbdSource.SelectedPath;
          //store the source folder
          Properties.Settings.Default.Save();
          //finally return the success
          retval = true;
        }
        else
        {
          //display the failure
          txtSource.Text = Properties.Resources.WizardFolderSelectionNoImages;
        }
      }
      //finally return the result
      return retval;
    }
    /// <summary>
    /// Selects the source folder.
    /// </summary>
    /// <returns><c>true</c> if the selection was successful,<c>false</c> otherwise.</returns>
    private bool SelectTargetFolder()
    {
      //local result
      bool retval = false;
      //check if a folder was already selected in a previous session
      if (
          (String.Empty != Properties.Settings.Default.LastTargetFolder) &&
          (Directory.Exists(Properties.Settings.Default.LastTargetFolder))
        )
      {
        //start in the last used folder
        fbdTarget.SelectedPath = Properties.Settings.Default.LastTargetFolder;
      }
      else
      {
        //start at the rootfolder
        fbdTarget.SelectedPath = fbdTarget.RootFolder.ToString();
      }
      //set the description text
      fbdSource.Description = Properties.Resources.WizardFolderSelectionFbdTargetDescription;
      //show the dialog
      DialogResult result = fbdTarget.ShowDialog();
      //check if the user pressed ok
      if (result == DialogResult.OK)
      {
        //backup the new path
        Properties.Settings.Default.LastTargetFolder = fbdTarget.SelectedPath;
        //store the source folder
        Properties.Settings.Default.Save();
        //finally return the success
        retval = true;
      }
      //finally return the result
      return retval;
    }
    /// <summary>
    /// Validates the selected paths.
    /// </summary>
    /// <returns><c>true</c> if all paths are valid, <c>false</c> otherwise.</returns>
    private bool ValidateInput()
    {
      //optimistic return value
      bool retval = true;
      //check if the source folder is invalid
      if(false == Directory.Exists(txtSource.Text)) retval = false;
      //check if the target folder is invalid
      if(false == Directory.Exists(txtTarget.Text)) retval = false;
      //finally return the result
      return retval;
    }
    #endregion
  }
}