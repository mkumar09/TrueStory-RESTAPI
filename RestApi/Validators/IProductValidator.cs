using RestApi.Models;

namespace RestApi.Validators
{
    public interface IProductValidator
    {
        bool validate(Product product);
    }
}
