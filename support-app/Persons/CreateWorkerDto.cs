namespace support_app.Persons;

public class CreateWorkerDto
{
    public string Name { get; set; }
    public Rol Rol { get; set; }
}

public enum Rol
{
    ScrumMaster,
    Developer,
    ProductOwner
}