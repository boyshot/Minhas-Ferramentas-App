using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhasFerramentasApp.Service
{
  public class RelatorioFerramentasService : IRelatorioService
  {
    private IFerramentaController ferramentaController = null;

    public RelatorioFerramentasService(IFerramentaController ferramentaController)
    {
      this.ferramentaController = ferramentaController;
    }

    public StringBuilder GerarRelatorio()
    {
      List<Ferramenta> list = ferramentaController.GetTodosRegistros();

      StringBuilder sbRelatorio = new StringBuilder();

      sbRelatorio.AppendLine(GetCabecalho());
      sbRelatorio.AppendLine(string.Empty);
      sbRelatorio.AppendLine(string.Empty);

      list.ForEach(item => sbRelatorio.AppendLine(GetLinha(item)));

      sbRelatorio.AppendLine(string.Empty);
      sbRelatorio.AppendLine(string.Empty);
      sbRelatorio.AppendLine(string.Format("Total do Estoque de Ferrametas: R$ {0:N2}", GetTotalFerramentas(list)));

      sbRelatorio.AppendLine(GetRodape());

      return sbRelatorio;
    }

    private string GetCabecalho() =>
      "======================\nRelatório Estoque de Ferramentas\n======================";

    private string GetRodape() => "============================================ ";

    private string GetLinha(Ferramenta ferramenta)
    {
      string strLinha = string.Format("Código: [{0}] Descricao: [{1}] Quantidade: [{2}]  Preço: [R$ {3:N2}] Total: [R$ {4:N2}]",
                                      ferramenta.Codigo,
                                      ferramenta.Descricao,
                                      ferramenta.Quantidade,
                                      ferramenta.Preco, GetTotalPrecoItem(ferramenta));

      return strLinha;
    }

    private decimal GetTotalPrecoItem(Ferramenta ferramenta)
    {
      return ferramenta.Quantidade * ferramenta.Preco;
    }

    private decimal GetTotalFerramentas(List<Ferramenta> list) => list.Sum(item => GetTotalPrecoItem(item));
  }
}
