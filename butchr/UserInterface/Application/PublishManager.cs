using System;
using System.Collections.Generic;
using System.Text;
using Matmaxx.Butchr.Application.Publish;
using Matmaxx.Butchr.Properties;
using System.IO;
using System.Windows.Forms;
using Matmaxx.Butchr.UserInterface;

namespace Matmaxx.Butchr.Application
{
  /// <summary>
  /// the business logic behind the PublishControl.
  /// </summary>
  public class PublishManager
  {
    #region const
    /// <summary>
    /// The root node tag for sessions
    /// </summary>
    const string SessionRootNodeTag = "matmaxx worlddomination on sessions";
    /// <summary>
    /// The root node tag for providers
    /// </summary>
    const string ProviderRootNodeTag = "matmaxx worlddomination on providers";
    #endregion

    #region props
    /// <summary>
    /// Gets the providers.
    /// </summary>
    /// <value>The providers.</value>
    public Dictionary<string,PublishProvider> Providers 
    { 
      //return the providers from the catalog adapter
      get {return catalogAdapter.Catalog.Model.Providers;}
    }
    #endregion

    #region members
    /// <summary>
    /// The adapter to work on the data.
    /// </summary>
    private CatalogAdapter catalogAdapter;
    /// <summary>
    /// The path of the session catalog.
    /// </summary>
    private string catalogPath;
    #endregion
    
    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="PublishManager"/> class.
    /// </summary>
    public PublishManager()
    {
      //initialize the dataadapter
      catalogAdapter = new CatalogAdapter();
      //build the path
      catalogPath = string.Format(Settings.Default.PublishSessionCatalogPath, Butchr.DataPath);
      //check if the file exists
      if(File.Exists(catalogPath).Equals(false))
      {
        //create a new catalog of sessions
        catalogAdapter.CreateCatalog(catalogPath);
      }
      else
      {
        //read the existing catalog of sessions
        catalogAdapter.ReadCatalog(catalogPath);
      }
    }
    #endregion

