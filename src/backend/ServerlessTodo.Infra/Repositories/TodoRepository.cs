using Cosmonaut;
using ServerlessTodo.Domain.Models;

namespace ServerlessTodo.Infra.Repositories
{
    public class TodoRepository : WriteRepository<Todo>
    {
        public TodoRepository(CosmosStore<Todo> cosmosStore) : base(cosmosStore)
        {
        }
    }
}