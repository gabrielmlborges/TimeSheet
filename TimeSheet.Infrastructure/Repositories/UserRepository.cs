using TimeSheet.Application.Interfaces;
using TimeSheet.Domain.Entities;
using TimeSheet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TimeSheet.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TimeSheetDbContext _context;

    public UserRepository(TimeSheetDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<User?> GetByIdAsync(Guid id) => await _context.Users.FindAsync(id);

    public async Task<bool> ExistsByEmailAsync(string email) => await _context.Users.AnyAsync(u => u.Email == email);

    public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
