namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the date and time the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time the product was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}

