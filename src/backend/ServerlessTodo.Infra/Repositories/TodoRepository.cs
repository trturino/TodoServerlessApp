using Cosmonaut;
using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Infra.Repositories
{
    public class TodoRepository : WriteRepository<Todo>, ITodoWriteRepository, ITodoReadOnlyRepository
    {
        public TodoRepository(ICosmosStore<Todo> cosmosStore) : base(cosmosStore)
        {
        }
    }
}