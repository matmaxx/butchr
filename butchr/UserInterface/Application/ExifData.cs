using System;
using System.Collections.Generic;
using System.Text;
using Matmaxx.Butchr.Properties;

namespace Matmaxx.Butchr.Application
{
  /// <summary>
  /// Class to hold the exifdata for a jpg file.
  /// </summary>
  public class ExifData
  {
    #region props
    /// <summary>
    /// Gets or sets the original timestamp.
    /// </summary>
    /// <value>The original timestamp.</value>
    public DateTime? OriginalTimestamp { get; set; }
    /// <summary>
    /// Gets or sets the exposure time.
    /// </summary>
    /// <value>The exposure time.</value>
    public double? ShutterSpeed { get; set; }
    /// <summary>
    /// Gets or sets the F stop.
    /// </summary>
    /// <value>The F stop.</value>
    public double? FStop { get; set; }
    /// <summary>
    /// Gets or sets the iso speed rating.
    /// </summary>
    /// <value>The iso speed rating.</value>
    public ushort? IsoSpeedRating { get; set; }
    /// <summary>
    /// Gets or sets the length of the focal.
    /// </summary>
    /// <value>The length of the focal.</value>
    public double? FocalLength { get; set; }
    /// <summary>
    /// Gets or sets the camera model.
    /// </summary>
    /// <value>The camera model.</value>
    public string CameraModel { get; set; }
    /// <summary>
    /// Gets or sets the camera oem.
    /// </summary>
    /// <value>The camera oem.</value>
    public string CameraOem { get; set; }
    /// <summary>
    /// Gets or sets the orientation.
    /// </summary>
    /// <value>The orientation.</value>
    public ushort? Orientation { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="ExifData"/> class.
    /// </summary>
    public ExifData()
    {
      //reset all values to save defaults
      OriginalTimestamp = null;
      ShutterSpeed = null;
      FStop = null;
      IsoSpeedRating = null;
      FocalLength = null;
      CameraModel = null;
      CameraOem = null;
      Orientation = null;
    }
    /// <summary>
    /// converts the exif data to a string/string dictionary.
    /// </summary>
    /// <returns>The dictionary.</returns>
    public Dictionary<string,string> ToDictionary()
    {
      //local result
      Dictionary<string,string> result = new Dictionary<string,string>();
      //format the original timestamp
      string timestamp = string.Format( "{0:0000}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}",
                                        OriginalTimestamp.Value.Year,
                                        OriginalTimestamp.Value.Month,
                                        OriginalTimestamp.Value.Day,
                                        OriginalTimestamp.Value.Hour,
                                        OriginalTimestamp.Value.Minute,
                                        OriginalTimestamp.Value.Second);
      //Add the camera model
      TryAddToDictionary<string>(result,Resources.ExifKeyCameraModel,CameraModel,string.Empty,string.Empty);
      //Add the camera OEM
      TryAddToDictionary<string>(result,Resources.ExifKeyCameraOEM,CameraOem,string.Empty,string.Empty);
      //add the original timestamp
      TryAddToDictionary<string>(result,Resources.ExifKeyOriginalTimestamp,timestamp,string.Empty,string.Empty);
      //Add the shutterspeed
      TryAddToDictionary<string>(result,Resources.ExifKeyShutterspeed,(ShutterSpeed != null ? ShutterSpeedToString() : Resources.ExifValueNotAvailable),string.Empty,"s");
      //Add the FStop
      TryAddToDictionary<double>(result,Resources.ExifKeyFStop,(FStop != null ? (double)FStop : (double)0),"f/",string.Empty);
      //Add the ISO
      TryAddToDictionary<ushort>(result,Resources.ExifKeyIsoSpeedRating,(IsoSpeedRating != null ? (ushort)IsoSpeedRating : (ushort)0),string.Empty,string.Empty);
      //Add the focal length
      TryAddToDictionary<double>(result,Resources.ExifKeyFocalLength,(FocalLength != null ? (double)FocalLength : (double)0),string.Empty,"mm");
      //Add the orientation
      TryAddToDictionary<string>(result,Resources.ExifKeyOrientation,(Orientation != null ? (((ushort)Orientation).Equals(0) ? Resources.ExifValueOrientationPortrait : Resources.ExifValueOrientationLandscape) : Resources.ExifValueNotAvailable),string.Empty,string.Empty);
      //finally return something
      return result;
    }
    /// <summary>
    /// Converts the shutterspeed to the fractional presentation.
    /// </summary>
    /// <returns></returns>
    private string ShutterSpeedToString()
    {
      //local for the fraction part
      double fraction = 0;
      //local for the non nullable shutterspeed (it is checked before calling this function
      double shutterspeed = (double) ShutterSpeed;
      //local result
      string result = string.Empty;
      //check if the shutterspeed is below one second
      if(ShutterSpeed < 1)
      {
        //reverse the fraction
        fraction = ((double)(1/shutterspeed));
        //and add it in the 1/x syntax
        result = string.Format("1/{0}",fraction);
      }
      else
      {
        //add it in the x.x syntax
        result = string.Format("{0:0.000}",shutterspeed);
      }
      //finally return the result
      return result;
    }
    /// <summary>
    /// Tries to convert and add the current value to the dictionary.
    /// </summary>
    /// <typeparam name="T">The type of value to be converted</typeparam>
    /// <param name="dict">The dictionary.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <param name="prefix">The prefix.</param>
    /// <param name="suffix">The suffix.</param>
    private void TryAddToDictionary<T>(Dictionary<string,string> dict,string key,T value, string prefix, string suffix) where T : IConvertible
    {
      string valString = string.Empty;
      //check if the value is null
      if(null != value)
      {
        try 
	      {	        
          //no, it has a value, so try to parse it
          valString = string.Format("{0}{1}{2}",prefix,value.ToString(),suffix);
	      }
	      catch (Exception)
	      {
          //conversion did not work, set a default
          valString = Resources.ExifValueNotAvailable;
	      }
      }
      else
      {
        //value is null, set a default
        valString = Resources.ExifValueNotAvailable;
      }
      //finally add it
      dict.Add(key,valString);
    }
    #endregion
  }
}
