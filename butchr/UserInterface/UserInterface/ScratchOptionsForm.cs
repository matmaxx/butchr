using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Matmaxx.Toolbox;
using Matmaxx.Butchr.Application.XmpTm;
using Matmaxx.Butchr.Properties;
using System.IO;
using Matmaxx.Butchr.Application;

namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// The options form for the scratch generation.
  /// </summary>
  public partial class ScratchOptionsForm : Form
  {
    #region members
    /// <summary>
    /// Handles all xml-storage operations.
    /// </summary>
    private XmlManager<xmpmeta> xml;
    /// <summary>
    /// local ref to the image manager.
    /// </summary>
    private ImageManager imageManager;
    /// <summary>
    /// local ref to the base path.
    /// </summary>
    private string basePath;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="ScratchOptionsForm"/> class.
    /// </summary>
    public ScratchOptionsForm()
    {
      //designer stuff
      InitializeComponent();
    }
    #endregion

    #region API
    /// <summary>
    /// Performs the scratch batch generation.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    /// <param name="imageManager">The image manager.</param>
    public void PerformScratchBatchGeneration(string basePath,ImageManager imageManager)
    {
      //backup the ref to the imagemanager
      this.imageManager = imageManager;
      //backup the ref to the base path
      this.basePath = basePath;
      //show yourself as dialog
      this.ShowDialog();
    }
    #endregion

    #region event handler
    /// <summary>
    /// Handles the Load event of the ScratchOptionsForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void ScratchOptionsForm_Load(object sender, EventArgs e)
    {
      //initialize the xmp stuff
      InitializeFromXmp(Path.Combine(Butchr.DataPath,Settings.Default.DefaultXmpFile));
      //initialize the remaining settings
      InitializeFromSettings();
    }
    /// <summary>
    /// Handles the CheckedChanged event of the rbLightSmoothing control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void rbLightSmoothing_CheckedChanged(object sender, EventArgs e)
    {
      //update the text for the smoothing
      lblLightSmoothingValue.Text = SmoothingCheckedToString();
    }
    /// <summary>
    /// Handles the Click event of the btnImport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnImport_Click(object sender, EventArgs e)
    {
      //show the openfile-dialog and check its result
      if(SelectXmpImportFile())
      {
        //valid file, update the UI
        InitializeFromXmp(ofdXmp.FileName);
      }
    }
    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnExport_Click(object sender, EventArgs e)
    {
      //show the savefile dialog and check its result
      if(SelectXmpExportFile())
      {
        //valid file, export UI settings to xml
        ExportToXmp(sfdXmp.FileName);
      }
    }
    /// <summary>
    /// Handles the Click event of the btnCreateScratchBatch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnCreateScratchBatch_Click(object sender, EventArgs e)
    {
      //save the current UI as default
      ExportToXmp(Path.Combine(Butchr.DataPath,Settings.Default.DefaultXmpFile));
      //create the batchfile
      imageManager.CreateHdrScratches(basePath,Path.Combine(Butchr.DataPath,Settings.Default.DefaultXmpFile));
      this.Close();
      LogManager.Instance.Output(string.Format(Resources.LogScratchBatchCreated,Path.Combine(basePath,Resources.ScratchBatchFilename)));
    }
    /// <summary>
    /// Handles the Click event of the btnPhotomatixOptionsHelp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnPhotomatixOptionsHelp_Click(object sender, EventArgs e)
    {
      string helpURL = Path.Combine(System.Windows.Forms.Application.StartupPath,Settings.Default.PhotomatixCommandlineOptionsURL);
      //launch the online help document from hdr soft
      System.Diagnostics.Process.Start(helpURL);
    }
    /// <summary>
    /// Handles the Click event of the btnPhotomatixOptionsDefault control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnPhotomatixOptionsDefault_Click(object sender, EventArgs e)
    {
      //get user confirmation for resetting the options to default
      DialogResult result = MessageBox.Show(Resources.StringMboxPhotomatixOptionsResetText,Resources.StringMboxPhotomatixOptionsResetTitle,MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
      //check confirmation
      if(DialogResult.OK == result)
      {
        //show the default options
        txtPhotomatixOptions.Text = Settings.Default.PhotomatixCommandlineOptionsDefault;
        //reset the stored options
        Settings.Default.PhotomatixCommandlineOptions = Settings.Default.PhotomatixCommandlineOptionsDefault;
        //and store them
        Settings.Default.Save();
      }
    }
    /// <summary>
    /// Handles the Click event of the btnSelectPhotomatixPath control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void btnSelectPhotomatixPath_Click(object sender, EventArgs e)
    {
      //show the openfile-dialog and check its result
      if(SelectPhotomatixCommandlineExecutable())
      {
		    //check if the path for photomatix is already stored
        if(File.Exists(Settings.Default.PhotomatixCommandlinePath))
        {
          //put it into the textbox
          txtPhotomatixPath.Text = Settings.Default.PhotomatixCommandlinePath;
        }
        else
        {
          //leave the textbox empty
          txtPhotomatixPath.Text = string.Empty;
        }
      }      
    }
    /// <summary>
    /// Handles the Leave event of the txtPhotomatixOptions control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void txtPhotomatixOptions_Leave(object sender, EventArgs e)
    {
      //backup the new path
      Settings.Default.PhotomatixCommandlineOptions = txtPhotomatixOptions.Text.Trim();
      //serialize the settings
      Settings.Default.Save();      
    }
    /// <summary>
    /// Handles the CheckedChanged event of the chkDeleteJpgsAfterScratching control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void chkDeleteJpgsAfterScratching_CheckedChanged(object sender, EventArgs e)
    {
      //store the new setting
      Settings.Default.DeleteSourceJpgsAfterScratching = chkDeleteJpgsAfterScratching.Checked;
      //save it
      Settings.Default.Save();
    }
    #endregion

    #region helper functions

    #region smoothing
    /// <summary>
    /// Converts the checked state to the bullshit string representation of the smoothing parameter.
    /// </summary>
    /// <returns>the smoothing string as expected in the xmp.</returns>
    private string SmoothingCheckedToString()
    {
      //local retval
      string result = string.Empty;
      //get a local ref to the x-table
      Dictionary<Matmaxx.Butchr.Application.XmpTm.Description.SmoothingLevel,string> dict = xml.Model.RDF.Description.SmoothingInt2String;
      //perform the check on each checkbox
      if(rbLightSmoothingVeryLow.Checked)   result = dict[Description.SmoothingLevel.VeryLow];
      if(rbLightSmoothingLow.Checked)       result = dict[Description.SmoothingLevel.Low];
      if(rbLightSmoothingMedium.Checked)    result = dict[Description.SmoothingLevel.Medium];
      if(rbLightSmoothingHigh.Checked)      result = dict[Description.SmoothingLevel.High];
      if(rbLightSmoothingVeryHigh.Checked)  result = dict[Description.SmoothingLevel.VeryHigh];
      //finally return the result
      return result;
    }
    /// <summary>
    /// Converts the bullshit string representation of the smoothing parameter to the corresponding checked state.
    /// </summary>
    /// <param name="smoothing">The smoothing string.</param>
    private void SmoothingStringToChecked(string smoothing)
    {
      //get a local ref to the x-table
      Dictionary<Matmaxx.Butchr.Application.XmpTm.Description.SmoothingLevel,string> dict = xml.Model.RDF.Description.SmoothingInt2String;
      //active the correct radio button
      if(smoothing.Equals(dict[Description.SmoothingLevel.VeryLow]))   rbLightSmoothingVeryLow.Checked   = true;
      if(smoothing.Equals(dict[Description.SmoothingLevel.Low]))       rbLightSmoothingLow.Checked       = true;
      if(smoothing.Equals(dict[Description.SmoothingLevel.Medium]))    rbLightSmoothingMedium.Checked    = true;
      if(smoothing.Equals(dict[Description.SmoothingLevel.High]))      rbLightSmoothingHigh.Checked      = true;
      if(smoothing.Equals(dict[Description.SmoothingLevel.VeryHigh]))  rbLightSmoothingVeryHigh.Checked  = true;
    }
    #endregion

    #region xmp import/export
    /// <summary>
    /// Selects the XMP file to import with an open file dialog.
    /// </summary>
    /// <returns><c>true</c> if the dialog was processed successfully, <c>false</c> otherwise.</returns>
    private bool SelectXmpImportFile()
    {
      //local result
      bool retval = false;
      //check if a folder was already selected in a previous session
      if(
          (false == Settings.Default.LastXmpImportFile.Equals(String.Empty)) &&
          (File.Exists(Settings.Default.LastXmpImportFile))
        )
      {
        //start at this folder
        ofdXmp.InitialDirectory = Path.GetDirectoryName(Settings.Default.LastXmpImportFile);
        //start with this file
        ofdXmp.FileName = Settings.Default.LastXmpImportFile;
      }
      else
      {
        //start at the docfolder
        ofdXmp.InitialDirectory = Butchr.DataPath;
        //without any selection
        ofdXmp.FileName = string.Empty;
      }
      //set the title
      ofdXmp.Title = Resources.ofdXmpImportTitle;
      //set the filter
      ofdXmp.Filter = Resources.ofdXmpImportFilter;
      //set the conditions
      ofdXmp.CheckFileExists = true;
      ofdXmp.CheckPathExists = true;
      //show the dialog
      DialogResult result = ofdXmp.ShowDialog();
      //check if the user pressed ok
      if (result == DialogResult.OK)
      {
        //backup the new path
        Settings.Default.LastXmpImportFile = ofdXmp.FileName;
        //serialize the settings
        Settings.Default.Save();
        //finally return the success
        retval = true;
      }
      //finally return the result
      return retval;
    }
    /// <summary>
    /// Initializes the UI from the settings of an xmp file.
    /// </summary>
    /// <param name="PathToXmp">The path to the xmp file.</param>
    private void InitializeFromXmp(string PathToXmp)
    {
      //try to init from the default.xmp
      try
      {
        //create the xmlManager
        xml = new XmlManager<xmpmeta>();
        //set the namespaces
        SetXmpNamespaces(xml);
        //deserialize the defaults
        xml.Deserialize(PathToXmp);
      }
      catch (Exception)
      {
        //use some hardcoded default values and notify about this 
        LogManager.Instance.Error(Resources.LogXmpImportFailed);
        //detail enhancer
        xml.Model.RDF.Description.Strength                = 100;
        xml.Model.RDF.Description.ColorSaturation         = 20;
        xml.Model.RDF.Description.Luminosity              = 10;
        xml.Model.RDF.Description.Microcontrast           = 0;
        xml.Model.RDF.Description.Smoothing               = xml.Model.RDF.Description.SmoothingInt2String[Description.SmoothingLevel.VeryHigh];
        //tone settings
        xml.Model.RDF.Description.WhiteClip               = 5.0;
        xml.Model.RDF.Description.BlackClip               = 5.0;
        xml.Model.RDF.Description.Gamma                   = 1.0;
        //color settings
        xml.Model.RDF.Description.ColorTemperature        = 0;
        xml.Model.RDF.Description.SaturationHighlights    = 0;
        xml.Model.RDF.Description.SaturationShadows       = 0;
        //smoothing settings
        xml.Model.RDF.Description.Microsmoothing          = 0;
        xml.Model.RDF.Description.HighlightsSmoothing     = 0;
        xml.Model.RDF.Description.ShadowsSmoothing        = 0;
        xml.Model.RDF.Description.ShadowsClipping         = 0;
        //write it back to the disk
        xml.Serialize(PathToXmp);
      }
      //now that we have valid values for sure, we can update the UI
      //detail enhancer
      dsStrength.ValuePhy             = xml.Model.RDF.Description.Strength;
      dsColorSaturation.ValuePhy      = xml.Model.RDF.Description.ColorSaturation;
      dsLuminosity.ValuePhy           = xml.Model.RDF.Description.Luminosity;
      dsMicroContrast.ValuePhy        = xml.Model.RDF.Description.Microcontrast;
      SmoothingStringToChecked(xml.Model.RDF.Description.Smoothing);
      //tone settings
      dsWhiteClip.ValuePhy            = xml.Model.RDF.Description.WhiteClip;
      dsBlackClip.ValuePhy            = xml.Model.RDF.Description.BlackClip;
      dsGamma.ValuePhy                = xml.Model.RDF.Description.Gamma;
      //color settings
      dsTemperature.ValuePhy          = xml.Model.RDF.Description.ColorTemperature;
      dsSaturationHighlights.ValuePhy = xml.Model.RDF.Description.SaturationHighlights;
      dsSaturationShadows.ValuePhy    = xml.Model.RDF.Description.SaturationShadows;
      //smoothing settings
      dsMicroSmoothing.ValuePhy       = xml.Model.RDF.Description.Microsmoothing;
      dsHighlightsSmoothing.ValuePhy  = xml.Model.RDF.Description.HighlightsSmoothing;
      dsShadowsSmoothing.ValuePhy     = xml.Model.RDF.Description.ShadowsSmoothing;
      dsShadowsClipping.ValuePhy      = xml.Model.RDF.Description.ShadowsClipping;
    }
    /// <summary>
    /// Selects the XMP file to export with an open file dialog.
    /// </summary>
    /// <returns><c>true</c> if the dialog was processed successfully, <c>false</c> otherwise.</returns>
    private bool SelectXmpExportFile()
    {
      //local result
      bool retval = false;
      //check if a folder was already selected in a previous session
      if(
          (false == Settings.Default.LastXmpExportFile.Equals(String.Empty)) &&
          (File.Exists(Settings.Default.LastXmpExportFile))
        )
      {
        //start at this folder
        sfdXmp.InitialDirectory = Path.GetDirectoryName(Settings.Default.LastXmpExportFile);
        //start with this file
        sfdXmp.FileName = Settings.Default.LastXmpExportFile;
      }
      else
      {
        //start at the docfolder
        sfdXmp.InitialDirectory = Butchr.DataPath;
        //without any selection
        sfdXmp.FileName = string.Empty;
      }
      //set the title
      sfdXmp.Title = Resources.sfdXmpExportTitle;
      //set the filter
      sfdXmp.Filter = Resources.sfdXmpExportFilter;
      //set the conditions
      sfdXmp.CheckFileExists = false;
      sfdXmp.CheckPathExists = true;
      //show the dialog
      DialogResult result = sfdXmp.ShowDialog();
      //check if the user pressed ok
      if (result == DialogResult.OK)
      {
        //backup the new path
        Settings.Default.LastXmpExportFile = sfdXmp.FileName;
        //serialize the settings
        Settings.Default.Save();
        //finally return the success
        retval = true;
      }
      //finally return the result
      return retval;
    }
    /// <summary>
    /// Exports the settings from the UI to the specified xmp file.
    /// </summary>
    /// <param name="PathToXmp">The path to the xmp file.</param>
    private void ExportToXmp(string PathToXmp)
    {
      try
      {
        //create the xmlManager
        xml = new XmlManager<xmpmeta>();
        //add the namespaces
        SetXmpNamespaces(xml);
        //detail enhancer
        xml.Model.RDF.Description.Strength                = (int)dsStrength.ValuePhy;
        xml.Model.RDF.Description.ColorSaturation         = (int)dsColorSaturation.ValuePhy;
        xml.Model.RDF.Description.Luminosity              = (int)dsLuminosity.ValuePhy;
        xml.Model.RDF.Description.Microcontrast           = (int)dsMicroContrast.ValuePhy;
        xml.Model.RDF.Description.Smoothing               = lblLightSmoothingValue.Text.Trim();
        //tone settings
        xml.Model.RDF.Description.WhiteClip               = dsWhiteClip.ValuePhy;
        xml.Model.RDF.Description.BlackClip               = dsBlackClip.ValuePhy;
        xml.Model.RDF.Description.Gamma                   = dsGamma.ValuePhy;
        //color settings
        xml.Model.RDF.Description.ColorTemperature        = (int)dsTemperature.ValuePhy;
        xml.Model.RDF.Description.SaturationHighlights    = (int)dsSaturationHighlights.ValuePhy;
        xml.Model.RDF.Description.SaturationShadows       = (int)dsSaturationShadows.ValuePhy;
        //smoothing settings
        xml.Model.RDF.Description.Microsmoothing          = (int)dsMicroSmoothing.ValuePhy;
        xml.Model.RDF.Description.HighlightsSmoothing     = (int)dsHighlightsSmoothing.ValuePhy;
        xml.Model.RDF.Description.ShadowsSmoothing        = (int)dsShadowsSmoothing.ValuePhy;
        xml.Model.RDF.Description.ShadowsClipping         = (int)dsShadowsClipping.ValuePhy;
        
        //serialize to the specified path
        xml.Serialize(PathToXmp);
      }
      catch (Exception ex)
      {
        //notify about the failure
        LogManager.Instance.Error(string.Format(Resources.LogXmpExportFailed,ex.Message));
      }      
    }
    /// <summary>
    /// Sets the XMP namespaces.
    /// </summary>
    /// <param name="xml">The XML manager.</param>
    private void SetXmpNamespaces(XmlManager<xmpmeta> xml)
    {
      //xmpmeta
      xml.AddNamespace("x","adobe:ns:meta/");
      //rdf
      xml.AddNamespace("rdf","http://www.w3.org/1999/02/22-rdf-syntax-ns#");
      //description
      xml.AddNamespace("pmtm","http://www.hdrsoft.com/tone_mapping_settings");
    }
    #endregion

    #region photomatix commandline
    /// <summary>
    /// Initializes from settings.
    /// </summary>
    private void InitializeFromSettings()
    {
      #region photomatix path
		  //check if the path for photomatix is already stored
      if(File.Exists(Settings.Default.PhotomatixCommandlinePath))
      {
        //put it into the textbox
        txtPhotomatixPath.Text = Settings.Default.PhotomatixCommandlinePath;
      }
      //no path stored, so check if the default path exists
      else if(File.Exists(Settings.Default.PhotomatixCommandlinePathDefault))
      {
        //put it into the textbox
        txtPhotomatixPath.Text = Settings.Default.PhotomatixCommandlinePathDefault;
      }
      else
      {
        //leave the textbox empty
        txtPhotomatixPath.Text = string.Empty;
      }
	    #endregion    

      #region photomatix options
		  //check if the options are still empty
      if(Settings.Default.PhotomatixCommandlineOptions.Equals(string.Empty))
      {
        //use default options in this case
        txtPhotomatixOptions.Text = Settings.Default.PhotomatixCommandlineOptionsDefault;
      }
      else
      {
        //use the stored options
        txtPhotomatixOptions.Text = Settings.Default.PhotomatixCommandlineOptions;
      }
      #endregion
    }
    /// <summary>
    /// Selects the photomatix commandline exe with an open file dialog.
    /// </summary>
    /// <returns><c>true</c> if the dialog was processed successfully, <c>false</c> otherwise.</returns>
    private bool SelectPhotomatixCommandlineExecutable()
    {
      //local result
      bool retval = false;
      //check if a folder was already selected in a previous session
      if(
          (false == Settings.Default.PhotomatixCommandlinePath.Equals(String.Empty)) &&
          (File.Exists(Settings.Default.PhotomatixCommandlinePath))
        )
      {
        //start at this folder
        ofdPhotomatix.InitialDirectory = Path.GetDirectoryName(Settings.Default.PhotomatixCommandlinePath);
        //start with this file
        ofdPhotomatix.FileName = Settings.Default.PhotomatixCommandlinePath;
      }
      else
      {
        //start at the docfolder
        ofdPhotomatix.InitialDirectory = Butchr.DataPath;
        //without any selection
        ofdPhotomatix.FileName = string.Empty;
      }
      //set the title
      ofdPhotomatix.Title = Resources.ofdPhotomatixTitle;
      //set the filter
      ofdPhotomatix.Filter = Resources.ofdPhotomatixFilter;
      //set the conditions
      ofdPhotomatix.CheckFileExists = true;
      ofdPhotomatix.CheckPathExists = true;
      //show the dialog
      DialogResult result = ofdPhotomatix.ShowDialog();
      //check if the user pressed ok
      if (result == DialogResult.OK)
      {
        //backup the new path
        Settings.Default.PhotomatixCommandlinePath = ofdPhotomatix.FileName;
        //serialize the settings
        Settings.Default.Save();
        //finally return the success
        retval = true;
      }
      //finally return the result
      return retval;
    }
    #endregion

    #endregion
  }
}