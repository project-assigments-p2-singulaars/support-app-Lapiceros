using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using support_app.Data;

namespace support_app.Persons;

public class WorkersRepository : IWorkersRepository
{
   private readonly AppDbContext _context;

   public WorkersRepository(AppDbContext context)
   {
      _context = context;
   }


   public async Task<List<Worker>> GetAllWorkers()
   {
      return await _context.Workers.ToListAsync();
   }

   public async Task<string> CreateWorker(Worker workerDto)
   {
      _context.Add(workerDto);
      await _context.SaveChangesAsync();
      return workerDto.Name;
   }

   public async Task UpdateWorker(Worker worker)
   {
      _context.Update(worker);
      await _context.SaveChangesAsync();
   }

   public async Task<bool> ExistWorker(int id)
   {
      return await _context.Workers.AnyAsync(x => x.Id == id);
   }

   public async Task DeleteWorker(int id)
   {
      await _context.Workers.Where(x => x.Id == id).ExecuteDeleteAsync();
   }
}