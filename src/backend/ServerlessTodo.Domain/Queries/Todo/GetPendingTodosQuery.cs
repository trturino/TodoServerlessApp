using System.Collections.Generic;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace ServerlessTodo.Domain.Queries.Todo
{
    public class GetPendingTodosQuery : ICommand<IEnumerable<Models.Todo>>
    {
    }
}