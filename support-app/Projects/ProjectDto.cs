namespace support_app.Projects;

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime? EndDateTime { get; set; }
}