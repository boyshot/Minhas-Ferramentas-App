using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhasFerramentas.WebApp.Models;

namespace MinhasFerramentas.WebApp.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = @"Aplicativo que utiliza a tecnologia C# Windows Forms nativo com persistência dos dados em arquivo XML localizado no próprio diretório de instalação do app.
                              Observação: Não foi utilizado biblioteca de terceiros na implementação deste app.

                              Objetivo
                              O aplicativo é um cadastro de Ferramentas onde e possível indicar os dados da ferramenta com objetivo de pré-requisito para realização da primeira etapa do curso de Testes Unitários no ERP RM.

                              Foram criados os testes unitários e também o Castle.Windsor no projeto.

                              Estou Mingrando este App de Windows Forms para Asp Net. MVC Core. Seguindo as tendências de mercado :)

                              Desenvolvedor: Paulo André da Rocha";

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
