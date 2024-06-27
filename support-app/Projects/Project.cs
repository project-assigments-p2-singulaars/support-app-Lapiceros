using System.ComponentModel.DataAnnotations;
using support_app.Tasks;

namespace support_app.Projects;

public class Project
{
    public int Id { get; set; }
    [StringLength(50), Required]
    public string Name { get; set; }
    [StringLength(500), Required]
    public string Description { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime? EndDateTime { get; set; } = null!;
    
    public ICollection<Duty> SupportTask { get; set; } = new List<Duty>();
}