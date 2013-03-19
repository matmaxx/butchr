using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matmaxx.Butchr.Application.Publish;
using System.IO;

namespace ButchrTests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class PublishDataModelTests
  {
    Matmaxx.Toolbox.XmlManager<Matmaxx.Butchr.Application.Publish.Catalog> xml;
    public PublishDataModelTests()
    {
      xml = new Matmaxx.Toolbox.XmlManager<Matmaxx.Butchr.Application.Publish.Catalog>();
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [TestMethod]
    public void TestDataModel()
    {
      //create tags
      List<string> tags_de = new List<string>();
      tags_de.Add("tag1_de");
      tags_de.Add("tag2_de");
      tags_de.Add("tag3_de");
      List<string> tags_en = new List<string>();
      tags_en.Add("tag1_en");
      tags_en.Add("tag2_en");
      tags_en.Add("tag3_en");
      //create localizable metadata
      Matmaxx.Toolbox.SerializableDictionary<LocalizableMetadata.Language,LocalizableMetadata> localizableMetadata = new Matmaxx.Toolbox.SerializableDictionary<LocalizableMetadata.Language,LocalizableMetadata>();
      localizableMetadata.Add(LocalizableMetadata.Language.English,new LocalizableMetadata("title_en", "description_en", tags_en));
      localizableMetadata.Add(LocalizableMetadata.Language.German,new LocalizableMetadata("title_de", "description_de", tags_de));
      //create providerdata
      ProviderMetadata providerMetadataFlickr = new ProviderMetadata("flickr",ProviderMetadata.ImagePublishState.Unpublished,DateTime.Now,DateTime.Now);
      ProviderMetadata providerMetadataFotocommunity = new ProviderMetadata("fotocommunity",ProviderMetadata.ImagePublishState.Unpublished,DateTime.Now,DateTime.Now);
      ProviderMetadata providerMetadataWhitewall = new ProviderMetadata("whitewall",ProviderMetadata.ImagePublishState.Unpublished,DateTime.Now,DateTime.Now);
      //create providerdata dictionary
      Matmaxx.Toolbox.SerializableDictionary<string,ProviderMetadata> providerMetadataDictionary = new Matmaxx.Toolbox.SerializableDictionary<string,ProviderMetadata>();
      providerMetadataDictionary.Add("flickr",providerMetadataFlickr);
      providerMetadataDictionary.Add("fotocommunity",providerMetadataFotocommunity);
      providerMetadataDictionary.Add("whitewall",providerMetadataWhitewall);
      //create the xml catalog
      Matmaxx.Toolbox.XmlManager<Catalog> catalogXml = new Matmaxx.Toolbox.XmlManager<Catalog>(Path.Combine(Path.Combine(System.Windows.Forms.Application.UserAppDataPath,"publish"),"Catalog.xml"));
      //loop all desired sessions
      for (int i = 0; i < 2; i++)
      {
        //create the dictionary for the images
        Matmaxx.Toolbox.SerializableDictionary<string,ImageMetadata> imageDictionary = new Matmaxx.Toolbox.SerializableDictionary<string,ImageMetadata>(); 
        //loop all desired images
        for(int j = 0;j < 2;j++)
        {
          //create invariant data
          NonLocalizableMetadata nonlocalizableMetadata = new NonLocalizableMetadata("pathtiff_"+i+"_"+j+".tiff", "pathjpgfull_"+i+"_"+j+".jpg", "pathjpgnet_"+i+"_"+j+".jpg", "geotag_"+i+"_"+j,NonLocalizableMetadata.ImageWorkingState.Pending,providerMetadataDictionary);
          //create and add the image
          imageDictionary.Add(nonlocalizableMetadata.PathJpgNet,new ImageMetadata(localizableMetadata, nonlocalizableMetadata));
        }
        //create a name for the session
        string sessionIdentifier = "Session_"+i;
        //create the path for this session
        string sessionPath = Path.Combine(Path.Combine(System.Windows.Forms.Application.UserAppDataPath,"publish"),sessionIdentifier+".xml");
        //create the session xml manager
        Matmaxx.Toolbox.XmlManager<Session> sessionXml = new Matmaxx.Toolbox.XmlManager<Session>(sessionPath);
        //fill its model
        sessionXml.Model.Title = sessionIdentifier;
        sessionXml.Model.Images = imageDictionary;
        try 
	      {	        
          //try to serialize the session
          sessionXml.Serialize();
	      }
	      catch (Exception ex)
	      {
          //exceptions fail the test
          Assert.Fail(ex.Message);
	      }        
        //add the session to the catalog
        catalogXml.Model.Sessions.Add(sessionPath);
      }
      //create the providers
      catalogXml.Model.Providers.Add("flickr",new PublishProvider("flickr","Flickr",@"C:\Users\virwl\AppData\Roaming\Microsoft Corporation\Microsoft (R) Visual Studio (R) 2008\9.0.30729.1\publish\icons\flickr.png",false));
      catalogXml.Model.Providers.Add("fotocommunity",new PublishProvider("fotocommunity","Fotocommunity",@"C:\Users\virwl\AppData\Roaming\Microsoft Corporation\Microsoft (R) Visual Studio (R) 2008\9.0.30729.1\publish\icons\fotocommunity.ico",false));
      catalogXml.Model.Providers.Add("whitewall",new PublishProvider("whitewall","Whitewall",@"C:\Users\virwl\AppData\Roaming\Microsoft Corporation\Microsoft (R) Visual Studio (R) 2008\9.0.30729.1\publish\icons\whitewall.jpg",true));
      try
      {
        //try to serialize the catalog
        catalogXml.Serialize();
      }
      catch (Exception ex)
      {
        //exceptions fail the test
        Assert.Fail(ex.Message);
      }
    }
  }
}
