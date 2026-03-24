using Lab3WPWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab3WPWebAPI.Services;

public class DbUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public DbUserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<ApplicationUser>> ReadAllAsync()
    {
        return await _db.Users.ToListAsync();
    }
}