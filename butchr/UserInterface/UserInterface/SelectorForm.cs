using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using Matmaxx.Toolbox.StopWatch;
using Matmaxx.Butchr.Application;
using Matmaxx.Toolbox;
using Matmaxx.Toolbox.Properties;
using Matmaxx.Butchr.Properties;
using Matmaxx.Butchr.Application.XmpTm;


namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// Form to select and group the images.
  /// </summary>
  public partial class SelectorForm : Form
  {
    #region enum
    /// <summary>
    /// Lists all available application modules
    /// </summary>
    public enum Module
    {
      /// <summary>
      /// Value for initialization.
      /// </summary>
      Init,
      /// <summary>
      /// The module to import brackets after a walk.
      /// </summary>
      Import,
      /// <summary>
      /// The module to keep track of the publishing process for a finished image.
      /// </summary>
      Publish
    }
    #endregion

    #region members

    #region application
    /// <summary>
    /// Instance of the image processor that does all the work. 
    /// </summary>
    ImageManager imageManager;
    /// <summary>
    /// Local ref to the debugtimer.
    /// </summary>
    DebugTimer dt;
    /// <summary>
    /// Counts the async steps of the complete import process.
    /// </summary>
    int PerformImportProcessStepCounter;
    /// <summary>
    /// The total number of thumbnails created during import.
    /// </summary>
    int PerformImportProcessThumbCount;
    /// <summary>
    /// Form for resolving copy conflicts.
    /// </summary>
    ExistingFileStrategyForm existingFileStrategyForm = new ExistingFileStrategyForm();
    /// <summary>
    /// The module that the main GUI is currently running.
    /// </summary>
    Module activeModule = Module.Init;
    #endregion

    #region graphics
    /// <summary>
    /// Font for displayin the group id.
    /// </summary>
    Font groupIdFont;
    /// <summary>
    /// Brush for painting the group id.
    /// </summary>
    SolidBrush groupIdFontBrush;
    /// <summary>
    /// Brush for painting the group id background.
    /// </summary>
    SolidBrush groupIdBackBrush;
    /// <summary>
    /// Pen for the frame around the group id.
    /// </summary>
    Pen groupIdPen;
    /// <summary>
    /// Pen for painting the selection frame.
    /// </summary>
    Pen selectedPen;
    /// <summary>
    /// Pen for painting the non selection frame.
    /// </summary>
    Pen unselectedPen;
    /// <summary>
    /// Font for painting the 'R' in the raw marker.
    /// </summary>
    Font rawFont;
    /// <summary>
    /// Brush for painting the 'R' in the raw marker.
    /// </summary>
    SolidBrush rawFontBrush;
    /// <summary>
    /// Brush for painting the background of the raw marker.
    /// </summary>
    SolidBrush rawBackBrush;
    /// <summary>
    /// Pen for the frame around the raw marker.
    /// </summary>
    Pen rawPen;
    #endregion

    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="SelectorForm"/> class.
    /// </summary>
    public SelectorForm()
    {
      //designer stuff
      InitializeComponent();
      
      //init the logging feature
      InitializeLogging();
      //initialize the image manager
      InitializeImageManager();
      //initialize the graphics objects
      InitializeGraphics();
      //initialize the stopwatch
      InitializeStopWatch();
      //initialize the raw combo
      InitializeRawCombo();
      //initialize the exif table
      InitializeExifTable();
      //always start in the import module
      //TODO always start in last module
      SwitchModule(Module.Init);
      //do some initial output
      Butchr.Log.Output(string.Format("Starting {0} {1}",Properties.Resources.ApplicationName,Butchr.Version));
    }
    private void InitializeRawCombo()
    {
      //remember the selected index 
      int selectedIndex = 0;
      //loop all items from the raw dictionary
      foreach (ImageManager.RawFormat format in imageManager.RawExtensions.Keys)
      {
        //skip the 'none' format
        if(format.Equals(ImageManager.RawFormat.None)) continue;
        //add it to the main menu
        int index = tscbRawFormats.Items.Add((object)imageManager.RawExtensions[format]);
        //check if this is the 'last raw format'
        if(imageManager.RawExtensions[format].Trim().Equals(Settings.Default.LastRawFormat.Trim()))
        {
          //update the selected menu item
          selectedIndex = index;
        }
      }
      //select the 'last raw format'
      tscbRawFormats.SelectedIndex = selectedIndex;
    }
    /// <summary>
    /// Initializes the logging feature.
    /// </summary>
    private void InitializeLogging()
    {
      //clear all
      tblLog.TableModel.Rows.Clear();
      tblLog.ColumnModel.Columns.Clear();
      //add the columns
      tblLog.ColumnModel.Columns.Add(new XPTable.Models.TextColumn(Properties.Resources.LogColTimestamp,200));
      tblLog.ColumnModel.Columns.Add(new XPTable.Models.TextColumn(Properties.Resources.LogColContent,tblLog.Width-230));
      //and adjust their widths
      AdjustLogColumnWidths();
      //set the fonts
      tblLog.HeaderFont = new System.Drawing.Font("Verdana",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
      tblLog.Font = new System.Drawing.Font("Verdana",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
      //activate tooltips
      tblLog.EnableToolTips = true;
      //register for log manager events
      Butchr.Log.OnNewLogAvailable += new Matmaxx.Toolbox.OnLogEventOccured(Log_OnNewLogAvailable);
    }
    /// <summary>
    /// Initializes the ImageManager.
    /// </summary>
    private void InitializeImageManager()
    {
      //create the form for resolving copy conflicts
      existingFileStrategyForm = new ExistingFileStrategyForm();
      existingFileStrategyForm.Tag = this;
      //create the instance
      imageManager = new ImageManager(this,existingFileStrategyForm);
    }
    /// <summary>
    /// Initializes the graphics objects.
    /// </summary>
    private void InitializeGraphics()
    {
      //brush for painting the group id
      groupIdFontBrush = new SolidBrush(Color.Black);
      //brush for painting the group id background
      groupIdBackBrush = new SolidBrush(Color.Yellow);
      //font for painting the group id
      groupIdFont = new Font("Verdana",10);
      //pen for the frame of the group id
      groupIdPen = new Pen(groupIdFontBrush);

      //pen for painting the selection frame
      selectedPen = new Pen(Color.LightGreen,2.0f);
      //pen for painting the non selection frame
      unselectedPen = new Pen(Color.LightGray);

      //font for the raw marker
      rawFont = new Font("Verdana",12,FontStyle.Bold);
      //brush for the raw marker's 'R'
      rawFontBrush = new SolidBrush(Color.Black);
      //brush for the raw marker's background
      rawBackBrush = new SolidBrush(Color.Red);
      rawPen = new Pen(rawFontBrush);
    }
    /// <summary>
    /// Initializes the stopwatch.
    /// </summary>
    private void InitializeStopWatch()
    {
      //init the stopwatch (log to string)
      dt = new DebugTimer();
      dt.Reset();
    }
    /// <summary>
    /// Initializes the exif table.
    /// </summary>
    private void InitializeExifTable()
    {
      //clear all
      tblExif.TableModel.Rows.Clear();
      tblExif.ColumnModel.Columns.Clear();
      //hide the grid
      tblExif.GridLines = XPTable.Models.GridLines.None;
      //add the columns
      tblExif.ColumnModel.Columns.Add(new XPTable.Models.TextColumn(Properties.Resources.LogColExifKey,200));
      tblExif.ColumnModel.Columns.Add(new XPTable.Models.TextColumn(Properties.Resources.LogColExifValue,200));
      //set the fonts
      tblExif.HeaderFont = new System.Drawing.Font("Verdana",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
      tblExif.Font = new System.Drawing.Font("Verdana",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
      //activate tooltips
      tblExif.EnableToolTips = false;
    }
    #endregion

    #region event handler

    #region form
    /// <summary>
    /// Handles the Load event of the SelectorForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void SelectorForm_Load(object sender, EventArgs e)
    {
      //check if the helpscreen shall be displayed
      if(Settings.Default.ShowHelpOpenApplication.Equals(true)) 
      {
        //show the help screen and adjust it's activation flag for the next time
        //TODO activate on next release
        //Settings.Default.ShowHelpOpenApplication = HelpForm.Instance.ShowHelp(this,Resources.ShowHelpOpenApplicationTitle,Resources.HelpContentOpenApplication,false);
        //immediately save the settings
        Settings.Default.Save();
      }
      //load the windowsize
      this.Size = Settings.Default.SelectorFormSize;
    }
    /// <summary>
    /// Handles the FormClosing event of the SelectorForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
    private void SelectorForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Settings.Default.SelectorFormSize = this.Size;
      //save the settings
      //Settings.Default.Save();
    }
    /// <summary>
    /// Handles the ResizeEnd event of the SelectorForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void SelectorForm_ResizeEnd(object sender, EventArgs e)
    {
      //adjust the width of the log columns
      AdjustLogColumnWidths();
    }
    /// <summary>
    /// Handles the Move event of the horizontal splitter.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.SplitterEventArgs"/> instance containing the event data.</param>
    private void splitHorizontal_SplitterMoved(object sender, SplitterEventArgs e)
    {
      //adjust the width of the log columns
      AdjustLogColumnWidths();
    }
    /// <summary>
    /// Handles the Move event of the vertical splitter.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.SplitterEventArgs"/> instance containing the event data.</param>
    private void splitVertical_SplitterMoved(object sender, SplitterEventArgs e)
    {
      //adjust the width of the log columns
      AdjustLogColumnWidths();
    }
    /// <summary>
    /// Handles the KeyDown event of the SelectorForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    private void SelectorForm_KeyDown(object sender, KeyEventArgs e)
    {
      //switch by the received keycode
      if(e.KeyCode.Equals(Settings.Default.KeyGroupSelectedImages))
      {
        //shortcut for grouping selected images
        CreateNewImageGroup();
      }
      if(e.KeyCode.Equals(Settings.Default.KeyUngroupSelectedImages))
      {
        //shortcut for grouping selected images
        UngroupSelectedImages();
      }
      else
      {
        //this shortcut is not handled
      }
    }
    #endregion

    #region listview
    /// <summary>
    /// Draws an item in the owner drawn listview.
    /// </summary>
    /// <param name="sender">The listview.</param>
    /// <param name="e">Eventdata.</param>
    private void list_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
      try
      {
        //backup the tag
        string jpgPath = (string)e.Item.Tag;
        //retrieve the thumbnail image
        Bitmap thumb = imageManager.GetThumbnail(jpgPath,Settings.Default.ThumbboxSizeUsed,Settings.Default.ThumbboxSizeUsed);
        //draw the thumbnail image
        e.Graphics.DrawImage(thumb,e.Bounds.Location);
        //retrieve the groupid
        int groupId = imageManager.GetGroupIdForImage(jpgPath);
        //check if the image is already grouped
        if(0 != groupId)
        {
          //create the rectangle
          Rectangle groupIdRect = new Rectangle(e.Bounds.Location.X,e.Bounds.Location.Y+thumb.Height-20,30,20);
          //mark this with a read square and an 'R' in the lower right corner
          e.Graphics.FillRectangle(groupIdBackBrush,groupIdRect);
          //place the 'R' over it
          e.Graphics.DrawString(groupId.ToString("D3"),groupIdFont,groupIdFontBrush,groupIdRect.X+1,groupIdRect.Y+1);
          //and a frame around
          e.Graphics.DrawRectangle(groupIdPen,groupIdRect.X+1,groupIdRect.Y,groupIdRect.Width-1,groupIdRect.Height-1);
        }
        //check if there exists a raw image for this file
        if(imageManager.IsRawAvailable(jpgPath))
        {
          //create the rectangle
          Rectangle rawRect = new Rectangle(e.Bounds.Location.X+thumb.Width-20,e.Bounds.Location.Y+thumb.Height-20,20,20);
          //mark this with a read square and an 'R' in the lower right corner
          e.Graphics.FillRectangle(rawBackBrush,rawRect);
          //place the 'R' over it
          e.Graphics.DrawString("R",rawFont,rawFontBrush,rawRect.X+1,rawRect.Y);
          //and a frame around
          e.Graphics.DrawRectangle(rawPen,rawRect.X,rawRect.Y,rawRect.Width-1,rawRect.Height-1);
        }
        //check if the item is selected
        if (e.Item.Selected)
        {
          //it is selected, so paint a green border around it
          Rectangle border = new Rectangle(e.Bounds.Location,thumb.Size); 
          e.Graphics.DrawRectangle(selectedPen,border);
        }
        else
        {
          //it is not selected, so paint a black border around it
          Rectangle border = new Rectangle(e.Bounds.Location,thumb.Size); 
          e.Graphics.DrawRectangle(unselectedPen,border);
        }
      }
      catch (Exception ex)
      {
        Butchr.Log.Error(string.Format(Resources.LogExListDrawItem,ex.Message));
      }
    }
    /// <summary>
    /// Handles the MouseUp event of the list control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void list_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        //force a repaint of the list to update the selection markers
        importModule.Refresh();
      }
      //check if exactly one item is selected
      if(importModule.SelectedItems.Count.Equals(1))
      {
        //display the exif data of this item
        DisplayExifInTable((string)importModule.SelectedItems[0].Tag);
      }
      else
      {
        ClearExifTable();
      }
    }
    #endregion

    #region context menu
    /// <summary>
    /// Handles the Click event of the groupSelectedImagesToolStripMenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void groupSelectedImagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CreateNewImageGroup();
    }
    private void ungroupSelectedImagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UngroupSelectedImages();
    }
    #endregion

    #region main menu

    #region modules
    /// <summary>
    /// Handles the Click event of the tsbImportModule control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsbImportModule_Click(object sender, EventArgs e)
    {
      //switch the GUI to the import module
      SwitchModule(Module.Import);
    }
    /// <summary>
    /// Handles the Click event of the tsbPublishModule control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsbPublishModule_Click(object sender, EventArgs e)
    {
      //switch the GUI to the publish module
      SwitchModule(Module.Publish);
    }
    #endregion

    #region file
    /// <summary>
    /// Handles the Click event of the tsiImport controls.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiImport_Click(object sender, EventArgs e)
    {
      //create the import form
      ImportOptionsForm importForm = new ImportOptionsForm();
      //show the log window
      splitHorizontal.Panel2Collapsed = false;
      //perform the import
      PerformImportProcess(importForm);
    }
    /// <summary>
    /// Handles the Click event of the tsbAutogroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsbAutogroup_Click(object sender, EventArgs e)
    {
      //show the log window
      splitHorizontal.Panel2Collapsed = false;
      //perform the command
      AutogroupImages();
    }
    /// <summary>
    /// Handles the Click event of the  tsiDistribute controls.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiDistribute_Click(object sender, EventArgs e)
    {
      //show the log window
      splitHorizontal.Panel2Collapsed = false;
      //perform the command
      DistributeImageGroups(Settings.Default.LastTargetFolder);
    }
    /// <summary>
    /// Handles the Click event of the tsiScratchbatch controls.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiScratchbatch_Click(object sender, EventArgs e)
    {
      //check if the helpscreen shall be displayed
      if(Settings.Default.ShowHelpScratchBatch.Equals(true)) 
      {
        //show the help screen and adjust it's activation flag for the next time
        Settings.Default.ShowHelpScratchBatch = HelpForm.Instance.ShowHelp(this,Resources.ShowHelpScratchBatchTitle,Resources.HelpContentScratchBatch,true);
        //immediately save the settings
        Settings.Default.Save();
      }
      PerformScratchBatchProcess();
    }
    /// <summary>
    /// Handles the Click event of the tsiExit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    #endregion
    
    #region edit
    /// <summary>
    /// Handles the Click event of the tsiGroupSelected control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiGroupSelected_Click(object sender, EventArgs e)
    {
      CreateNewImageGroup();
    }
    /// <summary>
    /// Handles the Click event of the tsiRemoveAllGroups controls.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiRemoveAllGroups_Click(object sender, EventArgs e)
    {
      RemoveAllGroups();
    }
    /// <summary>
    /// Handles the Click event of the tsiUngroupSelected control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiUngroupSelected_Click(object sender, EventArgs e)
    {
      UngroupSelectedImages();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the tscbRawFormats control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tscbRawFormats_SelectedIndexChanged(object sender, EventArgs e)
    {
      //update the settings
      Settings.Default.LastRawFormat = tscbRawFormats.Items[tscbRawFormats.SelectedIndex].ToString();
      //save the settings
      //Settings.Default.Save();
    }
    #endregion

    #region view
    /// <summary>
    /// Handles the Click event of the tsiRefresh controls.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiRefresh_Click(object sender, EventArgs e)
    {
      importModule.Refresh();
    }
    /// <summary>
    /// Handles the Click event of the tsiIncThumbSize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiIncThumbSize_Click(object sender, EventArgs e)
    {
      //update the size of the thumbnails
      if(Settings.Default.ThumbboxSizeUsed <= Settings.Default.ThumbboxSizeMax)
      {
        Settings.Default.ThumbboxSizeUsed += Settings.Default.ThumbsizeInterval;
      }
      importModule.Items.Clear();
      FillListView();
    }
    /// <summary>
    /// Handles the Click event of the tsiDecThumbSize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiDecThumbSize_Click(object sender, EventArgs e)
    {
      //update the size of the thumbnails
      if(Settings.Default.ThumbboxSizeUsed >= Settings.Default.ThumbboxSizeMin)
      {
        Settings.Default.ThumbboxSizeUsed -= Settings.Default.ThumbsizeInterval;
      }
      importModule.Items.Clear();
      FillListView();
    }
    /// <summary>
    /// Handles the Click event of the tsiToggleLogVisibility control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiToggleLogVisibility_Click(object sender, EventArgs e)
    {
      //check if the table is visible
      if(splitHorizontal.Panel2Collapsed.Equals(true))
      {
        //it is not, so make it visible
        splitHorizontal.Panel2Collapsed = false;
        //and change the text on the button
        tsbToggleLogVisibility.ToolTipText = Resources.tsbToggleLogVisibilityShow;
      }
      else
      {
        //it is, so collapse the panel
        splitHorizontal.Panel2Collapsed = true;
        //and change the text on the button
        tsbToggleLogVisibility.ToolTipText = Resources.tsbToggleLogVisibilityHide;
      }
    }
    #endregion

    #region help
    /// <summary>
    /// Handles the Click event of the tsiHelpContents control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiHelpContents_Click(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the Click event of the tsiPhotomatixCommandline control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiPhotomatixCommandline_Click(object sender, EventArgs e)
    {
      string helpURL = Path.Combine(System.Windows.Forms.Application.StartupPath,Settings.Default.PhotomatixCommandlineOptionsURL);
      //launch the online help document from hdr soft
      System.Diagnostics.Process.Start(helpURL);
    }
    /// <summary>
    /// Handles the Click event of the tsiHelpAbout control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void tsiHelpAbout_Click(object sender, EventArgs e)
    {
      //create a new about form
      AboutForm aboutForm = new AboutForm();
      //and show it
      aboutForm.ShowDialog();
    }
    /// <summary>
    /// Handles the Click event of the miHelpResetContextActivations control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void miHelpResetContextActivations_Click(object sender, EventArgs e)
    {
      //reset all help activation flags
      Settings.Default.ShowHelpImport           = true;
      Settings.Default.ShowHelpDistribute       = true;
      Settings.Default.ShowHelpGroupFiles       = true;
      Settings.Default.ShowHelpAutoGroup        = true;
      Settings.Default.ShowHelpOpenApplication  = true;
      Settings.Default.ShowHelpScratchBatch     = true;
    }
    #endregion

    #endregion
    
    #region LogManager
    /// <summary>
    /// Handles logging events
    /// </summary>
    /// <param name="sender">The LogManager.</param>
    /// <param name="e">The LogItem.</param>
    void Log_OnNewLogAvailable(object sender, Matmaxx.Toolbox.LogItem e)
    {
      //avoid cross thread calls to GUI elements
      if (this.InvokeRequired)
      {
        //we are in another thread, so invoke the GUI
        OnLogEventOccured handler = new OnLogEventOccured(Log_OnNewLogAvailable);
        this.Invoke(handler, new object[] { sender, e });
      }
      else
      {
        //use the correct color
        Color logcolor;
        //switch by the kind of log
        switch (e.LogType)
        {
          case LogManager.LogEventType.Debug:
              //default to black
              logcolor = Color.DarkGreen;
            break;
          case LogManager.LogEventType.Error:
              //default to black
              logcolor = Color.Red;
            break;
          case LogManager.LogEventType.Output:
          case LogManager.LogEventType.Init:
          default:
              //default to black
              logcolor = Color.Black;
            break;
        }
        //avoid screen updates while changing the table
        tblLog.BeginUpdate();
        //add a new row to the log
        int row = tblLog.TableModel.Rows.Add(new XPTable.Models.Row());
        tblLog.TableModel.Rows[tblLog.RowCount - 1].Tag = (object)e;
        string timestamp = string.Format("[{0:00}:{1:00}:{2:00}.{3:000}]",e.Timestamp.Hour,e.Timestamp.Minute,e.Timestamp.Second,e.Timestamp.Millisecond);
        int timestampCell = tblLog.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(timestamp));
        tblLog.TableModel.Rows[row].Cells[timestampCell].ForeColor = logcolor;
        int contentCell = tblLog.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(e.Content));
        tblLog.TableModel.Rows[row].Cells[contentCell].ToolTipText = e.Content;
        tblLog.TableModel.Rows[row].Cells[contentCell].ForeColor = logcolor;
        tblLog.EnsureVisible(tblLog.RowCount - 1,0);
        //enable screen updates again
        tblLog.EndUpdate();
      }
    }
    #endregion

    #endregion

    #region helper functions
    
    #region copy operation
    /// <summary>
    /// Selects the source folder.
    /// </summary>
    /// <returns><c>true</c> if the selection was successful,<c>false</c> otherwise.</returns>
    private bool SelectScratchBatchFolder()
    {
      //local result
      bool retval = false;
      //check if a folder was already selected in a previous session
      if (
          (String.Empty != Settings.Default.LastTargetFolder) &&
          (Directory.Exists(Settings.Default.LastTargetFolder))
        )
      {
        //start in the last used folder
        fbdScratch.SelectedPath = Settings.Default.LastTargetFolder;
      }
      else
      {
        //start at the rootfolder
        fbdScratch.SelectedPath = fbdScratch.RootFolder.ToString();
      }
      //show the dialog
      DialogResult result = fbdScratch.ShowDialog();
      //check if the user pressed ok
      if (result == DialogResult.OK)
      {
        //backup the new path
        Settings.Default.LastTargetFolder = fbdScratch.SelectedPath;
        //finally return the success
        retval = true;
      }
      //finally return the result
      return retval;
    }
    /// <summary>
    /// Distributes the image groups to the final directory structure.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    private void DistributeImageGroups(string basePath)
    {
      //check if the helpscreen shall be displayed
      if(Settings.Default.ShowHelpDistribute.Equals(true)) 
      {
        //show the help screen and adjust it's activation flag for the next time
        Settings.Default.ShowHelpDistribute = HelpForm.Instance.ShowHelp(this,Resources.ShowHelpDistributeTitle,Resources.HelpContentDistribute,true);
        //immediately save the settings
        Settings.Default.Save();
      }
      //route the request to the image manager
      imageManager.DistributeImageGroups(basePath);
      //finally clear the list
      importModule.Items.Clear();
      //and reset the imagemanager
      imageManager.Reset();
    }
    /// <summary>
    /// Performs the import process.
    /// </summary>
    /// <param name="importForm">The import form.</param>
    private void PerformImportProcess(ImportOptionsForm importForm)
    {
      //check if the helpscreen shall be displayed
      if(Settings.Default.ShowHelpImport.Equals(true)) 
      {
        //show the help screen and adjust it's activation flag for the next time
        Settings.Default.ShowHelpImport = HelpForm.Instance.ShowHelp(this,Resources.ShowHelpImportTitle,Resources.HelpContentImport,true);
        //immediately save the settings
        Settings.Default.Save();
      }
      //clear the listview
      if(importModule.Items != null) importModule.Items.Clear();
      //reset and clear everything from former imports
      imageManager.Reset();
      //clear the exif table
      ClearExifTable();
      //start the new import
      try
      {
        //set the import options
        if (importForm.ProcessImportDialog(this))
        {
          //scan the source folder for RAW images
          ScanSourceFolderForRawFormat(Settings.Default.LastSourceFolder);
          //register a special handler for copy progress
          imageManager.CopyStateChanged += new OnCopyStateChanged(PerformImportProcess_CopyStateChanged);
          //register for thumbnail finished events
          imageManager.ThumbnailCreated += new OnThumbnailCreationFinished(PerformImportProcess_ThumbnailCreated);
          //reset the counters
          PerformImportProcessStepCounter = 0;
          PerformImportProcessThumbCount = 0;
          //do some output
          Butchr.Log.Output("Start copy operation");
          //starts the copy operation
          imageManager.BeginCopyOperation(Settings.Default.LastSourceFolder, Settings.Default.LastTargetFolder);
        }
        else
        {
          Butchr.Log.Error("Invalid or no source folder.");
        }
      }
      catch (Exception ex)
      {
        //notify the user about the failure
        Butchr.Log.Error(string.Format("Import failed: {0}",ex.Message));
      }
    }
    /// <summary>
    /// Handles the CopyStateChanged event of the PerformImportProcess.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Matmaxx.Butchr.Application.CopyEventArgs"/> instance containing the event data.</param>
    private void PerformImportProcess_CopyStateChanged(object sender, CopyEventArgs e)
    {
      //avoid cross thread calls to GUI elements
      if (this.InvokeRequired)
      {
        //we are in another thread, so invoke the GUI
        OnCopyStateChanged handler = new OnCopyStateChanged(PerformImportProcess_CopyStateChanged);
        this.Invoke(handler, new object[] { sender, e });
      }
      else
      {
        if ((e.CopyEvent.Equals(CopyEventArgs.CopyEventType.JpgStep)) || (e.CopyEvent.Equals(CopyEventArgs.CopyEventType.RawStep)))
        {
          //output the message of this event
          Butchr.Log.Output(e.Message);
        }
        //check if the jpg copy has finished
        if (e.CopyEvent == CopyEventArgs.CopyEventType.JpgFinished)
        {
          //do some output
          Butchr.Log.Output(Resources.LogStepStartThumbnailCreation);
          //start the thumbnail creation
          imageManager.BeginCreateThumbnails(Path.Combine(Settings.Default.LastTargetFolder, Properties.Resources.FolderJpgInitial), 
                                             Settings.Default.ThumbboxSizeMax, 
                                             Settings.Default.ThumbboxSizeMax);
        }
        //check if the jpg copy has finished
        else if (e.CopyEvent == CopyEventArgs.CopyEventType.RawFinished)
        {
          //check if thumbnail creation already finished
          if (0 < PerformImportProcessStepCounter)
          {
            //do some output
            Butchr.Log.Output(Resources.LogStepCopyFinishedLast);
            //unregister all handlers
            imageManager.CopyStateChanged -= PerformImportProcess_CopyStateChanged;
            imageManager.ThumbnailCreated -= PerformImportProcess_ThumbnailCreated;
            //fill the listview
            FillListView();
            //check if the helpscreen shall be displayed
            if(Settings.Default.ShowHelpGroupFiles.Equals(true)) 
            {
              //show the help screen and adjust it's activation flag for the next time
              Settings.Default.ShowHelpGroupFiles = HelpForm.Instance.ShowHelp(this,Resources.ShowHelpGroupFiles,Resources.HelpContentGroupFiles,true);
              //immediately save the settings
              Settings.Default.Save();
            }
          }
          else
          {
            //do some output
            Butchr.Log.Output(Resources.LogStepCopyFinishedFirst);
            //and increment the counter
            PerformImportProcessStepCounter++;
          }
        }
      }
    }
    /// <summary>
    /// Handles the ThumbnailCreated event of the PerformImportProcess.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Matmaxx.Butchr.Application.ThumbnailWorkerEventArgs"/> instance containing the event data.</param>
    void PerformImportProcess_ThumbnailCreated(object sender, ThumbnailWorkerEventArgs e)
    {
      //avoid cross thread calls to GUI elements
      if (this.InvokeRequired)
      {
        //we are in another thread, so invoke the GUI
        OnThumbnailCreationFinished handler = new OnThumbnailCreationFinished(PerformImportProcess_ThumbnailCreated);
        this.Invoke(handler, new object[] { sender, e });
      }
      else
      {
        //do some output
        Butchr.Log.Output(string.Format(Resources.LogStepThumbnailCreated,PerformImportProcessThumbCount,e.expectedAmount,Path.GetFileName(e.Path)));
        //update the counter
        PerformImportProcessThumbCount++;
        //check if this is the last image
        if (PerformImportProcessThumbCount >= e.expectedAmount)
        {
          //check if thumbnail creation already finished
          if (0 < PerformImportProcessStepCounter)
          {
            //do some output
            Butchr.Log.Output(Resources.LogStepThumbnailingFinishedLast);
            //unregister all handlers
            imageManager.CopyStateChanged -= PerformImportProcess_CopyStateChanged;
            imageManager.ThumbnailCreated -= PerformImportProcess_ThumbnailCreated;
            //fill the listview
            FillListView();
            //check if the helpscreen shall be displayed
            if(Settings.Default.ShowHelpGroupFiles.Equals(true)) 
            {
              //show the help screen and adjust it's activation flag for the next time
              Settings.Default.ShowHelpGroupFiles = HelpForm.Instance.ShowHelp(this,Resources.ShowHelpGroupFiles,Resources.HelpContentGroupFiles,true);
              //immediately save the settings
              Settings.Default.Save();
            }
          }
          else
          {
            //do some output
            Butchr.Log.Output(Resources.LogStepThumbnailingFinishedFirst);
            //and increment the counter
            PerformImportProcessStepCounter++;
          }
        }
      }
    }
    /// <summary>
    /// Scans the source folder for raw format.
    /// </summary>
    /// <param name="path">The path.</param>
    private void ScanSourceFolderForRawFormat(string path)
    {
      //do the search
      ImageManager.RawFormat rawFormat = imageManager.ScanFolderForRawFormat(path);
      //leave here if nothing was found
      if(rawFormat.Equals(ImageManager.RawFormat.None)) return;
      //check if the found format matches the 'last raw format from the settings
      if(imageManager.RawExtensions[rawFormat].Equals(Settings.Default.LastRawFormat))
      {
        //everything ok in this case
      }
      else
      {
        //there is a mismatch and the current setting will not copy the raw files in the source folder
        //so ask the user again
        string message = string.Format(Resources.StringMboxRawFormatMismatchText,imageManager.RawExtensions[rawFormat],Settings.Default.LastRawFormat,Environment.NewLine);
        DialogResult result = MessageBox.Show(message,
                                              Resources.StringMboxRawFormatMismatchTitle,
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
        //check if the user wants to update
        if(result.Equals(DialogResult.Yes))
        {
          //update the settings
          Settings.Default.LastRawFormat = imageManager.RawExtensions[rawFormat];
          //save the settings
          //Settings.Default.Save();
        }
      }
    }
    #endregion

    #region thumbnailing
    /// <summary>
    /// Fills the listview with the loaded images
    /// </summary>
    private void FillListView()
    {
      //show wait cursor
      this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
      //set the tilesize of the Listview according to the size of the thumbs
      importModule.TileSize = new Size(Settings.Default.ThumbboxSizeUsed+Settings.Default.ThumbboxMargin,
                               Settings.Default.ThumbboxSizeUsed+Settings.Default.ThumbboxMargin);
      //read all files in the directory
      List<string> files = GetDisplayableImages(Path.Combine(Settings.Default.LastTargetFolder,Properties.Resources.FolderJpgInitial));
      //loop throught all files
      foreach (string file in files)
      {
        //create a listview item for the image
        ListViewItem item = new ListViewItem(Path.GetFileName(file));
        //add the complete path as tag
        item.Tag = (object)file;
        //and add the item to the listview
        importModule.Items.Add(item);
      }
      //reset the cursor
      this.Cursor = System.Windows.Forms.Cursors.Default;
    }
    /// <summary>
    /// Returns a list of displayable paths.
    /// </summary>
    /// <param name="path">The path to be searched.</param>
    /// <returns>A list of paths that shall be displayed.</returns>
    private List<string> GetDisplayableImages(string path)
    {
      //read all files in the directory
      string[] files = Directory.GetFiles(path);
      //return list
      List<string> images = new List<string>();
      //loop throught all files
      foreach (string file in files)
      {
        //check for jpgs before attempting to create a thumbnail
        if (imageManager.IsDisplayableExtension(file))
        {
          //add it to the result list
          images.Add(file);
        }
      }
      //return the list
      return images;
    }
    /// <summary>
    /// Creates a new image group.
    /// </summary>
    private void CreateNewImageGroup()
    {
      //check if there are files selected
      if (importModule.SelectedItems.Count > 1)
      {
        //create a list of paths
        List<string> paths = new List<string>();
        //loop all selected items
        foreach (ListViewItem item in importModule.SelectedItems)
        {
          paths.Add((string)item.Tag);
        }
        //create the new group
        imageManager.CreateImageGroup(paths);
        //and repaint the selected items
        RepaintSelectedItems();
      }
      else
      {
        //a group needs at least 2 items, do not react here
      }
    }
    /// <summary>
    /// Repaints all selected items in the listview.
    /// </summary>
    private void RepaintSelectedItems()
    {
      //loop all selected items
      foreach (ListViewItem item in importModule.SelectedItems)
      {
        importModule.RedrawItems(item.Index,item.Index,true);
      }
    }
    /// <summary>
    /// Removes all groups.
    /// </summary>
    private void RemoveAllGroups()
    {
      //kill all groups
      imageManager.RemoveAllImageGroups();
      //refresh the listview
      importModule.Refresh();
    }
    /// <summary>
    /// Ungroups the selected images.
    /// </summary>
    private void UngroupSelectedImages()
    {
      //check if there is at least one file selected
      if (importModule.SelectedItems.Count > 0)
      {
        //create a list of paths
        List<string> paths = new List<string>();
        //loop all selected items
        foreach (ListViewItem item in importModule.SelectedItems)
        {
          paths.Add((string)item.Tag);
        }
        //Ungroup these images
        imageManager.UngroupImages(paths);
        //and repaint the selected items
        RepaintSelectedItems();
      }
      else
      {
        //a group needs at least 2 items, do not react here
      }
    }
    #endregion

    #region scratchbatch
    /// <summary>
    /// Performs the scratch batch process.
    /// </summary>
    private void PerformScratchBatchProcess()
    {
      //create the form
      ScratchOptionsForm s = new ScratchOptionsForm();
      //check if currently a folder is loaded
      if((false == Directory.Exists(Settings.Default.LastTargetFolder)) ||
         (imageManager.AreNoImagesLoaded))
      {
        //try to set a new target folder, but return if canceled
        if (false == SelectScratchBatchFolder()) return;
      }
      //show the scratch-batch generator form
      s.PerformScratchBatchGeneration(Settings.Default.LastTargetFolder, imageManager);
    }   
    #endregion

    #region autogrouping
    /// <summary>
    /// Autogroups the images by their timestamp and exposure times.
    /// </summary>
    private void AutogroupImages()
    {
      //local list of paths
      List<string> paths = new List<string>();
      //local instance of the settings dialog
      AutoGroupSettingsForm form = new AutoGroupSettingsForm();
      //check if the helpscreen shall be displayed
      if(Settings.Default.ShowHelpAutoGroup.Equals(true)) 
      {
        //show the help screen and adjust it's activation flag for the next time
        Settings.Default.ShowHelpAutoGroup = HelpForm.Instance.ShowHelp(this,Resources.ShowHelpAutoGroupTitle,Resources.HelpContentAutoGroup,true);
        //immediately save the settings
        Settings.Default.Save();
      }
      //display the settings dialog
      if(form.AutoGroupSettingsDialog(this).Equals(true))
      {
        try
        {
          //check if any files are loaded at all
          if(imageManager.AreImagesLoaded)
          {
            //read all files in the directory
            List<string> files = GetDisplayableImages(Path.Combine(Settings.Default.LastTargetFolder,Properties.Resources.FolderJpgInitial));

            //loop through all files
            for (int index = 0; index < files.Count-1; index++)
			      {
              //check if the current and the next image have a timestamp
              if((null != imageManager.exifCache[files[index]].OriginalTimestamp) &&
                 (null != imageManager.exifCache[files[index+1]].OriginalTimestamp))
              {
                //get the timestamp of the currently indexed images
                DateTime timestamp_early = (DateTime)imageManager.exifCache[files[index]].OriginalTimestamp;
                //get the timestamp of the next indexed images
                DateTime timestamp_late = (DateTime)imageManager.exifCache[files[index+1]].OriginalTimestamp;
                //now check if the interval between these timestamps is small enough
                TimeSpan intervalReal = timestamp_late.Subtract(timestamp_early);
                TimeSpan intervalMin = new TimeSpan(0,0,Settings.Default.AutogroupMinimumInterval);
                //A negative integer: This instance is shorter than value. 
                //Zero: This instance is equal to value. 
                //A positive integer: This instance is longer than value. 
                //check if the minimum interval was reached
                if(intervalReal.CompareTo(intervalMin) >= 0)
                {
                  //intervalReal is longer than intervalMin, so this must be a new bracket
                  //add the current image to the current group
                  paths.Add(files[index]);
                  //create a group of the current images
                  imageManager.CreateImageGroup(paths);
                  //reset the pathlist
                  paths.Clear();
                }
                else
                {
                  //intervalReal is shorter than intervalMin, so this must be a the same bracket as before
                  paths.Add(files[index]);
                }
              }
			      }
            //finally add the last group
            //add the last image to the current group
            paths.Add(files[files.Count-1]);
            //create a group of the current images
            imageManager.CreateImageGroup(paths);
            //finally refresh the list again
            importModule.Refresh();
          }
          else
          {
            //do some output
            Butchr.Log.Output(Resources.LogPleaseLoadImages);
          }
        }
        catch (Exception ex)
        {
          //do some error output
          Butchr.Log.Error(string.Format(Resources.LogExAutogroupFailed,ex.Message));
        }
      }
      else
      {
        //the user chose to cancel the action
      }
    }
    #endregion

    #region form
    /// <summary>
    /// Switches the user interface to a different module.
    /// </summary>
    /// <param name="module">The module.</param>
    private void SwitchModule(Module module)
    {
      //check if the new module differs from the current one
      if((module != activeModule)||(Module.Init == module))
      {
        //cleanup the running module
        switch (activeModule)
        {
          #region import
          case Module.Import:
            //dock the imagelist 
            importModule.Dock = DockStyle.None;
            //make it visible
            importModule.Visible = false;
            //clear it
            importModule.Items.Clear();
            //and reset the imagemanager
            imageManager.Reset();
            break;
          #endregion

          #region publish
          case Module.Init:
          case Module.Publish:
            //dock the publishcontrol
            publishModule.Dock = DockStyle.None;
            //make it visible
            publishModule.Visible = false;
            //clear it
            publishModule.Reset();
            break;
          #endregion

          #region error handling
          default:
            //invalid state, notify in the logwindow
            Butchr.Log.Error(string.Format("Trying to deactivate an invalid module: {0}", module.ToString()));
            break;
          #endregion
        }
        //activate the new module
        switch (module)
        {
          #region import
          case Module.Init:
          case Module.Import:
            //dock the imagelist 
            importModule.Dock = DockStyle.Fill;
            //make it visible
            importModule.Visible = true;
            //clear it
            importModule.Items.Clear();
            //and reset the imagemanager
            imageManager.Reset();
            break;
        	#endregion

        	#region publish
          case Module.Publish:
            //dock the publishcontrol
            publishModule.Dock = DockStyle.Fill;
            //make it visible
            publishModule.Visible = true;
            //clear it
            publishModule.Reset();
            break;
          #endregion
          
          #region error handling
          default:
            //invalid state, notify in the logwindow
            Butchr.Log.Error(string.Format("Trying to activate an invalid module: {0}",module.ToString()));
            break;
          #endregion
        }
        //finally backup the new state
        activeModule = module;
      }
    }
    /// <summary>
    /// Adjusts the column widths of the XpTable.
    /// </summary>
    public void AdjustLogColumnWidths()
    {
      //constant width for the timestamp
      tblLog.ColumnModel.Columns[0].Width = (int)100;
      //check if the table shows the vertical scrollbar (more rows than displayable)
      //TODO check how this works on xptable 1.2.1
      //if ((tblLog.VisibleRowCount <= tblLog.RowCount) && (0 < tblLog.VisibleRowCount))
      if (true)
      {
        //vertical scrollbar is visible 
        //remaining width for the logs is the splitter width 
        //minus the width of the timestamp column minus the width of the scrollbar
        tblLog.ColumnModel.Columns[1].Width = (int)splitHorizontal.Width - tblLog.ColumnModel.Columns[0].Width - splitHorizontal.Margin.Horizontal - 20;
      }
      else
      {
        //vertical scrollbar is not visible
        //remaining width for the logs is the splitter width 
        //minus the width of the timestamp column
        tblLog.ColumnModel.Columns[1].Width = (int)splitHorizontal.Width - tblLog.ColumnModel.Columns[0].Width - splitHorizontal.Margin.Horizontal;
      }
    }
    /// <summary>
    /// Displays the exif data of the given file in the exif table.
    /// </summary>
    /// <param name="path">The path.</param>
    private void DisplayExifInTable(string path)
    {
      //get the exifdata for this image
      Dictionary<string,string> dictionary = imageManager.exifCache[path].ToDictionary();
      //show the grid
      tblExif.GridLines = XPTable.Models.GridLines.Both;
      //remove all old stuff
      tblExif.TableModel.Rows.Clear();
      //avoid screen updates while changing the table
      tblExif.BeginUpdate();
      //loop all keys of the dictionary
      foreach (string key in dictionary.Keys)
      {
        //add a new row to the log
        int row = tblExif.TableModel.Rows.Add(new XPTable.Models.Row());
        //add the cell for the key
        int cellkey = tblExif.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(key));
        //add the cell for the value
        int cellvalue = tblExif.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(dictionary[key]));
      }
      //enable screen updates again
      tblExif.EndUpdate();
    }
    /// <summary>
    /// Clears the exif table.
    /// </summary>
    private void ClearExifTable()
    {
      //clear the table
      tblExif.TableModel.Rows.Clear();
      //hide the grid
      tblExif.GridLines = XPTable.Models.GridLines.None;
    }
    #endregion

    #endregion

    #region debug functions
    /// <summary>
    /// Group selected images in a new group.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void button2_Click(object sender, EventArgs e)
    {
      CreateNewImageGroup();
    }
    /// <summary>
    /// Forces a repaint of the listview.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void button3_Click(object sender, EventArgs e)
    {
      //refresh the listview
      importModule.Refresh();
    }
    /// <summary>
    /// Removes all image groups
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void button4_Click(object sender, EventArgs e)
    {
      RemoveAllGroups();
    }
    private void button6_Click(object sender, EventArgs e)
    {
      PerformScratchBatchProcess();
    }
    #endregion
  }
}



