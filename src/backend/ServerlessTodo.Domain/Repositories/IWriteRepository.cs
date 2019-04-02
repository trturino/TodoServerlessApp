using System;
using ServerlessTodo.Domain.Models;

namespace ServerlessTodo.Domain.Repositories
{
    public interface IWriteRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Model
    {
        void Add(TEntity obj);
        void Remove(Guid id);
    }
}