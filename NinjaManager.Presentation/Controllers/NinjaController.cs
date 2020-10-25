using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NinjaManager.Domain.Data;
using NinjaManager.Domain.Models;
using NinjaManager.Domain.Repositories;

namespace NinjaManager.Presentation.Controllers
{
  public class NinjaController : Controller
  {
    private readonly INinjaRepository ninjaRepository;

    public NinjaController(INinjaRepository ninjaRepository)
    {
      this.ninjaRepository = ninjaRepository;
    }

    public ViewResult Index()
    {
      return View(ninjaRepository.All());
    }

    public async Task<IActionResult> Details(int id)
    {
      var ninja = await ninjaRepository.Get(id);

      if (ninja == null)
      {
        return NotFound();
      }

      return View(ninja);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Gold")]
            Ninja ninja)
    {
      if (!ModelState.IsValid) return View(ninja);
      await ninjaRepository.Add(ninja);
      await ninjaRepository.Save();
      return RedirectToAction("Index", "Ninja");
    }

    public async Task<IActionResult> Edit(int id)
    {
      var ninja = await ninjaRepository.Get(id);

      if (ninja == null)
      {
        return NotFound();
      }

      return View(ninja);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gold")]
            Ninja ninja)
    {
      if (id != ninja.Id)
      {
        return NotFound();
      }

      if (!ModelState.IsValid) return View(ninja);

      try
      {
        ninjaRepository.Update(ninja);
        await ninjaRepository.Save();
      }
      catch (DbUpdateConcurrencyException)
      {
        var exists = await NinjaExists(ninja.Id);

        if (exists != null) return NotFound();

        throw;
      }

      return RedirectToAction("Index", "Ninja");
    }

    public async Task<IActionResult> Delete(int id)
    {
      var ninja = await ninjaRepository.Get(id);

      if (ninja == null)
      {
        return NotFound();
      }

      return View(ninja);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await ninjaRepository.Remove(id);
      await ninjaRepository.Save();
      return RedirectToAction("Index", "Ninja");
    }

    private async Task<Ninja?> NinjaExists(int id)
    {
      return await ninjaRepository.Get(id);
    }
  }
}
