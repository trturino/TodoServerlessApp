using System;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace ServerlessTodo.Domain.Commands.Todo
{
    public class AddNewTodoCommand : ICommand<bool>
    {
        public string Description { get; set; }

        public Guid Id { get; set; }
    }
}
