using ServerlessTodo.Domain.Models;

namespace ServerlessTodo.Domain.Repositories
{
    public interface ITodoWriteRepository : IWriteRepository<Todo>
    {
    }
}
