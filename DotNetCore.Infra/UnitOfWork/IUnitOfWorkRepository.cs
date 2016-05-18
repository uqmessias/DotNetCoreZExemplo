using DotNetCore.Dominio;
using System.Threading.Tasks;

namespace DotNetCore.Infra.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        Task PersistirA(IRaizDeAgregacao entidade);
        Task PersistirAtualizacaoDa(IRaizDeAgregacao entidade);
        Task PersistirDelecaoDa(IRaizDeAgregacao entidade);
    }
}