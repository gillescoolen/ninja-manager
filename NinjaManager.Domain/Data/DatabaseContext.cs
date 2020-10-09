using Microsoft.EntityFrameworkCore;
using NinjaManager.Domain.Models;

namespace NinjaManager.Domain.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Ninja> Ninja { get; set; }
        public DbSet<Gear> Gear { get; set; }
    }
}