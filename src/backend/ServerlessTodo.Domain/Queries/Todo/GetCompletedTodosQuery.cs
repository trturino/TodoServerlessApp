using System.Collections.Generic;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace ServerlessTodo.Domain.Queries.Todo
{
    public class GetCompletedTodosQuery : ICommand<IEnumerable<Models.Todo>>
    {
    }
}