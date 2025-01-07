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
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<TipoVenda> TipoVenda { get; set; }

        public DbSet<LivroAssunto> LivroAssunto { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
        public DbSet<LivroTipoVenda> LivroTipoVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livro>()
                .HasKey(l => l.CodI);

            modelBuilder.Entity<Livro>()
                .Property(l => l.CodI)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Autor>()
               .HasKey(l => l.CodAu);

            modelBuilder.Entity<Autor>()
                .Property(l => l.CodAu)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Assunto>()
             .HasKey(l => l.codAs);

            modelBuilder.Entity<Assunto>()
               .Property(l => l.codAs)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<TipoVenda>()
          .HasKey(l => l.TipoVenda_CodI);

            modelBuilder.Entity<TipoVenda>()
               .Property(l => l.TipoVenda_CodI)
               .ValueGeneratedOnAdd();

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
