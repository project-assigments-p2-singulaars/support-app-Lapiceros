namespace support_app.Projects;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllProjects();
    Task<int> CreateProject(Project createProjectDto);
    Task UpdateProject(Project project);
    Task<bool> ExistProject(int id);
    Task Delete(int id);


}