using CSCI3110WPLab2CRRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI3110WPLab2CRRUD.Services;

public class DbProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;

    public DbProductRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<Product>> ReadAllAsync()
    {
        return await _db.Product.ToListAsync();
    }
}