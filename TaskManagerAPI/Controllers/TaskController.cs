using Microsoft.EntityFrameworkCore;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskDTO>> GetTasks(TaskFilterDTO filter)
    {
        var query = _context.Tasks.AsQueryable();

        if (filter.Status.HasValue)
        {
            query = query.Where(t => t.Status == filter.Status.Value);
        }

        if (filter.CategoryId.HasValue)
        {
            query = query.Where(t => t.CategoryId == filter.CategoryId.Value);
        }

        if (filter.DueDate.HasValue)
        {
            query = query.Where(t => t.DueDate.Date == filter.DueDate.Value.Date);
        }

        return await query.Select(t => new TaskDTO
        {
            Title = t.Title,
            Description = t.Description,
            DueDate = t.DueDate,
            Status = t.Status,
            CategoryId = t.CategoryId
        }).ToListAsync();
    }

    public async Task<TaskDTO> CreateTask(TaskDTO taskDTO)
    {
        var task = new Task
        {
            Title = taskDTO.Title,
            Description = taskDTO.Description,
            DueDate = taskDTO.DueDate,
            Status = taskDTO.Status,
            CategoryId = taskDTO.CategoryId
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return taskDTO;
    }
}
