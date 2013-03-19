using System;
using System.Collections.Generic;
using System.Text;

namespace Matmaxx.Butchr.Application
{
  #region ThumbnailWorkerEventArgs
  /// <summary>
  /// Data class for the threadpool workers.
  /// </summary>
  public class ThumbnailWorkerEventArgs : EventArgs
  {
    /// <summary>
    /// The path of the file to be loaded.
    /// </summary>
    public string Path;
    /// <summary>
    /// The maximum width of the created thumbnail.
    /// </summary>
    public int Width;
    /// <summary>
    /// The maximum height of the created thumbnail.
    /// </summary>
    public int Height;
    /// <summary>
    /// Flag to indicate that this is the last image to be loaded.
    /// </summary>
    public bool IsLastImage;
    /// <summary>
    /// The number of thumbnails to be expected in the current operation. 
    /// </summary>
    public int expectedAmount;
    /// <summary>
    /// Initializes a new instance of the ThumbnailWorkerData class.
    /// </summary>
    /// <param name="path">The path of the file to be loaded.</param>
    /// <param name="width">The maximum width of the created thumbnail.</param>
    /// <param name="height">The maximum height of the created thumbnail.</param>
    /// <param name="isLastImage">Flag to indicate that this is the last image to be loaded.</param>
    /// <param name="expectedAmount">The expected amount.</param>
    public ThumbnailWorkerEventArgs(string path, int width, int height, bool isLastImage, int expectedAmount)
    {
      this.Path         = path;
      this.Width        = width;
      this.Height       = height;
      this.IsLastImage  = isLastImage;
      this.expectedAmount = expectedAmount;
    }
  }
  #endregion

  #region CopyEventArgs
  /// <summary>
  /// Event args class for copy workers.
  /// </summary>
  public class CopyEventArgs : EventArgs
  {
    #region enum
    /// <summary>
    /// Specifies the event.
    /// </summary>
    public enum CopyEventType
    {
      /// <summary>
      /// Initial value for default construction.
      /// </summary>
      None,
      /// <summary>
      /// One more jpg is copied.
      /// </summary>
      JpgStep,
      /// <summary>
      /// One more raw is copied.
      /// </summary>
      RawStep,
      /// <summary>
      /// Finished copying the jpgs.
      /// </summary>
      JpgFinished,
      /// <summary>
      /// Finished copying the raws.
      /// </summary>
      RawFinished,
      /// <summary>
      /// Cancel the complete operation.
      /// </summary>
      CancelOperation,
      /// <summary>
      /// copy aborted with an error.
      /// </summary>
      Error
    }
    #endregion

    #region members
    /// <summary>
    /// The source directory.
    /// </summary>
    public string Source;
    /// <summary>
    /// The target directory.
    /// </summary>
    public string Target;
    /// <summary>
    /// The kind of event that is fired.
    /// </summary>
    public CopyEventType CopyEvent;
    /// <summary>
    /// A message to display in the log window.
    /// </summary>
    public string Message;
    /// <summary>
    /// the counting index of the current image.
    /// </summary>
    public int CountCurrent;
    /// <summary>
    /// The total number of images.
    /// </summary>
    public int CountTotal;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="CopyEventArgs"/> class.
    /// </summary>
    public CopyEventArgs() : this(string.Empty,string.Empty,CopyEventType.None,string.Empty) 
    {

    }
    /// <summary>
    /// Initializes a new instance of the <see cref="CopyEventArgs"/> class.
    /// </summary>
    /// <param name="source">The source directory.</param>
    /// <param name="target">The target directory.</param>
    /// <param name="copyEvent">The copy event.</param>
    /// <param name="Message">The message.</param>
    public CopyEventArgs(string source, string target, CopyEventType copyEvent, string Message)
    {
      //backup all specified values 
      this.Source     = source;
      this.Target     = target;
      this.CopyEvent  = copyEvent;
      this.Message    = Message;
    }
    #endregion
  }
  #endregion
}
