using Microsoft.EntityFrameworkCore;
using Ns.Domain.Models;

namespace Ns.Persistence
{
    public class NsDbContext:DbContext
    {
        public NsDbContext(DbContextOptions<NsDbContext> options):base(options)
        {
             
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NsDbContext).Assembly);
        }

    }
}
