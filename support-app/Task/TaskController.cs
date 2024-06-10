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
        
    }
}
