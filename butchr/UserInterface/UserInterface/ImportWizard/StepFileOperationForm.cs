using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Matmaxx.Butcher.Application;

namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  /// <summary>
  /// Form for wizard step: Selection of the desired file operations (copy/move).
  /// </summary>
  public partial class StepFileOperationForm : Matmaxx.Butcher.UserInterface.ImportWizard.BaseFormInside
  {
    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="StepFileOperationForm"/> class.
    /// </summary>
    public StepFileOperationForm()
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
      Title = Properties.Resources.WizardFileOperationTitle;
      Description = string.Format(Properties.Resources.WizardFileOperationDescription,Properties.Resources.ApplicationName);
      //update the text of the groupboxes
      gbImport.Text = Properties.Resources.WizardFileOperationGbImport;
      gbDistribute.Text = Properties.Resources.WizardFileOperationGbDistribute;
      //update the option button texts
      optImportCopy.Text = Properties.Resources.WizardFileOperationOptImportCopy;
      optImportMove.Text = Properties.Resources.WizardFileOperationOptImportMove;
      optDistributeCopy.Text = Properties.Resources.WizardFileOperationOptDistributeCopy;
      optDistributeMove.Text = Properties.Resources.WizardFileOperationOptDistributeMove;
    }
    #endregion

    #region event handler
    /// <summary>
    /// Handles the Load event of the StepFileOperationForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void StepFileOperationForm_Load(object sender, EventArgs e)
    {
      //activate the correct option buttons
      optImportCopy.Checked = (Data.CopyOperation == Matmaxx.Butcher.Application.ImportWizardData.FileOperation.Copy);
      optImportMove.Checked = (Data.CopyOperation == Matmaxx.Butcher.Application.ImportWizardData.FileOperation.Move);
      optDistributeCopy.Checked = (Data.DistributeOperation == Matmaxx.Butcher.Application.ImportWizardData.FileOperation.Copy);
      optDistributeMove.Checked = (Data.DistributeOperation == Matmaxx.Butcher.Application.ImportWizardData.FileOperation.Move);
    }
    /// <summary>
    /// Handles the CheckedChanged event of all OptionButton controls.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void OptionButtons_CheckedChanged(object sender, EventArgs e)
    {
      Data.CopyOperation = optImportCopy.Checked ? ImportWizardData.FileOperation.Copy : Data.CopyOperation;
      Data.CopyOperation = optImportMove.Checked ? ImportWizardData.FileOperation.Move : Data.CopyOperation;
      Data.DistributeOperation = optDistributeCopy.Checked ? ImportWizardData.FileOperation.Copy : Data.DistributeOperation;
      Data.DistributeOperation = optDistributeMove.Checked ? ImportWizardData.FileOperation.Move : Data.DistributeOperation;
    }
    #endregion

    #region helper functions
    #endregion
  }
}