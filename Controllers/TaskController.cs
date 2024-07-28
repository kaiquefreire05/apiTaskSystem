using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // Access to database methods

        private readonly ITaskRepository _taskRep;
        public TaskController(ITaskRepository taskRep)
        {
            _taskRep = taskRep;
        }

        // API methods
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> SearchAllTasks()
        {
            List<TaskModel> allTasks = await _taskRep.SearchAllTasks();
            return Ok(allTasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> FindById(int id)
        {
            TaskModel task = await _taskRep.FindTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRep.AddTask(taskModel);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRep.UpdateTask(taskModel, id);
            return Ok(task);
        }

        [HttpDelete]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            bool delete = await _taskRep.DeleteTask(id);
            return Ok(delete);
        }

    }
}
