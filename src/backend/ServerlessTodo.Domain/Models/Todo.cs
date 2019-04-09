namespace ServerlessTodo.Domain.Models
{
    public class Todo : Model
    {
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}