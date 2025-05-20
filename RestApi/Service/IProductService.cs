using RestApi.Models;

namespace RestApi.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> getProductsByNameandPage(string? search, int page = 1, int pageSize = 10);

        Task<Product> addProduct(Product product);

        Task<DeleteResponse> deleteProduct(String id);
    }
}