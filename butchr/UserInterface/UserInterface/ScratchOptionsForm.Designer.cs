namespace Matmaxx.Butchr.UserInterface
{
  partial class ScratchOptionsForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScratchOptionsForm));
      this.lblLightSmoothingValue = new System.Windows.Forms.Label();
      this.rbLightSmoothingVeryHigh = new System.Windows.Forms.RadioButton();
      this.rbLightSmoothingHigh = new System.Windows.Forms.RadioButton();
      this.rbLightSmoothingMedium = new System.Windows.Forms.RadioButton();
      this.rbLightSmoothingLow = new System.Windows.Forms.RadioButton();
      this.rbLightSmoothingVeryLow = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.gbToneSettings = new System.Windows.Forms.GroupBox();
      this.dsWhiteClip = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsBlackClip = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsGamma = new Matmaxx.Toolbox.DecoratedSlider();
      this.gbColorSettings = new System.Windows.Forms.GroupBox();
      this.dsSaturationHighlights = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsTemperature = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsSaturationShadows = new Matmaxx.Toolbox.DecoratedSlider();
      this.gbSmoothingSettings = new System.Windows.Forms.GroupBox();
      this.dsShadowsSmoothing = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsMicroSmoothing = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsHighlightsSmoothing = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsShadowsClipping = new Matmaxx.Toolbox.DecoratedSlider();
      this.gbDetailEnhancer = new System.Windows.Forms.GroupBox();
      this.dsMicroContrast = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsStrength = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsColorSaturation = new Matmaxx.Toolbox.DecoratedSlider();
      this.dsLuminosity = new Matmaxx.Toolbox.DecoratedSlider();
      this.btnImport = new System.Windows.Forms.Button();
      this.btnExport = new System.Windows.Forms.Button();
      this.btnCreateScratchBatch = new System.Windows.Forms.Button();
      this.ofdXmp = new System.Windows.Forms.OpenFileDialog();
      this.sfdXmp = new System.Windows.Forms.SaveFileDialog();
      this.btnSelectPhotomatixPath = new System.Windows.Forms.Button();
      this.lblPhotomatixPath = new System.Windows.Forms.Label();
      this.txtPhotomatixPath = new System.Windows.Forms.TextBox();
      this.txtPhotomatixOptions = new System.Windows.Forms.TextBox();
      this.lblPhotomatixOptions = new System.Windows.Forms.Label();
      this.btnPhotomatixOptionsDefault = new System.Windows.Forms.Button();
      this.btnPhotomatixOptionsHelp = new System.Windows.Forms.Button();
      this.gbPhotomatixCommandline = new System.Windows.Forms.GroupBox();
      this.chkDeleteJpgsAfterScratching = new System.Windows.Forms.CheckBox();
      this.ofdPhotomatix = new System.Windows.Forms.OpenFileDialog();
      this.gbToneSettings.SuspendLayout();
      this.gbColorSettings.SuspendLayout();
      this.gbSmoothingSettings.SuspendLayout();
      this.gbDetailEnhancer.SuspendLayout();
      this.gbPhotomatixCommandline.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblLightSmoothingValue
      // 
      this.lblLightSmoothingValue.Location = new System.Drawing.Point(117, 220);
      this.lblLightSmoothingValue.Name = "lblLightSmoothingValue";
      this.lblLightSmoothingValue.Size = new System.Drawing.Size(82, 13);
      this.lblLightSmoothingValue.TabIndex = 16;
      this.lblLightSmoothingValue.Text = "Text";
      this.lblLightSmoothingValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // rbLightSmoothingVeryHigh
      // 
      this.rbLightSmoothingVeryHigh.AutoSize = true;
      this.rbLightSmoothingVeryHigh.Location = new System.Drawing.Point(183, 243);
      this.rbLightSmoothingVeryHigh.Name = "rbLightSmoothingVeryHigh";
      this.rbLightSmoothingVeryHigh.Size = new System.Drawing.Size(14, 13);
      this.rbLightSmoothingVeryHigh.TabIndex = 15;
      this.rbLightSmoothingVeryHigh.UseVisualStyleBackColor = true;
      this.rbLightSmoothingVeryHigh.CheckedChanged += new System.EventHandler(this.rbLightSmoothing_CheckedChanged);
      // 
      // rbLightSmoothingHigh
      // 
      this.rbLightSmoothingHigh.AutoSize = true;
      this.rbLightSmoothingHigh.Location = new System.Drawing.Point(141, 243);
      this.rbLightSmoothingHigh.Name = "rbLightSmoothingHigh";
      this.rbLightSmoothingHigh.Size = new System.Drawing.Size(14, 13);
      this.rbLightSmoothingHigh.TabIndex = 15;
      this.rbLightSmoothingHigh.UseVisualStyleBackColor = true;
      this.rbLightSmoothingHigh.CheckedChanged += new System.EventHandler(this.rbLightSmoothing_CheckedChanged);
      // 
      // rbLightSmoothingMedium
      // 
      this.rbLightSmoothingMedium.AutoSize = true;
      this.rbLightSmoothingMedium.Location = new System.Drawing.Point(99, 243);
      this.rbLightSmoothingMedium.Name = "rbLightSmoothingMedium";
      this.rbLightSmoothingMedium.Size = new System.Drawing.Size(14, 13);
      this.rbLightSmoothingMedium.TabIndex = 15;
      this.rbLightSmoothingMedium.UseVisualStyleBackColor = true;
      this.rbLightSmoothingMedium.CheckedChanged += new System.EventHandler(this.rbLightSmoothing_CheckedChanged);
      // 
      // rbLightSmoothingLow
      // 
      this.rbLightSmoothingLow.AutoSize = true;
      this.rbLightSmoothingLow.Location = new System.Drawing.Point(57, 243);
      this.rbLightSmoothingLow.Name = "rbLightSmoothingLow";
      this.rbLightSmoothingLow.Size = new System.Drawing.Size(14, 13);
      this.rbLightSmoothingLow.TabIndex = 15;
      this.rbLightSmoothingLow.UseVisualStyleBackColor = true;
      this.rbLightSmoothingLow.CheckedChanged += new System.EventHandler(this.rbLightSmoothing_CheckedChanged);
      // 
      // rbLightSmoothingVeryLow
      // 
      this.rbLightSmoothingVeryLow.AutoSize = true;
      this.rbLightSmoothingVeryLow.Location = new System.Drawing.Point(15, 243);
      this.rbLightSmoothingVeryLow.Name = "rbLightSmoothingVeryLow";
      this.rbLightSmoothingVeryLow.Size = new System.Drawing.Size(14, 13);
      this.rbLightSmoothingVeryLow.TabIndex = 15;
      this.rbLightSmoothingVeryLow.UseVisualStyleBackColor = true;
      this.rbLightSmoothingVeryLow.CheckedChanged += new System.EventHandler(this.rbLightSmoothing_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 220);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Light Smoothing";
      // 
      // gbToneSettings
      // 
      this.gbToneSettings.Controls.Add(this.dsWhiteClip);
      this.gbToneSettings.Controls.Add(this.dsBlackClip);
      this.gbToneSettings.Controls.Add(this.dsGamma);
      this.gbToneSettings.Location = new System.Drawing.Point(235, 12);
      this.gbToneSettings.Name = "gbToneSettings";
      this.gbToneSettings.Size = new System.Drawing.Size(211, 267);
      this.gbToneSettings.TabIndex = 17;
      this.gbToneSettings.TabStop = false;
      this.gbToneSettings.Text = "Tone Settings";
      // 
      // dsWhiteClip
      // 
      this.dsWhiteClip.Caption = "White Point";
      this.dsWhiteClip.Location = new System.Drawing.Point(6, 19);
      this.dsWhiteClip.Maximum = 5;
      this.dsWhiteClip.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsWhiteClip.Minimum = 0;
      this.dsWhiteClip.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsWhiteClip.Name = "dsWhiteClip";
      this.dsWhiteClip.OutputFormat = "F2";
      this.dsWhiteClip.Size = new System.Drawing.Size(200, 45);
      this.dsWhiteClip.StepWidth = 0.01;
      this.dsWhiteClip.TabIndex = 5;
      this.dsWhiteClip.Unit = "%";
      this.dsWhiteClip.ValuePhy = 5;
      // 
      // dsBlackClip
      // 
      this.dsBlackClip.Caption = "Black Point";
      this.dsBlackClip.Location = new System.Drawing.Point(6, 70);
      this.dsBlackClip.Maximum = 5;
      this.dsBlackClip.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsBlackClip.Minimum = 0;
      this.dsBlackClip.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsBlackClip.Name = "dsBlackClip";
      this.dsBlackClip.OutputFormat = "F2";
      this.dsBlackClip.Size = new System.Drawing.Size(200, 45);
      this.dsBlackClip.StepWidth = 0.01;
      this.dsBlackClip.TabIndex = 6;
      this.dsBlackClip.Unit = "%";
      this.dsBlackClip.ValuePhy = 5;
      // 
      // dsGamma
      // 
      this.dsGamma.Caption = "Gamma";
      this.dsGamma.Location = new System.Drawing.Point(6, 121);
      this.dsGamma.Maximum = 2;
      this.dsGamma.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsGamma.Minimum = 0.35;
      this.dsGamma.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsGamma.Name = "dsGamma";
      this.dsGamma.OutputFormat = "F2";
      this.dsGamma.Size = new System.Drawing.Size(200, 45);
      this.dsGamma.StepWidth = 0.05;
      this.dsGamma.TabIndex = 7;
      this.dsGamma.Unit = "";
      this.dsGamma.ValuePhy = 0.35;
      // 
      // gbColorSettings
      // 
      this.gbColorSettings.Controls.Add(this.dsSaturationHighlights);
      this.gbColorSettings.Controls.Add(this.dsTemperature);
      this.gbColorSettings.Controls.Add(this.dsSaturationShadows);
      this.gbColorSettings.Location = new System.Drawing.Point(452, 12);
      this.gbColorSettings.Name = "gbColorSettings";
      this.gbColorSettings.Size = new System.Drawing.Size(211, 267);
      this.gbColorSettings.TabIndex = 17;
      this.gbColorSettings.TabStop = false;
      this.gbColorSettings.Text = "Color Settings";
      // 
      // dsSaturationHighlights
      // 
      this.dsSaturationHighlights.Caption = "Saturation Highlights";
      this.dsSaturationHighlights.Location = new System.Drawing.Point(6, 70);
      this.dsSaturationHighlights.Maximum = 10;
      this.dsSaturationHighlights.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsSaturationHighlights.Minimum = -10;
      this.dsSaturationHighlights.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsSaturationHighlights.Name = "dsSaturationHighlights";
      this.dsSaturationHighlights.OutputFormat = "";
      this.dsSaturationHighlights.Size = new System.Drawing.Size(200, 45);
      this.dsSaturationHighlights.StepWidth = 1;
      this.dsSaturationHighlights.TabIndex = 9;
      this.dsSaturationHighlights.Unit = "";
      this.dsSaturationHighlights.ValuePhy = -10;
      // 
      // dsTemperature
      // 
      this.dsTemperature.Caption = "Temperature";
      this.dsTemperature.Location = new System.Drawing.Point(6, 19);
      this.dsTemperature.Maximum = 10;
      this.dsTemperature.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsTemperature.Minimum = -10;
      this.dsTemperature.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsTemperature.Name = "dsTemperature";
      this.dsTemperature.OutputFormat = "";
      this.dsTemperature.Size = new System.Drawing.Size(200, 45);
      this.dsTemperature.StepWidth = 1;
      this.dsTemperature.TabIndex = 8;
      this.dsTemperature.Unit = "";
      this.dsTemperature.ValuePhy = -10;
      // 
      // dsSaturationShadows
      // 
      this.dsSaturationShadows.Caption = "Saturation Shadows";
      this.dsSaturationShadows.Location = new System.Drawing.Point(6, 121);
      this.dsSaturationShadows.Maximum = 10;
      this.dsSaturationShadows.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsSaturationShadows.Minimum = -10;
      this.dsSaturationShadows.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsSaturationShadows.Name = "dsSaturationShadows";
      this.dsSaturationShadows.OutputFormat = "";
      this.dsSaturationShadows.Size = new System.Drawing.Size(200, 45);
      this.dsSaturationShadows.StepWidth = 1;
      this.dsSaturationShadows.TabIndex = 10;
      this.dsSaturationShadows.Unit = "";
      this.dsSaturationShadows.ValuePhy = -10;
      // 
      // gbSmoothingSettings
      // 
      this.gbSmoothingSettings.Controls.Add(this.dsShadowsSmoothing);
      this.gbSmoothingSettings.Controls.Add(this.dsMicroSmoothing);
      this.gbSmoothingSettings.Controls.Add(this.dsHighlightsSmoothing);
      this.gbSmoothingSettings.Controls.Add(this.dsShadowsClipping);
      this.gbSmoothingSettings.Location = new System.Drawing.Point(669, 12);
      this.gbSmoothingSettings.Name = "gbSmoothingSettings";
      this.gbSmoothingSettings.Size = new System.Drawing.Size(211, 267);
      this.gbSmoothingSettings.TabIndex = 17;
      this.gbSmoothingSettings.TabStop = false;
      this.gbSmoothingSettings.Text = "Smoothing Settings";
      // 
      // dsShadowsSmoothing
      // 
      this.dsShadowsSmoothing.Caption = "Shadows Smoothing";
      this.dsShadowsSmoothing.Location = new System.Drawing.Point(6, 121);
      this.dsShadowsSmoothing.Maximum = 100;
      this.dsShadowsSmoothing.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsShadowsSmoothing.Minimum = 0;
      this.dsShadowsSmoothing.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsShadowsSmoothing.Name = "dsShadowsSmoothing";
      this.dsShadowsSmoothing.OutputFormat = "";
      this.dsShadowsSmoothing.Size = new System.Drawing.Size(200, 45);
      this.dsShadowsSmoothing.StepWidth = 1;
      this.dsShadowsSmoothing.TabIndex = 13;
      this.dsShadowsSmoothing.Unit = "";
      this.dsShadowsSmoothing.ValuePhy = 0;
      // 
      // dsMicroSmoothing
      // 
      this.dsMicroSmoothing.Caption = "Micro Smoothing";
      this.dsMicroSmoothing.Location = new System.Drawing.Point(6, 19);
      this.dsMicroSmoothing.Maximum = 30;
      this.dsMicroSmoothing.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsMicroSmoothing.Minimum = 0;
      this.dsMicroSmoothing.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsMicroSmoothing.Name = "dsMicroSmoothing";
      this.dsMicroSmoothing.OutputFormat = "";
      this.dsMicroSmoothing.Size = new System.Drawing.Size(200, 45);
      this.dsMicroSmoothing.StepWidth = 1;
      this.dsMicroSmoothing.TabIndex = 11;
      this.dsMicroSmoothing.Unit = "";
      this.dsMicroSmoothing.ValuePhy = 0;
      // 
      // dsHighlightsSmoothing
      // 
      this.dsHighlightsSmoothing.Caption = "Highlights Smoothing";
      this.dsHighlightsSmoothing.Location = new System.Drawing.Point(6, 70);
      this.dsHighlightsSmoothing.Maximum = 100;
      this.dsHighlightsSmoothing.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsHighlightsSmoothing.Minimum = 0;
      this.dsHighlightsSmoothing.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsHighlightsSmoothing.Name = "dsHighlightsSmoothing";
      this.dsHighlightsSmoothing.OutputFormat = "";
      this.dsHighlightsSmoothing.Size = new System.Drawing.Size(200, 45);
      this.dsHighlightsSmoothing.StepWidth = 1;
      this.dsHighlightsSmoothing.TabIndex = 12;
      this.dsHighlightsSmoothing.Unit = "";
      this.dsHighlightsSmoothing.ValuePhy = 0;
      // 
      // dsShadowsClipping
      // 
      this.dsShadowsClipping.Caption = "Shadows Clipping";
      this.dsShadowsClipping.Location = new System.Drawing.Point(6, 172);
      this.dsShadowsClipping.Maximum = 100;
      this.dsShadowsClipping.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsShadowsClipping.Minimum = 0;
      this.dsShadowsClipping.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsShadowsClipping.Name = "dsShadowsClipping";
      this.dsShadowsClipping.OutputFormat = "";
      this.dsShadowsClipping.Size = new System.Drawing.Size(200, 45);
      this.dsShadowsClipping.StepWidth = 1;
      this.dsShadowsClipping.TabIndex = 14;
      this.dsShadowsClipping.Unit = "";
      this.dsShadowsClipping.ValuePhy = 0;
      // 
      // gbDetailEnhancer
      // 
      this.gbDetailEnhancer.Controls.Add(this.dsMicroContrast);
      this.gbDetailEnhancer.Controls.Add(this.dsStrength);
      this.gbDetailEnhancer.Controls.Add(this.dsColorSaturation);
      this.gbDetailEnhancer.Controls.Add(this.dsLuminosity);
      this.gbDetailEnhancer.Controls.Add(this.label1);
      this.gbDetailEnhancer.Controls.Add(this.lblLightSmoothingValue);
      this.gbDetailEnhancer.Controls.Add(this.rbLightSmoothingVeryLow);
      this.gbDetailEnhancer.Controls.Add(this.rbLightSmoothingVeryHigh);
      this.gbDetailEnhancer.Controls.Add(this.rbLightSmoothingLow);
      this.gbDetailEnhancer.Controls.Add(this.rbLightSmoothingHigh);
      this.gbDetailEnhancer.Controls.Add(this.rbLightSmoothingMedium);
      this.gbDetailEnhancer.Location = new System.Drawing.Point(12, 12);
      this.gbDetailEnhancer.Name = "gbDetailEnhancer";
      this.gbDetailEnhancer.Size = new System.Drawing.Size(211, 267);
      this.gbDetailEnhancer.TabIndex = 17;
      this.gbDetailEnhancer.TabStop = false;
      this.gbDetailEnhancer.Text = "Detail Enhancer";
      // 
      // dsMicroContrast
      // 
      this.dsMicroContrast.Caption = "Microcontrast";
      this.dsMicroContrast.Location = new System.Drawing.Point(6, 172);
      this.dsMicroContrast.Maximum = 10;
      this.dsMicroContrast.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsMicroContrast.Minimum = -10;
      this.dsMicroContrast.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsMicroContrast.Name = "dsMicroContrast";
      this.dsMicroContrast.OutputFormat = "";
      this.dsMicroContrast.Size = new System.Drawing.Size(200, 45);
      this.dsMicroContrast.StepWidth = 1;
      this.dsMicroContrast.TabIndex = 4;
      this.dsMicroContrast.Unit = "";
      this.dsMicroContrast.ValuePhy = -10;
      // 
      // dsStrength
      // 
      this.dsStrength.Caption = "Strength";
      this.dsStrength.Location = new System.Drawing.Point(6, 19);
      this.dsStrength.Maximum = 100;
      this.dsStrength.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsStrength.Minimum = 0;
      this.dsStrength.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsStrength.Name = "dsStrength";
      this.dsStrength.OutputFormat = "";
      this.dsStrength.Size = new System.Drawing.Size(200, 45);
      this.dsStrength.StepWidth = 1;
      this.dsStrength.TabIndex = 0;
      this.dsStrength.Unit = "";
      this.dsStrength.ValuePhy = 0;
      // 
      // dsColorSaturation
      // 
      this.dsColorSaturation.Caption = "Color Saturation";
      this.dsColorSaturation.Location = new System.Drawing.Point(6, 70);
      this.dsColorSaturation.Maximum = 100;
      this.dsColorSaturation.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsColorSaturation.Minimum = 0;
      this.dsColorSaturation.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsColorSaturation.Name = "dsColorSaturation";
      this.dsColorSaturation.OutputFormat = "";
      this.dsColorSaturation.Size = new System.Drawing.Size(200, 45);
      this.dsColorSaturation.StepWidth = 1;
      this.dsColorSaturation.TabIndex = 1;
      this.dsColorSaturation.Unit = "";
      this.dsColorSaturation.ValuePhy = 0;
      // 
      // dsLuminosity
      // 
      this.dsLuminosity.Caption = "Luminosity";
      this.dsLuminosity.Location = new System.Drawing.Point(6, 121);
      this.dsLuminosity.Maximum = 10;
      this.dsLuminosity.MaximumSize = new System.Drawing.Size(0, 45);
      this.dsLuminosity.Minimum = -10;
      this.dsLuminosity.MinimumSize = new System.Drawing.Size(200, 45);
      this.dsLuminosity.Name = "dsLuminosity";
      this.dsLuminosity.OutputFormat = "";
      this.dsLuminosity.Size = new System.Drawing.Size(200, 45);
      this.dsLuminosity.StepWidth = 1;
      this.dsLuminosity.TabIndex = 2;
      this.dsLuminosity.Unit = "";
      this.dsLuminosity.ValuePhy = -10;
      // 
      // btnImport
      // 
      this.btnImport.Location = new System.Drawing.Point(235, 394);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new System.Drawing.Size(211, 32);
      this.btnImport.TabIndex = 18;
      this.btnImport.Text = "Import from xmp";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
      // 
      // btnExport
      // 
      this.btnExport.Location = new System.Drawing.Point(452, 394);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new System.Drawing.Size(211, 32);
      this.btnExport.TabIndex = 19;
      this.btnExport.Text = "Export to xmp";
      this.btnExport.UseVisualStyleBackColor = true;
      this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
      // 
      // btnCreateScratchBatch
      // 
      this.btnCreateScratchBatch.Location = new System.Drawing.Point(669, 394);
      this.btnCreateScratchBatch.Name = "btnCreateScratchBatch";
      this.btnCreateScratchBatch.Size = new System.Drawing.Size(211, 32);
      this.btnCreateScratchBatch.TabIndex = 20;
      this.btnCreateScratchBatch.Text = "create scratch-batch";
      this.btnCreateScratchBatch.UseVisualStyleBackColor = true;
      this.btnCreateScratchBatch.Click += new System.EventHandler(this.btnCreateScratchBatch_Click);
      // 
      // btnSelectPhotomatixPath
      // 
      this.btnSelectPhotomatixPath.Location = new System.Drawing.Point(833, 27);
      this.btnSelectPhotomatixPath.Name = "btnSelectPhotomatixPath";
      this.btnSelectPhotomatixPath.Size = new System.Drawing.Size(29, 20);
      this.btnSelectPhotomatixPath.TabIndex = 21;
      this.btnSelectPhotomatixPath.Text = "...";
      this.btnSelectPhotomatixPath.UseVisualStyleBackColor = true;
      this.btnSelectPhotomatixPath.Click += new System.EventHandler(this.btnSelectPhotomatixPath_Click);
      // 
      // lblPhotomatixPath
      // 
      this.lblPhotomatixPath.AutoSize = true;
      this.lblPhotomatixPath.Location = new System.Drawing.Point(7, 30);
      this.lblPhotomatixPath.Name = "lblPhotomatixPath";
      this.lblPhotomatixPath.Size = new System.Drawing.Size(216, 13);
      this.lblPhotomatixPath.TabIndex = 22;
      this.lblPhotomatixPath.Text = "Path to Photomatix commandline executable";
      // 
      // txtPhotomatixPath
      // 
      this.txtPhotomatixPath.Location = new System.Drawing.Point(233, 27);
      this.txtPhotomatixPath.Name = "txtPhotomatixPath";
      this.txtPhotomatixPath.Size = new System.Drawing.Size(594, 20);
      this.txtPhotomatixPath.TabIndex = 23;
      // 
      // txtPhotomatixOptions
      // 
      this.txtPhotomatixOptions.Location = new System.Drawing.Point(233, 53);
      this.txtPhotomatixOptions.Name = "txtPhotomatixOptions";
      this.txtPhotomatixOptions.Size = new System.Drawing.Size(535, 20);
      this.txtPhotomatixOptions.TabIndex = 25;
      this.txtPhotomatixOptions.Leave += new System.EventHandler(this.txtPhotomatixOptions_Leave);
      // 
      // lblPhotomatixOptions
      // 
      this.lblPhotomatixOptions.AutoSize = true;
      this.lblPhotomatixOptions.Location = new System.Drawing.Point(7, 56);
      this.lblPhotomatixOptions.Name = "lblPhotomatixOptions";
      this.lblPhotomatixOptions.Size = new System.Drawing.Size(161, 13);
      this.lblPhotomatixOptions.TabIndex = 24;
      this.lblPhotomatixOptions.Text = "Photomatix commandline options";
      // 
      // btnPhotomatixOptionsDefault
      // 
      this.btnPhotomatixOptionsDefault.Location = new System.Drawing.Point(774, 53);
      this.btnPhotomatixOptionsDefault.Name = "btnPhotomatixOptionsDefault";
      this.btnPhotomatixOptionsDefault.Size = new System.Drawing.Size(53, 20);
      this.btnPhotomatixOptionsDefault.TabIndex = 26;
      this.btnPhotomatixOptionsDefault.Text = "Default";
      this.btnPhotomatixOptionsDefault.UseVisualStyleBackColor = true;
      this.btnPhotomatixOptionsDefault.Click += new System.EventHandler(this.btnPhotomatixOptionsDefault_Click);
      // 
      // btnPhotomatixOptionsHelp
      // 
      this.btnPhotomatixOptionsHelp.Location = new System.Drawing.Point(833, 53);
      this.btnPhotomatixOptionsHelp.Name = "btnPhotomatixOptionsHelp";
      this.btnPhotomatixOptionsHelp.Size = new System.Drawing.Size(29, 20);
      this.btnPhotomatixOptionsHelp.TabIndex = 27;
      this.btnPhotomatixOptionsHelp.Text = "?";
      this.btnPhotomatixOptionsHelp.UseVisualStyleBackColor = true;
      this.btnPhotomatixOptionsHelp.Click += new System.EventHandler(this.btnPhotomatixOptionsHelp_Click);
      // 
      // gbPhotomatixCommandline
      // 
      this.gbPhotomatixCommandline.Controls.Add(this.chkDeleteJpgsAfterScratching);
      this.gbPhotomatixCommandline.Controls.Add(this.txtPhotomatixOptions);
      this.gbPhotomatixCommandline.Controls.Add(this.btnPhotomatixOptionsHelp);
      this.gbPhotomatixCommandline.Controls.Add(this.btnSelectPhotomatixPath);
      this.gbPhotomatixCommandline.Controls.Add(this.btnPhotomatixOptionsDefault);
      this.gbPhotomatixCommandline.Controls.Add(this.lblPhotomatixPath);
      this.gbPhotomatixCommandline.Controls.Add(this.txtPhotomatixPath);
      this.gbPhotomatixCommandline.Controls.Add(this.lblPhotomatixOptions);
      this.gbPhotomatixCommandline.Location = new System.Drawing.Point(12, 285);
      this.gbPhotomatixCommandline.Name = "gbPhotomatixCommandline";
      this.gbPhotomatixCommandline.Size = new System.Drawing.Size(868, 103);
      this.gbPhotomatixCommandline.TabIndex = 28;
      this.gbPhotomatixCommandline.TabStop = false;
      this.gbPhotomatixCommandline.Text = "Photomatix commandline";
      // 
      // chkDeleteJpgsAfterScratching
      // 
      this.chkDeleteJpgsAfterScratching.AutoSize = true;
      this.chkDeleteJpgsAfterScratching.Location = new System.Drawing.Point(233, 79);
      this.chkDeleteJpgsAfterScratching.Name = "chkDeleteJpgsAfterScratching";
      this.chkDeleteJpgsAfterScratching.Size = new System.Drawing.Size(423, 17);
      this.chkDeleteJpgsAfterScratching.TabIndex = 28;
      this.chkDeleteJpgsAfterScratching.Text = "Delete source jpgs after scratching (should only be used when shooting jpg and ra" +
          "w)";
      this.chkDeleteJpgsAfterScratching.UseVisualStyleBackColor = true;
      this.chkDeleteJpgsAfterScratching.CheckedChanged += new System.EventHandler(this.chkDeleteJpgsAfterScratching_CheckedChanged);
      // 
      // ScratchOptionsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(891, 435);
      this.Controls.Add(this.gbPhotomatixCommandline);
      this.Controls.Add(this.btnCreateScratchBatch);
      this.Controls.Add(this.btnExport);
      this.Controls.Add(this.btnImport);
      this.Controls.Add(this.gbSmoothingSettings);
      this.Controls.Add(this.gbToneSettings);
      this.Controls.Add(this.gbColorSettings);
      this.Controls.Add(this.gbDetailEnhancer);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ScratchOptionsForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Generate scratch HDRs";
      this.Load += new System.EventHandler(this.ScratchOptionsForm_Load);
      this.gbToneSettings.ResumeLayout(false);
      this.gbColorSettings.ResumeLayout(false);
      this.gbSmoothingSettings.ResumeLayout(false);
      this.gbDetailEnhancer.ResumeLayout(false);
      this.gbDetailEnhancer.PerformLayout();
      this.gbPhotomatixCommandline.ResumeLayout(false);
      this.gbPhotomatixCommandline.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Matmaxx.Toolbox.DecoratedSlider dsStrength;
    private System.Windows.Forms.Label label1;
    private Matmaxx.Toolbox.DecoratedSlider dsLuminosity;
    private Matmaxx.Toolbox.DecoratedSlider dsColorSaturation;
    private Matmaxx.Toolbox.DecoratedSlider dsMicroContrast;
    private Matmaxx.Toolbox.DecoratedSlider dsWhiteClip;
    private Matmaxx.Toolbox.DecoratedSlider dsBlackClip;
    private Matmaxx.Toolbox.DecoratedSlider dsHighlightsSmoothing;
    private Matmaxx.Toolbox.DecoratedSlider dsMicroSmoothing;
    private Matmaxx.Toolbox.DecoratedSlider dsSaturationShadows;
    private Matmaxx.Toolbox.DecoratedSlider dsSaturationHighlights;
    private Matmaxx.Toolbox.DecoratedSlider dsTemperature;
    private Matmaxx.Toolbox.DecoratedSlider dsGamma;
    private Matmaxx.Toolbox.DecoratedSlider dsShadowsClipping;
    private Matmaxx.Toolbox.DecoratedSlider dsShadowsSmoothing;
    private System.Windows.Forms.RadioButton rbLightSmoothingVeryHigh;
    private System.Windows.Forms.RadioButton rbLightSmoothingHigh;
    private System.Windows.Forms.RadioButton rbLightSmoothingMedium;
    private System.Windows.Forms.RadioButton rbLightSmoothingLow;
    private System.Windows.Forms.RadioButton rbLightSmoothingVeryLow;
    private System.Windows.Forms.Label lblLightSmoothingValue;
    private System.Windows.Forms.GroupBox gbToneSettings;
    private System.Windows.Forms.GroupBox gbColorSettings;
    private System.Windows.Forms.GroupBox gbSmoothingSettings;
    private System.Windows.Forms.GroupBox gbDetailEnhancer;
    private System.Windows.Forms.Button btnImport;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.Button btnCreateScratchBatch;
    private System.Windows.Forms.OpenFileDialog ofdXmp;
    private System.Windows.Forms.SaveFileDialog sfdXmp;
    private System.Windows.Forms.Button btnSelectPhotomatixPath;
    private System.Windows.Forms.Label lblPhotomatixPath;
    private System.Windows.Forms.TextBox txtPhotomatixPath;
    private System.Windows.Forms.TextBox txtPhotomatixOptions;
    private System.Windows.Forms.Label lblPhotomatixOptions;
    private System.Windows.Forms.Button btnPhotomatixOptionsDefault;
    private System.Windows.Forms.Button btnPhotomatixOptionsHelp;
    private System.Windows.Forms.GroupBox gbPhotomatixCommandline;
    private System.Windows.Forms.OpenFileDialog ofdPhotomatix;
    private System.Windows.Forms.CheckBox chkDeleteJpgsAfterScratching;
  }
}