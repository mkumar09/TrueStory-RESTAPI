using RestApi.Models;

namespace RestApi.Validators
{
    public class LaptopValidator : ProductValidator
    {
        public LaptopValidator()
        {
            requiredFields = RestApi.Utils.Constants.REQUIRED_FIELDS_LAPTOP;
        }
        public bool validate(Product product)
        {
            return base.validate(product);

        }
    }
}
