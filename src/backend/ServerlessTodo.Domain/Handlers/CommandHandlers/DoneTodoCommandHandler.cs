using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using ServerlessTodo.Domain.Commands.Todo;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Handlers.CommandHandlers
{
    public class DoneTodoCommandHandler : ICommandHandler<DoneTodoCommand, bool>
    {
        private readonly ITodoWriteRepository _todoRepository;

        public DoneTodoCommandHandler(ITodoWriteRepository todoWriteRepository)
        {
            _todoRepository = todoWriteRepository;
        }

        public async Task<bool> ExecuteAsync(DoneTodoCommand command, bool previousResult)
        {
            var todo = await _todoRepository.GetById(command.Id);
            if (todo == null)
            {
                return false;
            }

            todo.Completed = true;

            await _todoRepository.Update(todo);

            return true;
        }
    }
}