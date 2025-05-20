using RestApi.Models;

namespace RestApi.Validators
{
    public class HeadphoneValidator : ProductValidator
    {
        public HeadphoneValidator()
        {
            requiredFields = RestApi.Utils.Constants.REQUIRED_FIELDS_HEADPHONE;
        }
        public bool validate(Product product)
        {
            return base.validate(product);

        }
    }
}
