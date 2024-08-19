using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using support_app.Data;

namespace support_app.Persons
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkersRepository _workersRepository;

        public WorkerController(AppDbContext context, IMapper mapper, IWorkersRepository workersRepository)
        {
            _context = context;
            _mapper = mapper;
            _workersRepository = workersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Worker>>> GetAllWorkers()
        {
            var workers = await _workersRepository.GetAllWorkers();
            return Ok(workers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorker(CreateWorkerDto workerDto)
        {
            var worker = _mapper.Map<Worker>(workerDto);
            await _workersRepository.CreateWorker(worker);
            return Ok(worker);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateWorker(int id, [FromBody] CreateWorkerDto worker)
        {
            var modifiedWorker = await _context.Workers.FindAsync(id);
            if (modifiedWorker == null)
            {
                return NotFound();
            }

            _mapper.Map(worker, modifiedWorker);
            await _workersRepository.UpdateWorker(modifiedWorker);
            return Ok(modifiedWorker);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteWorker(int id)
        {
            var deletedWorker= await _context.Workers.FindAsync(id);
            if (deletedWorker == null)
            {
                return NotFound();
            }

            await _workersRepository.DeleteWorker(deletedWorker.Id);
            return NoContent();
        }
        
    }
}
