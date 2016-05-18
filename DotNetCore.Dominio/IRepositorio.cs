using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.Dominio
{
    public interface IRepository<TEntity> where TEntity : Entidade
    {
        Task Inserir(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Deletar(TEntity entity);
        Task<IList<TEntity>> ProcurarItensPor(Expression<Func<TEntity, bool>> predicado);
        //Task<IList<TEntity>> ProcurarItensPor(Especificacao<TEntity> especificacao);
        Task<TEntity> ProcurarItenPor(Guid codigo);
        //Task<TEntity> ProcurarItenPor(Especificacao<TEntity> especificacao);
        IQueryable<TEntity> ObterTodos();
    }
}