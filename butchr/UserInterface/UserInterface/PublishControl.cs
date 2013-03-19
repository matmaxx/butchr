using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Matmaxx.Butchr.Application;
using Matmaxx.Butchr.Application.Publish;

namespace Matmaxx.Butchr.UserInterface
{
  /// <summary>
  /// User control to handle all of the publishing process.
  /// </summary>
  public partial class PublishControl : UserControl
  {
    #region enum
    /// <summary>
    /// Lists all tabs of the InfoTabs control.
    /// </summary>
    private enum InfoTabsOrder
    {
      /// <summary>
      /// The provider specific options tab.
      /// </summary>
      Provider = 0,
      /// <summary>
      /// The common options tab.
      /// </summary>
      Common = 1
    }
    /// <summary>
    /// Lists the indices for the icons of the treeview
    /// </summary>
    public enum TreeIconIndex
    {
      /// <summary>
      /// Icon for the rootnode.
      /// </summary>
      Catalog = 0,
      /// <summary>
      /// Icon for a session.
      /// </summary>
      Session = 1,
      /// <summary>
      /// Icon for an image.
      /// </summary>
      Image = 2,
      /// <summary>
      /// Icon for a selected image.
      /// </summary>
      ImageSelected = 3,
      /// <summary>
      /// Icon for the collection of providers
      /// </summary>
      Providers = 4,
      /// <summary>
      /// Icon for a single provider
      /// </summary>
      Provider = 5
    }
    #endregion

