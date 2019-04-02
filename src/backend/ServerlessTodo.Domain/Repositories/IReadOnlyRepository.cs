using System;
using System.Linq;
using ServerlessTodo.Domain.Models;

namespace ServerlessTodo.Domain.Repositories
{
    public interface IReadOnlyRepository<TEntity> : IDisposable where TEntity : Model
    {
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
    }
}