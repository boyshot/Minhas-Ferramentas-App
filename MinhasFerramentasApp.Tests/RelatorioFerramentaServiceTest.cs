using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinhasFerramentasApp.Controller;
using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using MinhasFerramentasApp.Service;

namespace MinhasFerramentasApp.Tests
{
  [TestClass]
  public class RelatorioFerramentaServiceTest : TesteUnitarioFerramentaBase
  {
    [TestMethod]
    public void Relatorio_Gerar_Relatorio()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 1 });
      list.Add(new Ferramenta { Codigo = 2, Descricao = "Ferramenta 2", Preco = 2, Quantidade = 2 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      IFerramentaController ferramenta = StubControllerFerramenta(list);

      IRelatorioService relatorioFerramenta = new RelatorioFerramentasService(ferramenta);

      StringBuilder relatorio = relatorioFerramenta.GerarRelatorio();

      Assert.AreEqual(true, relatorio.ToString().Contains("Ferramenta 1"));
    }
  }
}
