using System.ComponentModel.DataAnnotations;
using support_app.Persons;
using support_app.Projects;

namespace support_app.Tasks;

public class Duty
{
    public int Id { get; set; }
    [StringLength(50), Required]
    public String Name { get; set; }
    public String Description { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime? EndDate { get; set; } = null!;
    
    public int? ProjectId { get; set; }
    public Project? Project { get; set; } = null!;
    public Worker? Worker { get; set; }
    
}