using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Task>> GetAll()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Task> GetById(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task Create(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var task = await GetById(id);
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}
