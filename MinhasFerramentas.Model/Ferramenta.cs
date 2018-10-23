using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinhasFerramentasApp.Model
{
  public class Ferramenta
  {
    public int Codigo { get; set; }

    public string Descricao { get; set; }

    public int Quantidade { get; set; }

    public decimal Preco { get; set; }

    public XElement ToXElement()
    {
      XElement x = new XElement("ferramenta");
      x.Add(new XAttribute("codigo", this.Codigo));
      x.Add(new XAttribute("descricao", this.Descricao));
      x.Add(new XAttribute("quantidade", this.Quantidade.ToString()));
      x.Add(new XAttribute("preco", this.Preco.ToString("N2")));
      return x;
    }
  }
}
