using DotNetCore.Dominio;
using DotNetCore.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace DotNetCore.Repositorio.EF.Repositorios
{
    public abstract class Repositorio<T> : IUnitOfWorkRepository, IRepository<T> where T : Entidade, IRaizDeAgregacao
    {
        private readonly IUnitOfWork _uow;
        private readonly Contexto _contexto;
        //protected CompiladorEspecificacao<T> Compilador;

        protected Repositorio(IUnitOfWork uow, Contexto contexto)
        {
            _uow = uow;
            _contexto = contexto;
          //  Compilador = new CompiladorEspecificacao<T>(GetObjectSet);
        }

        private void Validar(T entity)
        {
            if (!entity.EhValido())
                throw new InvalidOperationException(string.Join(Environment.NewLine, entity.TodosErros()));
        }

        public async Task Inserir(T entidade)
        {
            Validar(entidade);
            await _uow.RegistroAdicionado(entidade, this);
        }

        public async Task Deletar(T entidade)
        {
            await _uow.RegistroRemovido(entidade, this);
        }

        public async Task Atualizar(T entidade)
        {
            Validar(entidade);
            await _uow.RegistroAlterado(entidade, this);
        }

        public IQueryable<T> GetObjectSet()
        {
            return _contexto.Set<T>();
        }

        public async Task<T> ProcurarItenPor(Guid codigo)
        {
            return await GetObjectSet().FirstOrDefaultAsync(arg => arg.Codigo.Equals(codigo));
        }

        public async Task<IList<T>> ProcurarItensPor(Expression<Func<T, bool>> predicado)
        {
            return await GetObjectSet().Where(predicado).ToListAsync();
        }
        
        public IQueryable<T> ObterTodos()
        {
            return GetObjectSet();
        }

        public List<T> ObterTodos(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList();
        }

        public async Task PersistirA(IRaizDeAgregacao entidade)
        {
            await Task.Factory.StartNew(() =>
            _contexto.Set<T>().Add((T)entidade));
        }

        public async Task PersistirAtualizacaoDa(IRaizDeAgregacao entidade)
        {
            await Task.FromResult<object>(null);
        }

        public async Task PersistirDelecaoDa(IRaizDeAgregacao entidade)
        {
            await Task.Factory.StartNew(() =>
            _contexto.Set<T>().Remove((T)entidade));
        }
    }
}