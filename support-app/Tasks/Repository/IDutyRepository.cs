namespace support_app.Tasks.Repository;

public interface IDutyRepository
{ 
    Task<List<Duty>> GetAllTasks();
    Task<int> CreateTask(Duty dutydto);
    Task UpdateTask(Duty duty);
    Task<bool> ExistTask(int id);
    Task DeleteTask(int id);
    

}