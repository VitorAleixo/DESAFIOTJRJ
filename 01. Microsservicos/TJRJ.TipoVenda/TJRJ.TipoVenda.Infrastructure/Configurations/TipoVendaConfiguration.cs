using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.TipoVenda.Infrastructure.Configurations
{
    internal class TipoVendaConfiguration : IEntityTypeConfiguration<TJRJ.TipoVenda.Domain.Entities.TipoVenda>
    {
        public void Configure(EntityTypeBuilder<TJRJ.TipoVenda.Domain.Entities.TipoVenda> builder)
        {
            builder.HasKey(a => a.TipoVenda_CodI);
            builder.Property(a => a.Descricao).IsRequired().HasMaxLength(100);
        }
    }
}
