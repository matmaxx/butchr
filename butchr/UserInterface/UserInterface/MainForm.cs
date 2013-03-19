using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Globalization;

namespace Matmaxx.Butcher.UserInterface
{
  /// <summary>
  /// Main user interface for the butcher application.
  /// </summary>
  public partial class MainForm : Form
  {
    #region const
    /// <summary>
    /// Imageindex of a removable disk.
    /// </summary>
    const int Removable = 2;
    /// <summary>
    /// Imageindex of a local disk.
    /// </summary>
    const int LocalDisk = 3;
    /// <summary>
    /// Imageindex of a network drive.
    /// </summary>
    const int Network = 4;
    /// <summary>
    /// Imageindex of a CD drive.
    /// </summary>
    const int CD = 5;
    #endregion

    #region members
    /// <summary>
    /// Dictionary of thumbnail images
    /// </summary>
    Dictionary<string,Image> thumbnails;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the butcher main form user interface.
    /// </summary>
    public MainForm()
    {
      //designer stuff
      InitializeComponent();
      //fill the treeview (and init the ListView)
      PopulateDriveList();
      //initialize the thumbnails
      thumbnails = new Dictionary<string,Image>();
    }
    /// <summary>
    /// Initializes the dynamic properties of the listview.
    /// </summary>
    protected void InitListView()
    {
      //init ListView control
      list.Clear();
		  //set to display details
      list.View = View.Tile;
      //create column header for ListView
      list.Columns.Add(Properties.Resources.StringColName,      150,  System.Windows.Forms.HorizontalAlignment.Left);
      list.Columns.Add(Properties.Resources.StringColSize,      75,   System.Windows.Forms.HorizontalAlignment.Right);
      list.Columns.Add(Properties.Resources.StringColCreated,   140,  System.Windows.Forms.HorizontalAlignment.Left);
      list.Columns.Add(Properties.Resources.StringColModified,  140,  System.Windows.Forms.HorizontalAlignment.Left);
    }
    #endregion

