using DotNetCore.Dominio;
using DotNetCore.Repositorio.EF.Configuracoes;
using System;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore.Repositorio.EF
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configure<ClienteConfiguracao, Cliente>();
        }

    }

    public static class ModelBuilderExtention
    {
        public static void Configure<T, TD>(this ModelBuilder modelBuilder) where T : EntidadeConfiguracao<TD> where TD: Entidade
        {
            var instance = Activator.CreateInstance(typeof(T), modelBuilder.Entity<TD>());
        }
    }
}
