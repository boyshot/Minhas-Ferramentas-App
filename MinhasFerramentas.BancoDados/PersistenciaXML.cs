using MinhasFerramentasApp.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinhasFerramentasApp.BancoDados
{
  public class PersistenciaXML : IPersistenciaXML
  {
    public static readonly string NomeBancoDados = "Ferramentas.xml";

    public XElement GetXml()
    {
      XElement xml = XElement.Load(NomeBancoDados);
      return xml;
    }

    public void SetXml(XElement xml)
    {
      xml.Save(NomeBancoDados);
    }
  }
}
