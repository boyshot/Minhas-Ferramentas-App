namespace MinhasFerramentasApp.View
{
  partial class FrmRelatorio
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorio));
      this.txtRelatorio = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtRelatorio
      // 
      resources.ApplyResources(this.txtRelatorio, "txtRelatorio");
      this.txtRelatorio.Name = "txtRelatorio";
      // 
      // frmRelatorio
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtRelatorio);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmRelatorio";
      this.ShowIcon = false;
      this.Load += new System.EventHandler(this.frmRelatorio_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtRelatorio;
  }
}