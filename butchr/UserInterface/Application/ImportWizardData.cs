using System;
using System.Collections.Generic;
using System.Text;

namespace Matmaxx.Butcher.Application
{
  /// <summary>
  /// The storage class for the data that is collected by the wizard.
  /// </summary>
  public class ImportWizardData
  {
    #region enum
    /// <summary>
    /// Lists all possible file operations that can be applied to the images.
    /// </summary>
    public enum FileOperation
    {
      /// <summary>
      /// Initial value.
      /// </summary>
      None,
      /// <summary>
      /// Copy the images from source to target, but do not touch the originals.
      /// </summary>
      Copy,
      /// <summary>
      /// Move the images from source to target.
      /// </summary>
      Move
    }
    #endregion

    #region props

    #region source path
    /// <summary>
    /// The source path.
    /// </summary>
    private string sourcePath;
    /// <summary>
    /// Gets or sets the source path.
    /// </summary>
    /// <value>The source path.</value>
    public string SourcePath
    {
      get { return sourcePath; }
      set { sourcePath = value; }
    }
    #endregion

    #region target path
    /// <summary>
    /// The target path.
    /// </summary>
    private string targetPath;
    /// <summary>
    /// Gets or sets the target path.
    /// </summary>
    /// <value>The target path.</value>
    public string TargetPath
    {
      get { return targetPath; }
      set { targetPath = value; }
    }
    #endregion

    #region copy operation
    /// <summary>
    /// The way how the files are transfered from the source to the (initial) target folder.
    /// </summary>
    private FileOperation copyOperation;
    /// <summary>
    /// Gets or sets the copy operation for transfer from the source to the (initial) target folder.
    /// </summary>
    /// <value>The file operation for this step.</value>
    public FileOperation CopyOperation
    {
      get { return copyOperation; }
      set { copyOperation = value; }
    }
    #endregion

    #region distribute operation
    /// <summary>
    /// The way how the files are transfered from the (initial) target to the group folders.
    /// </summary>
    private FileOperation distributeOperation;
    /// <summary>
    /// Gets or sets the copy operation for transfer from the (initial) target to the group folders.
    /// </summary>
    /// <value>The file operation for this step.</value>
    public FileOperation DistributeOperation
    {
      get { return distributeOperation; }
      set { distributeOperation = value; }
    }
    #endregion

    #region create preview image
    /// <summary>
    /// Flag to indicate whether a preview image shall be created.
    /// </summary>
    private bool createPreview;
    /// <summary>
    /// Gets or sets a value indicating whether a preview image shall be created.
    /// </summary>
    /// <value><c>true</c> if a preview image shall be created; otherwise, <c>false</c>.</value>
    public bool CreatePreview
    {
      get { return createPreview; }
      set { createPreview = value; }
    }
    #endregion

    #region cache thumbnails
    /// <summary>
    /// Flag to indicate whether thumbnails shall be cached.
    /// </summary>
    private bool cacheThumbnails;
    /// <summary>
    /// Gets or sets a value indicating whether thumbnails shall be cached.
    /// </summary>
    /// <value><c>true</c> if thumbnails shall be cached; otherwise, <c>false</c>.</value>
    public bool CacheThumbnails
    {
      get { return cacheThumbnails; }
      set { cacheThumbnails = value; }
    }

    #endregion

    #region create hdrs
    /// <summary>
    /// Flag to indicate whether the HDR creation in photomatix shall be automated.
    /// </summary>
    private bool createHdr;
    /// <summary>
    /// Gets or sets a value indicating whether the HDR creation in photomatix shall be automated.
    /// </summary>
    /// <value><c>true</c> if the HDR creation in photomatix shall be automated; otherwise, <c>false</c>.</value>
    public bool CreateHdr
    {
      get { return createHdr; }
      set { createHdr = value; }
    }
    #endregion

    #region create release folders
    /// <summary>
    /// Flag to indicate whether release folders (finished/internet) shall be created.
    /// </summary>
    private bool createReleaseFolders;
    /// <summary>
    /// Gets or sets a value indicating whether release folders (finished/internet) shall be created.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if release folders (finished/internet) shall be created; otherwise, <c>false</c>.
    /// </value>
    public bool CreateReleaseFolders
    {
      get { return createReleaseFolders; }
      set { createReleaseFolders = value; }
    }
    #endregion

    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportWizardData"/> class.
    /// </summary>
    public ImportWizardData()
    {
      //initialize all props to safe values
      this.sourcePath           = string.Empty;
      this.targetPath           = string.Empty;
      this.copyOperation        = FileOperation.Copy;
      this.DistributeOperation  = FileOperation.Move;
      this.createPreview        = true;
      this.cacheThumbnails      = true;
      this.createHdr            = true;
      this.createReleaseFolders = true;
    }
    #endregion
  }
}