    #region file system explorer
    /// <summary>
    /// Fills the treeview with the initial list of drives
    /// </summary>
    private void PopulateDriveList()
    {
      //the wroking node
      TreeNode nodeTreeNode;
      //the image indices
      int imageIndex = 0;
      int selectIndex = 0;
      //activate wait state
      this.Cursor = Cursors.WaitCursor;
      //clear TreeView
      tree.Nodes.Clear();
      //create a new rootnode
      nodeTreeNode = new TreeNode(Properties.Resources.StringTreeRootnode, 0, 0);
      //add it to the tree
      tree.Nodes.Add(nodeTreeNode);
      //set node collection
      TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;
      //Get Drive list
      ManagementObjectCollection queryCollection = GetDrives();
      //loop all drives
      foreach (ManagementObject mo in queryCollection)
      {
        //switch by the drive type
        switch (int.Parse(mo["DriveType"].ToString()))
        {
          case Removable:			//removable drives
            imageIndex = 5;
            selectIndex = 5;
            break;
          case LocalDisk:			//Local drives
            imageIndex = 6;
            selectIndex = 6;
            break;
          case CD:				//CD rom drives
            imageIndex = 7;
            selectIndex = 7;
            break;
          case Network:			//Network drives
            imageIndex = 8;
            selectIndex = 8;
            break;
          default:				//defalut to folder
            imageIndex = 2;
            selectIndex = 3;
            break;
        }
        //create new drive node
        nodeTreeNode = new TreeNode(mo["Name"].ToString() + "\\", imageIndex, selectIndex);
        //add new node
        nodeCollection.Add(nodeTreeNode);
      }
      //init files ListView
      InitListView();
      //and fall back to the default cursor
      this.Cursor = Cursors.Default;
    }
    /// <summary>
    /// Fills the treeview with folders
    /// </summary>
    /// <param name="nodeCurrent">The node where to add the children.</param>
    /// <param name="nodeCurrentCollection">The current node collection.</param>
    protected void PopulateDirectory(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection)
    {
      //local work node
      TreeNode nodeDir;
      //unselected image index
      int imageIndex  = 2;
      //selected image index
      int selectIndex = 3;	  
      //check if it is not the rootnode (drives are handled seperately
      if (nodeCurrent.SelectedImageIndex != 0)
      {
        //populate treeview with folders
        try
        {
          //check path
          if (Directory.Exists(GetFullPath(nodeCurrent.FullPath)) == false)
          {
            MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
          }
          else
          {
            //populate files
            PopulateFiles(nodeCurrent);
            //check for subdirectories
            string[] stringDirectories = Directory.GetDirectories(GetFullPath(nodeCurrent.FullPath));
            string stringFullPath = "";
            string stringPathName = "";
            //loop through all directories
            foreach (string stringDir in stringDirectories)
            {
              //build the path
              stringFullPath = stringDir;
              stringPathName = GetPathName(stringFullPath);
              //create node for directories
              nodeDir = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
              nodeCurrentCollection.Add(nodeDir);
            }
          }
        }
        catch (IOException ex)
        {
          MessageBox.Show(string.Format(Properties.Resources.StringMboxDriveInvalid,ex.Message));
        }
        catch (UnauthorizedAccessException ex)
        {
          MessageBox.Show(string.Format(Properties.Resources.StringMboxDriveAuthFailed,ex.Message));
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format(Properties.Resources.StringMboxUnhandledException,ex.Message));
        }
      }
    }
    /// <summary>
    /// Fills the listview with the current list of files for the selected node
    /// </summary>
    /// <param name="node">The node that is currently selected in the tree.</param>
    protected void PopulateFiles(TreeNode node)
    {
      //Populate listview with files
      string[] data = new string[4];
      //clear list
      InitListView();
      //check for the rootnode
      if (node.SelectedImageIndex != 0)
      {
        //check path
        if (Directory.Exists((string)GetFullPath(node.FullPath)) == false)
        {
          MessageBox.Show("Directory or path " + node.ToString() + " does not exist.");
        }
        else
        {
          try
          {
            //read all files in the directory
            string[] files = Directory.GetFiles(GetFullPath(node.FullPath));
            //loop throught all files
            foreach (string file in files)
            {
              //check for jpegs
              if((Path.GetExtension(file).ToLower() == ".jpg") ||
                 (Path.GetExtension(file).ToLower() == ".jpeg"))
              {
                //Create actual list item
                ListViewItem item = new ListViewItem(Path.GetFileName(file));
                //add the full path as tag
                item.Tag = (object)file;
                //and add it to the listview
                list.Items.Add(item);
              }
            }
          }
          catch (IOException ex)
          {
            MessageBox.Show(string.Format(Properties.Resources.StringMboxDriveInvalid,ex.Message));
          }
          catch (UnauthorizedAccessException ex)
          {
            MessageBox.Show(string.Format(Properties.Resources.StringMboxDriveAuthFailed,ex.Message));
          }
          catch (Exception ex)
          {
            MessageBox.Show(string.Format(Properties.Resources.StringMboxUnhandledException,ex.Message));
          }
        }
      }
    }
    /// <summary>
    /// Fills the listview with the current list of files for the selected node
    /// </summary>
    /// <param name="nodeCurrent">The node that is currently selected in the tree.</param>
    protected void PopulateFiles2(TreeNode nodeCurrent)
    {
      //Populate listview with files
      string[] data = new string[4];
      //clear list
      InitListView();
      //check for the rootnode
      if (nodeCurrent.SelectedImageIndex != 0)
      {
        //check path
        if (Directory.Exists((string)GetFullPath(nodeCurrent.FullPath)) == false)
        {
          MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
        }
        else
        {
          try
          {
            //read all files in the directory
            string[] stringFiles = Directory.GetFiles(GetFullPath(nodeCurrent.FullPath));
            //reset the filename
            string stringFileName = "";
            //locals for the dates
            DateTime dtCreateDate, dtModifyDate;
            //local for the filesize
            Int64 lFileSize = 0;
            //loop throught all files
            foreach (string stringFile in stringFiles)
            {
              //backup the filename
              stringFileName = stringFile;
              //create a fileinfo object for the metadata
              FileInfo objFileSize = new FileInfo(stringFileName);
              //backup the size
              lFileSize = objFileSize.Length;
              //backup the creation date
              dtCreateDate = objFileSize.CreationTime; //GetCreationTime(stringFileName);
              //backup the last write date
              dtModifyDate = objFileSize.LastWriteTime; //GetLastWriteTime(stringFileName);
              //create listview data
              data[0] = GetPathName(stringFileName);
              data[1] = FormatSize(lFileSize);
              //check if file is in local current day light saving time
              if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtCreateDate) == false)
              {
                //not in day light saving time adjust time
                data[2] = FormatDate(dtCreateDate.AddHours(1));
              }
              else
              {
                //is in day light saving time adjust time
                data[2] = FormatDate(dtCreateDate);
              }
              //check if file is in local current day light saving time
              if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtModifyDate) == false)
              {
                //not in day light saving time adjust time
                data[3] = FormatDate(dtModifyDate.AddHours(1));
              }
              else
              {
                //not in day light saving time adjust time
                data[3] = FormatDate(dtModifyDate);
              }
              //Create actual list item
              ListViewItem item = new ListViewItem(data, 0);
              //and add it to the listview
              list.Items.Add(item);
            }
          }
          catch (IOException ex)
          {
            MessageBox.Show(string.Format(Properties.Resources.StringMboxDriveInvalid,ex.Message));
          }
          catch (UnauthorizedAccessException ex)
          {
            MessageBox.Show(string.Format(Properties.Resources.StringMboxDriveAuthFailed,ex.Message));
          }
          catch (Exception ex)
          {
            MessageBox.Show(string.Format(Properties.Resources.StringMboxUnhandledException,ex.Message));
          }
        }
      }
    }
    /// <summary>
    /// Reads all logical drives.
    /// </summary>
    /// <returns>Collection of all logical drives.</returns>
    protected ManagementObjectCollection GetDrives()
    {
      //create the query for the drive collection
      ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
      //get drive collection
      ManagementObjectCollection queryCollection = query.Get();
      //and return it
      return queryCollection;
    }
    /// <summary>
    /// generates the full path (removing 'my computer')
    /// </summary>
    /// <param name="path">The tool internal path representation.</param>
    /// <returns>A valid Windows path.</returns>
    protected string GetFullPath(string path)
    {
      //Get Full path
      string retval = "";
      //remove My Computer from path.
      retval = path.Replace(string.Format("{0}\\", Properties.Resources.StringTreeRootnode), "");
      //return it
      return retval;
    }
    /// <summary>
    /// retrieves the containing folder name.
    /// </summary>
    /// <param name="path">the complete path.</param>
    /// <returns>The containing folder.</returns>
    protected string GetPathName(string path)
    {
      //Get Name of folder
      string[] stringSplit = path.Split('\\');
      int _maxIndex = stringSplit.Length;
      return stringSplit[_maxIndex - 1];
    }
		/// <summary>
		/// Formats the date.
		/// </summary>
		/// <param name="date">The date as datetime.</param>
		/// <returns>The date as unified string.</returns>
    protected string FormatDate(DateTime date)
		{
			//Get date and time in short format
			string retval = string.Empty;
      //make it readable
			retval = date.ToShortDateString().ToString() + " " + date.ToShortTimeString().ToString();
      //and return it
			return retval;
		}
    /// <summary>
    /// Formats the size of the file.
    /// </summary>
    /// <param name="rawsize">the raw size.</param>
    /// <returns>Human readable string that contains the size.</returns>
		protected string FormatSize(Int64 rawsize)
		{
			//Format number to KB
			string retval = string.Empty;
      //create a numberformatinfo object
			NumberFormatInfo myNfi = new NumberFormatInfo();
      //local working size
			Int64 lKBSize = 0;
      //check for megabytes
      if (rawsize < 1024 ) 
			{
        //check for empty files
				if (rawsize == 0) 
				{
					//zero byte
					retval = "0";
				}
				else 
				{
					//less than 1K but not zero byte
					retval = "1";
				}
			}
			else 
			{
				//convert to KB
				lKBSize = rawsize / 1024;
				//format number with default format
				retval = lKBSize.ToString("n",myNfi);
				//remove decimal
				retval = retval.Replace(".00", "");
			}
			return retval + " KB";
		}

    #endregion

    #region event handler
    /// <summary>
    /// Eventhandler for select events in the tree.
    /// </summary>
    /// <param name="sender">The tree view.</param>
    /// <param name="e">Eventdata.</param>
    private void tree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      //Populate folders and files when a folder is selected
      this.Cursor = Cursors.WaitCursor;
      //get current selected drive or folder
      TreeNode nodeCurrent = e.Node;
      //clear all sub-folders
      nodeCurrent.Nodes.Clear();
      //check for the selection of the root node
      if (nodeCurrent.SelectedImageIndex == 0)
      {
        //Selected My Computer - repopulate drive list
        PopulateDriveList();
      }
      else
      {
        //populate sub-folders and folder files
        PopulateDirectory(nodeCurrent, nodeCurrent.Nodes);
      }
      //revert to the default cursor
      this.Cursor = Cursors.Default;
    }
    /// <summary>
    /// Owner draw event for Listitems
    /// </summary>
    /// <param name="sender">The Listview</param>
    /// <param name="e">Eventdata</param>
    private void list_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
      //check if the file is already in cache
      if(thumbnails.ContainsKey((string)e.Item.Tag))
      {
        //create the painting bounds
        Rectangle bounds = new Rectangle(e.Bounds.X,e.Bounds.Y,thumbnails[(string)e.Item.Tag].Width,thumbnails[(string)e.Item.Tag].Height);
        //paint from cache
        e.Graphics.DrawImage(thumbnails[(string)e.Item.Tag],bounds);
      }
      else
      {
        Image tmp = Image.FromFile((string)e.Item.Tag);
        //check landscape
        if(tmp.Width > tmp.Height)
        {
          //calculate the scaling for the height from the width
          float scaling = tmp.Width / e.Bounds.Width;
          //save the thumbnail
          //thumbnails.Add((string)e.Item.Tag,tmp.GetThumbnailImage(e.Bounds.Width,tmp.Height/scaling));
          //paint it landsape
          e.Graphics.DrawImage(tmp,e.Bounds.X,e.Bounds.Y,e.Bounds.Width,tmp.Height/scaling);
        }
        //check portrait
        else if(tmp.Width < tmp.Height)
        {
          //calculate the scaling for the width from the height
          float scaling = tmp.Height / e.Bounds.Height;
          //save the thumbnail
          //thumbnails.Add((string)e.Item.Tag,tmp.GetThumbnailImage(tmp.Width/scaling,e.Bounds.Height));
          //paint it landsape
          e.Graphics.DrawImage(tmp,e.Bounds.X,e.Bounds.Y,tmp.Width/scaling,e.Bounds.Height);
        }
        //both sides have the same dimensions
        else
        {
          //e.Graphics.DrawImage(tmp.GetThumbnailImage(e.Bounds.Width,e.Bounds.Height,AbortCallback,System.IntPtr.Zero),e.Bounds);
          //paint it as it is
          e.Graphics.DrawImage(tmp,e.Bounds);
        }
      }
    }
    private bool AbortCallback()
    {
      return true;
    }
    #endregion

  }
}