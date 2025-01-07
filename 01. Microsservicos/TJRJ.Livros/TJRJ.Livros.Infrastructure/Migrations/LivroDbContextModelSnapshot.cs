﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TJRJ.Livros.Infrastructure.Context;

#nullable disable

namespace TJRJ.Livros.Infrastructure.Migrations
{
    [DbContext(typeof(LivroDbContext))]
    partial class LivroDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.Assunto", b =>
                {
                    b.Property<int>("codAs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codAs"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codAs");

                    b.ToTable("Assunto");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.Autor", b =>
                {
                    b.Property<int>("CodAu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodAu"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodAu");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.Livro", b =>
                {
                    b.Property<int>("CodI")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodI"));

                    b.Property<string>("AnoPublicacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edicao")
                        .HasColumnType("int");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodI");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.LivroAssunto", b =>
                {
                    b.Property<int>("Livro_CodI")
                        .HasColumnType("int");

                    b.Property<int>("Assunto_codAs")
                        .HasColumnType("int");

                    b.HasKey("Livro_CodI", "Assunto_codAs");

                    b.HasIndex("Assunto_codAs");

                    b.ToTable("LivroAssunto");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.LivroAutor", b =>
                {
                    b.Property<int>("Livro_CodI")
                        .HasColumnType("int");

                    b.Property<int>("Autor_CodAu")
                        .HasColumnType("int");

                    b.HasKey("Livro_CodI", "Autor_CodAu");

                    b.HasIndex("Autor_CodAu");

                    b.ToTable("LivroAutor");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.LivroTipoVenda", b =>
                {
                    b.Property<int>("Livro_CodI")
                        .HasColumnType("int");

                    b.Property<int>("TipoVenda_CodI")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Livro_CodI", "TipoVenda_CodI");

                    b.HasIndex("TipoVenda_CodI");

                    b.ToTable("LivroTipoVenda");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.TipoVenda", b =>
                {
                    b.Property<int>("TipoVenda_CodI")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoVenda_CodI"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoVenda_CodI");

                    b.ToTable("TipoVenda");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.LivroAssunto", b =>
                {
                    b.HasOne("TJRJ.Livros.Domain.Entities.Assunto", "Assunto")
                        .WithMany("LivroAssuntos")
                        .HasForeignKey("Assunto_codAs")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TJRJ.Livros.Domain.Entities.Livro", "Livro")
                        .WithMany("LivroAssuntos")
                        .HasForeignKey("Livro_CodI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assunto");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.LivroAutor", b =>
                {
                    b.HasOne("TJRJ.Livros.Domain.Entities.Autor", "Autor")
                        .WithMany("LivroAutores")
                        .HasForeignKey("Autor_CodAu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TJRJ.Livros.Domain.Entities.Livro", "Livro")
                        .WithMany("LivroAutores")
                        .HasForeignKey("Livro_CodI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.LivroTipoVenda", b =>
                {
                    b.HasOne("TJRJ.Livros.Domain.Entities.Livro", "Livro")
                        .WithMany("LivroTipoVendas")
                        .HasForeignKey("Livro_CodI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TJRJ.Livros.Domain.Entities.TipoVenda", "TipoVenda")
                        .WithMany("LivroTipoVendas")
                        .HasForeignKey("TipoVenda_CodI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("TipoVenda");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.Assunto", b =>
                {
                    b.Navigation("LivroAssuntos");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.Autor", b =>
                {
                    b.Navigation("LivroAutores");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.Livro", b =>
                {
                    b.Navigation("LivroAssuntos");

                    b.Navigation("LivroAutores");

                    b.Navigation("LivroTipoVendas");
                });

            modelBuilder.Entity("TJRJ.Livros.Domain.Entities.TipoVenda", b =>
                {
                    b.Navigation("LivroTipoVendas");
                });
#pragma warning restore 612, 618
        }
    }
}
