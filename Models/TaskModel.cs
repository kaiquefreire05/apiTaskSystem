namespace TaskSystem.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; } // May be null
        public string? Tarefa { get; set; } // May be null
        public int Status { get; set; }
    }
}
