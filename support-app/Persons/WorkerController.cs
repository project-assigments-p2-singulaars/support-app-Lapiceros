using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using support_app.Data;

namespace support_app.Persons
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Worker>>> GetAllWorkers()
        {
            var workers = await _context.Workers.ToListAsync();
            return Ok(workers);
        }

        [HttpPost]
        public async Task<ActionResult<Worker>> CreateWorker(IWorkersRepository repository, CreateWorkerDto workerDto)
        {
            var worker = await repository.CreateWorker(workerDto);
            return Ok(worker);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateWorker(int id, [FromBody] Worker worker)
        {
            var modifiedWorker = await _context.Workers.FindAsync(id);
            if (modifiedWorker == null)
            {
                return NotFound();
            }

            modifiedWorker.Name = worker.Name;
            modifiedWorker.Rol = worker.Rol;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteWorker(int id)
        {
            var deletedWorker= await _context.Workers.FindAsync(id);
            if (deletedWorker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(deletedWorker);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
