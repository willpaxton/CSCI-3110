using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
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
        return await _db.Products.ToListAsync();
    }

    public async Task<Product> CreateAsync(Product newProduct)
    {
        await _db.Products.AddAsync(newProduct);
        await _db.SaveChangesAsync();
        return newProduct;
    }

    public async Task<Product> ReadAsync(int id)
    {
        return await _db.Products.FindAsync(id);
    }

    public async Task UpdateAsync(int oldId, Product product)
    {
        var productToUpdate = await ReadAsync(oldId);
        if (productToUpdate != null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.WeightInPounds = product.WeightInPounds;
            productToUpdate.ManufactureDate = product.ManufactureDate;
            productToUpdate.InStock = product.InStock;
            if (product.ImageData != null && product.ImageMIMEType != null)
            {
                productToUpdate.ImageData = product.ImageData;
                productToUpdate.ImageMIMEType = product.ImageMIMEType;
            }
            await _db.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var productToDelete = await ReadAsync(id);
        if (productToDelete != null)
        {
            _db.Products.Remove(productToDelete);
            await _db.SaveChangesAsync();
        }
    }
}