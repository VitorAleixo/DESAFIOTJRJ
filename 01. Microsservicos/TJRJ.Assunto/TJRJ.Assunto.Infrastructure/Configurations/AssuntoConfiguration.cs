using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Assunto.Infrastructure.Configurations
{
    internal class AssuntoConfiguration : IEntityTypeConfiguration<TJRJ.Assunto.Domain.Entities.Assunto>
    {
        public void Configure(EntityTypeBuilder<TJRJ.Assunto.Domain.Entities.Assunto> builder)
        {
            builder.HasKey(a => a.codAs);
            builder.Property(a => a.Descricao).IsRequired().HasMaxLength(20);
        }
    }
}
