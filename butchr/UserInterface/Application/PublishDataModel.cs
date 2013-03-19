using System;
using System.Collections.Generic;
using System.Text;
using Matmaxx.Toolbox;
using System.IO;

namespace Matmaxx.Butchr.Application.Publish
{
  #region CatalogAdapter
  /// <summary>
  /// Adapter class to handle all issues on the publish datamodel.
  /// </summary>
  public class CatalogAdapter
  {
    #region props
    /// <summary>
    /// The xml manager for the toplevel xml catalog that only contains the paths to the session xml files.
    /// </summary>
    public XmlManager<Catalog> Catalog { get; set; }
    /// <summary>
    /// Dictionary to hold a seperate xml manager for each session.
    /// Indexed by the filesystem path of the session's xml file.
    /// </summary>
    /// <value>The dictionary.</value>
    public Dictionary<string, XmlManager<Session>> Sessions { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="CatalogAdapter"/> class.
    /// </summary>
    public CatalogAdapter()
    {
      //set all props to safe values
      Catalog     = new XmlManager<Catalog>();
      Sessions    = new Dictionary<string, XmlManager<Session>>();
    }
    #endregion

    #region API
    /// <summary>
    /// Reads an existing catalog.
    /// </summary>
    /// <param name="Path">The path.</param>
    public void ReadCatalog(string Path)
    {
      //read the catalog from file
      Catalog.Deserialize(Path);
      //loop all sessions in the catalog
      foreach (string session in Catalog.Model.Sessions)
      {
        //create a temporary xml manager for this session
        XmlManager<Session> tmp = new XmlManager<Session>();
        //read this session from file
        tmp.Deserialize(session);
        //add this session to the session dictionary
        Sessions.Add(session, tmp);
      }
    }
    /// <summary>
    /// Creates a new catalog.
    /// </summary>
    /// <param name="CatalogPath">The catalog path.</param>
    public void CreateCatalog(string CatalogPath)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(CatalogPath));
      Catalog.Serialize(CatalogPath);
      //TODO add the standard provider info here 
    }
    #endregion
  }
  #endregion

  #region Catalog
  /// <summary>
  /// The datamodel to store a the publisher data.
  /// </summary>
  public class Catalog
  {
    #region const
    /// <summary>
    /// An invalid provider identifier for initialization.
    /// </summary>
    public const string InvalidProviderIdentifier = "InvalidProviderIdentifier";
    #endregion

    #region props
    /// <summary>
    /// Gets or sets the providers.
    /// </summary>
    /// <value>The providers.</value>
    public SerializableDictionary<string,PublishProvider> Providers { get; set; }
    /// <summary>
    /// The list of sessions.
    /// </summary>
    /// <value>The list of sessions.</value>
    public List<string> Sessions { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="Catalog"/> class.
    /// </summary>
    public Catalog()
    {
      //set all props to safe values
      Sessions  = new List<string>();
      Providers = new SerializableDictionary<string,PublishProvider>();
    }
    #endregion
  }
  #endregion

  #region Session
  /// <summary>
  /// A session defines a set of images that belong together logically.
  /// </summary>
  public class Session
  {
    #region props
    /// <summary>
    /// Gets or sets the title of the session.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; set; }
    /// <summary>
    /// Gets or sets the dictionary of images in this session.
    /// The images are indexed by the path of their __net.jpg
    /// </summary>
    /// <value>The dictionary of images.</value>
    public SerializableDictionary<string,ImageMetadata> Images { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="Session"/> class.
    /// </summary>
    public Session()
    {
      //set all props to safe values
      this.Title = string.Empty;
      this.Images = new SerializableDictionary<string,ImageMetadata>();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Session"/> class.
    /// </summary>
    /// <param name="Title">The title.</param>
    /// <param name="Images">The images.</param>
    public Session(string Title, SerializableDictionary<string,ImageMetadata> Images)
    {
      //set all props to the given values
      this.Title = Title;
      this.Images = Images;
    }
    #endregion
  }
  #endregion

  #region ImageMetadata
  /// <summary>
  /// This class holds all the metadata that is required for the publish process of the image.
  /// </summary>
  public class ImageMetadata
  {
    #region props
    /// <summary>
    /// Gets or sets the localized data.
    /// </summary>
    /// <value>The localized data.</value>
    public SerializableDictionary<LocalizableMetadata.Language,LocalizableMetadata> LocalizedData { get; set; }
    /// <summary>
    /// Gets or sets the culture invariant data.
    /// </summary>
    /// <value>The culture invariant data.</value>
    public NonLocalizableMetadata InvariantData { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageMetadata"/> class.
    /// </summary>
    public ImageMetadata()
    {
      //set all props to safe values
      LocalizedData = new SerializableDictionary<LocalizableMetadata.Language,LocalizableMetadata>();
      InvariantData = new NonLocalizableMetadata();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageMetadata"/> class.
    /// </summary>
    /// <param name="LocalizedData">The localized data.</param>
    /// <param name="InvariantData">The invariant data.</param>
    public ImageMetadata(SerializableDictionary<LocalizableMetadata.Language,LocalizableMetadata> LocalizedData,NonLocalizableMetadata InvariantData)
    {
      //set all props to the given values
      this.LocalizedData = LocalizedData;
      this.InvariantData = InvariantData;
    }
    #endregion
  }
  #endregion

  #region LocalizableMetadata
  /// <summary>
  /// The logical metadata of an image that is provided in several languages.
  /// </summary>
  public class LocalizableMetadata
  {
    #region enum
    /// <summary>
    /// Lists all supported languages. 
    /// </summary>
    public enum Language
    {
      /// <summary>
      /// English.
      /// </summary>
      English = 0,
      /// <summary>
      /// German.
      /// </summary>
      German = 1
    }    
    #endregion

    #region props
    /// <summary>
    /// Gets or sets the localized title of the image.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; set; }
    /// <summary>
    /// Gets or sets the localized description of the image.
    /// </summary>
    /// <value>The description.</value>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets the localized list of tags for this image.
    /// </summary>
    /// <value>The tags.</value>
    public List<string> Tags { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="LocalizableMetadata"/> class.
    /// </summary>
    public LocalizableMetadata()
    {
      //set all props to safe values
      Title = string.Empty;
      Description = string.Empty;
      Tags = new List<string>();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="LocalizableMetadata"/> class.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="description">The description.</param>
    /// <param name="tags">The tags.</param>
    public LocalizableMetadata(string title, string description, List<string> tags)
    {
      //set all props to the given values
      Title = title;
      Description = description;
      Tags = tags;
    }
    #endregion
    
    #region API
    /// <summary>
    /// Returns the tags of this image as a string seperated by the specified seperator.
    /// </summary>
    /// <param name="seperator">The seperator.</param>
    /// <returns>A string of tags seperated by the specified seperator</returns>
    public string TagsToString(string seperator)
    {
      //local result string
      string result = string.Empty;
      //check if there are any tags at all
      if(Tags.Count.Equals(0).Equals(false))
      {
        //loop all tags
        foreach(string tag in this.Tags)
        {
          //add the next tag
          result = string.Format("{0}{1}{2} ",result,tag,seperator);
        }
        //remove the last seperator
        result = result.Substring(0,result.Length-2);
      }
      //finally return the result
      return result;
    }
    #endregion
  }
  #endregion

  #region NonLocalizableMetadata
  /// <summary>
  /// The logical metadata of an image that is is not language dependend.
  /// </summary>
  public class NonLocalizableMetadata
  {
    #region enum
    /// <summary>
    /// Lists all states that an image can have before it get's published.
    /// </summary>
    public enum ImageWorkingState
    {
      /// <summary>
      /// The image is not processed at all yet.
      /// </summary>
      Pending,
      /// <summary>
      /// The image is not worth processing.
      /// </summary>
      Skipped,
      /// <summary>
      /// The image is currently processed.
      /// </summary>
      Working,
      /// <summary>
      /// The processing on the image is completely done.
      /// </summary>
      Done
    }
    #endregion

    #region props
    /// <summary>
    /// Gets or sets the tiff path.
    /// </summary>
    /// <value>The path tiff.</value>
    public string PathTiff { get; set; }
    /// <summary>
    /// Gets or sets the fullsize JPG path.
    /// </summary>
    /// <value>The path JPG full.</value>
    public string PathJpgFull { get; set; }
    /// <summary>
    /// Gets or sets the netsize JPG path.
    /// </summary>
    /// <value>The path JPG net.</value>
    public string PathJpgNet { get; set; }
    /// <summary>
    /// Gets or sets the geotag.
    /// </summary>
    /// <value>The geotag.</value>
    public string Geotag { get; set; }
    /// <summary>
    /// Gets or sets the working state of the image.
    /// </summary>
    /// <value>The working state of the image.</value>
    public ImageWorkingState WorkingState { get; set; }
    /// <summary>
    /// Gets or sets the provider data.
    /// </summary>
    /// <value>The provider data.</value>
    public SerializableDictionary<string,ProviderMetadata> ProviderData { get; set; }
    #endregion
    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="NonLocalizableMetadata"/> class.
    /// </summary>
    public NonLocalizableMetadata()
    {
      //reset all props to safe values
      this.PathTiff     = string.Empty;
      this.PathJpgFull  = string.Empty;
      this.PathJpgNet   = string.Empty;
      this.Geotag       = string.Empty;
      this.WorkingState = ImageWorkingState.Pending;
      this.ProviderData = new SerializableDictionary<string,ProviderMetadata>();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="NonLocalizableMetadata"/> class.
    /// </summary>
    /// <param name="PathTiff">The path tiff.</param>
    /// <param name="PathJpgFull">The path JPG full.</param>
    /// <param name="PathJpgNet">The path JPG net.</param>
    /// <param name="Geotag">The geotag.</param>
    /// <param name="WorkingState">Working state of the image.</param>
    /// <param name="ProviderData">The provider data.</param>
    public NonLocalizableMetadata(string PathTiff,string PathJpgFull,string PathJpgNet,string Geotag,ImageWorkingState WorkingState,SerializableDictionary<string,ProviderMetadata> ProviderData)
    {
      //set all props to the given values
      this.PathTiff     = PathTiff;
      this.PathJpgFull  = PathJpgFull;
      this.PathJpgNet   = PathJpgNet;
      this.Geotag       = Geotag;
      this.WorkingState = WorkingState;
      this.ProviderData = ProviderData;
    }
    #endregion

  }
  #endregion

  #region ProviderMetadata
  /// <summary>
  /// The locical metadata of an image that is unique for each provider.
  /// </summary>
  public class ProviderMetadata
  {    
    #region enum
    /// <summary>
    /// Lists all states an image can take during the publish process.
    /// </summary>
    public enum ImagePublishState
    {
      /// <summary>
      /// The image is either not finished yet or it is finished but not published at all.
      /// </summary>
      Unpublished,
      /// <summary>
      /// The image is in the approval process of a certain provider.
      /// </summary>
      InApproval,
      /// <summary>
      /// The image is finally published on a certain provider.
      /// </summary>
      Published,
      /// <summary>
      /// The image was declined by the provider.
      /// </summary>
      Declined
    }    
    #endregion

    #region props
    /// <summary>
    /// Gets or sets the provider identifier.
    /// </summary>
    /// <value>The provider identifier.</value>
    public string Identifier { get; set; }
    /// <summary>
    /// Gets or sets the publishstate of an image.
    /// </summary>
    /// <value>The publishstate of an image.</value>
    public ImagePublishState PublishState { get; set; }
    /// <summary>
    /// Gets or sets the upload date.
    /// </summary>
    /// <value>The upload date.</value>
    public DateTime UploadDate { get; set; }
    /// <summary>
    /// Gets or sets the approval date.
    /// </summary>
    /// <value>The approval date.</value>
    public DateTime ApprovalDate { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="ProviderMetadata"/> class.
    /// </summary>
    public ProviderMetadata()
    {
      //set all props to safe values
      this.Identifier   = Catalog.InvalidProviderIdentifier;
      this.PublishState = ImagePublishState.Unpublished;
      this.UploadDate   = DateTime.MinValue;
      this.ApprovalDate = DateTime.MinValue;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ProviderMetadata"/> class.
    /// </summary>
    /// <param name="ProviderIdentifier">The provider identifier.</param>
    /// <param name="PublishState">State of the publish.</param>
    /// <param name="UploadDate">The upload date.</param>
    /// <param name="ApprovalDate">The approval date.</param>
    public ProviderMetadata(string ProviderIdentifier,ImagePublishState PublishState,DateTime UploadDate,DateTime ApprovalDate)
    {
      //set all props to the given values
      this.Identifier   = ProviderIdentifier;
      this.PublishState = PublishState;
      this.UploadDate   = UploadDate;
      this.ApprovalDate = ApprovalDate;
    }
    #endregion  
  }
  #endregion

  #region PublishProvider
  /// <summary>
  /// Class to hold all provider specific data.
  /// </summary>
  public class PublishProvider
  {
    #region props
    /// <summary>
    /// Gets or sets the provider identifier.
    /// </summary>
    /// <value>The provider identifier.</value>
    public string Identifier { get; set; }
    /// <summary>
    /// Gets or sets the display name.
    /// </summary>
    /// <value>The display name.</value>
    public string DisplayName { get; set; }
    /// <summary>
    /// Gets or sets the provider icon's path.
    /// </summary>
    /// <value>The provider icon's path.</value>
    public string IconPath { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this provider has an approval process.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this provider has an approval process; otherwise, <c>false</c>.
    /// </value>
    public bool HasApprovalProcess { get; set; }
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="PublishProvider"/> class.
    /// </summary>
    public PublishProvider()
    {
      //set all props to safe values
      this.Identifier         = Catalog.InvalidProviderIdentifier;
      this.IconPath           = string.Empty;
      this.DisplayName        = string.Empty;
      this.HasApprovalProcess = false;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="PublishProvider"/> class.
    /// </summary>
    /// <param name="Identifier">The identifier.</param>
    /// <param name="DisplayName">The display name.</param>
    /// <param name="IconPath">The icon path.</param>
    /// <param name="HasApprovalProcess">if set to <c>true</c> the provider has an approval process.</param>
    public PublishProvider(string Identifier,string DisplayName,string IconPath,bool HasApprovalProcess)
    {
      //set all props to the given values
      this.Identifier         = Identifier;
      this.DisplayName        = DisplayName;
      this.IconPath           = IconPath;
      this.HasApprovalProcess = HasApprovalProcess;
    }
    #endregion
  }
  #endregion

}
