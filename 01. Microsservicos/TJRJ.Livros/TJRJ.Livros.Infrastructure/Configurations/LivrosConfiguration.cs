using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Infrastructure.Configurations
{
    internal class LivrosConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(a => a.CodI);
            builder.Property(a => a.Titulo).IsRequired().HasMaxLength(40);
            builder.Property(a => a.Editora).IsRequired().HasMaxLength(40);
            builder.Property(a => a.Edicao).IsRequired();
            builder.Property(a => a.AnoPublicacao).IsRequired().HasMaxLength(4);
        }
    }
}
