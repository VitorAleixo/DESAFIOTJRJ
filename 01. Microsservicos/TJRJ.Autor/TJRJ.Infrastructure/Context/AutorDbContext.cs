using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Autor.Infrastructure.Context
{
    public class AutorDbContext : DbContext
    {
        public AutorDbContext(DbContextOptions<AutorDbContext> options) : base(options) { }

        public DbSet<TJRJ.Autor.Domain.Entities.Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutorDbContext).Assembly);
        }
    }
}
