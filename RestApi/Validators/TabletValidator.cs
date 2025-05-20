using RestApi.Models;

namespace RestApi.Validators
{
    public class TabletValidator : ProductValidator
    {
        public TabletValidator()
        {
            requiredFields = RestApi.Utils.Constants.REQUIRED_FIELDS_TABLET;
        } 
        public bool validate(Product product)
        {
            return base.validate(product);
        }
    }
}
