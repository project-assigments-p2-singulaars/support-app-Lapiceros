using System.Drawing;
using support_app.joinTable;
using support_app.Tasks;

namespace support_app.Persons;

public class Worker
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Duty> Tasks { get; set; }
    public ICollection<ProjectWorkerRol> ProjectWorkerRoles { get; set; }
    
}