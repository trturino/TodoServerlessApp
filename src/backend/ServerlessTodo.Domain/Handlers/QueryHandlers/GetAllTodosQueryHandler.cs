using System.Collections.Generic;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Queries.Todo;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Handlers.QueryHandlers
{
    public class GetAllTodosQueryHandler : ICommandHandler<GetAllTodosQuery, IEnumerable<Todo>>
    {
        private readonly ITodoReadOnlyRepository _todoReadOnlyRepository;

        public GetAllTodosQueryHandler(ITodoReadOnlyRepository todoReadOnlyRepository)
        {
            _todoReadOnlyRepository = todoReadOnlyRepository;
        }

        public async Task<IEnumerable<Todo>> ExecuteAsync(GetAllTodosQuery command, IEnumerable<Todo> previousResult)
        {
            return await _todoReadOnlyRepository.GetAll();
        }
    }
}