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
  public interface INinjaRepository : IRepository<Ninja>
  {
    Task<int> SellAllGear([NotNull] Ninja ninja);
  }

  public class NinjaRepository : INinjaRepository
  {
    private readonly DatabaseContext context;

    public NinjaRepository(DatabaseContext context)
    {
      this.context = context;
    }

    public ICollection<Ninja> All()
    {
      return context.Ninja.OrderBy(n => n.Name).ToList();
    }

    public async Task<Ninja?> Get(int id)
    {
      return await context.Ninja.Include(n => n.Gear)
          .ThenInclude(n => n.Gear).FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<EntityEntry<Ninja>> Add([NotNull] Ninja ninja)
    {
      return await context.Ninja.AddAsync(ninja);
    }

    public async Task<int> Save()
    {
      return await context.SaveChangesAsync();
    }

    public async Task<EntityEntry?> Remove(int id)
    {
      var gear = await Get(id);
      return gear == null ? null : context.Ninja.Remove(gear);
    }

    public async Task<EntityEntry> Remove([NotNull] Ninja ninja)
    {
      return context.Ninja.Remove(ninja);
    }

    public EntityEntry Update([NotNull] Ninja ninja)
    {
      return context.Ninja.Update(ninja);
    }

    public async Task<int> SellAllGear([NotNull] Ninja ninja)
    {
      context.NinjaGear.RemoveRange(context.NinjaGear.Where(e => e.NinjaId == ninja.Id));
      return await context.SaveChangesAsync();
    }
  }
}