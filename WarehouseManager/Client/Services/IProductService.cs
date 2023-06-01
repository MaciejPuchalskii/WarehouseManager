using WarehouseManager.Shared;

namespace WarehouseManager.Client.Services
{
    public interface IProductService
    {
        Task<List<Product>?> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<Product?> CreateNewProduct(Product product);
        Task<List<Product>> SearchProduct(string text);
        Task<bool> DeleteProduct(int id);

    }
}
