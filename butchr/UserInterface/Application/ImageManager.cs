using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Matmaxx.Toolbox.StopWatch;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using Matmaxx.Butchr.Properties;
using Matmaxx.Butchr.UserInterface;
using ExifLib;

namespace Matmaxx.Butchr.Application
{
  /// <summary>
  /// ImageManager that does all the work.
  /// </summary>
  public class ImageManager
  {
    #region const
    /// <summary>
    /// Photomatix commandline option to introduce the xmp file.
    /// </summary>
    private const string PhotomatixXmpParameter = "-x1";
    /// <summary>
    /// Photomatix commandline option to introduce the output filename.
    /// </summary>
    private const string PhotomatixOutputParameter = "-o";
    /// <summary>
    /// Seperator to better organize the batch process.
    /// </summary>
    private const string BatchEchoSeperator = @"************************************************************************";
    #endregion

    #region enum
    /// <summary>
    /// Lists all predefined group ids.
    /// </summary>
    public enum GroupIds
    {
      /// <summary>
      /// Image is not grouped yet.
      /// </summary>
      NotGrouped = 0,
      /// <summary>
      /// Default value for the first group after reset.
      /// </summary>
      InitialGroup = 0
    }
    /// <summary>
    /// The identifiers for the different RAW Formats.
    /// </summary>
    public enum RawFormat
    {
      /// <summary>
      /// invalid format for initialization
      /// </summary>
      None,
      /// <summary>
      /// .RAW
      /// </summary>
      Generic,
      /// <summary>
      /// .NEF
      /// </summary>
      Nikon,
      /// <summary>
      /// .CR2
      /// </summary>
      Canon01,
      /// <summary>
      /// .CRW
      /// </summary>
      Canon02,
      /// <summary>
      /// .DNG
      /// </summary>
      Adobe
    }
    /// <summary>
    /// Lists all possible stragegies that the dialog will return.
    /// </summary>
    public enum ExistingFileStrategy
    {
      /// <summary>
      /// Overwrite this one file (and ask again for the next one).
      /// </summary>
      OverwriteOnce,
      /// <summary>
      /// Skip this one file (and ask again for the next one).
      /// </summary>
      OverwriteAll,
      /// <summary>
      /// Overwrite this file and all precending ones.
      /// </summary>
      SkipOnce,
      /// <summary>
      /// Skip this file and all precending ones.
      /// </summary>
      SkipAll,
      /// <summary>
      /// Cancel the complete operation with an error.
      /// </summary>
      Cancel,
      /// <summary>
      /// Dummy element for initialization.
      /// </summary>
      None
    }
    #endregion

    #region props
    /// <summary>
    /// Gets a value indicating whether any images are loaded.
    /// </summary>
    /// <value><c>true</c> if images are loaded; otherwise, <c>false</c>.</value>
    public bool AreImagesLoaded 
    { 
      get
      {
        return thumbCache.Count.Equals(0).Equals(false);
      }
    }
    /// <summary>
    /// Gets a value indicating whether no images are loaded.
    /// </summary>
    /// <value><c>true</c> if no images are loaded; otherwise, <c>false</c>.</value>
    public bool AreNoImagesLoaded 
    { 
      get
      {
        return thumbCache.Count.Equals(0).Equals(true);
      }
    }
    #endregion

    #region members
    /// <summary>
    /// Dictionary to hold the thumbnails.
    /// </summary>
    Dictionary<string, Bitmap> thumbCache;
    /// <summary>
    /// Dictionary to hold the exifdata.
    /// </summary>
    public Dictionary<string, ExifData> exifCache;
    /// <summary>
    /// The reader for jgp exif data.
    /// </summary>
    ExifReader exifReader;
    /// <summary>
    /// Dictionary for grouping the images.
    /// </summary>
    Dictionary<string,int> imageGroups;
    /// <summary>
    /// Dictionary to get from the the logical RawFormat to the corresponding file extension
    /// </summary>
    public Dictionary<RawFormat,string> RawExtensions;
    /// <summary>
    /// The background copy thread.
    /// </summary>
    Thread copyThread;
    /// <summary>
    /// running index for the current group.
    /// </summary>
    int currentGroupId;
    /// <summary>
    /// Stopwatch for time measurements
    /// </summary>
    DebugTimer dt;
    /// <summary>
    /// Stragegy on how to proceed with existing target files.
    /// </summary>
    ExistingFileStrategy existingFileStrategy = ExistingFileStrategy.None;
    /// <summary>
    /// The owner of this image manager (used for centering child windows)
    /// </summary>
    IWin32Window owner;
    #endregion

    #region events
    /// <summary>
    /// Event that is fired whenever a thumbnail is created.
    /// </summary>
    public event OnThumbnailCreationFinished ThumbnailCreated;
    /// <summary>
    /// Event that is fired if a statechange in the copy operation has occured.
    /// </summary>
    public event OnCopyStateChanged CopyStateChanged;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the ImageManager.
    /// </summary>
    public ImageManager() : this(null,null)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageManager"/> class.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <param name="existingFileStrategyForm">The existing file strategy form.</param>
    public ImageManager(IWin32Window owner,ExistingFileStrategyForm existingFileStrategyForm)
    {
      //backup the ref to the owner form (for opening dialog in 'center parent' mode)
      this.owner = owner;
      //initialize the thumbnail cache
      thumbCache = new Dictionary<string, Bitmap>();
      //initialize the exif cache
      exifCache = new Dictionary<string,ExifData>();
      //initialize the image group container
      imageGroups = new Dictionary<string,int>();
      //init the group ids (make it readable for humans)
      currentGroupId = (int)GroupIds.InitialGroup;
      //init the debug timer
      dt = new DebugTimer();
      dt.Reset();
      //init the Raw formats
      RawExtensions = new Dictionary<RawFormat,string>();
      RawExtensions.Add(RawFormat.None,string.Empty);
      RawExtensions.Add(RawFormat.Adobe,Properties.Resources.ExtensionRawAdobe);
      RawExtensions.Add(RawFormat.Canon01,Properties.Resources.ExtensionRawCanon01);
      RawExtensions.Add(RawFormat.Canon02,Properties.Resources.ExtensionRawCanon02);
      RawExtensions.Add(RawFormat.Generic,Properties.Resources.ExtensionRawGeneric);
      RawExtensions.Add(RawFormat.Nikon,Properties.Resources.ExtensionRawNikon);
    }
    #endregion

    #region API

