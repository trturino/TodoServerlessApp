using System.Collections.Generic;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace ServerlessTodo.Domain.Queries.Todo
{
    public class GetAllTodosQuery : ICommand<IEnumerable<Models.Todo>>
    {
    }
}