using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinhasFerramentasApp.Controller;
using MinhasFerramentasApp.Model;

namespace MinhasFerramentasApp.Tests
{
  [TestClass]
  public class FerramentasControllerTest : TesteUnitarioFerramentaBase
  {
    [TestMethod]
    public void Delete_Registro_Controller()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 1 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      bool deletouRegistro = controller.DeleteRegistro(list[0].Codigo);

      Assert.AreEqual(true, deletouRegistro);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "O código deve ser um número inteiro maior que zero e não existente!")]
    public void Alterar_Registro_Controller_CodigoZerado()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 0, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 01 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      bool alterou = controller.AlterarRegistro(list[0]);

      Assert.AreEqual(true, alterou);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Quantidade de Ferramenta Inválida. valor precisa ser maior que zero")]
    public void Alterar_Registro_Controller_Qtde_Zerado()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 0 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

     controller.AlterarRegistro(list[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Preço da Ferramenta Inválido. O valor precisa ser maior que zero")]
    public void Alterar_Registro_Controller_Preco_Zerado()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 0, Quantidade = 1 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      controller.AlterarRegistro(list[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "O código deve ser um número inteiro maior que zero e não existente!")]
    public void Salvar_Registro_Controller_CodigoZerado()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 0, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 01 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      bool save = controller.SaveRegistro(list[0]);

      Assert.AreEqual(true, save);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Quantidade de Ferramenta Inválida. valor precisa ser maior que zero")]
    public void Salvar_Registro_Controller_Qtde_Zerado()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 0 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      controller.SaveRegistro(list[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Preço da Ferramenta Inválido. O valor precisa ser maior que zero")]
    public void Salvar_Registro_Controller_Preco_Zerado()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 0, Quantidade = 1 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      controller.SaveRegistro(list[0]);
    }

    [TestMethod]   
    public void GetItem_Registro_Controller()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 1 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      Ferramenta fer = controller.GetItem(1);

      Assert.AreEqual(1, fer.Codigo);
    }

    [TestMethod]
    public void GetTodosRegistros_Controller()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 1 });
      list.Add(new Ferramenta { Codigo = 2, Descricao = "Ferramenta 2", Preco = 2, Quantidade = 2 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      List<Ferramenta> listCarregada = controller.GetTodosRegistros();

      Assert.AreEqual(listCarregada.Count, 2);
    }

    [TestMethod]
    public void GetTodosRegistros_Controller_FiltroCodigo()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 1 });
      list.Add(new Ferramenta { Codigo = 2, Descricao = "Ferramenta 2", Preco = 2, Quantidade = 2 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      List<Ferramenta> listCarregada = controller.GetTodosRegistros(1);

      Assert.AreEqual(listCarregada[0].Codigo, 1);
    }

    [TestMethod]
    public void GetTodosRegistros_Controller_FiltroDescricao()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 1 });
      list.Add(new Ferramenta { Codigo = 2, Descricao = "Ferramenta 2", Preco = 2, Quantidade = 2 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      List<Ferramenta> listCarregada = controller.GetTodosRegistros("Ferramenta 2");

      XElement x = listCarregada[0].ToXElement();

      Assert.AreEqual(listCarregada[0].Codigo, 2);
    }

    [TestMethod]
    public void GetTodosRegistros_Controller_FiltroDescricao_XElement()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 1 });
      list.Add(new Ferramenta { Codigo = 2, Descricao = "Ferramenta 2", Preco = 2, Quantidade = 2 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);

      FerramentaController controller = new FerramentaController(bd);

      List<Ferramenta> listCarregada = controller.GetTodosRegistros("Ferramenta 2");

      Assert.AreEqual(listCarregada[0].ToXElement().Attribute("codigo").Value, "2");
    }

    [TestMethod]
    public void Test_GetNovaFerramenta()
    {
      List<Ferramenta> list = new List<Ferramenta>();
      list.Add(new Ferramenta { Codigo = 1, Descricao = "Ferramenta 1", Preco = 1, Quantidade = 1 });
      list.Add(new Ferramenta { Codigo = 2, Descricao = "Ferramenta 2", Preco = 2, Quantidade = 2 });
      IBancoDados<Ferramenta> bd = StubBancoDados(list);
      FerramentaController controller = new FerramentaController(bd);

      Ferramenta fer = controller.GetNovaFerramenta(3, "Ferramenta 3", 3, 3);

      Assert.AreEqual(3, fer.Codigo);
    }
  }
}
