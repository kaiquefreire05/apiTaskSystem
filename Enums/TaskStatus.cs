using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("In progress")]
        InProgress = 2,
        [Description("Concluded")]
        Concluded = 3
    }
}
