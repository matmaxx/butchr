using System;
using System.Collections.Generic;
using System.Text;
using Matmaxx.Butcher.UserInterface;
using Matmaxx.Butcher.UserInterface.ImportWizard;
using System.Windows.Forms;

namespace Matmaxx.Butcher.Application
{
  /// <summary>
  /// The control logic for the import wizard.
  /// </summary>
  public class ImportWizardManager
  {
    #region members
    /// <summary>
    /// List of wizard forms.
    /// </summary>
    private List<BaseForm> wizardForms;
    /// <summary>
    /// Index of the current active form.
    /// </summary>
    private int currentFormIndex;
    /// <summary>
    /// The data object that is passed to every form.
    /// </summary>
    private ImportWizardData data;
    /// <summary>
    /// Reference to the imagemanager of the caller.
    /// </summary>
    private ImageManager importImageManager;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportWizardManager"/> class.
    /// </summary>
    public ImportWizardManager()
    {
      //initialize the wizard forms
      InitializeWizardForms();
      //initialize the data objects
      InitializeData();
    }
    /// <summary>
    /// Initializes the data objects.
    /// </summary>
    private void InitializeData()
    {
      //create a new data object
      data = new ImportWizardData();
      //the image manager reference is set in the Start() method
      importImageManager = null;
    }
    /// <summary>
    /// Initializes the wizard forms.
    /// </summary>
    private void InitializeWizardForms()
    {
      //create the list for storing the forms
      wizardForms = new List<BaseForm>();
      //add the introduction form
      wizardForms.Add((BaseForm) new StepIntroductionForm());
      //add the form for folder selection
      wizardForms.Add((BaseForm)new StepFolderSelectionForm());
      //add the form for file options
      wizardForms.Add((BaseForm)new StepFileOperationForm());
      //add the form for import settings
      wizardForms.Add((BaseForm)new StepImportSettingsForm());
      //add the form for photomatix settings
      wizardForms.Add((BaseForm)new StepPhotomatixSettingsForm());
      //add the finish form
      wizardForms.Add((BaseForm) new StepFinishedForm());
      //create a local delegate function
      OnWizardButtonClicked handler = new OnWizardButtonClicked(StepForm_WizardButtonClicked);
      //loop all forms
      foreach (BaseForm form in wizardForms)
      {
        //register for each form's button event
        form.wizardButtonClicked += handler;
      }
      //start with the first form
      currentFormIndex = 0;
    }
    #endregion

    #region API
    /// <summary>
    /// Starts the wizard.
    /// </summary>
    public void Start(ImageManager ImportImageManager)
    {
      //update the reference to the image manager
      importImageManager = ImportImageManager;
      //and show the first form
      SwitchWizardForm(0);
    }
    #endregion

    #region event handler
    /// <summary>
    /// Handles the WizardButtonClicked event of the StepForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Matmaxx.Butcher.UserInterface.ImportWizard.WizardEventArgs"/> instance containing the event data.</param>
    void StepForm_WizardButtonClicked(object sender, WizardEventArgs e)
    {
      //switch by the kind of button that was pressed
      switch (e.StepButton)
      {
        //back button was pressed
        case WizardEventArgs.WizardStepButton.Back:
          //check if we are already at the first form of the wizard
          if(currentFormIndex > 0)
          {
            //go back one form
            SwitchWizardForm(currentFormIndex-1);
          }
          break;
        case WizardEventArgs.WizardStepButton.Next:
          //check if we are already at the last form of the wizard
          if(currentFormIndex < wizardForms.Count-1)
          {
            //go back one form
            SwitchWizardForm(currentFormIndex+1);
          }
          else
          {
            //hide the current form
            wizardForms[currentFormIndex].Hide();
            //do some debug output
            MessageBox.Show(string.Format("Wizard finished{0}Source: {1}{2}Target: {3}{4}",Environment.NewLine,data.SourcePath,Environment.NewLine,data.TargetPath,Environment.NewLine));
          }
          break;
        case WizardEventArgs.WizardStepButton.Cancel:
           //hide the current form
           wizardForms[currentFormIndex].Hide();
          //reset the index
          currentFormIndex = 0;
          //$$$wl: forward the cancel event to the caller of Start()
          break;
        default:
          break;
      }
    }

    #endregion

    #region helper functions
    /// <summary>
    /// Switches the wizard form.
    /// </summary>
    /// <param name="newIndex">The new index.</param>
    private void SwitchWizardForm(int newIndex)
    {
      //try to close the old form
      try
      {
        //close the form
        wizardForms[currentFormIndex].Hide();
      }
      catch (Exception ex)
      {
        //do not forward an exception here, since this is intended to fail if no form is open
        Butcher.Log.Error(ex.Message);
      }
      //try to open the new form
      try
      {
        //pass the data object
        wizardForms[newIndex].Data = data;
        //pass the image manager object
        wizardForms[newIndex].ImportImageManager = importImageManager;
        //open the form
        wizardForms[newIndex].Show();
        //update the current forms flag
        currentFormIndex = newIndex;
      }
      catch (Exception ex)
      {
        //forward the exception
        Butcher.Log.Error(ex.Message);
      }
    }
    #endregion

  }
}
