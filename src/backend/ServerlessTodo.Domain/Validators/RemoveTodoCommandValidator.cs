using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Validators
{
    public class RemoveTodoCommandValidator : ModelExistsCommandValidator<Todo>
    {
        public RemoveTodoCommandValidator(ITodoReadOnlyRepository modelRepository) : base(modelRepository)
        {
        }
    }
}