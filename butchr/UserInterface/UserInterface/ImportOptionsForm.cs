using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Matmaxx.Butchr.Application;
using Matmaxx.Butchr.Properties;

namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// handles the import process in a more polite way than the standard filesystem pickers.
  /// </summary>
  public partial class ImportOptionsForm : Form
  {
    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportOptionsForm"/> class.
    /// </summary>
    public ImportOptionsForm()
    {
      //designer stuff
      InitializeComponent();
      //initialize the controls
      InitializePaths();
      //initialize the copy/move options
      InitializeCopyOptions();
    }
    /// <summary>
    /// Initializes the paths.
    /// </summary>
    private void InitializePaths()
    {
      //check if the last source folder is valid
      if(
          (String.Empty != Settings.Default.LastSourceFolder) &&
          (Directory.Exists(Settings.Default.LastSourceFolder))
        )
      {
        //start in the last used folder
        txtSourcePath.Text = Settings.Default.LastSourceFolder;
      }
      else
      {
        //start at the user's home directory
        txtSourcePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //save back the new source folder
        Settings.Default.LastSourceFolder = txtSourcePath.Text;
        //save the settings
        Settings.Default.Save();
      }
      //check if a folder was already selected in a previous session
      if (
          (String.Empty != Settings.Default.LastTargetFolder) &&
          (Directory.Exists(Settings.Default.LastTargetFolder))
        )
      {
        //start in the last used folder
        txtTargetPath.Text = Settings.Default.LastTargetFolder;
      }
      else
      {
        //start at the user's home directory
        txtTargetPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //save back the new target folder
        Settings.Default.LastTargetFolder = txtTargetPath.Text;
        //save the settings
        Settings.Default.Save();
      }
      //check if the paths are the same
      if (txtSourcePath.Text.Trim().Equals(txtTargetPath.Text.Trim()))
      {
        //activate the checkbox 
        chkTargetMatchesSourcePath.Checked = true;
        //and disable the target path textbox
        txtTargetPath.Enabled = false;
      }
      else
      {
        //deactivate the checkbox 
        chkTargetMatchesSourcePath.Checked = false;
        //and enable the target path textbox
        txtTargetPath.Enabled = true;
      }
      //save a reference to the errorproviders in the tag
      txtSourcePath.Tag = epSource;
      txtTargetPath.Tag = epTarget;
    }
    /// <summary>
    /// Initializes the copy options.
    /// </summary>
    private void InitializeCopyOptions()
    {
      //set the copy options radiobutton according the the stored settings
      rbMoveFilesOnImport.Checked     = Settings.Default.MoveFilesOnImport;
      rbCopyFilesOnImport.Checked     = !Settings.Default.MoveFilesOnImport;
      rbMoveFilesOnDistribute.Checked = Settings.Default.MoveFilesOnDistribute;
      rbCopyFilesOnDistribute.Checked = !Settings.Default.MoveFilesOnDistribute;
      //set the 'source matches target' checkbox
      chkTargetMatchesSourcePath.Checked = Settings.Default.TargetFolderMatchesSourceFolder;
    }
    #endregion

    #region API
    /// <summary>
    /// Processes the import dialog.
    /// </summary>
    /// <param name="owner">The owning window.</param>
    /// <returns><c>true</c> if the import options were set correctly, <c>false</c> otherwise.</returns>
    public bool ProcessImportDialog(IWin32Window owner)
    {
      //local result
      bool result = false;
      //show this as a modal dialog
      if(this.ShowDialog(owner).Equals(DialogResult.OK))
      {
        //remember the success
        result = true;
      }
      //finally return the result
      return result;
    }
    #endregion

    #region event handler

    #region misc
    /// <summary>
    /// Handles the Load event of the ImportOptionsForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void ImportOptionsForm_Load(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the CheckedChanged event of the chkTargetMatchesSourcePath control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void chkTargetMatchesSourcePath_CheckedChanged(object sender, EventArgs e)
    {
      //backup the new checked state
      Settings.Default.TargetFolderMatchesSourceFolder = chkTargetMatchesSourcePath.Checked;
      //save the settings
      //Settings.Default.Save();
      //check if this is an activation of the checkbox
      if(chkTargetMatchesSourcePath.Checked.Equals(true))
      {
        //disable the target textbox
        txtTargetPath.Enabled = false;
        //set the selected sourcefolder as target
        txtTargetPath.Text = txtSourcePath.Text;
        //update the setting for the target folder
        Settings.Default.LastTargetFolder = txtTargetPath.Text;
      }
      else
      {
        //enable the target textbox, but leave the current text untouched
        txtTargetPath.Enabled = true;
      }
    }
    #endregion
    
    #region buttons
    /// <summary>
    /// Handles the Click event of the btnSourcePath control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnSourcePath_Click(object sender, EventArgs e)
    {
      //select a new source folder
      if(SelectSourceFolder())
      {
        //update the sourcefolder if a valid folder was selected
        txtSourcePath.Text = Settings.Default.LastSourceFolder;
        //check if the 'source matches target' checkbox is activated
        if(chkTargetMatchesSourcePath.Checked.Equals(true))
        {
          //update the setting for the targetfolder
          Settings.Default.LastTargetFolder = Settings.Default.LastSourceFolder;
          //save the settings
          //Settings.Default.Save();
          //update the target textbox
          txtTargetPath.Text = Settings.Default.LastTargetFolder;
        }
      }
    }
    /// <summary>
    /// Handles the Click event of the btnTargetPath control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnTargetPath_Click(object sender, EventArgs e)
    {
      //select a new target folder
      if(SelectTargetFolder())
      {
        //update the targetfolder if a valid folder was selected
        txtTargetPath.Text = Settings.Default.LastTargetFolder;
      }
    }
    /// <summary>
    /// Handles the Click event of the btnImport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnImport_Click(object sender, EventArgs e)
    {
      //check the user inputs
      if(ValidateUserInputs().Equals(true))
      {
        //store the new settings
        StoreUserInputs();
        //inputs are valid, set the dialog result to ok
        this.DialogResult = DialogResult.OK;
        //save the settings explicitly here
        Settings.Default.Save();
      }
      else
      {
        //wait for the user to correct the problem
      }
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnCancel_Click(object sender, EventArgs e)
    {
      //set the global result of the dialog
      this.DialogResult = DialogResult.Cancel;
      //and revert the changes on the settings
      Settings.Default.Reload();
    }
    #endregion

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
          (String.Empty != Settings.Default.LastSourceFolder) &&
          (Directory.Exists(Settings.Default.LastSourceFolder))
        )
      {
        //start in the last used folder
        fbdSource.SelectedPath = Settings.Default.LastSourceFolder;
      }
      else
      {
        //start at the rootfolder
        fbdSource.SelectedPath = fbdSource.RootFolder.ToString();
      }
      //show the dialog
      DialogResult result = fbdSource.ShowDialog(this);
      //check if the user pressed ok
      if (result == DialogResult.OK)
      {
        //check if the folder contains images
        if (GetDisplayableImages(fbdSource.SelectedPath).Count > 0)
        {
          //backup the new path
          Settings.Default.LastSourceFolder = fbdSource.SelectedPath;
          //store the source folder
          Settings.Default.Save();
          //finally return the success
          retval = true;
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
          (String.Empty != Settings.Default.LastTargetFolder) &&
          (Directory.Exists(Settings.Default.LastTargetFolder))
        )
      {
        //start in the last used folder
        fbdTarget.SelectedPath = Settings.Default.LastTargetFolder;
      }
      else
      {
        //start at the rootfolder
        fbdTarget.SelectedPath = fbdTarget.RootFolder.ToString();
      }
      //show the dialog
      DialogResult result = fbdTarget.ShowDialog();
      //check if the user pressed ok
      if (result == DialogResult.OK)
      {
        //backup the new path
        Settings.Default.LastTargetFolder = fbdTarget.SelectedPath;
        //store the source folder
        Settings.Default.Save();
        //finally return the success
        retval = true;
      }
      //finally return the result
      return retval;
    }
    /// <summary>
    /// Returns a list of displayable paths.
    /// </summary>
    /// <param name="path">The path to be searched.</param>
    /// <returns>A list of paths that shall be displayed.</returns>
    private List<string> GetDisplayableImages(string path)
    {
      //create a local image manager
      ImageManager imageManager = new ImageManager();
      //read all files in the directory
      string[] files = Directory.GetFiles(path);
      //return list
      List<string> images = new List<string>();
      //loop throught all files
      foreach (string file in files)
      {
        //check for jpgs before attempting to create a thumbnail
        if (imageManager.IsDisplayableExtension(file))
        {
          //add it to the result list
          images.Add(file);
        }
      }
      //return the list
      return images;
    }
    /// <summary>
    /// Stores the user inputs.
    /// </summary>
    /// <returns></returns>
    private void StoreUserInputs()
    {
      //remember the source path
      Settings.Default.LastSourceFolder = txtSourcePath.Text.Trim();
      //remember the target path
      Settings.Default.LastTargetFolder = txtTargetPath.Text.Trim();
      //remember the import strategy
      Settings.Default.MoveFilesOnImport = rbMoveFilesOnImport.Checked;
      //remember the distribution strategy
      Settings.Default.MoveFilesOnDistribute = rbMoveFilesOnDistribute.Checked;
      //save the settings
      Settings.Default.Save();
    }
    /// <summary>
    /// Validates all user inputs.
    /// </summary>
    /// <returns><c>true</c> if the userinput is valid, <c>false</c> otherwise.</returns>
    private bool ValidateUserInputs()
    {
      //local for the result
      bool result = true;
      //check if the sourcefolder is valid
      if(ValidateFolder(txtSourcePath,true,false).Equals(false))
      {
        //remember the failure
        result = false;
      }
      //check if the targetfolder is valid
      if(ValidateFolder(txtTargetPath,false,true).Equals(false))
      {
        //remember the failure
        result = false;
      }
      //finally return the result
      return result;
    }
    /// <summary>
    /// Validates the folder.
    /// </summary>
    /// <param name="textbox">The textbox to be checked.</param>
    /// <param name="checkFolderContainsImages">if set to <c>true</c> the folder is check if it contains images.</param>
    /// <param name="tryCreateLowLevelFolder">if set to <c>true</c> the butchr tries to create a non existing low level folder (last parent must exist).</param>
    /// <returns>
    /// 	<c>true</c> if this is a valid folder, <c>false</c> otherwise.
    /// </returns>
    private bool ValidateFolder(TextBox textbox, bool checkFolderContainsImages, bool tryCreateLowLevelFolder)
    {
      //local return value
      bool result = true;
      //local message container
      string epMessage = Resources.ImportOptionsFolderDoesNotExist;
      //check if the folder exists
      if(Directory.Exists(textbox.Text).Equals(true))
      {
        //check if the folder shall be checked to contain images
        if(checkFolderContainsImages.Equals(true))
        {
          //check if the folder contains images
          if (GetDisplayableImages(textbox.Text).Count > 0)
          {
            //everything ok, folder is valid
            result = true;
          }
          else
          {
            //change the message for the errorprovider
            epMessage = Resources.ImportOptionsFolderContainsNoImages;
            //folder does not contain images, return the failure
            result = false;
          }
        }
        else
        {
          //reset the errorprovider for this control
          ResetErrorNotification((Control)textbox);
          //nothing more to check, return the success
          result = true;
        }
      }
      else
      {
        //check if a low level folder creation shall be attempted
        if (tryCreateLowLevelFolder.Equals(true))
        {
          //extract the parent folder
          string parentFolder = Path.GetDirectoryName(textbox.Text);
          //check if this one exists
          if(Directory.Exists(parentFolder).Equals(true))
          {
            //ask the user to create the directory
              DialogResult dialogResult = MessageBox.Show(Resources.MboxImportCreateDirectoryText, Resources.MboxImportCreateDirectoryTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //check the user's reaction
            if(dialogResult.Equals(DialogResult.Yes))
            {
              //the user want's the butchr to create the directory, so do it
              Directory.CreateDirectory(textbox.Text);
              //no lowlevel creation, folder does not exist, remember the failure
              result = true;
            }
            else
            {
              //no lowlevel creation, folder does not exist, remember the failure
              result = false;
            }
          }
          else
          {
            //no lowlevel creation, folder does not exist, remember the failure
            result = false;
          }
        }
        else
        {
          //no lowlevel creation, folder does not exist, remember the failure
          result = false;
        }
      }
      //check for the result
      if(result.Equals(true))
      {
        //remove the errorprovider
        ResetErrorNotification((Control)textbox);
      }
      else
      {
        //show the errorprovider
        SetErrorNotification((Control)textbox,epMessage);
      }
      //finally return the result
      return result;
    }
    /// <summary>
    /// Resets the error for the given control.
    /// </summary>
    /// <param name="control">The control to work on.</param>
    private void ResetErrorNotification(Control control)
    {
      //clear this control's error provider
      ((ErrorProvider)control.Tag).Clear();
    }
    /// <summary>
    /// Notifies the user about an error.
    /// </summary>
    /// <param name="control">The control to work on.</param>
    /// <param name="message">The message to be displayed.</param>
    private void SetErrorNotification(Control control, string message)
    {
      //reset to blink again
      ResetErrorNotification(control);
      //set the icon to the left
      ((ErrorProvider)control.Tag).SetIconAlignment((Control)control,ErrorIconAlignment.MiddleLeft);
      //show the errorprovider with the given message
      ((ErrorProvider)control.Tag).SetError((Control)control,message);
    }
    #endregion
  }
}