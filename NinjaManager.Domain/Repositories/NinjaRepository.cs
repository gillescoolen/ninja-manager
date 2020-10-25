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
  public class NinjaRepository : IRepository<Ninja>
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
          .ThenInclude(ni => ni.Gear).FirstOrDefaultAsync(n => n.Id == id);
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
      var equipment = await Get(id);
      return equipment == null ? null : context.Ninja.Remove(equipment);
    }

    public async Task<EntityEntry> Remove([NotNull] Ninja ninja)
    {
      return context.Ninja.Remove(ninja);
    }

    public EntityEntry Update([NotNull] Ninja ninja)
    {
      return context.Ninja.Update(ninja);
    }
  }
}