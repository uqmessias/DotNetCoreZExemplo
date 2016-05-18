using DotNetCore.Repositorio.EF.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore.Repositorio.EF
{
    public static class Configurador
    {
        public static void Configurar(IServiceCollection services, IConfigurationRoot configuration)
        {
            var sqlConnectionString = configuration["Data:ConnectionString"];
            services
              .AddDbContext<Contexto>(options => options.UseSqlServer(sqlConnectionString, b => b.MigrationsAssembly("DotNetCore.Api")));
            services.AddScoped<Infra.UnitOfWork.IUnitOfWork, UnitOfWork>();
            services.AddScoped<Dominio.IClienteRepositorio, ClienteRepositorio>();

        }
    }
}