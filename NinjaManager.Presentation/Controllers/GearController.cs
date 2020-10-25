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
  public class GearController : Controller
  {
    private readonly IGearRepository gearRepository;

    public GearController(IGearRepository gearRepository)
    {
      this.gearRepository = gearRepository;
    }

    public ViewResult Index()
    {
      return View(gearRepository.All());
    }

    public async Task<IActionResult> Details(int id)
    {
      var gear = await gearRepository.Get(id);

      if (gear == null)
      {
        return NotFound();
      }

      return View(gear);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Price,Name,Strength,Intelligence,Agility,Slot")] Gear gear)
    {
      if (!ModelState.IsValid) return View(gear);
      await gearRepository.Add(gear);
      await gearRepository.Save();
      return RedirectToAction("Index", "Gear");
    }

    public async Task<IActionResult> Edit(int id)
    {
      var gear = await gearRepository.Get(id);

      if (gear == null)
      {
        return NotFound();
      }

      return View(gear);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Name,Strength,Intelligence,Agility,Slot")]
            Gear gear)
    {
      if (id != gear.Id)
      {
        return NotFound();
      }

      if (!ModelState.IsValid) return View(gear);

      try
      {
        gearRepository.Update(gear);
        await gearRepository.Save();
      }
      catch (DbUpdateConcurrencyException)
      {
        var exists = await GearExists(gear.Id);

        if (exists != null) return NotFound();

        throw;
      }

      return RedirectToAction("Index", "Gear");
    }

    public async Task<IActionResult> Delete(int id)
    {
      var gear = await gearRepository.Get(id);

      if (gear == null)
      {
        return NotFound();
      }

      return View(gear);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await gearRepository.Remove(id);
      await gearRepository.Save();
      return RedirectToAction("Index", "Gear");
    }

    private async Task<Gear> GearExists(int id)
    {
      return await gearRepository.Get(id);
    }
  }
}
