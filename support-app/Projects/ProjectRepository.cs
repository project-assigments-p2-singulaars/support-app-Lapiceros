using Microsoft.EntityFrameworkCore;
using support_app.Data;

namespace support_app.Projects;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllProjects()
    {
        return await _context.Projects.ToListAsync();
    }


    public async Task<int> CreateProject(Project projectDto)
    {
        _context.Add(projectDto);
        await _context.SaveChangesAsync();
        return projectDto.Id;
    }

    public async Task UpdateProject(Project project)
    {
        _context.Update(project);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> ExistProject(int id)
    {
        return await _context.Projects.AnyAsync(x => x.Id == id);
    }

    public async Task Delete(int id)
    {
        await _context.Projects.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

}