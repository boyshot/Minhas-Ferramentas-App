using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinhasFerramentasApp.BancoDados
{
  public class BancoDadosXML : IBancoDados<Ferramenta>
  {
    private IPersistenciaXML persistenciaXML = null;

    public BancoDadosXML(IPersistenciaXML persistenciaXML)
    {
      this.persistenciaXML = persistenciaXML;
    }

    public bool AlterarRegistro(Ferramenta item)
    {
      XElement xml = persistenciaXML.GetXml();
      XElement x = xml.Elements().Where(
        p => p.Attribute("codigo").Value.Equals(item.Codigo.ToString())).FirstOrDefault();

      if (x != null)
      {
        x.Attribute("descricao").SetValue(item.Descricao);
        x.Attribute("quantidade").SetValue(item.Quantidade.ToString());
        x.Attribute("preco").SetValue(item.Preco.ToString());
        persistenciaXML.SetXml(xml);
      }
      else
        throw new Exception("Não existe ferramenta para ser alterada!");

      return true;
    }

    public bool DeleteRegistro(int codigo)
    {
      XElement xml = persistenciaXML.GetXml();
      XElement x = xml.Elements().Where(
        p => p.Attribute("codigo").Value.Equals(codigo.ToString())).FirstOrDefault();
      if (x != null)
      {
        x.Remove();
        persistenciaXML.SetXml(xml);
        return true;
      }

      return false;
    }

    public Ferramenta GetItem(int codigo)
    {
      XElement xml = persistenciaXML.GetXml();
      XElement x = xml.Elements().Where(
        p => p.Attribute("codigo").Value.Equals(codigo.ToString())).FirstOrDefault();

      if (x != null)
        return GetItemFerramenta(x);
      else
        return null;
    }

    public List<Ferramenta> GetTodosRegistros()
    {
      List<Ferramenta> listaFerramentas = new List<Ferramenta>();
      XElement xml = persistenciaXML.GetXml();

      foreach (XElement x in xml.Elements())
      {
        Ferramenta ferramenta = GetItemFerramenta(x);
        listaFerramentas.Add(ferramenta);
      }

      return listaFerramentas;
    }

    public bool SaveRegistro(Ferramenta item)
    {
      XElement xml = persistenciaXML.GetXml();

      XElement x = xml.Elements().Where(
                     p => p.Attribute("codigo").Value.Equals(
                     item.Codigo.ToString())).FirstOrDefault();
      if(x != null)
        throw new Exception("Registro com este código já existe no arquivo XML!");


      xml.Add(item.ToXElement());
      persistenciaXML.SetXml(xml);
      return true;
    }

    private Ferramenta GetItemFerramenta(XElement x)
    {
      Ferramenta ferramenta = new Ferramenta();
      ferramenta.Codigo = Convert.ToInt32(x.Attribute("codigo").Value);
      ferramenta.Descricao = x.Attribute("descricao").Value;
      ferramenta.Quantidade = Convert.ToInt32(x.Attribute("quantidade").Value);
      ferramenta.Preco = Convert.ToDecimal(x.Attribute("preco").Value);

      return ferramenta;
    }
  }
}
