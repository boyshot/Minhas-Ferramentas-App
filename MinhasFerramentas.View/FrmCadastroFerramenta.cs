using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using System;
using System.Windows.Forms;

namespace MinhasFerramentasApp.View
{
  public partial class FrmCadastroFerramenta : Form
  {
    private IFerramentaController ferramentaController = null;
    private bool ehNovoRegistro = true;

    public FrmCadastroFerramenta(IFerramentaController ferramentaController)
    {
      InitializeComponent();
      this.Text = "(Incluir) Cadastro Ferramenta";
      this.ferramentaController = ferramentaController;
    }

    public FrmCadastroFerramenta(IFerramentaController ferramentaController, Ferramenta ferramenta)
    {
      InitializeComponent();

      if(ferramenta == null)
        throw new ArgumentNullException("Favor informar dos Dados da Ferramenta para Atualização");
      this.ferramentaController = ferramentaController;
      this.Text = "(Edita) Cadastro Ferramenta";
      SetDadosFerramentaForm(ferramenta);
      ehNovoRegistro = false;
    }

    private void SetDadosFerramentaForm(Ferramenta ferramenta)
    {
      txtCodigo.Value = ferramenta.Codigo;
      txtDescricao.Text = ferramenta.Descricao;
      txtQuantidade.Text = ferramenta.Quantidade.ToString();
      txtValor.Text = ferramenta.Preco.ToString("N2");
      txtCodigo.Enabled = false;
      txtDescricao.Focus();
    }

    private Ferramenta GetDadosFerramentaForm()
    {
      try
      {
        return ferramentaController.GetNovaFerramenta(Convert.ToInt32(txtCodigo.Value), txtDescricao.Text,
          Convert.ToInt32(txtQuantidade.Text), Convert.ToDecimal(txtValor.Text));
      }
      catch
      {
        throw new Exception($"Cadastro Incorreto! Favor corrigir seu cadastro!");
      }
    }

    private void SalvarRegistro()
    {
      Ferramenta item = GetDadosFerramentaForm();

      try
      {
        if (ehNovoRegistro)
          ferramentaController.SaveRegistro(item);
        else
          ferramentaController.AlterarRegistro(item);

        MessageBox.Show(string.Format("Valor Total: {0:N2}", item.Quantidade * item.Preco),
          "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        throw new Exception($"Erro ao salvar registro! Motivo: {ex.Message}");
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      try
      {
        SalvarRegistro();        
        DialogResult = DialogResult.OK;
        Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