    #region members
    /// <summary>
    /// Instance of the business logic behind this UI.
    /// </summary>
    PublishManager manager;
    /// <summary>
    /// <c>true</c> if the common tab is currently updated by code, <c>false</c> otherwise.
    /// This lock avoids the evaluation of LanguageOptionButton_CheckedChange events.
    /// </summary>
    bool CommonTabIsUpdating;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="PublishControl"/> class.
    /// </summary>
    public PublishControl()
    {
      //designer stuff
      InitializeComponent();
      //init the UI
      Reset();
    }
    /// <summary>
    /// Resets this instance.
    /// </summary>
    public void Reset()
    {
      //Initialize the manager
      manager = new PublishManager();
      //init the session tree
      InitializeTree();
      //init the provider table
      InitializeProviderTable();
      //init the common tab
      InitializeCommonTab();
    }
    /// <summary>
    /// Initializes the session tree.
    /// </summary>
    private void InitializeTree()
    {
      //clear the tree
      PublishTree.Nodes.Clear();
      //add all sessions
      PublishTree.Nodes.Add(manager.SessionsToTreeNode());
      //add all providers
      PublishTree.Nodes.Add(manager.ProvidersToTreeNode());
    }
    /// <summary>
    /// Initializes the provider table.
    /// </summary>
    private void InitializeProviderTable()
    {
      //clear all
      ProviderTable.TableModel.Rows.Clear();
      ProviderTable.ColumnModel.Columns.Clear();
      //add the column for the icon
      ProviderTable.ColumnModel.Columns.Add(new XPTable.Models.ImageColumn(string.Empty,32));
      //add the column for the provider title
      ProviderTable.ColumnModel.Columns.Add(new XPTable.Models.TextColumn(Properties.Resources.ProviderColTitle,200));
      //add the column for the working state
      int workingstateCol = ProviderTable.ColumnModel.Columns.Add(new XPTable.Models.ComboBoxColumn(Properties.Resources.ProviderColWorkingState,100));
      //create an editor for the working state combobox
      XPTable.Editors.ComboBoxCellEditor workingstateEditor = new XPTable.Editors.ComboBoxCellEditor();
      //read the names of the corresponding enum
      string[] workingstateDisplayNames = Enum.GetNames(typeof(Application.Publish.NonLocalizableMetadata.ImageWorkingState));
      //loop all enum entries
      for (int i = 0; i < workingstateDisplayNames.Length; i++)
			{
        //add this enum entry to the editor
        workingstateEditor.Items.Add(workingstateDisplayNames[i]);
			}
      //add the editor to the column
      ProviderTable.ColumnModel.Columns[workingstateCol].Editor = workingstateEditor;
      //add the column for the publish state
      int publishstateCol = ProviderTable.ColumnModel.Columns.Add(new XPTable.Models.ComboBoxColumn(Properties.Resources.ProviderColPublishState,100));
      //create an editor for the column state combobox
      XPTable.Editors.ComboBoxCellEditor publishstateEditor = new XPTable.Editors.ComboBoxCellEditor();
      //read the names of the corresponding enum
      string[] publishstateDisplayNames = Enum.GetNames(typeof(Application.Publish.ProviderMetadata.ImagePublishState));
      //loop all enum entries
      for (int i = 0; i < publishstateDisplayNames.Length; i++)
			{
        //add this enum entry to the editor
        publishstateEditor.Items.Add(publishstateDisplayNames[i]);
			}
      //add the editor to the column
      ProviderTable.ColumnModel.Columns[publishstateCol].Editor = publishstateEditor;
      //add the column for the upload date
      ProviderTable.ColumnModel.Columns.Add(new XPTable.Models.DateTimeColumn(Properties.Resources.ProviderColUploadDate,100));
      //add the column for the approval date
      ProviderTable.ColumnModel.Columns.Add(new XPTable.Models.DateTimeColumn(Properties.Resources.ProviderColApprovalDate,100));
      //set the fonts
      ProviderTable.HeaderFont = new System.Drawing.Font("Verdana",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
      ProviderTable.Font = new System.Drawing.Font("Verdana",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
      //activate tooltips
      ProviderTable.EnableToolTips = true;
    }
    /// <summary>
    /// Initializes the common tab.
    /// </summary>
    private void InitializeCommonTab()
    {
      //reset the update flag
      CommonTabIsUpdating = false;
      //and clear all entries
      ClearCommonTab();
      //reset the language
      rbCommonEnglish.Checked   = true;
      rbCommonGerman.Checked    = false;
    }
    #endregion

    #region event handling
    /// <summary>
    /// Handles the AfterSelect event of the CatalogTree control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
    private void CatalogTree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      //update the infotabs
      UpdateInfoTabsFromSelectedNode(e.Node);
    }
    /// <summary>
    /// Handles the CheckedChanged event of the rbLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void rbLanguage_CheckedChanged(object sender,EventArgs e)
    {
      //make sure this event is not raised by checked-changes from code
      if(CommonTabIsUpdating.Equals(false))
      {
        //check if the selected node is an image
        if((PublishTree.SelectedNode != null) && (manager.IsImageNode(PublishTree.SelectedNode)))
        {
          //it really was the user, so refill the common tab
          FillCommonTabFromImage((string)PublishTree.SelectedNode.Parent.Tag,(string)PublishTree.SelectedNode.Tag);
        }
      }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the InfoTabs control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void InfoTabs_SelectedIndexChanged(object sender,EventArgs e)
    {
      //check if there is a selected node 
      if(PublishTree.SelectedNode != null)
      {
        //update the infotabs
        UpdateInfoTabsFromSelectedNode(PublishTree.SelectedNode);
      }
    }
    #endregion

    #region helper functions
    /// <summary>
    /// Updates the info tabs from selected node.
    /// </summary>
    /// <param name="selectedNode">The selected node.</param>
    private void UpdateInfoTabsFromSelectedNode(TreeNode selectedNode)
    {
      //check if this is an image node
      if(manager.IsImageNode(selectedNode))
      {
        //check if this provider tab is active
        if(InfoTabs.SelectedIndex.Equals((int)InfoTabsOrder.Provider))
        {
          //fill the table
          FillProviderTableFromImage((string)selectedNode.Parent.Tag,(string)selectedNode.Tag);
        }
        //check if the common tab is active
        else if(InfoTabs.SelectedIndex.Equals((int)InfoTabsOrder.Common))
        {
          //fill the common tab's textboxes with the metadata of this image
          FillCommonTabFromImage((string)selectedNode.Parent.Tag,(string)selectedNode.Tag);
        }
        else
        {
          //is there another tab - I did not create it
        }
      }
      //check if this is a provider node
      else if (manager.IsProviderNode(selectedNode))
      {
            
      }
      //check if this is a session node
      else if(manager.IsSessionNode(selectedNode))
      {
        //avoid updates on the table
        ProviderTable.BeginUpdate();
        //let the manager update the table
        ProviderTable.TableModel.Rows.Clear();
        //enable updates on the table
        ProviderTable.EndUpdate();
        //session nodes have nothing to show on the common tab, so clear all entries
        ClearCommonTab();
      }
      else
      {
        //this must be the either the root node or some mysteriously added node we don't know
        //avoid updates on the table
        ProviderTable.BeginUpdate();
        //let the manager update the table
        ProviderTable.TableModel.Rows.Clear();
        //enable updates on the table
        ProviderTable.EndUpdate();
        //session nodes have nothing to show on the common tab, so clear all entries
        ClearCommonTab();
      }
    }
    /// <summary>
    /// Updates the provider table for the given image.
    /// </summary>
    /// <param name="SessionKey">The session key.</param>
    /// <param name="ImageKey">The image key.</param>
    public void FillProviderTableFromImage(string SessionKey, string ImageKey)
    {
      //avoid updates on the table
      ProviderTable.BeginUpdate();
      try
      {
        //clear the contents of the table
        ProviderTable.TableModel.Rows.Clear();
        //try to read the metadata for this image
        ImageMetadata image = manager.GetImageMetadata(SessionKey,ImageKey);

        //get a local ref to the current session
        //Session session = catalogAdapter.Sessions[SessionKey].Model;
        //create a local ref for the image
        
        //loop all providers that are stored for this image
        foreach(string providerKey in image.InvariantData.ProviderData.Keys)
        {
          //get a ref to the providerData
          ProviderMetadata providerData = image.InvariantData.ProviderData[providerKey];
          //add a new row to the table
          int row = ProviderTable.TableModel.Rows.Add(new XPTable.Models.Row());
          //add a the ref to the provider as tag for this row
          ProviderTable.TableModel.Rows[row].Tag = (object)providerData;
          //add the icon of the provider
          int imagecell = ProviderTable.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(string.Empty,System.Drawing.Image.FromFile(manager.Providers[providerData.Identifier].IconPath)));
          //add a cell for the title
          int titlecell = ProviderTable.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(manager.Providers[providerData.Identifier].DisplayName));
          //add a cell for the working state
          int workingstatecell = ProviderTable.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(image.InvariantData.WorkingState.ToString()));
          //add a cell for the publish state
          int publishstatecell = ProviderTable.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(providerData.PublishState.ToString()));
          //add a cell for the upload date
          int uploaddatecell = ProviderTable.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(providerData.UploadDate));
          //check if this provider has an approval process
          if(manager.Providers[providerData.Identifier].HasApprovalProcess)
          {
            //add a cell for the approval date
            int approvaldatecell = ProviderTable.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(providerData.ApprovalDate));
          }
          else
          {
            //add an empty uneditalbe cell for the approval date
            int approvaldatecell = ProviderTable.TableModel.Rows[row].Cells.Add(new XPTable.Models.Cell(string.Empty));
            ProviderTable.TableModel.Rows[row].Cells[approvaldatecell].Editable = false;
            ProviderTable.TableModel.Rows[row].Cells[approvaldatecell].Enabled = false;
          }
        }
      }
      catch(Exception ex)
      {
        //notify about the error in the log window
        Butchr.Log.Error(string.Format("FillProviderTableFromImage failed: {0}", ex.Message));
        //clear the table
        ProviderTable.TableModel.Rows.Clear();
      }
      finally
      {
        //enable updates on the table
        ProviderTable.EndUpdate();
      }
    }
    /// <summary>
    /// Fills the common tab from the metadata of an image.
    /// </summary>
    /// <param name="SessionKey">The session key.</param>
    /// <param name="ImageKey">The image key.</param>
    private void FillCommonTabFromImage(string SessionKey, string ImageKey)
    {
      //avoid CheckedChange events on the radiobuttons
      CommonTabIsUpdating = true;
      try
      {
        //try to read the metadata for this image
        Matmaxx.Butchr.Application.Publish.ImageMetadata imageMetadata = manager.GetImageMetadata(SessionKey,ImageKey);
        //check if german is explicitly selected
        if(rbCommonEnglish.Checked.Equals(false)&&rbCommonGerman.Checked.Equals(true))
        {
          //nail the radiobutton to be sure (in case no or both! are selected)
          rbCommonEnglish.Checked   = false;
          rbCommonGerman.Checked    = true;
          //add the contents to the textboxes
          txtDescription.Text       = imageMetadata.LocalizedData[LocalizableMetadata.Language.German].Description;
          txtTags.Text              = imageMetadata.LocalizedData[LocalizableMetadata.Language.German].TagsToString(",");
          txtTitle.Text             = imageMetadata.LocalizedData[LocalizableMetadata.Language.German].Title;
        }
        else
        //in any other case, display the english parts
        {
          //nail the radiobutton to be sure (in case no or both! are selected)
          rbCommonEnglish.Checked   = true;
          rbCommonGerman.Checked    = false;
          //add the contents to the textboxes
          txtDescription.Text       = imageMetadata.LocalizedData[LocalizableMetadata.Language.English].Description;
          txtTags.Text              = imageMetadata.LocalizedData[LocalizableMetadata.Language.English].TagsToString(",");
          txtTitle.Text             = imageMetadata.LocalizedData[LocalizableMetadata.Language.English].Title;
        }
        //fill the invariant metadata from the image into the textboxes
        txtGeotag.Text            = imageMetadata.InvariantData.Geotag;
        txtPathJpgFull.Text       = imageMetadata.InvariantData.PathJpgFull;
        txtPathJpgNet.Text        = imageMetadata.InvariantData.PathJpgNet;
        txtPathTiff.Text          = imageMetadata.InvariantData.PathTiff;
      }
      catch(Exception ex)
      {
        //notify about the error in the log window
        Butchr.Log.Error(string.Format("FillCommonTabFromImage failed: {0}", ex.Message));
        //and clear the tab
        ClearCommonTab();
      }
      finally
      {
        //reenable CheckedChange events on the radiobuttons again
        CommonTabIsUpdating = false;
      }
    }
    /// <summary>
    /// Clears all entries in the common tab.
    /// </summary>
    private void ClearCommonTab()
    {
      txtDescription.Text       = string.Empty;
      txtGeotag.Text            = string.Empty;
      txtPathJpgFull.Text       = string.Empty;
      txtPathJpgNet.Text        = string.Empty;
      txtPathTiff.Text          = string.Empty;
      txtTags.Text              = string.Empty;
      txtTitle.Text             = string.Empty;
    }
    #endregion
  }
}
