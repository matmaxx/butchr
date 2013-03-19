using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Matmaxx.Toolbox
{
  /// <summary>
  /// User control that imitates the slider controls in Photomatix
  /// </summary>
  public partial class DecoratedSlider : UserControl
  {
    #region props

    #region Caption
    /// <summary>
    /// Gets or sets the caption.
    /// </summary>
    /// <value>The caption.</value>
    [Description("The displayed name of the slider value.")]
    [Category("Physical values")]
    public string Caption
    {
      get { return lblCaption.Text; }
      set 
      { 
        //set the new value
        lblCaption.Text = value; 
        //and display it
        UpdateDisplay();
      }
    }
    #endregion

    #region Unit
    /// <summary>
    /// The unit.
    /// </summary>
    private string unit;
    /// <summary>
    /// Gets or sets the unit.
    /// </summary>
    /// <value>The unit.</value>
    [Description("The physical unit of the slider value.")]
    [Category("Physical values")]
    public string Unit
    {
      get { return unit; }
      set 
      { 
        //set the new value
        unit = value; 
        //and display it
        UpdateDisplay();
      }
    }
    #endregion

    #region Minimum
    /// <summary>
    /// The physical minimum.
    /// </summary>
    private double minimum;
    /// <summary>
    /// Gets or sets the physical minimum.
    /// </summary>
    /// <value>The physical minimum.</value>
    [Description("The physical minimum of the slider.")]
    [Category("Physical values")]
    public double Minimum
    {
      get { return minimum; }
      set { minimum = value; }
    }
    #endregion

    #region Maximum
    /// <summary>
    /// The physical maximum.
    /// </summary>
    private double maximum;
    /// <summary>
    /// Gets or sets the physical maximum.
    /// </summary>
    /// <value>The physical maximum.</value>
    [Description("The physical maximum of the slider.")]
    [Category("Physical values")]
    public double Maximum
    {
      get { return maximum; }
      set { maximum = value; }
    }
    #endregion

    #region StepWidth
    /// <summary>
    /// The physical stepwidth.
    /// </summary>
    private double stepWidth;
    /// <summary>
    /// Gets or sets the physical stepwidth.
    /// </summary>
    /// <value>The physical stepwidth.</value>
    [Description("The physical stepwidth to divide the slider in.")]
    [DisplayName("Step width")]
    [Category("Physical values")]
    public double StepWidth
    {
      get { return stepWidth; }
      set { stepWidth = value; }
    }
    #endregion

    #region OutputFormat
    /// <summary>
    /// The output format of the phyical value.
    /// </summary>
    private string outputFormat;
    /// <summary>
    /// Gets or sets the output format of the phyical value.
    /// </summary>
    /// <value>The output format of the phyical value.</value>
    [Description("The output format of the numerical representation of the slider value (format for the ToString() conversion).")]
    [Category("Physical values")]
    public string OutputFormat
    {
      get { return outputFormat; }
      set 
      { 
        //set the new value
        outputFormat = value; 
        //and display it
        UpdateDisplay();
      }
    }
    #endregion

    #region ValuePhy
    /// <summary>
    /// Gets or sets the physical value.
    /// </summary>
    /// <value>The physical value.</value>
    [Description("The physical value of the slider.")]
    [DisplayName("Physical value")]
    [Category("Physical values")]
    public double ValuePhy
    {
      get { return Raw2Phy(tbValue.Value); }
      set 
      { 
        //update the internal value
        tbValue.Value = Phy2Raw(value); 
        //and display it
        UpdateDisplay();
      }
    }

    #endregion

    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="DecoratedSlider"/> class.
    /// </summary>
    public DecoratedSlider()
    {
      //designer stuff
      InitializeComponent();
    }
    #endregion

    #region event handler
    /// <summary>
    /// Handles the Scroll event of the tbValue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tbValue_Scroll(object sender, EventArgs e)
    {
      //update the display
      UpdateDisplay();
    }
    /// <summary>
    /// Handles the Load event of the DecoratedSlider control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void DecoratedSlider_Load(object sender, EventArgs e)
    {
      //update the control
      UpdateDisplay();
    }
    /// <summary>
    /// Handles the Resize event of the DecoratedSlider control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void DecoratedSlider_Resize(object sender, EventArgs e)
    {
      tbValue.Left = 0;
      tbValue.Width = this.Width;
      txtValuePhy.Left = this.Width - txtValuePhy.Width - 10;
    }
    /// <summary>
    /// Handles the KeyDown event of the txtValuePhy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    private void txtValuePhy_KeyDown(object sender, KeyEventArgs e)
    {
      //local for the numerical value
      double newValue = 0.0;
      //check if this was the return key
      if(e.KeyCode.Equals(Keys.Return))
      {
        try
        {
          if(false == unit.Equals(string.Empty))
          {
            newValue = double.Parse(txtValuePhy.Text.Replace(unit,string.Empty).Replace(" ",string.Empty).Trim());
          }
          else
          {
            newValue = double.Parse(txtValuePhy.Text.Trim());
          }

          tbValue.Value = Phy2Raw(newValue);   
        }
        catch(Exception)
        {
          //return to the old value in finally
        }
        finally 
        {
          UpdateDisplay();
          this.Focus();
        }
      }
    }
    /// <summary>
    /// Handles the Click event of the txtValuePhy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void txtValuePhy_Click(object sender, EventArgs e)
    {
      try
      {
        if(false == unit.Equals(string.Empty))
        {
          txtValuePhy.Text = txtValuePhy.Text.Replace(unit,string.Empty).Replace(" ",string.Empty).Trim();
        }
      }
      catch(Exception)
      {
      
      }
      txtValuePhy.Select(0,txtValuePhy.Text.Length);
    }
    #endregion

    #region helper functions
    /// <summary>
    /// Updates the display.
    /// </summary>
    private void UpdateDisplay()
    {
      try
      {
        //set the limits
        tbValue.Minimum = Phy2Raw(minimum);
        tbValue.Maximum = Phy2Raw(maximum);
        txtValuePhy.Text = (unit.Equals(string.Empty) ? ValuePhy.ToString(outputFormat) : string.Format("{0} {1}",ValuePhy.ToString(outputFormat),unit));
        lblValueRaw.Text = string.Format("[ {0} / {1} / {2} ]",tbValue.Minimum.ToString(),tbValue.Value.ToString(),tbValue.Maximum.ToString());
        tbValue.Value = (int)tbValue.Value;
      }
      catch(Exception)
      {
        
      }
    }
    /// <summary>
    /// Converts from the the physical value to the raw screen representation.
    /// </summary>
    /// <param name="phy">The physical value.</param>
    /// <returns>the raw value.</returns>
    private int Phy2Raw(double phy)
    {
      return (int)Math.Round(((phy-minimum) / stepWidth),0);
    }
    /// <summary>
    /// Converts from the raw screen representation to the physical value.
    /// </summary>
    /// <param name="raw">The raw value.</param>
    /// <returns>the physical value</returns>
    private double Raw2Phy(int raw)
    {
      return (double)Math.Round(((raw * stepWidth) + minimum),2);
    }
    #endregion
  }
}