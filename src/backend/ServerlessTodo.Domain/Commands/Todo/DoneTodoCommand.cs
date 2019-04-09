using AzureFromTheTrenches.Commanding.Abstractions;
using System;

namespace ServerlessTodo.Domain.Commands.Todo
{
    public class DoneTodoCommand : ICommand<bool>
    {
        public Guid Id { get; set; }
    }
}