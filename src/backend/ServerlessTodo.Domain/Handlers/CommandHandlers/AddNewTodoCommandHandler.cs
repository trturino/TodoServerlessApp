using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using ServerlessTodo.Domain.Commands.Todo;
using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Handlers.CommandHandlers
{
    public class AddNewTodoCommandHandler : ICommandHandler<AddNewTodoCommand, Todo>
    {
        private readonly ITodoWriteRepository _todoRepository;

        public AddNewTodoCommandHandler(ITodoWriteRepository todoWriteRepository)
        {
            _todoRepository = todoWriteRepository;
        }

        public async Task<Todo> ExecuteAsync(AddNewTodoCommand command, Todo previousResult)
        {
            var todo = new Todo()
            {
                Completed = false,
                Id = Guid.NewGuid(),
                Description = command.Description
            };

            await _todoRepository.Add(todo);

            return todo;
        }
    }
}