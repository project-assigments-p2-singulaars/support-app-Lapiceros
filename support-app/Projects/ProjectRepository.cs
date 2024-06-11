using support_app.Data;

namespace support_app.Projects;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Project> CreateProject(CreateProjectDto createProjectDto)
    {
        var project = new Project
        {
            Name = createProjectDto.Name,
            Description = createProjectDto.Description,
            InitDate = createProjectDto.InitDate,
            EndDateTime = createProjectDto.EndDateTime
        };
        _context.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }
}