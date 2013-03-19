namespace Matmaxx.Butcher.UserInterface.ImportWizard
{
  partial class StepFileOperationForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.gbImport = new System.Windows.Forms.GroupBox();
      this.optImportMove = new System.Windows.Forms.RadioButton();
      this.optImportCopy = new System.Windows.Forms.RadioButton();
      this.gbDistribute = new System.Windows.Forms.GroupBox();
      this.optDistributeMove = new System.Windows.Forms.RadioButton();
      this.optDistributeCopy = new System.Windows.Forms.RadioButton();
      this.gbImport.SuspendLayout();
      this.gbDistribute.SuspendLayout();
      this.SuspendLayout();
      // 
      // gbImport
      // 
      this.gbImport.Controls.Add(this.optImportMove);
      this.gbImport.Controls.Add(this.optImportCopy);
      this.gbImport.Location = new System.Drawing.Point(89, 147);
      this.gbImport.Name = "gbImport";
      this.gbImport.Size = new System.Drawing.Size(446, 74);
      this.gbImport.TabIndex = 9;
      this.gbImport.TabStop = false;
      this.gbImport.Text = "gbImport.Text";
      // 
      // optImportMove
      // 
      this.optImportMove.AutoSize = true;
      this.optImportMove.Location = new System.Drawing.Point(6, 42);
      this.optImportMove.Name = "optImportMove";
      this.optImportMove.Size = new System.Drawing.Size(120, 17);
      this.optImportMove.TabIndex = 0;
      this.optImportMove.TabStop = true;
      this.optImportMove.Text = "optImportMove.Text";
      this.optImportMove.UseVisualStyleBackColor = true;
      this.optImportMove.CheckedChanged += new System.EventHandler(this.OptionButtons_CheckedChanged);
      // 
      // optImportCopy
      // 
      this.optImportCopy.AutoSize = true;
      this.optImportCopy.Location = new System.Drawing.Point(6, 19);
      this.optImportCopy.Name = "optImportCopy";
      this.optImportCopy.Size = new System.Drawing.Size(117, 17);
      this.optImportCopy.TabIndex = 0;
      this.optImportCopy.TabStop = true;
      this.optImportCopy.Text = "optImportCopy.Text";
      this.optImportCopy.UseVisualStyleBackColor = true;
      this.optImportCopy.CheckedChanged += new System.EventHandler(this.OptionButtons_CheckedChanged);
      // 
      // gbDistribute
      // 
      this.gbDistribute.Controls.Add(this.optDistributeMove);
      this.gbDistribute.Controls.Add(this.optDistributeCopy);
      this.gbDistribute.Location = new System.Drawing.Point(89, 227);
      this.gbDistribute.Name = "gbDistribute";
      this.gbDistribute.Size = new System.Drawing.Size(446, 76);
      this.gbDistribute.TabIndex = 9;
      this.gbDistribute.TabStop = false;
      this.gbDistribute.Text = "gbDistribute.Text";
      // 
      // optDistributeMove
      // 
      this.optDistributeMove.AutoSize = true;
      this.optDistributeMove.Location = new System.Drawing.Point(6, 42);
      this.optDistributeMove.Name = "optDistributeMove";
      this.optDistributeMove.Size = new System.Drawing.Size(135, 17);
      this.optDistributeMove.TabIndex = 0;
      this.optDistributeMove.TabStop = true;
      this.optDistributeMove.Text = "optDistributeMove.Text";
      this.optDistributeMove.UseVisualStyleBackColor = true;
      this.optDistributeMove.CheckedChanged += new System.EventHandler(this.OptionButtons_CheckedChanged);
      // 
      // optDistributeCopy
      // 
      this.optDistributeCopy.AutoSize = true;
      this.optDistributeCopy.Location = new System.Drawing.Point(6, 19);
      this.optDistributeCopy.Name = "optDistributeCopy";
      this.optDistributeCopy.Size = new System.Drawing.Size(132, 17);
      this.optDistributeCopy.TabIndex = 0;
      this.optDistributeCopy.TabStop = true;
      this.optDistributeCopy.Text = "optDistributeCopy.Text";
      this.optDistributeCopy.UseVisualStyleBackColor = true;
      this.optDistributeCopy.CheckedChanged += new System.EventHandler(this.OptionButtons_CheckedChanged);
      // 
      // StepFileOperationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(644, 486);
      this.Controls.Add(this.gbDistribute);
      this.Controls.Add(this.gbImport);
      this.Name = "StepFileOperationForm";
      this.Text = "StepFileOperationForm";
      this.Load += new System.EventHandler(this.StepFileOperationForm_Load);
      this.Controls.SetChildIndex(this.gbImport, 0);
      this.Controls.SetChildIndex(this.gbDistribute, 0);
      this.gbImport.ResumeLayout(false);
      this.gbImport.PerformLayout();
      this.gbDistribute.ResumeLayout(false);
      this.gbDistribute.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox gbImport;
    private System.Windows.Forms.RadioButton optImportMove;
    private System.Windows.Forms.RadioButton optImportCopy;
    private System.Windows.Forms.GroupBox gbDistribute;
    private System.Windows.Forms.RadioButton optDistributeMove;
    private System.Windows.Forms.RadioButton optDistributeCopy;
  }
}