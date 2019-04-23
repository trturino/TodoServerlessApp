using System.Collections.Generic;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Queries.Todo;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Handlers.QueryHandlers
{
    public class GetCompletedTodosQueryHandler : ICommandHandler<GetCompletedTodosQuery, IEnumerable<Todo>>
    {
        private readonly ITodoReadOnlyRepository _todoReadOnlyRepository;

        public GetCompletedTodosQueryHandler(ITodoReadOnlyRepository todoReadOnlyRepository)
        {
            _todoReadOnlyRepository = todoReadOnlyRepository;
        }

        public async Task<IEnumerable<Todo>> ExecuteAsync(GetCompletedTodosQuery command, IEnumerable<Todo> previousResult)
        {
            return await _todoReadOnlyRepository.GetAll(x => x.Completed == true);
        }
    }
}