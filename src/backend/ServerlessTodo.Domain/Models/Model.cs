using System;

namespace ServerlessTodo.Domain.Models
{
    public abstract class Model
    {
        public Guid Id { get; set; }
    }
}