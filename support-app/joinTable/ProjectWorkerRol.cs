using support_app.Persons;
using support_app.Projects;

namespace support_app.joinTable;

public class ProjectWorkerRol
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    
    public int WorkerId { get; set; }
    public Worker Worker { get; set; }
    
    public int RoleId { get; set; }
    public Role.Role Role { get; set; }
}