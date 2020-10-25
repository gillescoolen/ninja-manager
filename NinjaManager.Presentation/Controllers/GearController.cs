using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NinjaManager.Domain.Data;
using NinjaManager.Domain.Models;

namespace NinjaManager.Presentation.Controllers
{
  public class GearController : Controller
  {
    private readonly DatabaseContext _context;

    public GearController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: Gear
    public async Task<IActionResult> Index()
    {
      return View(await _context.Gear.ToListAsync());
    }

    // GET: Gear/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var gear = await _context.Gear
          .FirstOrDefaultAsync(m => m.Id == id);
      if (gear == null)
      {
        return NotFound();
      }

      return View(gear);
    }

    // GET: Gear/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Gear/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Price,Name,Strength,Intelligence,Agility,Slot")] Gear gear)
    {
      if (ModelState.IsValid)
      {
        _context.Add(gear);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(gear);
    }

    // GET: Gear/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var gear = await _context.Gear.FindAsync(id);
      if (gear == null)
      {
        return NotFound();
      }
      return View(gear);
    }

    // POST: Gear/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Name,Strength,Intelligence,Agility,Slot")] Gear gear)
    {
      if (id != gear.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(gear);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!GearExists(gear.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(gear);
    }

    // GET: Gear/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var gear = await _context.Gear
          .FirstOrDefaultAsync(m => m.Id == id);
      if (gear == null)
      {
        return NotFound();
      }

      return View(gear);
    }

    // POST: Gear/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var gear = await _context.Gear.FindAsync(id);
      _context.Gear.Remove(gear);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool GearExists(int id)
    {
      return _context.Gear.Any(e => e.Id == id);
    }
  }
}
