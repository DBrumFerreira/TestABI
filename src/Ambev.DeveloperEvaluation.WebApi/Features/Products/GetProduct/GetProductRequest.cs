using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Request model for getting a Product by ID
/// </summary>
public class GetProductRequest
{
    /// <summary>
    /// The unique identifier of the Product to retrieve
    // Require that the Id is not null.
    // Use custom validation error.
    /// </summary>
    [Required(ErrorMessage = "Id is required.")]
    public Guid Id { get; set; }
}