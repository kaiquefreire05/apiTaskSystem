using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        // Inject database dependency
        private readonly TaskSystemDBContext _context;

        public TaskRepository(TaskSystemDBContext context)
        {
            _context = context;
        }

        // Methods
        public async Task<TaskModel> FindTaskById(int id)
        {
            return await _context.Tasks
                .Include(x => x.User)  // Trazendo o usuário indexado (se tiver)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> SearchAllTasks()
        {
            return await _context.Tasks
                .Include(x => x.User) // Trazendo o usuário indexado (se tiver)
                .ToListAsync();
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel task = await FindTaskById(id);
            if (task == null)
            {
                throw new Exception($"The task with ID: {id} is not found in database");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
          
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel findTask = await FindTaskById(id);
            if (findTask == null)
            {
                throw new Exception($"The task with ID: {id} is not found in database");
            }

            // Updating attributes
            findTask.Name = task.Name;
            findTask.Desc = task.Desc;
            findTask.Status = task.Status;
            findTask.UserId = task.UserId;

            _context.Tasks.Update(findTask);
            await _context.SaveChangesAsync();
            return findTask;

        }

    }
}
