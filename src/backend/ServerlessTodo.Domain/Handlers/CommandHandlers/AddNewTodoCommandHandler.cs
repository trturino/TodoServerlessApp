using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using ServerlessTodo.Domain.Commands.Todo;
using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Handlers.CommandHandlers
{
    public class AddNewTodoCommandHandler : ICommandHandler<AddNewTodoCommand, bool>
    {
        private readonly ITodoWriteRepository _todoRepository;

        public AddNewTodoCommandHandler(ITodoWriteRepository todoWriteRepository)
        {
            _todoRepository = todoWriteRepository;
        }

        public async Task<bool> ExecuteAsync(AddNewTodoCommand command, bool previousResult)
        {
            var todo = new Todo()
            {
                Completed = false,
                Id = command.Id,
                Description = command.Description
            };

            await _todoRepository.Add(todo);

            return true;
        }
    }
}