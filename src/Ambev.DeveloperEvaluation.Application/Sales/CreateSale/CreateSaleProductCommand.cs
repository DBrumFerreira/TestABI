namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProductCommand
{
    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the product being sold.
    /// </summary>
    public ProductCommand? Product { get; set; } = null;
}
