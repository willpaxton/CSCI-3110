using CSCI3110WPLab2CRRUD.Models.Entities;

namespace CSCI3110WPLab2CRRUD.Services;

public interface IProductRepository {
    Task<ICollection<Product>> ReadAllAsync();
    Task<Product> CreateAsync(Product newProduct);
}