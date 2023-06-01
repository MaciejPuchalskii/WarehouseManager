using System.Net.Http.Json;
using WarehouseManager.Shared;

namespace WarehouseManager.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Product>?> GetAllProducts()
        {
            return await httpClient.GetFromJsonAsync<List<Product>>("api/Products");
        }
        public async Task<Product?> GetProductById(int id)
        {
            var result = await httpClient.GetAsync($"api/Blog/{id}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var mess = await result.Content.ReadAsStringAsync();
                Console.WriteLine(mess);
                return new Product { Name = mess };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Product>();
            }
        }
        public async Task<Product?> CreateNewProduct(Product product)
        {
            var result = await httpClient.PostAsJsonAsync("api/Products", product);
            return await result.Content.ReadFromJsonAsync<Product>();
        }


        public async Task<Product?> UpdateProduct(int id, Product product)
        {
            var result = await httpClient.PutAsJsonAsync($"api/Products/{id}", product);
            return await result.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result = await httpClient.DeleteAsync($"api/Products/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<List<Product?>> SearchProduct(string text)
        {
            return await httpClient.GetFromJsonAsync<List<Product>>($"api/Product/search/{text}");
        }
    }
}
