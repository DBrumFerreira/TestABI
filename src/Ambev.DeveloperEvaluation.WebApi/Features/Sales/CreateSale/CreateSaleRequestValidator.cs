using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for creating a sale.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - CustomerName: Required, length between 3 and 100 characters.
    /// - Branch: Required, length between 3 and 100 characters.
    /// - Products: Must contain at least one product.
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.CustomerName)
            .NotEmpty()
            .Length(3, 100).WithMessage("Customer name must be between 3 and 100 characters.");

        RuleFor(sale => sale.Branch)
            .NotEmpty()
            .Length(3, 100).WithMessage("Branch name must be between 3 and 100 characters.");

        RuleFor(sale => sale.SaleProducts)
            .NotEmpty().WithMessage("A sale must include at least one product.")
            .ForEach(product =>
            {
                product.SetValidator(new CreateSaleProductRequestValidator());
            });
    }
}