using support_app.joinTable;

namespace support_app.Role;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ProjectWorkerRol> ProjectWorkerRoles { get; set; }
}