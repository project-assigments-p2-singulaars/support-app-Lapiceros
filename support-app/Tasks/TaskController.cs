using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using support_app.Data;
using support_app.Tasks.Repository;

namespace support_app.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDutyRepository _dutyRepository;

        public TaskController(AppDbContext context, IMapper mapper, IDutyRepository dutyRepository)
        {
            _context = context;
            _mapper = mapper;
            _dutyRepository = dutyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DutyDto>>> GetAllProjects()
        {
            var duties = await _dutyRepository.GetAllTasks();
            return Ok(duties);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<DutyDto>>> GetIdTask(int id)
        {
            var task = await _dutyRepository.ExistTask(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateDutyDto dutydto)
        {
            var task = _mapper.Map<Duty>(dutydto);
            await _dutyRepository.CreateTask(task);
            return Ok(task);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id,[FromBody]CreateDutyDto dutyDto)
        {
            var task = await _context.Duties.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _mapper.Map(dutyDto, task);
            await _dutyRepository.UpdateTask(task);
            return Ok(task);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = await _context.Duties.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            await _dutyRepository.DeleteTask(task.Id);
            return NoContent();
        }
        
    }
}
