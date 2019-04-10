using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Validators
{
    public class DoneTodoCommandValidator : ModelExistsCommandValidator<Todo>
    {
        public DoneTodoCommandValidator(ITodoReadOnlyRepository modelRepository) : base(modelRepository)
        {
        }
    }
}