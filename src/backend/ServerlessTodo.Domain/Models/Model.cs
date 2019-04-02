using System;
namespace ServerlessTodo.Domain.Models
{
    public class Model
    {
        public Guid Id { get; set; }

        public bool Completed { get; set; }
    }
}
