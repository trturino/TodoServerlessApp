using AzureFromTheTrenches.Commanding.Abstractions;
using System;

namespace ServerlessTodo.Domain.Commands.Todo
{
    public class DoneTodoCommand : ModelCommand<Models.Todo>, ICommand<bool>
    {
    }
}