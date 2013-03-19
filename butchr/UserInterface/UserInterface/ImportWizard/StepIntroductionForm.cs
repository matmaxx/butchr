using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  /// <summary>
  /// Form for wizard step: Initial form of the wizard.
  /// </summary>
  public partial class StepIntroductionForm : Matmaxx.Butcher.UserInterface.ImportWizard.BaseFormOutside
  {
    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="StepIntroductionForm"/> class.
    /// </summary>
    public StepIntroductionForm()
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
      //disable the back button
      BackButton.Enabled = false;
      //update the form caption
      this.Text = Properties.Resources.WizardFormText;
      //update title and description
      Title = Properties.Resources.WizardIntroductionTitle;
      Description = string.Format(Properties.Resources.WizardIntroductionDescription,Properties.Resources.ApplicationName.ToLower(),Environment.NewLine);
    }
    #endregion
  }
}