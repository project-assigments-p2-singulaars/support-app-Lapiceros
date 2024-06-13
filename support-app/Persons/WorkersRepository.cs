using support_app.Data;

namespace support_app.Persons;

public class WorkersRepository : IWorkersRepository
{
   private readonly AppDbContext _context;

   public WorkersRepository(AppDbContext context)
   {
      _context = context;
   }

   public async Task<Worker> CreateWorker(CreateWorkerDto workerDto)
   {
      var worker = new Worker
      {
         Name = workerDto.Name,
         Rol = workerDto.Rol
      };
      _context.Add(worker);
      await _context.SaveChangesAsync();
      return worker;
   }
}