using MinhasFerramentasApp.Controller;
using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using Rhino.Mocks;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace MinhasFerramentasApp.Tests
{
  public class TesteUnitarioFerramentaBase
  {
    protected IPersistenciaXML StubPersistencia(string xmldefault = null)
    {
      var persistXML = MockRepository.GenerateStub<IPersistenciaXML>();

      persistXML.Stub(x => x.SetXml(Arg<XElement>.Is.Anything));

      //Carregar XML
      string xml = string.IsNullOrWhiteSpace(xmldefault) ? GetXmlDefault() : xmldefault;

      var byteArray = Encoding.UTF8.GetBytes(xml);
      MemoryStream stream = new MemoryStream(byteArray);
      XElement elemento = XElement.Load(stream);
      persistXML.Stub(x => x.GetXml()).Return(elemento);

      return persistXML;
    }
         
    protected IBancoDados<Ferramenta> StubBancoDados(List<Ferramenta> ferramentas)
    {
      var bd = MockRepository.GenerateStub<IBancoDados<Ferramenta>>();

      bd.Stub(x => x.SaveRegistro(Arg<Ferramenta>.Is.Anything)).Return(true);
      bd.Stub(x => x.AlterarRegistro(Arg<Ferramenta>.Is.Anything)).Return(true);
      bd.Stub(x => x.DeleteRegistro(Arg<int>.Is.Anything)).Return(true);
      bd.Stub(x => x.GetItem(Arg<int>.Is.Anything)).Return(ferramentas[0]);
      bd.Stub(x => x.GetTodosRegistros()).Return(ferramentas);

      return bd;
    }

    protected IFerramentaController StubControllerFerramenta(List<Ferramenta> ferramentas)
    {
      IBancoDados<Ferramenta> bd = StubBancoDados(ferramentas);

      IFerramentaController ferramentaController = MockRepository.GenerateStub<FerramentaController>(bd);

      return ferramentaController;
    }

    protected string GetXmlDefault() => @"<?xml version= ""1.0"" encoding=""UTF-8""?>
                                          <Ferramentas>  
                                          <Ferramenta codigo = ""1"" descricao = ""Alicate"" quantidade = ""5"" preco = ""30,00"" />
                                          <Ferramenta codigo = ""2"" descricao = ""Martelo"" quantidade = ""3"" preco = ""20,00"" />                
                                          <Ferramenta codigo = ""3"" descricao = ""Chave""   quantidade = ""2"" preco = ""25,00"" />
                                          </Ferramentas >";    
  }
}
