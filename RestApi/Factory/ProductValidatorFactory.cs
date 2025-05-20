using RestApi.Models;
using RestApi.Utils;
using RestApi.Validators;

namespace RestApi.Factory
{
    public class ProductValidatorFactory : IProductValidatorFactory
    {
        public IProductValidator createValidator(Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.name) || string.IsNullOrWhiteSpace(product.name))
            {
                throw new ArgumentNullException("Product and Product name can't be null or empty!");
            }

            Category category = findProductCategory(product);
            switch (category)
            {
                case Category.SMARTPHONE:
                    return new SmartphoneValidator();
                case Category.HEADPHONE:
                    return new HeadphoneValidator();
                case Category.LAPTOP:
                    return new LaptopValidator();
                case Category.TABLET:
                    return new TabletValidator();
                case Category.SMARTWATCH:
                    return new SmartwatchValidator();
                default:
                    throw new NotSupportedException($"No validator found for category: {category}, update constants.cs file to handle more keywords");
            }
        }

        // This method finds the category of the product based on the keywords in the name.
        // Keywords are defined in the Constants.cs class.
        public Category findProductCategory(Product product)
        {
            string[] keyWords = product.name.Split(' ');
            foreach (var keyword in keyWords)
            {
                string lowerKeyword = keyword.ToLower();
                switch (lowerKeyword)
                {
                    case var _ when Constants.SMARTPHONE.Contains(lowerKeyword):
                        return Category.SMARTPHONE;
                    case var _ when Constants.HEADPHONE.Contains(lowerKeyword):
                        return Category.HEADPHONE;
                    case var _ when Constants.LAPTOP.Contains(lowerKeyword):
                        return Category.LAPTOP;
                    case var _ when Constants.TABLET.Contains(lowerKeyword):
                        return Category.TABLET;
                    case var _ when Constants.SMARTWATCH.Contains(lowerKeyword):
                        return Category.SMARTWATCH;
                }
            }
            return Category.OTHER;
        }
    }
}
