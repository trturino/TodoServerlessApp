using System.Collections.Generic;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Queries.Todo;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Handlers.QueryHandlers
{
    public class GetPendingTodosQueryHandler : ICommandHandler<GetPendingTodosQuery, IEnumerable<Todo>>
    {
        private readonly ITodoReadOnlyRepository _todoReadOnlyRepository;

        public GetPendingTodosQueryHandler(ITodoReadOnlyRepository todoReadOnlyRepository)
        {
            _todoReadOnlyRepository = todoReadOnlyRepository;
        }

        public async Task<IEnumerable<Todo>> ExecuteAsync(GetPendingTodosQuery command, IEnumerable<Todo> previousResult)
        {
            return await _todoReadOnlyRepository.GetAll(x => x.Completed == false);
        }
    }
}