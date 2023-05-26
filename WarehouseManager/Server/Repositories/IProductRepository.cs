using WarehouseManager.Shared;

namespace WarehouseManager.Server.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>?> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<Product?> CreateNewProduct(Product product);
        Task<List<Product>> SearchProduct(string text);
    }
}
