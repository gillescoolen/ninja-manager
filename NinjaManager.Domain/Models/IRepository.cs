#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NinjaManager.Domain.Models
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> All();
        Task<T?> Get(int id);
        Task<EntityEntry<T>> Add([NotNull] T model);
        Task<int> Save();
        Task<EntityEntry?> Remove(int id);
        Task<EntityEntry> Remove([NotNull] T model);
        EntityEntry Update([NotNull] T model);
    }
}