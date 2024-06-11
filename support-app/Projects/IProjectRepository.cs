namespace support_app.Projects;

public interface IProjectRepository
{
    Task<Project> CreateProject(CreateProjectDto createProjectDto);
}