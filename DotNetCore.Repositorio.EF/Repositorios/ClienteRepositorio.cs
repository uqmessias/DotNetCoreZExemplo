using DotNetCore.Dominio;
using DotNetCore.Infra.UnitOfWork;

namespace DotNetCore.Repositorio.EF.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(IUnitOfWork uow, Contexto contexto) : base(uow, contexto)
        {
        }
    }
}