using Microsoft.EntityFrameworkCore;
using NinjaManager.Business.Models;

namespace NinjaManager.Business.Data
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