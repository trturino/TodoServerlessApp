using AzureFromTheTrenches.Commanding.Abstractions;
using System;

namespace ServerlessTodo.Domain.Commands.Todo
{
    public class RemoveTodoCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
