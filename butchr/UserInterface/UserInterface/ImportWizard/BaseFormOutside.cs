using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  /// <summary>
  /// Base Form for the import wizard's outer forms.
  /// </summary>
  public partial class BaseFormOutside : BaseForm
  {
    #region props

    #region title
    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title
    {
      get { return lblTitle.Text; }
      set { lblTitle.Text = value; }
    }
    #endregion

    #region description
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    public string Description
    {
      get { return lblDescription.Text; }
      set { lblDescription.Text = value; }
    }
    #endregion

    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseFormOutside"/> class.
    /// </summary>
    public BaseFormOutside()
    {
      //designer stuff
      InitializeComponent();
    }
    #endregion

  }
}