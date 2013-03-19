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
  /// Form for wizard step: Final check before the show starts.
  /// </summary>
  public partial class StepFinishedForm : Matmaxx.Butcher.UserInterface.ImportWizard.BaseFormOutside
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StepFinishedForm"/> class.
    /// </summary>
    public StepFinishedForm()
    {
      InitializeComponent();
      NextButton.Text = Properties.Resources.WizardButtonFinish;
    }
  }
}