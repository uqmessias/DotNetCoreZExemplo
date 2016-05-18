using System.Threading.Tasks;
using DotNetCore.Dominio;
using DotNetCore.Infra.UnitOfWork;

namespace DotNetCore.Repositorio.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;

        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task RegistroAlterado(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio)
        {
            await unitofWorkRepositorio.PersistirAtualizacaoDa(entidade);
        }

        public async Task RegistroAdicionado(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio)
        {
            await unitofWorkRepositorio.PersistirA(entidade);
        }

        public async Task RegistroRemovido(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio)
        {
            await unitofWorkRepositorio.PersistirDelecaoDa(entidade);
        }

        public async Task Commit()
        {
            await _contexto.SaveChangesAsync();
        }

        public async Task Rollback()
        {
            await Task.Factory.StartNew(() => { });
        }
    }
}