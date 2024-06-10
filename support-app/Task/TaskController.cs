using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using support_app.Data;

namespace support_app.Task
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Task>>> GetAllTasks()
        {
            var jobs = await _context.Tasks.ToListAsync();
            return Ok(jobs);
        }

        [HttpPost]
        public async Task<ActionResult<Task>> CreateTask(CreateTask createTask)
        {
            var newTask = new Task
            {
                Name = createTask.Name,
                Description = createTask.Description,
                Status = createTask.Status
            };
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
            return Ok(newTask);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTask(int id, [FromBody] Task task)
        {
            var modifiedTask = await _context.Tasks.FindAsync(id);
            if (modifiedTask == null)
            {
                return NotFound();
            }

            modifiedTask.Name = task.Name;
            modifiedTask.Description = task.Description;
            modifiedTask.Status = task.Status;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
