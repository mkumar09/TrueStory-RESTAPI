using RestApi.Models;

namespace RestApi.Validators
{
    public class SmartwatchValidator : ProductValidator
    {
        public SmartwatchValidator()
        {
            requiredFields = RestApi.Utils.Constants.REQUIRED_FIELDS_SMARTWATCH;
        }
        public bool validate(Product product)
        {
            return base.validate(product);

        }
    }
}
