using RestApi.Factory;
using RestApi.Models;
using RestApi.Validators;
using System.Collections.Generic;

namespace RestApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IProductValidatorFactory _productValidatorFactory;

        public ProductService(IHttpClientFactory httpClientFactory, IProductValidatorFactory productValidatorFactory)
        {
            _httpClientFactory = httpClientFactory;
            _productValidatorFactory = productValidatorFactory;
        }

        public async Task<IEnumerable<Product>> getProductsByNameandPage(string? search, int page = 1, int pageSize = 10)
        {
            try
            {
                //get all products from API
                IEnumerable<Product> products = await GetProducts();
                if (!string.IsNullOrWhiteSpace(search))
                {
                    // Filter products by name, page no and page size
                    products = products.Where(p => p.name != null && p.name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize); ;
                }    
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products from API: {ex.Message}");
                throw ex;
            }
        }

        public async Task<Product> addProduct(Product product)
        {
            try
            {
                // Validate the product object using the appropriate validator from the factory
                IProductValidator productValidator = _productValidatorFactory.createValidator(product);
                // Validate the product object against the rules defined in the validator
                bool isValid = productValidator.validate(product);
                if (isValid)
                {
                    var client = _httpClientFactory.CreateClient();

                    // Serialize the product object to JSON content
                    var jsonContent = new StringContent(
                        System.Text.Json.JsonSerializer.Serialize(product),
                        System.Text.Encoding.UTF8,
                        "application/json"
                    );

                    var response = await client.PostAsync("https://api.restful-api.dev/objects", jsonContent);
                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();
                    var products = System.Text.Json.JsonSerializer.Deserialize<Product>(json, new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return products!=null? products:new Product();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding products from API: {ex.Message}");
                throw ex;
            }

            return new Product();
        }

        public async Task<DeleteResponse> deleteProduct(String id)
        {
            try
            {
                    var client = _httpClientFactory.CreateClient();
                    var response = await client.DeleteAsync($"https://api.restful-api.dev/objects/{id}");
                    var json = await response.Content.ReadAsStringAsync();
                    var deleteResponse = System.Text.Json.JsonSerializer.Deserialize<DeleteResponse>(json, new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if (deleteResponse == null)
                        throw new Exception("Error deleting product from API: Response is null.");

                    // Check for errors in the response
                    if (deleteResponse.error != null)
                        throw new HttpRequestException(deleteResponse.error);

                return deleteResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting products from API: {ex.Message}");
                throw ex;
            }
        }

        private async Task<IEnumerable<Product>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://api.restful-api.dev/objects");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var products = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Product>>(json, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return products ?? Enumerable.Empty<Product>();

        }
    }
}
