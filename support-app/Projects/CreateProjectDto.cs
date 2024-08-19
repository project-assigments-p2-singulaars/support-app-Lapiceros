namespace support_app.Projects;

public class CreateProjectDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime? EndDateTime { get; set; }
}