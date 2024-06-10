namespace support_app.Task;

public class Task
{
    public int Id { set; get; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TaskStatus Status { get; set; }
    
}

