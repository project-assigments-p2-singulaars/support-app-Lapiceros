using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using support_app.Data;

namespace support_app.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public ProjectController(AppDbContext context, IProjectRepository projectRepository, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ProjectDto>>> GetIdProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();

            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDto createProjectDto)
        {
            var project = _mapper.Map<Project>(createProjectDto);
            await _projectRepository.CreateProject(project);
            return Ok(project);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct([FromBody]CreateProjectDto updateProjectDto)
        {
            var project = _mapper.Map<Project>(updateProjectDto);
            await _projectRepository.UpdateProject(project);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
