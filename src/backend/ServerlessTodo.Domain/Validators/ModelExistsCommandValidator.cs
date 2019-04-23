using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using ServerlessTodo.Domain.Commands.Todo;
using ServerlessTodo.Domain.Repositories;

namespace ServerlessTodo.Domain.Validators
{
    public abstract class ModelExistsCommandValidator<TEntity> : AbstractValidator<ModelCommand<TEntity>> where TEntity : Models.Model
    {
        private readonly IReadOnlyRepository<TEntity> _modelRepository;

        protected ModelExistsCommandValidator(IReadOnlyRepository<TEntity> modelRepository)
        {
            _modelRepository = modelRepository;

            RuleFor(x => x.Id).MustAsync(ValidateId).WithMessage("Invalid Id");
        }

        private async Task<bool> ValidateId(Guid id, CancellationToken cancelationToken)
        {
            return await _modelRepository.Exists(id);
        }
    }
}