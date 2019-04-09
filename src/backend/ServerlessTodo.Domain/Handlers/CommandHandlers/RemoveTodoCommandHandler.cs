using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using ServerlessTodo.Domain.Commands.Todo;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Handlers.CommandHandlers
{
    public class RemoveTodoCommandHandler : ICommandHandler<RemoveTodoCommand, bool>
    {
        private readonly ITodoWriteRepository _todoRepository;

        public RemoveTodoCommandHandler(ITodoWriteRepository todoWriteRepository)
        {
            _todoRepository = todoWriteRepository;
        }

        public async Task<bool> ExecuteAsync(RemoveTodoCommand command, bool previousResult)
        {
            var todo = await _todoRepository.GetById(command.Id);
            if (todo == null)
            {
                return false;
            }

            await _todoRepository.Remove(command.Id);

            return true;
        }
    }
}