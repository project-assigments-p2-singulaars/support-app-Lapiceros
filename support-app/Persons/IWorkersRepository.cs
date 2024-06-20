using Microsoft.AspNetCore.Mvc;

namespace support_app.Persons;

public interface IWorkersRepository
{
    Task<List<Worker>> GetAllWorkers();
    Task<string> CreateWorker(Worker workerDto);
    Task UpdateWorker(Worker worker);
    Task<bool> ExistWorker(int id);
    Task DeleteWorker(int id);
}
