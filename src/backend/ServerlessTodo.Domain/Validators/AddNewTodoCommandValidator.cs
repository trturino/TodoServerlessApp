using FluentValidation;
using ServerlessTodo.Domain.Commands.Todo;

namespace ServerlessTodo.Domain.Validators
{
    public class AddNewTodoCommandValidator : AbstractValidator<AddNewTodoCommand>
    {
        public AddNewTodoCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please specify a description");
        }
    }
}