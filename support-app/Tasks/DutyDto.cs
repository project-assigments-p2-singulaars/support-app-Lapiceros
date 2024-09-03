namespace support_app.Tasks;

public class DutyDto
{
    public int Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime? EndDate { get; set; } = null;
}