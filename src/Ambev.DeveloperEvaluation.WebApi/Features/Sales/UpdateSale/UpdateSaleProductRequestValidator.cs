using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleProductRequestValidator : AbstractValidator<UpdateSaleProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleProductRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Product: Must be not null.
        /// - Quantity: Must be greater than 0.
        /// </remarks>
        public UpdateSaleProductRequestValidator()
        {
            RuleFor(product => product.Product)
                .NotNull().WithMessage("Product is required.");

            RuleFor(product => product.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
