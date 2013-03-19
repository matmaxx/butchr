using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using Matmaxx.Toolbox;
using Matmaxx.Butchr.Application;
using Matmaxx.Butchr.UserInterface;
using System.IO;

namespace Matmaxx.Butchr
{
  #region delegates
  /// <summary>
  /// Delegate prototype for the notification about the creation of a thumbnail.
  /// </summary>
  /// <param name="sender">The ImageManager.</param>
  /// <param name="e">ThumbnailWorkerEventArgs that contain all the information about the event.</param>
  public delegate void OnThumbnailCreationFinished(Object sender, ThumbnailWorkerEventArgs e);
  /// <summary>
  /// Delegate prototype for the state change of a copy operation.
  /// </summary>
  /// <param name="sender">The ImageManager.</param>
  /// <param name="e">CopyEventArge that contain all the information about the event.</param>
  public delegate void OnCopyStateChanged(Object sender, CopyEventArgs e);
  #endregion


  static class Butchr
  {
    #region static props
    
    #region log manager
    /// <summary>
    /// Private instance of the log manager.
    /// </summary>
    private static LogManager log;
    /// <summary>
    /// Public getter for the log manager.
    /// </summary>
    public static LogManager Log
    {
      get { return log;  }
      set { log = value; }
    }	
    #endregion

    #region version
    /// <summary>
    /// static property to read the current version of the assembly from Properties->AssemblyInfo.cs
    /// without the revision number that is not used in this project
    /// </summary>
    public static string Version
    {
      get 
      {
        return string.Format("{0}.{1}.{2}",Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(),
                                           Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString(),
                                           Assembly.GetExecutingAssembly().GetName().Version.Build.ToString());
      }
    }
    #endregion
    
    #region initial paths
    /// <summary>
    /// Gets the data path.
    /// </summary>
    public static string DataPath
    {
      get { return System.Windows.Forms.Application.UserAppDataPath; }
    }
    /// <summary>
    /// Gets the path of the crashlog.
    /// </summary>
    public static string CrashLogPath
    {
      get { return System.IO.Path.Combine(Butchr.DataPath,"Butchered.log"); }
    }
    #endregion
    
    #endregion

    #region application lifecycle code
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      //initialize all global objects
      InitializeStaticObjects();
      //designer stuff
      System.Windows.Forms.Application.EnableVisualStyles();
      //designer stuff
      System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
      try
      {
        //start the show
        System.Windows.Forms.Application.Run(new SelectorForm());
      }
      catch (Exception ex)
      {
        //this is the last chance to catch a top level exception correctly instead of just crashing the program
        HandleTopLevelException(ex);
        System.Windows.Forms.Application.Exit();
      }
    }
    /// <summary>
    /// Initializes all static (global) objects.
    /// </summary>
    private static void InitializeStaticObjects()
    {
      //initialize the log manager
      Log = LogManager.Instance;
    }
    #endregion

    #region final crash handling
    /// <summary>
    /// Handles the top level exception.
    /// </summary>
    /// <param name="ex">The ex.</param>
    private static void HandleTopLevelException(Exception ex)
    {
      //log the crash
      LogCrashData(ex);
      //create the contents for the messagebox
      string content = string.Format("Sorry, but the butcher encountered a serious problem:{0}{1}.{0}A crashdump was created at:{0}{2}",Environment.NewLine,ex.Message,CrashLogPath);
      //show the messagebox
      MessageBox.Show(content,"World domination failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
    }
    /// <summary>
    /// Logs the crash data.
    /// </summary>
    /// <param name="exception">The exception.</param>
    private static void LogCrashData(Exception exception)
    {
      try
      {
        //create the common header for the message
        string message = string.Format("Timestamp:\t{0}\r\nException:\t{1}\r\nMessage:\t{2}\r\nStacktrace:\r\n{3}\r\n",
                                        DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"),
                                        exception.GetType().ToString(),
                                        exception.Message,
                                        exception.StackTrace
                                );
        //check for inner exceptions
        if(null != exception.InnerException) 
        {
          //add a header for the inner exceptions
          message += "InnerExceptions:\r\n";
          //and add them to the message
          while(null != exception.InnerException)
          {
            //step down one exception
            exception = exception.InnerException;
            //create the common header for the message
            message += string.Format("Timestamp:\t{0}\r\nException:\t{1}\r\nMessage:\t{2}\r\nStacktrace:\r\n{3}\r\n",
                                      DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"),
                                      exception.GetType().ToString(),
                                      exception.Message,
                                      exception.StackTrace
                                    );
          }
        }
        //add some trailing space
        message += "\r\n\r\n\r\n";
        //finally use a file for logging
        using (StreamWriter sw = File.AppendText(CrashLogPath))
        {
          //and add the message to the file
          sw.Write(message);
        }
      }
      catch(Exception)
      {
        //there is nothing more we can do if this fails
      }
    }
    #endregion
  }
}