namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleProductRequest
{
    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Gets or sets the product being sold.
    /// </summary>
    public UpdateProductRequest? Product { get; set; } = null;
}
