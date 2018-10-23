namespace MinhasFerramentasApp.View
{
  partial class FrmCadastroFerramenta
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroFerramenta));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtDescricao = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancelar = new System.Windows.Forms.Button();
      this.txtValor = new System.Windows.Forms.TextBox();
      this.txtQuantidade = new System.Windows.Forms.TextBox();
      this.txtCodigo = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // txtDescricao
      // 
      resources.ApplyResources(this.txtDescricao, "txtDescricao");
      this.txtDescricao.Name = "txtDescricao";
      // 
      // label3
      // 
      resources.ApplyResources(this.label3, "label3");
      this.label3.Name = "label3";
      // 
      // label4
      // 
      resources.ApplyResources(this.label4, "label4");
      this.label4.Name = "label4";
      // 
      // btnOK
      // 
      resources.ApplyResources(this.btnOK, "btnOK");
      this.btnOK.Name = "btnOK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancelar
      // 
      resources.ApplyResources(this.btnCancelar, "btnCancelar");
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.UseVisualStyleBackColor = true;
      this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
      // 
      // txtValor
      // 
      resources.ApplyResources(this.txtValor, "txtValor");
      this.txtValor.Name = "txtValor";
      // 
      // txtQuantidade
      // 
      resources.ApplyResources(this.txtQuantidade, "txtQuantidade");
      this.txtQuantidade.Name = "txtQuantidade";
      // 
      // txtCodigo
      // 
      resources.ApplyResources(this.txtCodigo, "txtCodigo");
      this.txtCodigo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      this.txtCodigo.Name = "txtCodigo";
      this.txtCodigo.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      // 
      // FrmCadastroFerramenta
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtCodigo);
      this.Controls.Add(this.txtQuantidade);
      this.Controls.Add(this.txtValor);
      this.Controls.Add(this.btnCancelar);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtDescricao);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmCadastroFerramenta";
      this.ShowIcon = false;
      ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtDescricao;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.TextBox txtValor;
    private System.Windows.Forms.TextBox txtQuantidade;
    private System.Windows.Forms.NumericUpDown txtCodigo;
  }
}