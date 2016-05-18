using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DotNetCore.Repositorio.EF;

namespace DotNetCore.Api.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20160518224933_start")]
    partial class start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCore.Dominio.Cliente", b =>
                {
                    b.Property<Guid>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<string>("Nome");

                    b.HasKey("Codigo");

                    b.ToTable("Clientes");
                });
        }
    }
}
