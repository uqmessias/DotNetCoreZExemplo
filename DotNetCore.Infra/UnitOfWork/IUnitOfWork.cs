using DotNetCore.Dominio;
using System.Threading.Tasks;

namespace DotNetCore.Infra.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task RegistroAlterado(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio);
        Task RegistroAdicionado(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio);
        Task RegistroRemovido(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio);
        Task Commit();
        Task Rollback();
    }
}