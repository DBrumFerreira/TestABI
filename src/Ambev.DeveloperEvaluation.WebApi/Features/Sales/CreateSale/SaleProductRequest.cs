namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class SaleProductRequest
{
    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the product being sold.
    /// </summary>
    public ProductRequest? Product { get; set; } = null;
}
