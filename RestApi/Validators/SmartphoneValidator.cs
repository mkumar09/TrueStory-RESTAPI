using RestApi.Models;


namespace RestApi.Validators
{
    public class SmartphoneValidator : ProductValidator
    {
        public SmartphoneValidator()
        {
            requiredFields = RestApi.Utils.Constants.REQUIRED_FIELDS_SMARTPHONE;
        }
        public bool validate(Product product)
        {
            return base.validate(product);

        }
    }
    
}
