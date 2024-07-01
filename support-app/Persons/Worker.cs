using support_app.Tasks;

namespace support_app.Persons;

public class Worker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? TaskId { get; set; }
    public Duty? TaskAssigned { get; set; }
    
}