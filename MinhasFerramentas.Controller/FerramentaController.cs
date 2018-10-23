using MinhasFerramentasApp.BancoDados;
using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFerramentasApp.Controller
{
  public class FerramentaController : IFerramentaController
  {
    private readonly IBancoDados<Ferramenta> bancoDados;

    public FerramentaController(IBancoDados<Ferramenta> bancoDados)
    {
      this.bancoDados = bancoDados;
    }

    public bool DeleteRegistro(int codigo)
    {
      return bancoDados.DeleteRegistro(codigo);
    }

    public Ferramenta GetItem(int codigo)
    {
      return bancoDados.GetItem(codigo);
    }

    public List<Ferramenta> GetTodosRegistros()
    {
      return bancoDados.GetTodosRegistros();
    }

    public List<Ferramenta> GetTodosRegistros(int codigo)
    {
      return bancoDados.GetTodosRegistros().Where(item => item.Codigo.Equals(codigo)).ToList();
    }

    public List<Ferramenta> GetTodosRegistros(string descricao)
    {
      return bancoDados.GetTodosRegistros().Where(item => item.Descricao.ToLower().Contains(descricao.ToLower())).ToList();
    }

    public bool SaveRegistro(Ferramenta item)
    {
      ValidarRegistro(item);
      return bancoDados.SaveRegistro(item);
    }

    public bool AlterarRegistro(Ferramenta item)
    {
      ValidarRegistro(item);
      return bancoDados.AlterarRegistro(item);
    }

    protected void ValidarRegistro(Ferramenta item)
    {
      if (item.Codigo <= 0)
        throw new Exception("O código deve ser um número inteiro maior que zero e não existente!");

      if (item.Quantidade <= 0)
        throw new Exception("Quantidade de Ferramenta Inválida. valor precisa ser maior que zero");

      if (item.Preco <= 0)
        throw new Exception("Preço da Ferramenta Inválido. O valor precisa ser maior que zero");
    }

    public Ferramenta GetNovaFerramenta(int codigo, string descricao, int quantidade, decimal preco)
    {
      Ferramenta novaFerramenta = new Ferramenta();
      novaFerramenta.Codigo = codigo;
      novaFerramenta.Descricao = descricao;
      novaFerramenta.Quantidade = quantidade;
      novaFerramenta.Preco = preco;

      return novaFerramenta;
    }
  }
}
