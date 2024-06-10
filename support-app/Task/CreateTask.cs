namespace support_app.Task;

public class CreateTask
{
    public int Id { set; get; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TaskStatus Status { get; set; }
}

public enum TaskStatus
{
    Pending,
    InProgress,
    Complete
}