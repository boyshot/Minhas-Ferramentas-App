using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFerramentasApp.Model
{
  public interface IBancoDados<T>
  {
    bool SaveRegistro(T item);

    bool AlterarRegistro(T item);

    bool DeleteRegistro(int codigo);

    T GetItem(int codigo);

    List<T> GetTodosRegistros();
  }
}
