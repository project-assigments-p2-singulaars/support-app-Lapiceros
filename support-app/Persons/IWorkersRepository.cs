namespace support_app.Persons;

public interface IWorkersRepository
{
    Task<Worker> CreateWorker(CreateWorkerDto workerDto);
}
