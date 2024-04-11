using Microsoft.EntityFrameworkCore;
using Ns.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
