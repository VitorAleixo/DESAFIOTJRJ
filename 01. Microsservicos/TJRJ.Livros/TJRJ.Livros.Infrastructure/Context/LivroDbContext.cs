using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Livros.Infrastructure.Context
{
    public class LivroDbContext : DbContext
    {
        public LivroDbContext(DbContextOptions<LivroDbContext> options) : base(options) { }

        public DbSet<Livro> Livro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livro>()
                .HasKey(l => l.CodI);

            modelBuilder.Entity<Autor>()
               .HasKey(l => l.CodAu);

            modelBuilder.Entity<Assunto>()
             .HasKey(l => l.codAs);

            modelBuilder.Entity<TipoVenda>()
          .HasKey(l => l.TipoVenda_CodI);

            modelBuilder.Entity<LivroAutor>()
                .HasKey(la => new { la.Livro_CodI, la.Autor_CodAu});

            modelBuilder.Entity<LivroAutor>()
                .HasOne(la => la.Livro)
                .WithMany(l => l.LivroAutores)
                .HasForeignKey(la => la.Livro_CodI);

            modelBuilder.Entity<LivroAutor>()
                  .HasOne(la => la.Autor) 
                  .WithMany(a => a.LivroAutores)  
                  .HasForeignKey(la => la.Autor_CodAu); 

            modelBuilder.Entity<LivroAssunto>()
               .HasKey(la => new { la.Livro_CodI, la.Assunto_codAs});

            modelBuilder.Entity<LivroAssunto>()
                .HasOne(la => la.Livro)
                .WithMany(l => l.LivroAssuntos)
                .HasForeignKey(la => la.Livro_CodI);

            modelBuilder.Entity<LivroAssunto>()
               .HasOne(la => la.Assunto)
               .WithMany(l => l.LivroAssuntos)
               .HasForeignKey(la => la.Assunto_codAs);

            modelBuilder.Entity<LivroTipoVenda>()
             .HasKey(la => new { la.Livro_CodI, la.TipoVenda_CodI});

            modelBuilder.Entity<LivroTipoVenda>()
                .HasOne(la => la.Livro)
                .WithMany(l => l.LivroTipoVendas)
                .HasForeignKey(la => la.Livro_CodI);
            
            modelBuilder.Entity<LivroTipoVenda>()
               .HasOne(la => la.TipoVenda)
               .WithMany(l => l.LivroTipoVendas)
               .HasForeignKey(la => la.TipoVenda_CodI);
        }
    }
}