    #region generic
    /// <summary>
    /// Resets all objects for a new operation.
    /// </summary>
    public void Reset()
    {
      //clear the arrays
      if(null != imageGroups) imageGroups.Clear();
      if(null != thumbCache)  thumbCache.Clear();
      if(null != exifCache)   exifCache.Clear();
      //reset the current group;
      currentGroupId = (int)GroupIds.InitialGroup;
      //unregister all eventhandlers
      ThumbnailCreated = null;
      CopyStateChanged = null;
    }
    #endregion

    #region thumbnailing
    /// <summary>
    /// Creates thumbnails of all jpgs in the given path.
    /// </summary>
    /// <param name="path">The source directory for thumbnail creation.</param>
    /// <param name="width">The maximum width of the thumbnail.</param>
    /// <param name="height">The maximum height of the thumbnail.</param>
    public void BeginCreateThumbnails(string path, int width, int height)
    {
      //local buffer for all jpg paths
      List<string> jpgs = new List<string>();
      //check if the directory exists
      if (Directory.Exists(path))
      {
        try
        {
          //read all files in the directory
          string[] files = Directory.GetFiles(path);
          //loop all files and extract the jpg-images
          foreach (string file in files)
          {
            //check for jpgs before attempting to create a thumbnail
            if (IsDisplayableExtension(file))
            {
              //add it to the jpg collection
              jpgs.Add(file);
            }
          }
          //loop through all jpgs
          for (int i = 0; i < jpgs.Count; i++)
          {
            //check if the file is not yet thumbnailed before adding it to the dictionary
            if (false == thumbCache.ContainsKey(jpgs[i]))
            {
              //remember whether this is the last image
              bool isLastImage = (i == jpgs.Count-1) ? true : false;
              object threadData = (object)(new ThumbnailWorkerEventArgs(jpgs[i],width,height,isLastImage,jpgs.Count));
              ThreadPool.SetMaxThreads(2, 2);
              ThreadPool.QueueUserWorkItem(new WaitCallback(CreateThumbnailWorker),threadData); 
            }
          }
        }
        catch (Exception ex)
        {
          //thumbnail creation failed, notify by exception
          throw new InvalidOperationException(string.Format(Properties.Resources.ExThumbnailCreationFailed, ex.Message));
        }
      }
      else
      { 
        //directory does not exist, notify by exception
        throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.ExDirectoryDoesNotExist,path));
      }
    }
    /// <summary>
    /// Returns a thumbnail for an image that is specified by its path.
    /// </summary>
    /// <param name="path">The path of the original image.</param>
    /// <param name="width">The desired width of the thumbnail.</param>
    /// <param name="height">The desired height of the thumbnail.</param>
    /// <returns>The thumbnail for the requested image.</returns>
    public System.Drawing.Bitmap GetThumbnail(string path, int width, int height)
    {
      //check if the file is already thumbnailed
      if (thumbCache.ContainsKey(path))
      {
        //check if the thumbnail has to be resized
        if((width != thumbCache[path].Size.Width) || (height != thumbCache[path].Size.Height))
        {
          //size is different, so return the scaled image
          return ResizeBitmap(thumbCache[path],width,height);
        }
        else
        {
          //size is ok, so just return it
          return thumbCache[path];
        }
      }
      else
      { 
        //notify by exception
        throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.ExThumbnailNotCached,path));
      }
    }
    /// <summary>
    /// Resizes the given bitmap.
    /// </summary>
    /// <param name="bitmap">The bitmap to be resized.</param>
    /// <param name="width">The new width.</param>
    /// <param name="height">The new height.</param>
    /// <returns>The resized bitmap</returns>
    public Bitmap ResizeBitmap( Bitmap bitmap, int width, int height)
    {
      //create a bitmap to paint into
      Bitmap result = new Bitmap(width,height);
//      using( Graphics g = Graphics.FromImage((Image)result))
//        g.DrawImage( bitmap, 0, 0, width, height );
      //create a graphics context in the temporary bitmap
      Graphics g = Graphics.FromImage((Image)result);
      //draw the given bitmap scaled into the temporary bitmap
      g.DrawImage(bitmap,0,0,width,height);
      //return the temporary bitmap
      return result;
    }
    /// <summary>
    /// Checks if the file shall be displayed.
    /// </summary>
    /// <param name="path">The path of the file to be checked.</param>
    /// <returns><c>true</c> if the type of file shall be displayed, <c>false</c> otherwise.</returns>
    public bool IsDisplayableExtension(string path)
    {
      //local retval
      bool retval = false;
      //get the extension from the path, make it lowercase and remove the point
      string extension = Path.GetExtension(path).ToLower().Replace(".", "");
      //remove any points from the 
      if ((extension.Equals("jpg")) || (extension.Equals("jpeg")))
      {
        retval = true;
      }
      //finally return the result
      return retval;
    }
    /// <summary>
    /// Checks if the file is a RAW.
    /// </summary>
    /// <param name="path">The path of the file to be checked.</param>
    /// <returns><c>true</c> if the type of file is a RAW, <c>false</c> otherwise.</returns>
    public bool IsRawExtension(string path)
    {
      //local retval
      bool retval = false;
      //get the extension from the path, make it lowercase and remove the point
      string extension = Path.GetExtension(path).ToLower().Replace(".", "");
      //check if this is now really a raw
      if (extension.Equals(Settings.Default.LastRawFormat.ToLower()))
      {
        retval = true;
      }
      //finally return the result
      return retval;
    }
    /// <summary>
    /// Checks if there is a raw image along with the jpg.
    /// </summary>
    /// <param name="path">The path of the jpg.</param>
    /// <returns><c>true</c> if the raw image exists, <c>false</c> otherwise.</returns>
    public bool IsRawAvailable(string path)
    {
      //strip the pure filename
      string filename = Path.GetFileNameWithoutExtension(path);
      //create the raw directory name
      string directory = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(path)),Properties.Resources.FolderRawInitial);
      //build the name of the expected raw file
      string raw = string.Format("{0}\\{1}.{2}",directory,filename,Settings.Default.LastRawFormat);
      //return if the expected file exists
      return File.Exists(raw);
    }
    #endregion
    
    #region image grouping
    /// <summary>
    /// Adds a new group of images.
    /// </summary>
    /// <param name="paths">The paths of the images to be grouped.</param>
    public void CreateImageGroup(List<string> paths)
    {
      //update the group id for this group
      int groupId = UpdateGroupId();
      //loop all paths
      foreach (string path in paths)
      {
        //check if the path already exists
        if(imageGroups.ContainsKey(path))
        {
          //overwrite it
          imageGroups[path] = groupId;
        }
        else
        {
          //add it to the new group
          imageGroups.Add(path,groupId);
        }
      }
    }
    /// <summary>
    /// Removes all image groups.
    /// </summary>
    public void RemoveAllImageGroups()
    {
      //clear the image groups
      imageGroups.Clear();    
      //and reset the index
      currentGroupId = FindStartOffset(Settings.Default.LastTargetFolder);
    }
    /// <summary>
    /// Ungroups the images.
    /// </summary>
    /// <param name="paths">The paths.</param>
    public void UngroupImages(List<string> paths)
    {
      //loop all paths
      foreach (string path in paths)
      {
        //check if the path already exists
        if(imageGroups.ContainsKey(path))
        {
          //remove it
          imageGroups.Remove(path);
        }
        else
        {
          //image is not grouped - nothing to do
        }
      }
    }
    /// <summary>
    /// Retrieves the group identifier for a given image.
    /// </summary>
    /// <param name="path">The path of the image.</param>
    /// <returns>The numerical group id or 0 if the image is not grouped yet.</returns>
    public int GetGroupIdForImage(string path)
    {
      //local retval 
      int groupId = 0;
      //check if the image is already grouped
      if(imageGroups.ContainsKey(path))
      {
        groupId = imageGroups[path];
      }
      //finally return the group id for this image
      return groupId;
    }
    #endregion
    
    #region file system operations
    /// <summary>
    /// Scans the specified folder for raw images to detect the format.
    /// </summary>
    /// <param name="path">The folder to be scanned.</param>
    /// <returns>The format of the first found raw image that is found in the specified folder.</returns>
    public RawFormat ScanFolderForRawFormat(string path)
    {
      //local for the returning result
      RawFormat result = RawFormat.None;
      //check if the path exists
      if(Directory.Exists(path))
      {
        //loop all files in this directory
        foreach (string file in Directory.GetFiles(path))
        {
          //extract the extension of the file
          string extension = Path.GetExtension(file).ToLower().Replace(".",string.Empty);
          //loop the raw extensions
          foreach (RawFormat format in RawExtensions.Keys)
	        {
            //check if this extension exists in the raw extensions 
            if(RawExtensions[format].ToLower().Equals(extension))
            {
              //found it, backup the format
              result = format;
              //leave the inner loop;
              break;
            }
          }
          //check if something was found to leave to outer loop
          if(result.Equals(RawFormat.None)) continue;
          else                              break;
        }
      }
      //finally return the result
      return result;
    }
    /// <summary>
    /// Starts the copy operation that continues in background.
    /// </summary>
    /// <param name="source">The source directory.</param>
    /// <param name="target">The target directory.</param>
    public void BeginCopyOperation(string source, string target)
    {
      //now that the target directory is known, update the offset for the group ids
      currentGroupId = FindStartOffset(target);
      //check if the folder already contained butchr folders
      if(currentGroupId.Equals(0).Equals(false))
      {
        //notify the user
        MessageBox.Show(string.Format(Resources.MboxFolderAlreadyContainsButchrsText,Environment.NewLine),
                                      Resources.MboxFolderAlreadyContainsButchrsTitle,
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.None);        
      }
      //create the data package for the worker
      Object data = (object)new CopyEventArgs(source, target, CopyEventArgs.CopyEventType.None,string.Empty);
      //create the thread
      copyThread = new Thread(new ParameterizedThreadStart(ImportWorker));
      //and start it
      copyThread.Start(data);
      //return to the caller while copy continues in background
      return;
    }
    /// <summary>
    /// Distributes the image groups to the final directory structure.
    /// </summary>
    /// <param name="baseDirectory">The base directory.</param>
    public void DistributeImageGroups(string baseDirectory)
    {
      //check if the target directory already has distributed directories
      int offset = FindStartOffset(baseDirectory);
      //build the initial source folder
      string jpgInitialDirectory = Path.Combine(baseDirectory, Properties.Resources.FolderJpgInitial);
      //build the initial source folder
      string rawInitialDirectory = Path.Combine(baseDirectory, Properties.Resources.FolderRawInitial);
      //build the finished directory path
      string finishedDirectory = Path.Combine(baseDirectory, Properties.Resources.FolderFinished);
      //build the internet directory path
      string internetDirectory = Path.Combine(baseDirectory, Properties.Resources.FolderInternet);
      //build the tiff directory path
      string tiffDirectory = Path.Combine(baseDirectory, Properties.Resources.FolderTiff);
      //build the standard directories
      if (Directory.Exists(finishedDirectory).Equals(false))  Directory.CreateDirectory(finishedDirectory);
      if (Directory.Exists(internetDirectory).Equals(false))  Directory.CreateDirectory(internetDirectory);
      if (Directory.Exists(tiffDirectory).Equals(false))   Directory.CreateDirectory(tiffDirectory);
      //create a list for the group ids
      List<int> groupIds = new List<int>();
      //fill all group ids
      foreach (int id in imageGroups.Values)
      { 
        //check if the group id is already added and add it if not
        if (false == groupIds.Contains(id)) groupIds.Add(id);
      }
      //loop all groups
      foreach (int id in groupIds)
      {
        //create the lists of source files to be copied
        List<string> jpgs = new List<string>();
        //loop all files in the jpg directory
        foreach (string jpg in Directory.GetFiles(jpgInitialDirectory))
        {
          //check if the file is grouped and if it contains the correct group
          if (imageGroups.ContainsKey(jpg) && imageGroups[jpg].Equals(id))
          { 
            //found one, add it to the jpgs group
            jpgs.Add(jpg);
          }
        }
        //create the basedirectory for this group
//        string groupDirectory = Path.Combine(baseDirectory, (id+offset).ToString(Properties.Resources.FolderGroupFormat));
        string groupDirectory = Path.Combine(baseDirectory, id.ToString(Properties.Resources.FolderGroupFormat));
        //create the jpg directory for this group
        string jpgGroupDirectory = Path.Combine(groupDirectory, Properties.Resources.FolderJpgTarget);
        //create the work directory for this group
        string workGroupDirectory = Path.Combine(groupDirectory, Properties.Resources.FolderWorkTarget);
        //create the raw directory for this group
        string rawGroupDirectory = Path.Combine(groupDirectory, Properties.Resources.FolderRawTarget);
        //create the jpg directory
        if (Directory.Exists(jpgGroupDirectory).Equals(false)) Directory.CreateDirectory(jpgGroupDirectory);
        //create the work directory
        if (Directory.Exists(workGroupDirectory).Equals(false)) Directory.CreateDirectory(workGroupDirectory);
        //select the path for the preview thumbnail by taking the 'middle' one 
        string previewSource = jpgs[(int)Math.Round((double)(jpgs.Count / 2), 0)];
        //create the path in the group directory
//        string previewTarget = Path.Combine(groupDirectory, string.Format("{0}{1}{2}", Properties.Resources.PreviewPrefix, (id+offset).ToString(Properties.Resources.FolderGroupFormat), Properties.Resources.PreviewSuffix));
        string previewTarget = Path.Combine(groupDirectory, string.Format("{0}{1}{2}", Properties.Resources.PreviewPrefix, id.ToString(Properties.Resources.FolderGroupFormat), Properties.Resources.PreviewSuffix));
        //save its thumbnail in the groupdirectory
        thumbCache[previewSource].Save(previewTarget);
        //extract the groupname
        string baseName = Path.GetFileName(baseDirectory);
        //loop all jpgs of this group
        foreach (string jpgSource in jpgs)
        {
          //create the name of the target jpg
          string jpgTarget = Path.Combine(jpgGroupDirectory, Path.GetFileName(jpgSource));
          try
          {
            if(Settings.Default.MoveFilesOnDistribute.Equals(true))
            {
              //move the jpg
              File.Move(jpgSource, jpgTarget);
            }
            else
            {
              //copy the jpg
              File.Copy(jpgSource, jpgTarget);
            }
          }
          catch (Exception ex)
          {
            //notify about the failure
            Butchr.Log.Error(string.Format(Properties.Resources.ExMoveFailed,jpgSource,jpgTarget,ex.Message));
          }
          //notify about the success
          Butchr.Log.Output(string.Format(Properties.Resources.LogMoveSuccessful, jpgSource, jpgTarget));
          //check if the raw exists for this jpg
          if (IsRawAvailable(jpgSource))
          { 
            //create the name of the corresponding raws
            string rawFile = string.Format("{0}.{1}", Path.GetFileNameWithoutExtension(jpgSource), Settings.Default.LastRawFormat);
            string rawSource = Path.Combine(rawInitialDirectory, rawFile);
            string rawTarget = Path.Combine(rawGroupDirectory, rawFile);
            //check if the raw directory is already created and create if not
            if (Directory.Exists(rawGroupDirectory).Equals(false)) Directory.CreateDirectory(rawGroupDirectory);
            try
            {
              if(Settings.Default.MoveFilesOnDistribute.Equals(true))
              {
                //move the raw file
                File.Move(rawSource, rawTarget);
              }
              else
              {
                //copy the raw file
                File.Copy(rawSource, rawTarget);
              }
            }
            catch (Exception ex)
            {
              //notify about the failure
              Butchr.Log.Error(string.Format(Properties.Resources.ExMoveFailed, rawSource, rawTarget, ex.Message));
            }
            //notify about the success
            Butchr.Log.Output(string.Format(Properties.Resources.LogMoveSuccessful, rawSource, rawTarget));
          }
        }
      }
      //do a final output for the distribution
      Butchr.Log.Output(Properties.Resources.LogDistributionFinished);
    }
    /// <summary>
    /// Finds the start offset in the target directory (if this directory already contains distributed images.
    /// </summary>
    /// <param name="baseDirectory">The base directory.</param>
    /// <returns>The start offset for creating distribution directories.</returns>
    private int FindStartOffset(string baseDirectory)
    {
      //local retval
      int maximum = 0;
      //local for the maximum
      int current = 0;
      //read all subdirectories in the basedirectory
      string[] subs = Directory.GetDirectories(baseDirectory);
      //check if there are any subdirectories
      if (null != subs)
      { 
        //loop all subdirs
        foreach (string dir in subs)
        {
          //try to parse the current directory's name 
          if (int.TryParse(Path.GetFileName(dir), out current))
          { 
            //it's an int, check if it is bigger than the current maximum
            if (current > maximum)
            {
              //update the maximum
              maximum = current;
            }
          }
        }
      }
      //finally return the maximum
      return maximum;
    }
    #endregion

    #region photomatix remote control
    /// <summary>
    /// Creates the HDR scratch batch.
    /// </summary>
    /// <param name="BasePath">The base path.</param>
    /// <param name="XmpPath">The path to the xmp file.</param>
    public void CreateHdrScratches(string BasePath,string XmpPath)
    {
      //local content of the scratch batch
      string batchContent = string.Empty;
      //local for the xmp target
      string xmpTarget = Path.Combine(BasePath,Path.GetFileName(XmpPath));
      //local for the generation date
      string genTimestamp = string.Format("[{0}-{1}-{2} {3}:{4}:{5}]",DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
      //add some intro to create the necessary folder structure
      batchContent += string.Format(@"@ECHO OFF{0}",Environment.NewLine);
      batchContent += string.Format(@"echo {0}{1}",BatchEchoSeperator,Environment.NewLine);
      batchContent += string.Format(@"echo Welcome to the Butcher-ScratchBatch{0}",Environment.NewLine);
      batchContent += string.Format(@"echo written by matmaxx{0}",Environment.NewLine);
      batchContent += string.Format(@"echo generated on {0}{1}",genTimestamp,Environment.NewLine);
      batchContent += string.Format(@"echo {0}{1}",BatchEchoSeperator,Environment.NewLine);
      batchContent += string.Format(@":MKDIR_SCRATCH{0}",Environment.NewLine);
      batchContent += string.Format(@"if exist .\{0}\ goto MKDIR_SCRATCH_DONE{1}",Resources.FolderScratch,Environment.NewLine);
      batchContent += string.Format(@"mkdir {0}{1}",Resources.FolderScratch,Environment.NewLine);
      batchContent += string.Format(@"echo Created folder: {0}{1}",Resources.FolderScratch,Environment.NewLine);
      batchContent += string.Format(@":MKDIR_SCRATCH_DONE{0}",Environment.NewLine);
      batchContent += string.Format(@"if exist .\{0}\{1}\ goto MKDIR_SCRATCH_SKIPPED{2}",Resources.FolderScratch,Resources.FolderScratchDone,Environment.NewLine);
      batchContent += string.Format(@"mkdir {0}\{1}{2}",Resources.FolderScratch,Resources.FolderScratchDone,Environment.NewLine);
      batchContent += string.Format(@"echo Created folder: {0}\{1}{2}",Resources.FolderScratch,Resources.FolderScratchDone,Environment.NewLine);
      batchContent += string.Format(@":MKDIR_SCRATCH_SKIPPED{0}",Environment.NewLine);
      batchContent += string.Format(@"if exist .\{0}\{1}\ goto PHOTOMATIX{2}",Resources.FolderScratch,Resources.FolderScratchSkipped,Environment.NewLine);
      batchContent += string.Format(@"mkdir {0}\{1}{2}",Resources.FolderScratch,Resources.FolderScratchSkipped,Environment.NewLine);
      batchContent += string.Format(@"echo Created folder: {0}\{1}{2}",Resources.FolderScratch,Resources.FolderScratchSkipped,Environment.NewLine);
      batchContent += string.Format(@":PHOTOMATIX{0}",Environment.NewLine);
      
      //loop all directories in the basepath
      string[] directories = Directory.GetDirectories(BasePath);
      //loop them 
      for (int index = 0; index < directories.Length; index++)
      {
        //local for the result of the parse
        int result = 0;
        //try to convert the name of the current directory to a number
        if(int.TryParse(directories[index].Replace(BasePath,string.Empty).Replace(@"\",string.Empty),out result))
        {
          //build the potential jpg directory
          string jpgDirectory = Path.Combine(Path.Combine(BasePath,directories[index]),Properties.Resources.FolderJpgTarget);
          //check if this directory contains a jpg folder
          if(Directory.Exists(jpgDirectory))
          {
            //create the hdr for this directory
            CreateHdrScratch(BasePath,jpgDirectory,Path.Combine(BasePath,Path.GetFileName(XmpPath)),result,ref batchContent);
          }
        }
      }
      //add some outro
      batchContent += string.Format(@"{0}:END{1}",Environment.NewLine,Environment.NewLine);
      batchContent += string.Format(@"echo All scratches generated.{0}",Environment.NewLine);
      batchContent += string.Format(@"pause{0}",Environment.NewLine);
      //finally write the batchfile
      try
      {
        //try to write with the german codepage to enable äöü and ß in the pathnames
        File.WriteAllText(Path.Combine(BasePath,Resources.ScratchBatchFilename),batchContent,Encoding.GetEncoding(850));
      }
      catch (Exception)
      {
        //use default encoding
        File.WriteAllText(Path.Combine(BasePath,Resources.ScratchBatchFilename),batchContent);
      }
      //check if the xmp already exists and delete it (may ask the user..?)
      if(File.Exists(xmpTarget)) File.Delete(xmpTarget);
      //and copy the xmp to the project directory 
      File.Copy(XmpPath,xmpTarget);
    }
    /// <summary>
    /// Creates the HDR scratch batch command.
    /// "C:\Programme\PhotomatixPro3\PhotomatixCL.exe" //path to photomatix command line tool
    /// -3                  //Merge of the source images into an HDR image (by default saved in Radiance ".hdr" format)
    /// -t1                 //Tone map HDR image with "Details Enhancer" (requires option -3)
    /// -s jpg              //Resulting image saved in a format different from the one of the source images. Options are: -s tif or -s jpg
    /// -j 100              //Jpeg quality for resulting image saved in the JPEG format, e.g. -j 90 (default is 100)
    /// -h "remove"         //HDR saving options: -h "exr" will save the HDR image in the OpenEXR format, -h "remove" will remove the HDR image after having tone mapped it.
    /// -x1 scratch.xmp     //Settings file in XMP format for tone mapping method "Details Enhancer", .e.g. -x1 EnhancerSettings.xmp
    /// -o output_scratch   //Name of the resulting image (without the extension)
    /// P1100502.JPG P1100502_minus.JPG P1100502_plus.JPG
    /// </summary>
    /// <param name="BasePath">The base directory.</param>
    /// <param name="GroupPath">The group directory.</param>
    /// <param name="XmpPath">The path to the xmp file.</param>
    /// <param name="ImageNumber">The image number.</param>
    /// <param name="BatchContent">Content of the batchfile to be filled by this method.</param>
    private void CreateHdrScratch(string BasePath,string GroupPath, string XmpPath, int ImageNumber, ref string BatchContent)
    {
      //local for the final list of files 
      string jpgFiles = string.Empty;
      //local for the commandline options
      string photomatixConstParameters = string.Empty;
      #region photomatix options
		  //check if the options are still empty
      if(Settings.Default.PhotomatixCommandlineOptions.Equals(string.Empty))
      {
        //use default options in this case
        photomatixConstParameters = Settings.Default.PhotomatixCommandlineOptionsDefault;
      }
      else
      {
        //use the stored options
        photomatixConstParameters = Settings.Default.PhotomatixCommandlineOptions;
      }
      #endregion
      //get all files in this directory
      string[] allFiles = Directory.GetFiles(GroupPath);
      //build the list of files
      for (int index = 0; index < allFiles.Length; index++)
      {
        //check if this is a jpg
        if(IsDisplayableExtension(allFiles[index]))
        {
          //add this file to the list of jpgs
          jpgFiles = string.Format("{0} \"{1}\"",jpgFiles,allFiles[index]);
        }
      }
      //check if there are any jpgs collected
      if(false == jpgFiles.Equals(string.Empty))
      {
        //generate the output name
        string outputName = string.Format("scratch__{0}__{1}",Path.GetFileName(BasePath),ImageNumber.ToString(Properties.Resources.FolderGroupFormat));
        //generate the output path
        string outputPath = Path.Combine(Path.Combine(BasePath,Properties.Resources.FolderScratch),outputName);
        //generate the command string
        string photomatixCommand = string.Format("\"{0}\" {1} {2} \"{3}\" {4} \"{5}\" {6}",Settings.Default.PhotomatixCommandlinePath,
                                                                                           photomatixConstParameters,
                                                                                           PhotomatixXmpParameter,
                                                                                           XmpPath,
                                                                                           PhotomatixOutputParameter,
                                                                                           outputPath,
                                                                                           jpgFiles);
        //create the delete command
        string deleteCommand = string.Format("rd /S /Q {0}",GroupPath,Environment.NewLine);
        //add an intro for this command to the batchfile
        BatchContent = string.Format("{0}{1}echo {2}",BatchContent,Environment.NewLine,BatchEchoSeperator);
        BatchContent = string.Format("{0}{1}echo Now processing: {2}",BatchContent,Environment.NewLine,outputName);
        BatchContent = string.Format("{0}{1}echo {2}",BatchContent,Environment.NewLine,BatchEchoSeperator);
        //add the photomatix command to the batchfile
        BatchContent = string.Format("{0}{1}{2}",BatchContent,Environment.NewLine,photomatixCommand);
        //check if the source jpgs shall be deleted after scratching
        if(Settings.Default.DeleteSourceJpgsAfterScratching.Equals(true))
        {
          //add the delete command for the jpgs that are no longer needed
          BatchContent = string.Format("{0}{1}echo {2}",BatchContent,Environment.NewLine,BatchEchoSeperator);
          BatchContent = string.Format("{0}{1}{2}",BatchContent,Environment.NewLine,deleteCommand);
        }
        //add an outro for this command to the batchfile
        BatchContent = string.Format("{0}{1}echo {2}",BatchContent,Environment.NewLine,BatchEchoSeperator);
        BatchContent = string.Format("{0}{1}echo Finished: {2}",BatchContent,Environment.NewLine,outputName);
        BatchContent = string.Format("{0}{1}echo {2}",BatchContent,Environment.NewLine,BatchEchoSeperator);
        BatchContent = string.Format("{0}{1}echo .",BatchContent,Environment.NewLine);
      }
    }
    #endregion

    #endregion

    #region helper functions
    /// <summary>
    /// Background task for copying the images.
    /// </summary>
    /// <param name="data">The data.</param>
    private void ImportWorker(Object data)
    { 
      //unpack the working data
      CopyEventArgs args = (CopyEventArgs)data;
      //backup the target directory
      string targetDir = args.Target;
      //backup the source dir
      string sourceDir = args.Source;
      //create the jpg list
      List<string> jpgs = new List<string>();
      //create the raw list
      List<string> raws = new List<string>();
      // the counting index of the current image.
      int countCurrent = 0;
      // The total number of images.
      int countTotal = 0;
      //read all files in the source directory
      string[] files = Directory.GetFiles(sourceDir);
      //reset the overwrite strategy for existing files
      existingFileStrategy = ExistingFileStrategy.None;
      //loop all files
      foreach (string file in files)
      { 
        //check for a jpg and add it to the list
        if (IsDisplayableExtension(file)) jpgs.Add(file);
        //check for a raw and add it to the other list
        if (IsRawExtension(file)) raws.Add(file);
      }
      try
      {
        //check if the target directories exists and create if necessary
        if (false == Directory.Exists(args.Target)) Directory.CreateDirectory(args.Target);
        if (false == Directory.Exists(string.Format("{0}\\{1}",args.Target,Properties.Resources.FolderJpgInitial))) Directory.CreateDirectory(string.Format("{0}\\{1}",args.Target,Properties.Resources.FolderJpgInitial));
        if (false == Directory.Exists(string.Format("{0}\\{1}",args.Target,Properties.Resources.FolderRawInitial))) Directory.CreateDirectory(string.Format("{0}\\{1}",args.Target,Properties.Resources.FolderRawInitial));
        //update the copy event
        args.CopyEvent = CopyEventArgs.CopyEventType.JpgStep;
        //update the total count of jpg images
        countTotal = jpgs.Count;
        //reset the current counter
        countCurrent = 0;
        //copy all jpgs
        foreach (string jpg in jpgs)
        {
          //generate the target filepath
          args.Target = string.Format("{0}\\{1}\\{2}",targetDir,Properties.Resources.FolderJpgInitial,Path.GetFileName(jpg));
          //backup the source path
          args.Source = jpg;
          //update the current counter
          args.CountCurrent = ++countCurrent;
          //update the total counter
          args.CountTotal = countTotal;
          //check how to proceed with existing target files
          bool overwriteExisting = CheckExistingTargetHandling(args.Source,args.Target);
          //check if the file shall be skipped
          if(existingFileStrategy.Equals(ExistingFileStrategy.SkipAll)||existingFileStrategy.Equals(ExistingFileStrategy.SkipOnce))
          {
            //skip this file, but read the exif
            ReadExifData(args.Target);
          }
          //check if the operation shall be cancelled
          else if(existingFileStrategy.Equals(ExistingFileStrategy.Cancel))
          {
            //build the message for this copy step
            BuildLogMessage(args, overwriteExisting);
            //fire the event
            if (null != CopyStateChanged) CopyStateChanged(this, args);
            return;
          }
          else
          {
            if(Settings.Default.MoveFilesOnImport.Equals(true))
            {
              try
              {
                //make sure the target does not exist
                File.Delete(args.Target);
              }
              catch (Exception ex)
              {
                //do some error output
                Butchr.Log.Error(string.Format("Cannot delete file[{0}]: {1}",Path.GetFileName(args.Target),ex.Message));
              }
              //move this file
              File.Move(args.Source, args.Target);
              ReadExifData(args.Target);
            }
            else
            {
              //process this file
              File.Copy(args.Source, args.Target, overwriteExisting);
              ReadExifData(args.Target);
            }
          }
          //build the message for this copy step
          BuildLogMessage(args, overwriteExisting);
          //fire the event
          if (null != CopyStateChanged) CopyStateChanged(this, args);
        }
      }
      catch (Exception ex)
      {
        //update the CopyEvent
        args.CopyEvent = CopyEventArgs.CopyEventType.Error;
        //update the message
        args.Message = ex.Message;
        //notify by errorevent
        if (null != CopyStateChanged) CopyStateChanged(this, args);
        //leave the function right here
        return;
      }
      //copy all jpgs finished, update the copy event
      args.CopyEvent = CopyEventArgs.CopyEventType.JpgFinished;
      //and fire the event
      if (null != CopyStateChanged) CopyStateChanged(this, args);
      try
      {
        //update the copy event
        args.CopyEvent = CopyEventArgs.CopyEventType.RawStep;
        //update the total count of jpg images
        countTotal = raws.Count;
        //reset the current counter
        countCurrent = 0;
        //copy all raws
        foreach (string raw in raws)
        {
          //update the current counter
          args.CountCurrent = ++countCurrent;
          //update the total counter
          args.CountTotal = countTotal;
          //generate the target filepath
          args.Target = string.Format("{0}\\{1}\\{2}",targetDir,Properties.Resources.FolderRawInitial,Path.GetFileName(raw));
          //backup the source path
          args.Source = raw;
          //check how to proceed with existing target files
          bool overwriteExisting = CheckExistingTargetHandling(args.Source,args.Target);
          //check if the file shall be skipped
          if(existingFileStrategy.Equals(ExistingFileStrategy.SkipAll)||existingFileStrategy.Equals(ExistingFileStrategy.SkipOnce))
          {
            //skip this file
          }
          //check if the operation shall be cancelled
          else if(existingFileStrategy.Equals(ExistingFileStrategy.Cancel))
          {
            //build the message for this copy step
            BuildLogMessage(args, overwriteExisting);
            //fire the event
            if (null != CopyStateChanged) CopyStateChanged(this, args);
            return;
          }
          else
          {
            if(Settings.Default.MoveFilesOnImport.Equals(true))
            {
              try
              {
                //make sure the target does not exist
                File.Delete(args.Target);
              }
              catch (Exception ex)
              {
                //do some error output
                Butchr.Log.Error(string.Format("Cannot delete file[{0}]: {1}",Path.GetFileName(args.Target),ex.Message));
              }
              //move this file
              File.Move(args.Source, args.Target);
            }
            else
            {
              //copy this file
              File.Copy(args.Source, args.Target, overwriteExisting);
            }
          }
          //build the message for this copy step
          BuildLogMessage(args, overwriteExisting);
          //fire the event
          if (null != CopyStateChanged) CopyStateChanged(this, args);
        }
      }
      catch (Exception ex)
      {
        //update the CopyEvent
        args.CopyEvent = CopyEventArgs.CopyEventType.Error;
        //update the message
        args.Message = ex.Message;
        //notify by errorevent
        if (null != CopyStateChanged) CopyStateChanged(this, args);
        //leave the function right here
        return;
      }
      //copy all raws finished, update the copy event
      args.CopyEvent = CopyEventArgs.CopyEventType.RawFinished;
      //and fire the event
      if (null != CopyStateChanged) CopyStateChanged(this, args);
    }
    /// <summary>
    /// Reads the exif data.
    /// </summary>
    /// <param name="path">The path.</param>
    private void ReadExifData(string path)
    {
      //local to be used for the out values
      DateTime originalTimestamp;
      double exposureTime;
      double fstop;
      ushort iso;
      double focalLength;
      string cameraModel;
      string cameraOem;
      ushort orientation;
      try
      {
        //initialize the exif reader on the given file
        exifReader = new ExifReader(path);
        //create an exif object for this image
        ExifData exifData = new ExifData();
        //try to read the original timestamp
        if (exifReader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out originalTimestamp))
        {
          //it worked, so add it to our own exif data object            
          exifData.OriginalTimestamp = originalTimestamp;
        }
        //try to read the exposure time
        if (exifReader.GetTagValue<double>(ExifTags.ExposureTime, out exposureTime))
        {
          //it worked, so add it to our own exif data object            
          exifData.ShutterSpeed = exposureTime;
        }
        //try to read the fstop
        if (exifReader.GetTagValue<double>(ExifTags.FNumber, out fstop))
        {
          //it worked, so add it to our own exif data object            
          exifData.FStop = fstop;
        }
        //try to read the iso
        if (exifReader.GetTagValue<ushort>(ExifTags.ISOSpeedRatings, out iso))
        {
          //it worked, so add it to our own exif data object            
          exifData.IsoSpeedRating = iso;
        }
        //try to read the focal length
        if (exifReader.GetTagValue<double>(ExifTags.FocalLength, out focalLength))
        {
          //it worked, so add it to our own exif data object            
          exifData.FocalLength = focalLength;
        }
        //try to read the camera model
        if (exifReader.GetTagValue<string>(ExifTags.Model, out cameraModel))
        {
          //it worked, so add it to our own exif data object            
          exifData.CameraModel = cameraModel;
        }
        //try to read the camera oem
        if (exifReader.GetTagValue<string>(ExifTags.Make, out cameraOem))
        {
          //it worked, so add it to our own exif data object            
          exifData.CameraOem = cameraOem;
        }
        //try to read the orientation
        if (exifReader.GetTagValue<ushort>(ExifTags.Orientation, out orientation))
        {
          //it worked, so add it to our own exif data object            
         // exifData.Orientation = orientation;
        }
        //finally add the exifdata for this image to the dictionary
        exifCache.Add(path,exifData);
      }
      catch (Exception ex)
      {
        //do some error output
        Butchr.Log.Error(string.Format(Resources.LogExExifReader,ex.Message));
      }
      finally
      {
        //clean up and release the files
        exifReader.Dispose();
      }
    }
    /// <summary>
    /// Thread worker function for reading the images
    /// </summary>
    /// <param name="data">Thread working data.</param>
    private void CreateThumbnailWorker(Object data)
    {
      //cast a local copy of the working data
      ThumbnailWorkerEventArgs tmp = (ThumbnailWorkerEventArgs)data;
      //do the work that takes sooo long
      Bitmap thumb = CreateThumbnail(tmp.Path,tmp.Width,tmp.Height);
      //lock the dictionary to avoid multiple thread access 
      Monitor.Enter((object)thumbCache);
      //add the current thumb to the dictionary
      thumbCache.Add(tmp.Path,thumb);
      //release the dictionary
      Monitor.Exit((object)thumbCache);
      //fire the finished event
      if(null != ThumbnailCreated) ThumbnailCreated(this,tmp);
      //debug time measurement on the last item
      //if(tmp.IsLastImage) dt.StopMsgBox();
    }
    /// <summary>
    /// Creates a thumbnail image from the given bitmap to fit in the specified borders.
    /// </summary>
    /// <param name="path">The original image.</param>
    /// <param name="width">The maximum width of the thumbnail.</param>
    /// <param name="height">The maximum height of the thumbnail.</param>
    /// <returns>a thumbnail representation bitmap for the original image.</returns>
    private Bitmap CreateThumbnail(string path, int width, int height)
    {
      //read the file 
      Bitmap original = (Bitmap)Bitmap.FromFile(path);
      //rectangle for the thumb
      Rectangle thumbrect = new Rectangle();
      // calculate the aspect ratio of the image
      double ratio = (double)original.Width / (double)original.Height;
      //paddings
      int padWidth = width/100*5;
      int padHeight = height/100*5;
      //check if the image is landscape
      if(original.Width > original.Height) 
      {
        //add the orientation setting to the exif data
        exifCache[path].Orientation = 1;
        //build the rectangle for the thumb
        thumbrect.Width   = width - 2*padWidth;
        thumbrect.Height  = (int)Math.Round(height / ratio, 0) - padHeight;
        thumbrect.X       = padWidth;
        thumbrect.Y       = ((height - thumbrect.Height - padHeight) / 2);
      }
      else //or portrait
      {
        //add the orientation setting to the exif data
        exifCache[path].Orientation = 0;
        //build the rectangle for the thumb
        thumbrect.Width   = (int)Math.Round(width * ratio, 0) - padWidth;
        thumbrect.Height  = height - 2*padHeight;
        thumbrect.X       = (width - thumbrect.Width - padWidth) / 2;
        thumbrect.Y       = padHeight;
      }
      //create a new image from the orignal with the new size
      Bitmap thumb = new Bitmap((Image)original, thumbrect.Size);
      //create a new bitmap with the bounds of the thumbnail
      Bitmap canvas = new Bitmap(width,height);
      //create a graphics context from the canvas bitmap
      Graphics g = Graphics.FromImage(canvas);
      //color the background of the canvas
      g.FillRectangle(new SolidBrush(Color.Gray),new Rectangle(0,0,width,height));
      //draw the thumbnail to the canvas
//      g.DrawImage(thumb,thumbrect,thumbrect,GraphicsUnit.Pixel);
      g.DrawImage(thumb,thumbrect);
      g.DrawRectangle(new Pen(Color.Black),thumbrect);
      //dispose the mem eaters
      original.Dispose();
      thumb.Dispose();
      original = null;
      thumb = null;
      //finally return the thumbnail on the canvas
      return canvas;
    }
    /// <summary>
    /// Finds the next free group id.
    /// </summary>
    /// <returns>The next group id to be used.</returns>
    private int UpdateGroupId()
    {
      ////backup the currentGroupId
      //int nextGroupId = currentGroupId;
      ////try to find unused group ids below the current one (e.g. if all images of a group were overwritten)
      //for (int i = 1; i <= currentGroupId; i++)
      //{
      //  //check if this group id is in use
      //  if (false == imageGroups.ContainsValue(i))
      //  {
      //    //it is not, use this id
      //    nextGroupId = i;
      //    //and leave the loop
      //    break;
      //  }
      //}
      ////check if an unused id was found
      //if (nextGroupId == currentGroupId)
      //{
      //  //no unused id found, increment to the next
      //  currentGroupId++;
      //  nextGroupId = currentGroupId;
      //}
      ////return the next group id to be used
      //return nextGroupId;
      
      //increment the current id
      currentGroupId++;
      //and return it
      return currentGroupId;
    }
    /// <summary>
    /// Check if the target file exists and if it does, asks the user how to proceed.
    /// </summary>
    /// <param name="source">The source path.</param>
    /// <param name="target">The target path.</param>
    /// <returns>
    /// 	<c>True</c> if the file shall be overwritten, <c>false</c> otherwise (also if the file does not exist).
    /// </returns>
    private bool CheckExistingTargetHandling(string source,string target)
    {
      //local result of this function
      bool result = false;
      //result from the strategy dialog
      ImageManager.ExistingFileStrategy localStrategy = ImageManager.ExistingFileStrategy.None;
      //check if the global strategy requires the dialog
      switch (existingFileStrategy)
      {
        case ExistingFileStrategy.OverwriteAll:
          //overwrite without asking
          result = true;
          //sync the local strategy
          localStrategy = existingFileStrategy;
          break;
        case ExistingFileStrategy.SkipAll:
          //skip without asking
          result = false;
          //sync the local strategy
          localStrategy = existingFileStrategy;
          break;
        case ExistingFileStrategy.OverwriteOnce:
        case ExistingFileStrategy.SkipOnce:
        case ExistingFileStrategy.Cancel:
        case ExistingFileStrategy.None:
        default:
          //check if the target file exists
          if(File.Exists(target))
          {
            ExistingFileStrategyForm tmp = new ExistingFileStrategyForm();
            //target file exists, ask the user how to proceed
            localStrategy = tmp.ShowDialog(source,target);
          }
          else
          {
            //target does not exist, reset the strategy 
            localStrategy = ExistingFileStrategy.None;
          }
          break;
      }
      //check if a new local strategy was found
      switch (localStrategy)
      {
        case ExistingFileStrategy.OverwriteOnce:
        case ExistingFileStrategy.OverwriteAll:
          //overwrite this time
          result = true;
          break;
        case ExistingFileStrategy.SkipOnce:
        case ExistingFileStrategy.SkipAll:
        case ExistingFileStrategy.Cancel:
        case ExistingFileStrategy.None:
        default:
          //skip this time
          result = false;
          break;
      }
      //backup the local strategy for the next images
      existingFileStrategy = localStrategy;
      //finally return a result
      return result;
    }
    /// <summary>
    /// Builds the log message.
    /// </summary>
    /// <param name="args">The <see cref="Matmaxx.Butchr.Application.CopyEventArgs"/> instance containing the event data.</param>
    /// <param name="overwriteExisting">if set to <c>true</c> [overwrite existing].</param>
    private void BuildLogMessage(CopyEventArgs args, bool overwriteExisting)
    {
      //local for the message
      string message = string.Empty;
      //check if an error occured
      if(args.CopyEvent.Equals(CopyEventArgs.CopyEventType.Error))
      {
        //error occured
        message = string.Format(Resources.LogStepError,args.Source);
      }
      else
      {
        //everything ok, switch by the strategy to create a matching message
        switch (existingFileStrategy)
        {
          case ExistingFileStrategy.OverwriteOnce:
          case ExistingFileStrategy.OverwriteAll:
            message = string.Format(Resources.LogStepOverwrite,args.Target,args.Source);
            break;
          case ExistingFileStrategy.SkipOnce:
          case ExistingFileStrategy.SkipAll:
            message = string.Format(Resources.LogStepSkip,args.Source);
            break;
          case ExistingFileStrategy.Cancel:
            message = string.Format(Resources.LogStepCancel);
            break;
          case ExistingFileStrategy.None:
          default:
            //the normal case, decide on the move/copy setting for this import
            if(Settings.Default.MoveFilesOnImport.Equals(true))
            {
              //it's moving files
              message = string.Format(Resources.LogStepMove,args.Source,args.Target);
            }
            else
            {
              //it's copying files
              message = string.Format(Resources.LogStepCopy,args.Source,args.Target);
            }
            break;
        }
      }
      //add the [current/total]
      message = string.Format(Resources.LogStepCounterCurrentTotal,args.CountCurrent,args.CountTotal,message);
      //finally return the message in the args
      args.Message = message;
    }
    #endregion
  }
}
