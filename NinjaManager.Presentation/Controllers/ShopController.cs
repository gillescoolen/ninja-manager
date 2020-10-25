using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NinjaManager.Domain.Models;
using NinjaManager.Domain.Repositories;
using NinjaManager.Models;

namespace NinjaManager.Controllers
{
  public class ShopController : Controller
  {
    private readonly INinjaRepository ninjaRepository;
    private readonly IGearRepository gearRepository;

    public ShopController(INinjaRepository ninjaRepository, IGearRepository gearRepository)
    {
      this.ninjaRepository = ninjaRepository;
      this.gearRepository = gearRepository;
    }

    public async Task<IActionResult> Index(int id, GearType? filterBy = null)
    {
      var ninja = await ninjaRepository.Get(id);

      if (ninja == null)
      {
        return NotFound();
      }

      var viewModel = new NinjaShopViewModel
      {
        gear = filterBy != null
              ? gearRepository.FindByCategory(filterBy ?? GearType.Chest)
              : gearRepository.All(),
        ninja = ninja
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Sell(int ninjaId, int gearId, bool isFromProfile = false)
    {
      var ninja = await ninjaRepository.Get(ninjaId);
      var gear = await gearRepository.Get(gearId);

      if (ninja == null || gear == null || !ninja.HasGear(gear))
      {
        return NotFound();
      }

      var ninjaGear = ninja.Gear.FirstOrDefault(e => e.Gear == gear);

      ninja.Gear.Remove(ninjaGear);

      if (ninjaGear != null) ninja.Gold += ninjaGear.Price;

      await ninjaRepository.Save();

      return isFromProfile ? RedirectToAction("Details", "Ninja", new { id = ninjaId }) : RedirectToAction("Index", new { id = ninjaId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Buy(int ninjaId, int gearId)
    {
      var ninja = await ninjaRepository.Get(ninjaId);
      var gear = await gearRepository.Get(gearId);

      if (ninja == null || gear == null || ninja.HasGear(gear))
      {
        return NotFound();
      }

      var ninjaGear = ninja.GetGearBySlot(gear.Slot);

      if (ninjaGear.Name != null)
      {
        ninja.Gear.Remove(ninja.Gear.FirstOrDefault(e => e.Gear == ninjaGear));
        ninja.Gold += ninjaGear.Price;
      }

      ninja.Gear.Add(new NinjaGear { NinjaId = ninjaId, GearId = gearId, Price = gear.Price });
      ninja.Gold -= gear.Price;

      await ninjaRepository.Save();

      return RedirectToAction("Index", new { id = ninjaId });
    }
  }
}