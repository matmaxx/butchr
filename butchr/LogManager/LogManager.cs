using System;
using System.Collections.Generic;
using System.Text;

namespace Matmaxx.Toolbox
{
  #region delegates
  /// <summary>
  /// Delegate type for the log event in the <see cref="LogManager"/>.
  /// </summary>
  /// <param name="sender">The <see cref="LogManager"/>.</param>
  /// <param name="e">The <see cref="LogItem"/> to be sent to the <see cref="LogManager"/>.</param>
  public delegate void OnLogEventOccured(object sender,LogItem e);
  /// <summary>
  /// Delegate type for the state change events of the <see cref="LogManager"/>.
  /// </summary>
  /// <param name="sender">The <see cref="LogManager"/>.</param>
  /// <param name="state">The new <see cref="LogManager.LogState"/> of the <see cref="LogManager"/>.</param>
  public delegate void OnLogStateChanged(object sender,LogManager.LogState state);

  #endregion

  #region LogItem
  /// <summary>
  /// Defines the datastructure used by the <see cref="LogManager"/>.
  /// </summary>
  public class LogItem
  {
    #region props
    /// <summary>
    /// Timestamp of the logevent.
    /// </summary>
    private DateTime timestamp;
    /// <summary>
    /// Gets or sets the timestamp.
    /// </summary>
    /// <value>The timestamp.</value>
    public DateTime Timestamp
    {
      get { return timestamp; }
      set { timestamp = value; }
    }
    /// <summary>
    /// Textual content of the item.
    /// </summary>
    private string content;
    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    /// <value>The content.</value>
    public string Content
    {
      get { return content; }
      set { content = value; }
    }
    /// <summary>
    /// Gets or sets the type of the log.
    /// </summary>
    /// <value>The type of the log.</value>
    public LogManager.LogEventType LogType { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem"/> class.
    /// </summary>
    public LogItem()
    {
      this.content     = string.Empty;
      this.timestamp   = DateTime.Now;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem"/> class.
    /// </summary>
    /// <param name="content">The content.</param>
    public LogItem(string content)
    {
      this.content     = content;
      this.timestamp   = DateTime.Now;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="LogItem"/> class.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <param name="timestamp">The timestamp.</param>
    public LogItem(string content,DateTime timestamp)
    {
      this.content     = content;
      this.timestamp   = timestamp;
    }
    #endregion

    #region API
    /// <summary>
    /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
    /// </returns>
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("[{0}:{1}:{2}.{3}] {4}",timestamp.Hour,timestamp.Minute,timestamp.Second,timestamp.Millisecond,content);
      return sb.ToString();
    }
    #endregion
  }
  #endregion

  #region LogManager
  /// <summary>
  /// Handles all logging issues for the application.
  /// </summary>
  public class LogManager
  {
    #region enum
    /// <summary>
    /// Lists all possible states the the log state may take.
    /// </summary>
    public enum LogState
    {
      /// <summary>
      /// The logmanager is not running.
      /// </summary>
      Idle,
      /// <summary>
      /// The logmanager is running.
      /// </summary>
      Running,
      /// <summary>
      /// The logmanager is paused.
      /// </summary>
      Paused
    }
    /// <summary>
    /// Type of the logevent.
    /// </summary>
    public enum LogEventType
    {
      /// <summary>
      /// initial state.
      /// </summary>
      Init,
      /// <summary>
      /// official output.
      /// </summary>
      Output,
      /// <summary>
      /// debug output.
      /// </summary>
      Debug,
      /// <summary>
      /// Error output.
      /// </summary>
      Error
    }
    #endregion 

    #region props
    /// <summary>
    /// Global state of the logmanager.
    /// </summary>
    private LogState state;
    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    /// <value>The state.</value>
    public LogState State
    {
      get { return state; }
      set { state = value; }
    }
    /// <summary>
    /// The singleton instance.
    /// </summary>
    private static LogManager instance;
    /// <summary>
    /// Gets the singleton instance.
    /// </summary>
    /// <value>The singleton.</value>
    public static LogManager Instance
    {
      get 
      { 
        //check if a new instance has to be created.
        if(null == instance) instance = new LogManager();
        //return the singleton instance
        return instance; 
      }
    }

    #endregion

    #region events
    /// <summary>
    /// Event to notify all connected loggers about a new log item available.
    /// </summary>
    public event OnLogEventOccured OnNewLogAvailable;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="LogManager"/> class.
    /// </summary>
    private LogManager()
    {
      //start in the running state
      state = LogState.Running;
    }
    #endregion

    #region API
    /// <summary>
    /// API for the application to create a debug logitem during development.
    /// </summary>
    /// <param name="content">The text to be displayed.</param>
    public void Debug(String content)
    {
//      #if(DEBUG)
      //check if the log is currently running and if vector user is logged in (only on release build)
      if(LogState.Running == state)
      {
        //create a local object for the logevent
        LogItem item = new LogItem(content);
        //change the logtype
        item.LogType = LogEventType.Debug;
        //broadcast the event to all connected clients
        if(null != OnNewLogAvailable) OnNewLogAvailable((object)null,item);
      }
//      #endif
    }
    /// <summary>
    /// API for the application to create a error logitem during development.
    /// </summary>
    /// <param name="content">The text to be displayed.</param>
    public void Error(String content)
    {
      //check if the log is currently running and if vector user is logged in (only on release build)
      if(LogState.Running == state)
      {
        //create a local object for the logevent
        LogItem item = new LogItem(content);
        //change the logtype
        item.LogType = LogEventType.Error;
        //broadcast the event to all connected clients
        if(null != OnNewLogAvailable) OnNewLogAvailable((object)null,item);
      }
    }
    /// <summary>
    /// API for the application to create a official logitems.
    /// </summary>
    /// <param name="content">The text to be displayed.</param>
    public void Output(String content)
    {
      //check if the log is currently running
      if(LogState.Running == state)
      {
        //create a local object for the logevent
        LogItem item = new LogItem(content);
        //change the logtype
        item.LogType = LogEventType.Output;
        //broadcast the event to all connected clients
        if(null != OnNewLogAvailable) OnNewLogAvailable((object)null,item);
      }
    }
    #endregion
  }
  #endregion
}

