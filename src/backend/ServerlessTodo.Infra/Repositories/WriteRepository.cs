using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cosmonaut;
using Cosmonaut.Extensions;
using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Infra.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : Model
    {
        private readonly ICosmosStore<TEntity> _cosmosStore;

        public WriteRepository(ICosmosStore<TEntity> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task Add(TEntity obj)
        {
            await _cosmosStore.AddAsync(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _cosmosStore.Query();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _cosmosStore.FindAsync(id.ToString());
        }

        public async Task Remove(Guid id)
        {
            await _cosmosStore.RemoveByIdAsync(id.ToString());
        }

        public async Task Update(TEntity obj)
        {
            await _cosmosStore.UpdateAsync(obj);
        }
    }
}