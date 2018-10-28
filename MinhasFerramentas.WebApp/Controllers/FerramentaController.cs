using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhasFerramentasApp.Model;
using MinhasFerramentasApp.Model.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinhasFerramentas.WebApp.Controllers
{
  public class FerramentaController : Controller
  {
    IFerramentaController ferramentaController = null;

    public FerramentaController(IFerramentaController ferramentaController)
    {
      this.ferramentaController = ferramentaController;
    }

    // GET: /<controller>/
    public IActionResult Index()
    {
      var itens = ferramentaController.GetTodosRegistros();
      return View(itens);
    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      Ferramenta ferramenta = ferramentaController.GetItem(id.Value);

      if (ferramenta == null)    
        return NotFound();
     
      return View(ferramenta);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind]Ferramenta ferramenta)
    {
      if (ModelState.IsValid)
      {
        ferramentaController.SaveRegistro(ferramenta);
        return RedirectToAction("Index");
      }
      return View(ferramenta);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
      if (id == null) 
        return NotFound();    

      Ferramenta ferramenta = ferramentaController.GetItem(id.Value);

      if (ferramenta == null)
        return NotFound();

      return View(ferramenta);
    }

    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind]Ferramenta ferramenta)
    {
      if (id != ferramenta.Codigo)
        return NotFound();
      
      if (ModelState.IsValid)
      {
        ferramentaController.AlterarRegistro(ferramenta);
        return RedirectToAction("Index");
      }
      return View(ferramenta);
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
      if (id == null)   
        return NotFound();

      Ferramenta ferramenta = ferramentaController.GetItem(id.Value);

      if (ferramenta == null)
        return NotFound();
 
      return View(ferramenta);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int? id)
    {
      ferramentaController.DeleteRegistro(id.Value);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Relatorio()
    {
      var itens = ferramentaController.GetTodosRegistros();
      return View(itens);
    }
  }
}