    #region API
    /// <summary>
    /// Reads all sessions and their content to a treenode that the GUI can paste 1:1 to the treeview.
    /// </summary>
    /// <returns>The rootnode for the session treeview part.</returns>
    public TreeNode SessionsToTreeNode()
    {
      //local rootnode to work off from
      TreeNode root = new TreeNode();
      //easter the egg
      root.Tag = SessionRootNodeTag;
      //set a useful text for the rootnode
      root.Text = "Catalog";
      //set the icon for this node
      root.ImageIndex = (int)PublishControl.TreeIconIndex.Catalog;
      root.SelectedImageIndex = (int)PublishControl.TreeIconIndex.Catalog;
      //loop all sessions
      foreach(string sessionKey in catalogAdapter.Sessions.Keys)
      {
        //create a temporary node
        TreeNode tmpSessionNode = new TreeNode();
        //get a ref to the session
        Session session = catalogAdapter.Sessions[sessionKey].Model;
        //backup the key as tag of the node
        tmpSessionNode.Tag = sessionKey;
        //set the name of the session as text of the Node
        tmpSessionNode.Text = session.Title;
        //set the icon for this node
        tmpSessionNode.ImageIndex = (int)PublishControl.TreeIconIndex.Session;
        tmpSessionNode.SelectedImageIndex = (int)PublishControl.TreeIconIndex.Session;
        //now loop all images of this session
        foreach(string imageKey in session.Images.Keys)
        {
          ImageMetadata image = session.Images[imageKey];
          //create a temporary node
          TreeNode tmpImageNode = new TreeNode();
          //backup the net path as tag
          tmpImageNode.Tag = image.InvariantData.PathJpgNet;
          //set the icon for this node
          tmpImageNode.ImageIndex = (int)PublishControl.TreeIconIndex.Image;
          tmpImageNode.SelectedImageIndex = (int)PublishControl.TreeIconIndex.ImageSelected;
          //check if the file has an english name
          if(image.LocalizedData[LocalizableMetadata.Language.English].Title.Equals(string.Empty).Equals(false))
          {
            //display the english name
            tmpImageNode.Text = image.LocalizedData[LocalizableMetadata.Language.English].Title;
          }
          //check if the file has a german name
          else if(image.LocalizedData[LocalizableMetadata.Language.German].Title.Equals(string.Empty).Equals(false))
          {
            //display the german name
          tmpImageNode.Text = image.LocalizedData[LocalizableMetadata.Language.German].Title;
          }
          else
          {
            //display the pure filename as text of the node 
            tmpImageNode.Text = Path.GetFileNameWithoutExtension(image.InvariantData.PathJpgNet);
          }
          //add this node to the sessionnode
          tmpSessionNode.Nodes.Add(tmpImageNode);
        }
        //add the sessionnode to the rootnode
        root.Nodes.Add(tmpSessionNode);
      }
      //finally return the rootnode (and of course the complete tree below)
      return root;
    }
    /// <summary>
    /// Reads all providers and their content to a treenode that the GUI can paste 1:1 to the treeview.
    /// </summary>
    /// <returns>The rootnode for the provider treeview part.</returns>
    public TreeNode ProvidersToTreeNode()
    {
      //local rootnode to work off from
      TreeNode root = new TreeNode();
      //easter the egg
      root.Tag = ProviderRootNodeTag;
      //set a useful text for the rootnode
      root.Text = "Providers";
      //set the icon for this node
      root.ImageIndex = (int)PublishControl.TreeIconIndex.Providers;
      root.SelectedImageIndex = (int)PublishControl.TreeIconIndex.Providers;
      //loop all providers
      foreach(string providerKey in catalogAdapter.Catalog.Model.Providers.Keys)
      {
        //create a temporary node
        TreeNode tmpProviderNode = new TreeNode();
        //get a ref to the provider
        PublishProvider provider = catalogAdapter.Catalog.Model.Providers[providerKey];
        //backup the key as tag of the node
        tmpProviderNode.Tag = providerKey;
        //set the name of the provider as text of the Node
        tmpProviderNode.Text = provider.DisplayName;
        //set the icon for this node
        tmpProviderNode.ImageIndex = (int)PublishControl.TreeIconIndex.Provider;
        tmpProviderNode.SelectedImageIndex = (int)PublishControl.TreeIconIndex.Provider;
        //add the providernode to the rootnode
        root.Nodes.Add(tmpProviderNode);
      }
      //finally return the rootnode (and of course the complete tree below)
      return root;
    }

    /// <summary>
    /// Determines whether the given node is a session node.
    /// </summary>
    /// <param name="Node">The node.</param>
    /// <returns>
    /// 	<c>true</c> if the specified node is a session node; otherwise, <c>false</c>.
    /// </returns>
    public bool IsSessionNode(TreeNode Node)
    {
      //check if the tag is the path to an xml file
      return ((string)Node.Tag).EndsWith(".xml").Equals(true);
    }
    /// <summary>
    /// Determines whether the given node is an image node.
    /// </summary>
    /// <param name="Node">The node.</param>
    /// <returns>
    /// 	<c>true</c> if the specified node is an image node; otherwise, <c>false</c>.
    /// </returns>
    public bool IsImageNode(TreeNode Node)
    {
      //check if the tag is the path to an jpg file
      return (((string)Node.Tag).ToLower().EndsWith(".jpg").Equals(true));
    }
    /// <summary>
    /// Determines whether the given node is an provider (not providers) node.
    /// </summary>
    /// <param name="Node">The node.</param>
    /// <returns>
    /// 	<c>true</c> if the specified node is a provider node; otherwise, <c>false</c>.
    /// </returns>
    public bool IsProviderNode(TreeNode Node)
    {
      //check if the tag is a provider identifier
      return (((string)Node.Tag).ToLower().EndsWith(".provider").Equals(true));
    }
    /// <summary>
    /// Gets the metadata for an image.
    /// </summary>
    /// <param name="SessionKey">The session key.</param>
    /// <param name="ImageKey">The image key.</param>
    /// <returns>The metadata of the requested image.</returns>
    public ImageMetadata GetImageMetadata(string SessionKey, string ImageKey)
    {
      //get a local ref to the current session
      Session session = catalogAdapter.Sessions[SessionKey].Model;
      //create a local ref for the image
      ImageMetadata image = session.Images[ImageKey];
      //finally return the metadata for this image
      return image;
    }
    #endregion
  }
}
