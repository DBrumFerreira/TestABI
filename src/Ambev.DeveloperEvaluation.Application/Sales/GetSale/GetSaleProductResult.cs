namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale product relationship.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the sale this product is associated with.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the product being sold.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product at the time of sale.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the total amount for the product (after applying the discount).
    /// </summary>
    public decimal TotalItemAmount { get; set; }
}
