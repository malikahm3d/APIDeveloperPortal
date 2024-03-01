using APIDeveloperPortal.Client.Models;

namespace APIDeveloperPortal.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Product[]> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<Product[]>("https://localhost:7056/api/Products");
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"https://localhost:7056/api/Products/{id}");
        }

        public async Task UpdateProduct(int id, Product product)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7056/api/Products//{id}", product);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7056/api/Products", product);
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7056/api/Products/{id}");
        }

        public async Task<bool> ProductExists(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7056/api/Products/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
