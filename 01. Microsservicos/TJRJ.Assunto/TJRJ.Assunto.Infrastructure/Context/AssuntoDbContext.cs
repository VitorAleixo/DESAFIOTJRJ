using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Assunto.Infrastructure.Context
{
    public class AssuntoDbContext : DbContext
    {
        public AssuntoDbContext(DbContextOptions<AssuntoDbContext> options) : base(options) { }

        public DbSet<TJRJ.Assunto.Domain.Entities.Assunto> Assunto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssuntoDbContext).Assembly);
        }
    }
}
