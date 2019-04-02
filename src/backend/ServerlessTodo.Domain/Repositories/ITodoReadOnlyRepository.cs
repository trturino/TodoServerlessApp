using ServerlessTodo.Domain.Models;

namespace ServerlessTodo.Domain.Repositories
{
    public interface ITodoReadOnlyRepository : IReadOnlyRepository<Todo>
    {
    }
}