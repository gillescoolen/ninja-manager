#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NinjaManager.Domain.Data;
using NinjaManager.Domain.Models;

namespace NinjaManager.Domain.Repositories
{
  public interface IGearRepository : IRepository<Gear>
  {
    ICollection<Gear> FindByCategory(GearType gearType);
  }

  public class GearRepository : IGearRepository
  {
    private readonly DatabaseContext context;
    private readonly INinjaRepository ninjaRepository;

    public GearRepository(DatabaseContext context, INinjaRepository ninjaRepository)
    {
      this.context = context;
      this.ninjaRepository = ninjaRepository;
    }

    public ICollection<Gear> All()
    {
      return context.Gear.OrderBy(e => e.Slot).ThenBy(e => e.Name).ToList();
    }

    public async Task<Gear?> Get(int id)
    {
      return await context.Gear.Include(e => e.Ninjas)
          .ThenInclude(ni => ni.Ninja).FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<EntityEntry<Gear>> Add([NotNull] Gear gear)
    {
      return await context.Gear.AddAsync(gear);
    }

    public async Task<int> Save()
    {
      return await context.SaveChangesAsync();
    }

    public async Task<EntityEntry?> Remove(int id)
    {
      var gear = await Get(id);

      if (gear == null) return null;

      await Refund(gear);
      return context.Gear.Remove(gear);
    }

    public async Task<EntityEntry> Remove([NotNull] Gear gear)
    {
      await Refund(gear);
      return context.Gear.Remove(gear);
    }

    public EntityEntry Update([NotNull] Gear gear)
    {
      return context.Gear.Update(gear);
    }

    public ICollection<Gear> FindByCategory(GearType gearType)
    {
      return context.Gear.Where(e => e.Slot == gearType)
          .ToList();
    }

    private async Task Refund(Gear gear)
    {
      gear.Ninjas.ToList().ForEach(ninjaGear =>
      {
        ninjaGear.Ninja.Gold += ninjaGear.Price;
        ninjaRepository.Update(ninjaGear.Ninja);
      });

      await ninjaRepository.Save();
    }
  }
}