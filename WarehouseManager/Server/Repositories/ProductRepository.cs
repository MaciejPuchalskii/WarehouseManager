using Microsoft.EntityFrameworkCore;
using WarehouseManager.Server.Data;
using WarehouseManager.Shared;

namespace WarehouseManager.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext) { this._appDbContext= appDbContext; }


        public async Task<List<Product>?> GetAllProducts()
        {
            return await _appDbContext.Products.OrderByDescending(p => p.Id).ToListAsync();
        }
        public async Task<Product?> GetProductById(int id)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<Product?> CreateNewProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }



        public async Task<List<Product>> SearchProduct(string text)
        {
            return await _appDbContext.Products.Where(p => p.Name.ToLower().Contains(text.ToLower())).ToListAsync();
        }
    }
}

