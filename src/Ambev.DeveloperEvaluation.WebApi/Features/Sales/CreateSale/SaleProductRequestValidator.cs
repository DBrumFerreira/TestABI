using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validator for individual products in a sale.
    /// </summary>
    public class SaleProductRequestValidator : AbstractValidator<SaleProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the SaleProductRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Product: Must be not null.
        /// - Quantity: Must be greater than 0 and not exceed 20.
        /// </remarks>
        public SaleProductRequestValidator()
        {
            RuleFor(product => product.Product)
                .NotNull().WithMessage("Product is required.");

            RuleFor(product => product.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                .LessThanOrEqualTo(20).WithMessage("Quantity cannot exceed 20.");
        }
    }
}
