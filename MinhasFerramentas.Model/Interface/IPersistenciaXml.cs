using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinhasFerramentasApp.Model.Interface
{
  public interface IPersistenciaXML
  {
    void SetXml(XElement xml);
    XElement GetXml();
  }
}
