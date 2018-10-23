using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MinhasFerramentasApp.BancoDados;
using MinhasFerramentasApp.Controller;
using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;
using MinhasFerramentasApp.Service;
using MinhasFerramentasApp.View;
using System;
using System.Windows.Forms;

namespace MinhasFerramentasApp
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var container = new WindsorContainer();

      container.Register(Component.For<IPersistenciaXML>().ImplementedBy<PersistenciaXML>());
      container.Register(Component.For<IBancoDados<Ferramenta>>().ImplementedBy<BancoDadosXML>());
      container.Register(Component.For<IFerramentaController>().ImplementedBy<FerramentaController>());
      container.Register(Component.For<IRelatorioService>().ImplementedBy<RelatorioFerramentasService>());

      Application.Run(new FrmFerramentas(container));
    }
  }
}
