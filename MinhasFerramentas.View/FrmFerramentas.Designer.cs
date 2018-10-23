namespace MinhasFerramentasApp.View
{
  partial class FrmFerramentas
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFerramentas));
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnAlterar = new System.Windows.Forms.Button();
      this.btnDeletar = new System.Windows.Forms.Button();
      this.btnIncluir = new System.Windows.Forms.Button();
      this.btnRelatorio = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnConsulta = new System.Windows.Forms.Button();
      this.cbxFiltro = new System.Windows.Forms.ComboBox();
      this.txtConsulta = new System.Windows.Forms.TextBox();
      this.panel3 = new System.Windows.Forms.Panel();
      this.dgvFerramentas = new System.Windows.Forms.DataGridView();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFerramentas)).BeginInit();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.White;
      this.panel2.Controls.Add(this.btnAlterar);
      this.panel2.Controls.Add(this.btnDeletar);
      this.panel2.Controls.Add(this.btnIncluir);
      this.panel2.Controls.Add(this.btnRelatorio);
      resources.ApplyResources(this.panel2, "panel2");
      this.panel2.Name = "panel2";
      // 
      // btnAlterar
      // 
      this.btnAlterar.BackColor = System.Drawing.Color.White;
      this.btnAlterar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      resources.ApplyResources(this.btnAlterar, "btnAlterar");
      this.btnAlterar.Name = "btnAlterar";
      this.btnAlterar.UseVisualStyleBackColor = false;
      this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
      // 
      // btnDeletar
      // 
      this.btnDeletar.BackColor = System.Drawing.Color.White;
      this.btnDeletar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      resources.ApplyResources(this.btnDeletar, "btnDeletar");
      this.btnDeletar.Name = "btnDeletar";
      this.btnDeletar.UseVisualStyleBackColor = false;
      this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
      // 
      // btnIncluir
      // 
      this.btnIncluir.BackColor = System.Drawing.Color.White;
      this.btnIncluir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      resources.ApplyResources(this.btnIncluir, "btnIncluir");
      this.btnIncluir.Name = "btnIncluir";
      this.btnIncluir.UseVisualStyleBackColor = false;
      this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
      // 
      // btnRelatorio
      // 
      this.btnRelatorio.BackColor = System.Drawing.Color.White;
      this.btnRelatorio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      resources.ApplyResources(this.btnRelatorio, "btnRelatorio");
      this.btnRelatorio.Name = "btnRelatorio";
      this.btnRelatorio.UseVisualStyleBackColor = false;
      this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnConsulta);
      this.panel1.Controls.Add(this.cbxFiltro);
      this.panel1.Controls.Add(this.txtConsulta);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // btnConsulta
      // 
      this.btnConsulta.BackColor = System.Drawing.Color.White;
      this.btnConsulta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      resources.ApplyResources(this.btnConsulta, "btnConsulta");
      this.btnConsulta.Name = "btnConsulta";
      this.btnConsulta.UseVisualStyleBackColor = false;
      this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
      // 
      // cbxFiltro
      // 
      this.cbxFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxFiltro.FormattingEnabled = true;
      this.cbxFiltro.Items.AddRange(new object[] {
            resources.GetString("cbxFiltro.Items"),
            resources.GetString("cbxFiltro.Items1"),
            resources.GetString("cbxFiltro.Items2")});
      resources.ApplyResources(this.cbxFiltro, "cbxFiltro");
      this.cbxFiltro.Name = "cbxFiltro";
      // 
      // txtConsulta
      // 
      resources.ApplyResources(this.txtConsulta, "txtConsulta");
      this.txtConsulta.Name = "txtConsulta";
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
      this.panel3.Controls.Add(this.dgvFerramentas);
      resources.ApplyResources(this.panel3, "panel3");
      this.panel3.Name = "panel3";
      // 
      // dgvFerramentas
      // 
      this.dgvFerramentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      resources.ApplyResources(this.dgvFerramentas, "dgvFerramentas");
      this.dgvFerramentas.Name = "dgvFerramentas";
      // 
      // FrmFerramentas
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "FrmFerramentas";
      this.Load += new System.EventHandler(this.FerramentasView_Load);
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvFerramentas)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnAlterar;
    private System.Windows.Forms.Button btnDeletar;
    private System.Windows.Forms.Button btnIncluir;
    private System.Windows.Forms.Button btnRelatorio;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnConsulta;
    private System.Windows.Forms.ComboBox cbxFiltro;
    private System.Windows.Forms.TextBox txtConsulta;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.DataGridView dgvFerramentas;
  }
}