using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Matmaxx.Toolbox.StopWatch
{
  /// <summary>
  /// Debug Timer for time measurements.
  /// </summary>
  public class DebugTimer
  {
    #region const
    /// <summary>
    /// The default path that is set in the constructor
    /// </summary>
    public const string DefaultPath = @"DebugTimerOutput.txt";
    /// <summary>
    /// The default action that is set in the constructor
    /// </summary>
    public const string DefaultAction = "Action without a name";
    #endregion

    #region enum
    /// <summary>
    /// The output method of the timer.
    /// </summary>
    public enum Method
    { 
      /// <summary>
      /// Output to file.
      /// </summary>
      File,
      /// <summary>
      /// Output to string.
      /// </summary>
      String
    }
    #endregion

    #region props

    #region singleton
    /// <summary>
    /// singleton instance.
    /// </summary>
    private static DebugTimer instance;
    /// <summary>
    /// Singleton property.
    /// </summary>
    public static DebugTimer Instance
    {
      get
      {
        //create the instance if not done yet
        if (null == instance) instance = new DebugTimer();
        //return the instance
        return instance;
      }
    }
    #endregion

    #region output
    /// <summary>
    /// Local output string.
    /// </summary>
    private string output;
    /// <summary>
    /// Current output string.
    /// </summary>
    public string Output
    {
      get { return output; }
      set { output = value; }
    }
	
    #endregion

    #endregion

    #region members
    /// <summary>
    /// The instrument for measuring the time.
    /// </summary>
    Stopwatch timer;
    /// <summary>
    /// The internal method to be used.
    /// </summary>
    Method method;
    /// <summary>
    /// The path for logging to a file.
    /// </summary>
    string path;
    /// <summary>
    /// The name of the current action to be measured.
    /// </summary>
    string action;
    #endregion

    #region lifecycle code
    /// <summary>
    /// private construction for the singleton instance
    /// </summary>
    public DebugTimer()
    {
      //create the timer
      timer = new Stopwatch();
      //set the method to filelogging as default
      method = Method.File;
      //use the default path
      path = DefaultPath;
      //use the default action
      action = DefaultAction;
    }
    #endregion

    #region API
    /// <summary>
    /// Configuration API to change the method to file logging.
    /// </summary>
    /// <param name="path">The path for logging.</param>
    public void OutputToFile(string path)
    {
      //set the method
      this.method = Method.File;
      //and backup the path
      this.path = path;
    }
    /// <summary>
    /// Configuration API to change the method to string logging.
    /// </summary>
    public void OutputToString()
    {
      //change the method
      method = Method.String;    
    }
    /// <summary>
    /// Resets the timer and reinits everything.
    /// </summary>
    public void Reset()
    {
      try
      {
        //try to delete the file
        if(File.Exists(path)) File.Delete(path);
      }
      catch (Exception)
      {
      }
      //stop the timer if necessary
      if(timer.IsRunning) timer.Reset();
      //clear the output string
      output = string.Empty;
    }
    /// <summary>
    /// Starts a new measurement without a new action.
    /// </summary>
    public void Start()
    {
      Start(String.Empty);
    }
    /// <summary>
    /// Starts a new measurement with a defined action.
    /// </summary>
    /// <param name="action"></param>
    public void Start(string action)
    {
      //check if the timer is already running
      if (timer.IsRunning) throw new InvalidOperationException(Properties.Resources.ExTimerAlreadyActive);
      //backup the action
      this.action = action.Equals(string.Empty) ? DefaultAction : action;
      //reset the timer
      timer.Reset();
      //start the timer
      timer.Start();
    }
    /// <summary>
    /// Stops a running measurement.
    /// </summary>
    public void Stop()
    {
      //check if the timer is already running
      if (false == timer.IsRunning) throw new InvalidOperationException(Properties.Resources.ExTimerNotActive);
      //start the timer
      timer.Stop();
      //build the output
      output = BuildOutput();
      //check for file output
      if(method == Method.File)
      { 
        //add to the file
        File.AppendAllText(path,output);      
      }
    }
    /// <summary>
    /// Stops a running measurement and displays the result in a Messagebox.
    /// </summary>
    public void StopMsgBox()
    {
      //stop it
      Stop();  
      //and display the result
      MessageBox.Show(Output);
    }
    /// <summary>
    /// Adds the given number of empty lines to the log file.
    /// </summary>
    /// <param name="amount">The number of empty lines to be added</param>
    public void AddNewLine(int amount)
    {
      //check if file logging is active
      if(method == Method.File)
      {
        //loop by the amount
        for (int i = 0; i < amount; i++)
			  {
          //add one new line
          File.AppendAllText(path,Environment.NewLine);   
			  }
      }
    }
    #endregion

    #region helper functions
    /// <summary>
    /// Builds the current output string.
    /// </summary>
    /// <returns>The current output string.</returns>
    private string BuildOutput()
    { 
      DateTime now = DateTime.Now;
      return string.Format("[{0}:{1}:{2}.{3}] {4}: {5}ms{6}", 
                           now.Hour.ToString("d2"),
                           now.Minute.ToString("d2"),
                           now.Second.ToString("d2"),
                           now.Millisecond.ToString("d4"), 
                           action, 
                           timer.ElapsedMilliseconds.ToString(),
                           Environment.NewLine);    
    }
    #endregion
  }
}
