using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFerramentasApp.Model.Interface
{
  public interface IFerramentaController
  {
    bool DeleteRegistro(int codigo);

    Ferramenta GetItem(int codigo);

    List<Ferramenta> GetTodosRegistros();

    List<Ferramenta> GetTodosRegistros(int codigo);

    List<Ferramenta> GetTodosRegistros(string descricao);

    bool SaveRegistro(Ferramenta item);

    bool AlterarRegistro(Ferramenta item);

    Ferramenta GetNovaFerramenta(int codigo, string descricao, int quantidade, decimal preco);
  }
}
