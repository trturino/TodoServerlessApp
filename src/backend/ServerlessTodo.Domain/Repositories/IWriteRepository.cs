using System;
using System.Threading.Tasks;
using ServerlessTodo.Domain.Models;

namespace ServerlessTodo.Domain.Repositories
{
    public interface IWriteRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Model
    {
        Task Add(TEntity obj);

        Task Update(TEntity obj);

        Task Remove(Guid id);
    }
}