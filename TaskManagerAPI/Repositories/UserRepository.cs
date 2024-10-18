using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task Create(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
