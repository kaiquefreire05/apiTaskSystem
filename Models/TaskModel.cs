namespace TaskSystem.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Name { get; set; } // May be null
        public string? Desc { get; set; } // May be null
        public TaskStatus Status { get; set; }
        public int? UserId { get; set; }
        public virtual UserModel? User { get; set; }
    }
}
