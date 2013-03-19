using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  #region delegates
  /// <summary>
  /// Delegate for clicks on the back button.
  /// </summary>
  public delegate void OnWizardButtonClicked(object sender,WizardEventArgs e);
  #endregion

  #region BaseForm
  /// <summary>
  /// Base Form for the import wizard.
  /// </summary>
  public partial class BaseForm : Form
  {
    #region props

    #region NextButton
    /// <summary>
    /// Gives access to the the next button from the child forms.
    /// </summary>
    public Button NextButton
    {
      get { return NextButtonInternal; }
    }
    #endregion

    #region BackButton
    /// <summary>
    /// Gives access to the the back button from the child forms.
    /// </summary>
    public Button BackButton
    {
      get { return BackButtonInternal; }
    }
    #endregion
    
    #region AbortButton
    /// <summary>
    /// Gives access to the the abort button from the child forms.
    /// </summary>
    public Button AbortButton
    {
      get { return AbortButtonInternal; }
    }
    #endregion

    #region Data
    /// <summary>
    /// The data that is passed from form to form.
    /// </summary>
    private Application.ImportWizardData data;
    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    /// <value>The data.</value>
    public Application.ImportWizardData Data
    {
      get { return data; }
      set { data = value; }
    }

    #endregion

    #region image manager
    /// <summary>
    /// Reference to the imagemanager of the caller.
    /// </summary>
    private Application.ImageManager importImageManager;
    /// <summary>
    /// Gets or sets the reference to the imagemanager of the caller..
    /// </summary>
    /// <value>Reference to the imagemanager of the caller.</value>
    public Application.ImageManager ImportImageManager
    {
      get { return importImageManager; }
      set { importImageManager = value; }
    }
    #endregion

    #endregion

    #region events
    /// <summary>
    /// Event that occurs when a wizard button is clicked.
    /// </summary>
    public event OnWizardButtonClicked wizardButtonClicked;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseForm"/> class.
    /// </summary>
    public BaseForm()
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
      BackButtonInternal.Text   = Properties.Resources.WizardButtonBack;
      NextButtonInternal.Text   = Properties.Resources.WizardButtonNext;
      AbortButtonInternal.Text  = Properties.Resources.WizardButtonCancel;
    }
    #endregion

    #region event handler
    /// <summary>
    /// Handles the Click event of the BackButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void BackButton_Click(object sender, EventArgs e)
    {
      //convert the event and forward it
      if(null != wizardButtonClicked) wizardButtonClicked(sender, new WizardEventArgs(WizardEventArgs.WizardStepButton.Back));
    }
    /// <summary>
    /// Handles the Click event of the NextButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void NextButton_Click(object sender, EventArgs e)
    {
      //convert the event and forward it
      if(null != wizardButtonClicked) wizardButtonClicked(sender, new WizardEventArgs(WizardEventArgs.WizardStepButton.Next));
    }
    /// <summary>
    /// Handles the Click event of the AbortButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void AbortButton_Click(object sender, EventArgs e)
    {
      //convert the event and forward it
      if(null != wizardButtonClicked) wizardButtonClicked(sender, new WizardEventArgs(WizardEventArgs.WizardStepButton.Cancel));
    }
    #endregion
  }
  #endregion

  #region wizard event args
  /// <summary>
  /// Event args class for wizard button events.
  /// </summary>
  public class WizardEventArgs
  {
    #region enum
    /// <summary>
    /// Lists all buttons of a wizard form
    /// </summary>
    public enum WizardStepButton
    {
      /// <summary>
      /// One step back.
      /// </summary>
      Back,
      /// <summary>
      /// One step forward.
      /// </summary>
      Next,
      /// <summary>
      /// Cancel the wizard.
      /// </summary>
      Cancel
    }
    #endregion  

    #region props
    /// <summary>
    /// The step button.
    /// </summary>
    private WizardStepButton stepButton;
    /// <summary>
    /// Gets or sets the step button.
    /// </summary>
    /// <value>The step button.</value>
    public WizardStepButton StepButton
    {
      get { return stepButton; }
      set { stepButton = value; }
    }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="WizardEventArgs"/> class.
    /// </summary>
    public WizardEventArgs(WizardStepButton stepButton)
    {
      //backup the given data
      this.stepButton = stepButton;
    }
    #endregion
  }
  #endregion
}