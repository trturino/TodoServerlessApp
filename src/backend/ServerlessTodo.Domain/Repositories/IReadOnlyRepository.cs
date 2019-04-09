using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ServerlessTodo.Domain.Models;

namespace ServerlessTodo.Domain.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Model
    {
        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null);
    }
}