using CSCI3110WPLab2CRRUD.Models.Entities;

namespace CSCI3110WPLab2CRRUD.Services;

public interface IProductRepository {
    Task<ICollection<Product>> ReadAllAsync();
    Task<Product> CreateAsync(Product newProduct);
    Task<Product> ReadAsync(int id);
    Task UpdateAsync(int oldId, Product product);
    Task DeleteAsync(int id);
}