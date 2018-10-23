using Castle.Windsor;
using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinhasFerramentasApp.View
{
  public partial class FrmFerramentas : Form
  {
    private IFerramentaController ferramentaController;
    private IWindsorContainer container;

    public FrmFerramentas(IWindsorContainer container)
    {
      InitializeComponent();
      this.ferramentaController = container.Resolve<IFerramentaController>();
      this.container = container;
    }

    private void FerramentasView_Load(object sender, EventArgs e)
    {
      CarregarFerramentas();
    }

    private void btnIncluir_Click(object sender, EventArgs e)
    {
      try
      {
        FrmCadastroFerramenta frmFerramenta = new FrmCadastroFerramenta(ferramentaController);
        if (frmFerramenta.ShowDialog() == DialogResult.OK)
          CarregarFerramentas();
      }
      catch (Exception ex)
      {
        ExibirErro("Erro ao incluir registro. Motivo: {0}", ex);
      }
    }

    private void btnAlterar_Click(object sender, EventArgs e)
    {
      try
      {
        Ferramenta ferramenta = GetRegistroSelecionado();

        if (ferramenta != null)
        {
          FrmCadastroFerramenta frmFerramenta = new FrmCadastroFerramenta(ferramentaController, ferramenta);

          if (frmFerramenta.ShowDialog() == DialogResult.OK)
            CarregarFerramentas();
        }
        else
          MessageBox.Show("Registro não encontrado na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      catch (Exception ex)
      {
        ExibirErro("Erro ao alterar o registro. Motivo: {0}", ex);
      }
    }

    private void btnDeletar_Click(object sender, EventArgs e)
    {
      try
      {
        int linhaSelecionada = dgvFerramentas?.CurrentRow?.Index ?? -1;

        if (linhaSelecionada != -1)
        {
          int codigoRegistro = Convert.ToInt32(dgvFerramentas[0, linhaSelecionada].Value);

          if (ferramentaController.DeleteRegistro(codigoRegistro))
            CarregarFerramentas();
        }
        else
          MessageBox.Show("Favor selecionar o registro valido na lista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      catch (Exception ex)
      {
        ExibirErro("Erro ao deletar o reistro. Motivo: {0}", ex);
      }
    }

    private void CarregarFerramentas()
    {
      dgvFerramentas.DataSource = null;
      dgvFerramentas.DataSource = ferramentaController.GetTodosRegistros();
      dgvFerramentas.Refresh();
    }

    private void ExibirErro(string msg, Exception ex)
    {
      MessageBox.Show(string.Format(msg, ex.Message), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public Ferramenta GetRegistroSelecionado()
    {
      Ferramenta ferramenta = null;

      try
      {  
        int linhaSelecionada = dgvFerramentas?.CurrentRow?.Index ?? -1;

        if (linhaSelecionada != -1)    
          ferramenta = ferramentaController.
                         GetNovaFerramenta(Convert.ToInt32(dgvFerramentas[0, linhaSelecionada].Value),
                                           Convert.ToString(dgvFerramentas[1, linhaSelecionada].Value),
                                           Convert.ToInt32(dgvFerramentas[2, linhaSelecionada].Value),
                                           Convert.ToDecimal(dgvFerramentas[3, linhaSelecionada].Value));
        

        return ferramenta;
      }
      catch (Exception ex)
      {
        ExibirErro("Cadastro Incorreto! Favor corrigir seu cadastro! Motivo: {0}", ex);
      }

      return null;
    }

    private void btnRelatorio_Click(object sender, EventArgs e)
    {
      FrmRelatorio frRelatorio = new FrmRelatorio(container);
      frRelatorio.ShowDialog();
    }

    private void btnConsulta_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(cbxFiltro.Text))
      {
        string consulta = txtConsulta.Text.Trim();

        //Consulta Diferente de vazio
        List<Ferramenta> listaConsulta = null;
        try
        {
          if ("Código".Equals(cbxFiltro.Text.Trim()))
            listaConsulta = ferramentaController.GetTodosRegistros(Convert.ToInt32(consulta));
          else
            listaConsulta = ferramentaController.GetTodosRegistros(consulta);
        }
        catch (Exception ex)
        {
          ExibirErro("Erro ao realizar a consulta verifique o parâmetro! Motivo: {0}", ex);
        }


        if (listaConsulta != null && listaConsulta.Count > 0)
        {
          dgvFerramentas.DataSource = null;
          dgvFerramentas.DataSource = listaConsulta;
          dgvFerramentas.Refresh();
        }
        else
        {
          MessageBox.Show("Não foi encontrado registro! será carregado todos os registros", "Erro",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          CarregarFerramentas();
        }
      }
    }
  }
}
