using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.TipoVenda.Infrastructure.Context
{
    public class TipoVendaDbContext : DbContext
    {
        public TipoVendaDbContext(DbContextOptions<TipoVendaDbContext> options) : base(options) { }

        public DbSet<TJRJ.TipoVenda.Domain.Entities.TipoVenda> TipoVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TipoVendaDbContext).Assembly);
        }
    }
}
