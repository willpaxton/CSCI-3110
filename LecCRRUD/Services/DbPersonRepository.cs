using LecCRRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LecCRRUD.Services;

public class DbPersonRepository : IPersonRepository {
    private readonly ApplicationDbContext _db;

// inject applicationdbcontext into the repo (this is probably going to be an exam question!)
    public DbPersonRepository(ApplicationDbContext db) 
    {
        _db = db;
    }

    public async Task<ICollection<Person>> ReadAllAsync()
    {
        return await _db.People.ToListAsync();
    }

}