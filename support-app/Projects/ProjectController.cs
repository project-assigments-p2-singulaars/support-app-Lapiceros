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

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(IProjectRepository repository,
            CreateProjectDto projectDto)
        {
            var project = await repository.CreateProject(projectDto);
            return Ok(project);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProject(int id,[FromBody]Project project )
        {
            var modifiedProject = await _context.Projects.FindAsync(id);
            if (modifiedProject == null )
            {
                return NotFound();
            }

            modifiedProject.Name = project.Name;
            modifiedProject.Description = project.Description;
            modifiedProject.EndDateTime = project.EndDateTime;
            await _context.SaveChangesAsync();
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
