using AzureFromTheTrenches.Commanding.Abstractions;

namespace ServerlessTodo.Domain.Commands.Todo
{
    public class RemoveTodoCommand : ModelCommand<Models.Todo>, ICommand<bool>
    {
    }
}