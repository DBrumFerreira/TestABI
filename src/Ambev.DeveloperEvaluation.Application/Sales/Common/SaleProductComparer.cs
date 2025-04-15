using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Common;

public class SaleProductComparer : IEqualityComparer<SaleProduct?>
{
    /// <summary>
    /// Determines whether the specified SaleProduct saleProductects are equal.
    /// </summary>
    /// <param name="originalSaleProduct">The first SaleProduct to compare.</param>
    /// <param name="updatedSaleProduct">The second SaleProduct to compare.</param>
    /// <returns>true if the specified SaleProduct saleProductects are equal; otherwise, false.</returns>
    public bool Equals(SaleProduct? originalSaleProduct, SaleProduct? updatedSaleProduct)
    {
        if (ReferenceEquals(originalSaleProduct, updatedSaleProduct)) return true;
        if (originalSaleProduct == null || updatedSaleProduct == null) return false;

        return originalSaleProduct.ProductId == updatedSaleProduct.ProductId &&
               originalSaleProduct.Quantity == updatedSaleProduct.Quantity;
    }

    /// <summary>
    /// Returns a hash code for the specified SaleProduct.
    /// </summary>
    /// <param name="saleProduct">The SaleProduct for which a hash code is to be returned.</param>
    /// <returns>A hash code for the specified SaleProduct, suitable for use in hashing algorithms and data structures like a hash table.</returns>
    public int GetHashCode(SaleProduct? saleProduct)
    {
        if (saleProduct == null) return 0;

        return HashCode.Combine(saleProduct.ProductId, saleProduct.Quantity);
    }
}