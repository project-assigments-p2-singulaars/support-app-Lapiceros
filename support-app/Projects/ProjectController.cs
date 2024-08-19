using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
        {
            var projects = await _projectRepository.GetAllProjects();
            var projectsDto = _mapper.Map<IEnumerable<Project>>(projects);
            return Ok(projectsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ProjectDto>>> GetIdProject(int id)
        {
            var project = await _projectRepository.ExistProject(id);
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
        public async Task<ActionResult> UpdateProduct(int id,[FromBody]CreateProjectDto createProjectDto)
        {

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _mapper.Map(createProjectDto, project);
            await _projectRepository.UpdateProject(project);
            return Ok(project); 
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            await _projectRepository.Delete(project.Id);
            return NoContent();
        }
        
    }
}
