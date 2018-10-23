using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinhasFerramentasApp.BancoDados;
using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using System;
using System.Collections.Generic;

namespace MinhasFerramentasApp.Tests
{
  [TestClass]
  public class BancoDadosXMLTest : TesteUnitarioFerramentaBase
  {
    protected BancoDadosXML bancoDados
    {
      get
      {
        if (_bancoDados == null)
        {
          IPersistenciaXML persistenciaXML = StubPersistencia();
          _bancoDados = new BancoDadosXML(persistenciaXML);
        }
        return _bancoDados;
      }
    }
    private BancoDadosXML _bancoDados = null;

    [TestMethod]
    public void Teste_BD_XML_AlterarRegistro()
    {
      Ferramenta fer1 = new Ferramenta { Codigo = 1, Descricao = "Ferramenta Teste 1", Preco = 1, Quantidade = 1 };
      bool retorno = bancoDados.AlterarRegistro(fer1);
      Assert.AreEqual(true, retorno);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Não existe ferramenta para ser alterada!")]
    public void Teste_BD_XML_AlterarRegistro_Inexistente()
    {
      Ferramenta fer1 = new Ferramenta { Codigo = 122, Descricao = "Ferramenta Teste 1", Preco = 1, Quantidade = 1 };
      bool retorno = bancoDados.AlterarRegistro(fer1);
      Assert.AreEqual(true, retorno);
    }

    [TestMethod]
    public void Teste_DeleteRegistro_Sucesso()
    {
      bool retorno = bancoDados.DeleteRegistro(1);
      Assert.AreEqual(true, retorno);
    }

    [TestMethod]
    public void Teste_DeleteRegistro_NaoEncontrado()
    {
      bool retorno = bancoDados.DeleteRegistro(100);
      Assert.AreEqual(false, retorno);
    }

    [TestMethod]
    public void Teste_GetItem_Sucesso()
    {
      Ferramenta fer1 = bancoDados.GetItem(1);
      Assert.AreEqual(1, fer1.Codigo);
    }

    [TestMethod]
    public void Teste_GetItem_NaoEncontrado()
    {
      Ferramenta fer1 = bancoDados.GetItem(100);
      bool existeFerramenta = fer1 != null;
      Assert.AreEqual(false, existeFerramenta);
    }

    [TestMethod]
    public void Teste_GetTodosRegistros()
    {
      List<Ferramenta> lista = bancoDados.GetTodosRegistros();
      Assert.AreEqual(3, lista.Count);
    }

    [TestMethod]
    public void Teste_SaveRegistro()
    {
      Ferramenta fer1 = new Ferramenta { Codigo = 122, Descricao = "Ferramenta Teste 1", Preco = 1, Quantidade = 1 };
      bool retorno = bancoDados.SaveRegistro(fer1);
      Assert.AreEqual(true, retorno);
    }

    [TestMethod]
    public void Teste_SaveRegistro_Persistencia()
    {
      IPersistenciaXML persistenciaXML = StubPersistencia(GetXmlDefaultPersist());
      BancoDadosXML bancoXml = new BancoDadosXML(persistenciaXML);
      Ferramenta fer1 = new Ferramenta { Codigo = 122, Descricao = "Ferramenta Teste 1", Preco = 1, Quantidade = 1 };
      bool retorno = bancoXml.SaveRegistro(fer1);
      Assert.AreEqual(true, retorno);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Registro com este código já existe no arquivo XML!")]
    public void Teste_SaveRegistro_Existente()
    {
      Ferramenta fer1 = new Ferramenta { Codigo = 1, Descricao = "Ferramenta Teste 1", Preco = 1, Quantidade = 1 };
      bancoDados.SaveRegistro(fer1);
    }

    protected string GetXmlDefaultPersist() => @"<?xml version= ""1.0"" encoding=""UTF-8""?>
                                                 <Ferramentas>  
                                                 <Ferramenta codigo = ""4"" descricao = ""Alicate"" quantidade = ""5"" preco = ""30,00"" />
                                                 <Ferramenta codigo = ""5"" descricao = ""Martelo"" quantidade = ""3"" preco = ""20,00"" />                
                                                 <Ferramenta codigo = ""6"" descricao = ""Chave""   quantidade = ""2"" preco = ""25,00"" />
                                                 </Ferramentas >";


  }
}
