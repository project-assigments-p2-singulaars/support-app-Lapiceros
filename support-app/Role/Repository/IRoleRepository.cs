namespace support_app.Role.Repository;

public interface IRoleRepository
{
    Task<List<Role>> GetAllRoles();
    Task<Role> CreateProject(Role roleDto);
    Task<bool> ExistRole(int id);
    Task UpdateProject(Role role);
}