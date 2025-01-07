﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TJRJ.TipoVenda.Infrastructure.Context;

#nullable disable

namespace TJRJ.TipoVenda.Infrastructure.Migrations
{
    [DbContext(typeof(TipoVendaDbContext))]
    partial class TipoVendaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TJRJ.TipoVenda.Domain.Entities.TipoVenda", b =>
                {
                    b.Property<int>("TipoVenda_CodI")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoVenda_CodI"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TipoVenda_CodI");

                    b.ToTable("TipoVenda");
                });
#pragma warning restore 612, 618
        }
    }
}
