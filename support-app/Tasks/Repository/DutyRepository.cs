using Microsoft.EntityFrameworkCore;
using support_app.Data;

namespace support_app.Tasks.Repository; 

public class DutyRepository : IDutyRepository
{
    private readonly AppDbContext _context;

    public DutyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Duty>> GetAllTasks()
    {
        return await _context.Duties.ToListAsync();
        
    }

    public async Task<int> CreateTask(Duty dutyDto)
    {
        _context.Add(dutyDto);
        await _context.SaveChangesAsync();
        return dutyDto.Id;
    }

    public async Task UpdateTask(Duty updateDuty)
    {
        _context.Update(updateDuty);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistTask(int id)
    {
        return await _context.Duties.AnyAsync(x => x.Id == id);
    }


    public async Task DeleteTask(int id)
    {
        await _context.Duties.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}
