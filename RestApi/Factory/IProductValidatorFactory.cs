using RestApi.Models;
using RestApi.Validators;

namespace RestApi.Factory
{
    public interface IProductValidatorFactory
    {
        IProductValidator createValidator(Product product);
    }
}
