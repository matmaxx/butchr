using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Matmaxx.Butchr.Application.XmpTm
{
  #region xmpmeta
  /// <summary>
  /// xmpmeta wrapper class
  /// </summary>
  [XmlRoot(Namespace = "adobe:ns:meta/")]
  public class xmpmeta
  {
    #region props
    /// <summary>
    /// THe RDF.
    /// </summary>
    private RDF rdf;
    /// <summary>
    /// Gets or sets the RDF.
    /// </summary>
    /// <value>The RDF.</value>
    [XmlElement(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public RDF RDF
    {
	    get { return rdf;}
	    set { rdf = value;}
    }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="xmpmeta"/> class.
    /// </summary>
    public xmpmeta()
    {
      //init the one and only object
      rdf = new RDF();
    }
    #endregion
  }
  #endregion

  #region RDF
  /// <summary>
  /// RDF wrapper class
  /// </summary>
  public class RDF
  {
    #region props
    /// <summary>
    /// The description.
    /// </summary>
    private Description description;
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    [XmlElement(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public Description Description
    {
      get { return description; }
      set { description = value; }
    }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="RDF"/> class.
    /// </summary>
    public RDF()
    {
      //init the one and only object
      description = new Description();
    }
    #endregion
  }
  #endregion

  #region Description
  /// <summary>
  /// The description part of the xmp file.
  /// </summary>
  public class Description
  {
    #region const
    /// <summary>
    /// The supported photomatix version.
    /// </summary>
    public const string PhotomatixVersion = "3.1";
    /// <summary>
    /// The supported photomatix method.
    /// </summary>
    public const string PhotomaticMethod = "Details Enhancer";
    #endregion

    #region enum
    /// <summary>
    /// Lists all smoothing levels.
    /// </summary>
    public enum SmoothingLevel
    {
      /// <summary>
      /// Never use this on.
      /// </summary>
      VeryLow = 0,
      /// <summary>
      /// Still really awful.
      /// </summary>
      Low = 1,
      /// <summary>
      /// Awful in most cases.
      /// </summary>
      Medium = 2,
      /// <summary>
      /// Looks good sometimes.
      /// </summary>
      High = 3,
      /// <summary>
      /// Looks good in most cases.
      /// </summary>
      VeryHigh = 4
    }
    #endregion

    #region props

    #region Version
    /// <summary>
    /// The version string.
    /// </summary>
    private string version;
    /// <summary>
    /// Gets or sets the version.
    /// </summary>
    /// <value>The version.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public string Version
    {
      get { return version; }
      set { version = value; }
    }
    #endregion

    #region Method
    /// <summary>
    /// The method (currently, only 'details enhancer' is supported)
    /// </summary>
    private string method;
    /// <summary>
    /// Gets or sets the method (currently, only 'details enhancer' is supported).
    /// </summary>
    /// <value>The method (currently, only 'details enhancer' is supported).</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public string Method
    {
      get { return method; }
      set { method = value; }
    }
    #endregion

    #region Luminosity
    /// <summary>
    /// The Luminosity.
    /// </summary>
    private int luminosity;
    /// <summary>
    /// Gets or sets the luminosity.
    /// </summary>
    /// <value>The luminosity.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int Luminosity
    {
      get { return luminosity; }
      set { luminosity = value; }
    }
    #endregion

    #region Strength
    /// <summary>
    /// The Strength.
    /// </summary>
    private int strength;
    /// <summary>
    /// Gets or sets the strength.
    /// </summary>
    /// <value>The strength.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int Strength
    {
      get { return strength; }
      set { strength = value; }
    }
    #endregion

    #region ColorSaturation
    /// <summary>
    /// The color saturation.
    /// </summary>
    private int colorSaturation;
    /// <summary>
    /// Gets or sets the color saturation.
    /// </summary>
    /// <value>The color saturation.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int ColorSaturation
    {
      get { return colorSaturation; }
      set { colorSaturation = value; }
    }
    #endregion

    #region WhiteClip
    /// <summary>
    /// The white point.
    /// </summary>
    private double whiteClip;
    /// <summary>
    /// Gets or sets the white point.
    /// </summary>
    /// <value>The white point.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public double WhiteClip
    {
      get { return whiteClip; }
      set { whiteClip = value; }
    }
    #endregion

    #region BlackClip
    /// <summary>
    /// The black point.
    /// </summary>
    private double blackClip;
    /// <summary>
    /// Gets or sets the black point.
    /// </summary>
    /// <value>The black point.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public double BlackClip
    {
      get { return blackClip; }
      set { blackClip = value; }
    }

    #endregion

    #region Smoothing
    /// <summary>
    /// The smoothing.
    /// </summary>
    private string smoothing;
    /// <summary>
    /// Gets or sets the smoothing.
    /// </summary>
    /// <value>The smoothing.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public string Smoothing
    {
      get { return smoothing; }
      set { smoothing = value; }
    }
    #endregion

    #region MicroContrast
    /// <summary>
    /// The micro contrast.
    /// </summary>
    private int microcontrast;
    /// <summary>
    /// Gets or sets the micro contrast.
    /// </summary>
    /// <value>The micro contrast.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int Microcontrast
    {
      get { return microcontrast; }
      set { microcontrast = value; }
    }
    #endregion

    #region Microsmoothing
    /// <summary>
    /// The micro smoothing.
    /// </summary>
    private int microsmoothing;
    /// <summary>
    /// Gets or sets the micro smoothing.
    /// </summary>
    /// <value>The micro smoothing.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int Microsmoothing
    {
      get { return microsmoothing; }
      set { microsmoothing = value; }
    }
    #endregion

    #region Gamma
    /// <summary>
    /// The gamma.
    /// </summary>
    private double gamma;
    /// <summary>
    /// Gets or sets the gamma.
    /// </summary>
    /// <value>The gamma.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public double Gamma
    {
      get { return gamma; }
      set { gamma = value; }
    }
    #endregion

    #region HighlightsSmoothing
    /// <summary>
    /// The highlights smoothing.
    /// </summary>
    private int highlightsSmoothing;
    /// <summary>
    /// Gets or sets the highlights smoothing.
    /// </summary>
    /// <value>The highlights smoothing.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int HighlightsSmoothing
    {
      get { return highlightsSmoothing; }
      set { highlightsSmoothing = value; }
    }
    #endregion

    #region ShadowsSmoothing
    /// <summary>
    /// The shadow smoothing.
    /// </summary>
    private int shadowsSmoothing;
    /// <summary>
    /// Gets or sets the shadow smoothing.
    /// </summary>
    /// <value>The shadow smoothing.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int ShadowsSmoothing
    {
      get { return shadowsSmoothing; }
      set { shadowsSmoothing = value; }
    }
    #endregion

    #region ShadowsClipping
    /// <summary>
    /// The shadow clipping.
    /// </summary>
    private int shadowsClipping;
    /// <summary>
    /// Gets or sets the shadow clipping.
    /// </summary>
    /// <value>The shadow clipping.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int ShadowsClipping
    {
      get { return shadowsClipping; }
      set { shadowsClipping = value; }
    }
    #endregion

    #region ColorTemperature
    /// <summary>
    /// The color temperature.
    /// </summary>
    private int colorTemperature;
    /// <summary>
    /// Gets or sets the color temperature.
    /// </summary>
    /// <value>The color temperature.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int ColorTemperature
    {
      get { return colorTemperature; }
      set { colorTemperature = value; }
    }
    #endregion

    #region SaturationHighlights
    /// <summary>
    /// The saturation of the highlights.
    /// </summary>
    private int saturationHighlights;
    /// <summary>
    /// Gets or sets the saturation of the highlights.
    /// </summary>
    /// <value>The saturation of the highlights.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int SaturationHighlights
    {
      get { return saturationHighlights; }
      set { saturationHighlights = value; }
    }
    #endregion

    #region SaturationShadows
    /// <summary>
    /// The saturation of the shadows.
    /// </summary>
    private int saturationShadows;
    /// <summary>
    /// Gets or sets the saturation of the shadows.
    /// </summary>
    /// <value>The saturation of the shadows.</value>
    [XmlElement(Namespace = "http://www.hdrsoft.com/tone_mapping_settings")]
    public int SaturationShadows
    {
      get { return saturationShadows; }
      set { saturationShadows = value; }
    }
    #endregion

    #endregion

    #region members
    /// <summary>
    /// Conversion table to get from the numerical representation of a smoothing value to its string representation.
    /// </summary>
    [XmlIgnore()]
    public Dictionary<SmoothingLevel,string> SmoothingInt2String;
    /// <summary>
    /// Conversion table to get from the string representation of a smoothing value to its numerical representation.
    /// </summary>
    [XmlIgnore()]
    public Dictionary<string,SmoothingLevel> SmoothingString2Int;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="Description"/> class.
    /// </summary>
    public Description()
    {
      //Initialize the x-tables
      InitializeConversionTables();
      //reset all props to my preferred defaults
      InitializeProperties();
    }
    /// <summary>
    /// Initializes the properties.
    /// </summary>
    private void InitializeProperties()
    {
      this.version = Description.PhotomatixVersion;
      this.method = Description.PhotomaticMethod;
      this.luminosity = 10;
      this.strength = 100;
      this.colorSaturation = 20;
      this.whiteClip = 5.0;
      this.blackClip = 5.0;
      this.smoothing = SmoothingInt2String[SmoothingLevel.VeryHigh];
      this.microcontrast = 3;
      this.microsmoothing = 0;
      this.gamma = 1.0;
      this.highlightsSmoothing = 0;
      this.shadowsSmoothing = 0;
      this.shadowsClipping = 0;
      this.colorTemperature = 0;
      this.saturationHighlights = 2;
      this.saturationShadows = 2;
    }
    /// <summary>
    /// Initializes the conversion tables.
    /// </summary>
    private void InitializeConversionTables()
    {
      //smoothing int -> string
      SmoothingInt2String = new Dictionary<SmoothingLevel,string>();
      SmoothingInt2String.Add(SmoothingLevel.VeryLow,   "Very Low");
      SmoothingInt2String.Add(SmoothingLevel.Low,       "Low");
      SmoothingInt2String.Add(SmoothingLevel.Medium,    "Medium");
      SmoothingInt2String.Add(SmoothingLevel.High,      "High");
      SmoothingInt2String.Add(SmoothingLevel.VeryHigh,  "Very High");
      //smoothing string -> int 
      SmoothingString2Int = new Dictionary<string,SmoothingLevel>();
      SmoothingString2Int.Add("Very Low"  ,SmoothingLevel.VeryLow);
      SmoothingString2Int.Add("Low"       ,SmoothingLevel.Low);
      SmoothingString2Int.Add("Medium"    ,SmoothingLevel.Medium);
      SmoothingString2Int.Add("High"      ,SmoothingLevel.High);
      SmoothingString2Int.Add("Very High" ,SmoothingLevel.VeryHigh);
    }
    #endregion
  }
  #endregion
}
