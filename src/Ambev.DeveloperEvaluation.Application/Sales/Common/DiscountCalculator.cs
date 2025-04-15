using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Common;

public class DiscountCalculator
{
    /// <summary>
    /// Calculates the discount and total values for a sale product.
    /// </summary>
    /// <param name="saleProduct">The sale product to calculate values for.</param>
    /// <remarks>
    /// Calculation rules include:
    /// - TotalItemAmount:
    ///     - Calculated as UnitPrice multiplied by Quantity.
    /// - Discount:
    ///     - 20% discount applied if Quantity is between 10 and 20 (inclusive).
    ///     - 10% discount applied if Quantity is between 4 and 9 (inclusive).
    ///     - No discount is applied if Quantity is less than 4.
    /// - Final TotalItemAmount:
    ///     - Discount is subtracted from the TotalItemAmount.
    /// </remarks>
    public static void Calculate(SaleProduct saleProduct)
    {
        saleProduct.TotalItemAmount += saleProduct.UnitPrice * saleProduct.Quantity;

        bool between10And20Items = saleProduct.Quantity >= 10 && saleProduct.Quantity <= 20;
        if (between10And20Items)
            saleProduct.Discount = saleProduct.TotalItemAmount * 0.2m;

        bool between4And9Items = saleProduct.Quantity >= 4 && saleProduct.Quantity <= 9;
        if (between4And9Items)
            saleProduct.Discount = saleProduct.TotalItemAmount * 0.1m;

        saleProduct.TotalItemAmount -= saleProduct.Discount;
    }
}
