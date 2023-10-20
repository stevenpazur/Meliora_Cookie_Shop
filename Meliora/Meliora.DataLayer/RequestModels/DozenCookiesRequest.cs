using Meliora.BusinessLayer.shared;
using Meliora.DataLayer.Model;

namespace Meliora.DataLayer.RequestModels
{
    public class DozenCookiesRequest : BaseRequestModel<IEnumerable<Product>>
    {
        public IEnumerable<BaseProductRequest> Dozens { get; set; }
        public int CustomerId { get; set; }

        public class BaseProductRequest
        {
            public int Quantity { get; set; }
            public int ProductId { get; set; }
            public ICollection<int> MixinIds { get; set; }
        }

        public override IEnumerable<OptionListValue<RequestErrors>> GetPossibleRequestErrors()
        {
            var options = new List<OptionListValue<RequestErrors>>() { };
            options.Add(new OptionListValue<RequestErrors>() { DisplayValue = "Order is not a dozen", Value = RequestErrors.NotADozen, Id = (int)RequestErrors.NotADozen });
            options.Add(new OptionListValue<RequestErrors>() { DisplayValue = "Cart cannot be empty", Value = RequestErrors.CookiesRequired, Id = (int)RequestErrors.CookiesRequired });
            return options;
        }

        public override IEnumerable<Product> Map()
        {
            var toReturn = new List<Product> { };
            foreach (var lineItem in Dozens)
            {
                toReturn.Add(new Product());
            }
            return toReturn;
        }

        private int TotalQuantity()
        {
            var quantity = 0;
            foreach (BaseProductRequest pr in Dozens)
            {
                quantity += pr.Quantity;
            }
            return quantity;
        }

        protected override IEnumerable<OptionListValue<RequestErrors>>? DoValidation()
        {
            var validations = new List<OptionListValue<RequestErrors>>();

            var defaultValue = new OptionListValue<RequestErrors>()
            {
                Id = 0,
                DisplayValue = "Unexpected Error",
                Value = RequestErrors.UnexpectedError
            };

            if (TotalQuantity() % 12 != 0)
            {
                validations.Add(GetPossibleRequestErrors().FirstOrDefault(x => x.Value == RequestErrors.NotADozen) ?? defaultValue);
            }

            if (validations.Any())
            {
                return validations;
            }
            return null;
        }
    }
}
