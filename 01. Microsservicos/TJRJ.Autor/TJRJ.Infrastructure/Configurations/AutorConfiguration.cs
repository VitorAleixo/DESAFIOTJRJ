using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Autor.Infrastructure.Configurations
{
    internal class AutorConfiguration : IEntityTypeConfiguration<TJRJ.Autor.Domain.Entities.Autor>
    {
        public void Configure(EntityTypeBuilder<TJRJ.Autor.Domain.Entities.Autor> builder)
        {
            builder.HasKey(a => a.CodAu);
            builder.Property(a => a.Nome).IsRequired().HasMaxLength(40);
        }
    }
}
