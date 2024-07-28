using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> SearchAllTasks();
        Task<TaskModel> FindTaskById(int id);
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int id);
        Task<bool> DeleteTask(int id);
    }
}
