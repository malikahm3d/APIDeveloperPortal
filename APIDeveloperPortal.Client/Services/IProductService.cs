using APIDeveloperPortal.Client.Models;

namespace APIDeveloperPortal.Client.Services
{
    public interface IProductService
    {
        Task<Product[]> GetProducts();
        Task<Product> GetProductById(int id);
        Task UpdateProduct(int id, Product product);
        Task<Product> CreateProduct(Product product);
        Task DeleteProduct(int id);
        Task<bool> ProductExists(int id);
    }
}
