using Castle.Windsor;
using MinhasFerramentasApp.Model.Interface;
using System;
using System.Text;
using System.Windows.Forms;

namespace MinhasFerramentasApp.View
{
  public partial class FrmRelatorio : Form
  {
    private IRelatorioService relatorioService;

    public FrmRelatorio(IWindsorContainer container)
    {
      InitializeComponent();
      this.relatorioService = container.Resolve<IRelatorioService>();
    }

    private void frmRelatorio_Load(object sender, EventArgs e)
    {
      StringBuilder sbRelatorio = relatorioService.GerarRelatorio();
      txtRelatorio.Text = sbRelatorio.ToString();
    }
  }
}
