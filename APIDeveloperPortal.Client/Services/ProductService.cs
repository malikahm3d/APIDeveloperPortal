using APIDeveloperPortal.Client.Models;

namespace APIDeveloperPortal.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        public async Task<Product[]> GetProducts()
        {
            Product[] products;
            products =  await _httpClient.GetFromJsonAsync<Product[]>("https://localhost:7056/api/Products");
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var encodedId = Uri.EscapeDataString(id.ToString());

            Product p = new Product();
            for (int retry = 0; retry < 3; retry++)
            {
                try
                {
                    var response = await _httpClient.GetAsync($"https://localhost:7056/api/Products/{encodedId}");
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadFromJsonAsync<Product>();
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    Console.WriteLine($"Retry {retry + 1}: {ex.Message}");
                    await Task.Delay(30);
                }
            }
            return p;
        }

        public async Task UpdateProduct(int id, Product product)
        {
            var result = await _httpClient.PutAsJsonAsync($"https://localhost:7056/api/Products/{id}", product);
            if (true)
            {

            }
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
