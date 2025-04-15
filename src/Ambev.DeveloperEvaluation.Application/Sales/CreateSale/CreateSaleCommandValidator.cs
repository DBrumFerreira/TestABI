using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for UpdateSaleCommand
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleProducts: Cannot be empty and must contain at least one product.
    /// - Product: Each product in the sale must be valid and not null.
    /// - Quantity: 
    ///     - Must be greater than 0 (minimum required quantity).
    ///     - Must be less than or equal to 20 (maximum allowed quantity).
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.SaleProducts)
                .NotEmpty()
                .WithMessage(x => $"The sale needs at least 1 product.");

        RuleFor(x => x.SaleProducts)
        .NotEmpty()
        .WithMessage("The sale needs at least 1 product.")
        .ForEach(productRule =>
        {
            productRule.Must(product => product.Product != null)
                       .WithMessage("Each product in the sale must be valid and not null.");

            productRule
            .Must(product => product.Quantity > 0)
            .WithMessage("The minimum quantity for each product must be greater than 0.");

            productRule
                .Must(product => product.Quantity <= 20)
                .WithMessage("The maximum quantity for each product must be 20.");
        });
    }
}
