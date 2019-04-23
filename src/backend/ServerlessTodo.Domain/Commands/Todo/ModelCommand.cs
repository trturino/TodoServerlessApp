using System;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace ServerlessTodo.Domain.Commands.Todo
{
    public abstract class ModelCommand<TEntity> : ICommand where TEntity : Models.Model
    {
        public Guid Id { get; set; }
    }
}