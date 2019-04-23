using AzureFromTheTrenches.Commanding.Abstractions;

namespace ServerlessTodo.Domain.Commands.Todo
{
    public class AddNewTodoCommand : ICommand<Models.Todo>
    {
        public string Description { get; set; }
    }
}
