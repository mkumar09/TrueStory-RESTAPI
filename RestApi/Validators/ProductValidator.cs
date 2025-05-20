using RestApi.Models;

namespace RestApi.Validators
{
    public class ProductValidator : IProductValidator
    {
        // This array contains the required fields for the product validation.
        // each specific validator will override this array with its own required fields.
        public string[] requiredFields;

        public ProductValidator()
        {
            requiredFields = new string[] { };
        }

        // This method validates the product object against the required fields.
        // All child classes can override this method to add their own specific validation rules in future.
        public bool validate(Product product)
        {
            if (product.data == null || product.data.Count == 0)
                throw new ArgumentException("Product data cannot be null or empty.");

            foreach (var field in requiredFields)
            {
                if (!product.data.Keys.Any(k => string.Equals(k, field, StringComparison.OrdinalIgnoreCase)))
                    throw new ArgumentException($"Product data must contain the field: {field}.");
            }
            return true;
        }
    }
}
