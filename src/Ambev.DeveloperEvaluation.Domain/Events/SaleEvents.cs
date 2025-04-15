using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public static class SaleEvents
    {
        /// <summary>
        /// Event identifier for when a sale is successfully registered.
        /// </summary>
        public static readonly EventId SaleRegistered = new(1001, nameof(SaleRegistered));

        /// <summary>
        /// Event identifier for errors that occur during sale registration.
        /// </summary>
        public static readonly EventId SaleRegistrationError = new(1002, nameof(SaleRegistrationError));

        /// <summary>
        /// Event identifier for when a sale has been modified.
        /// </summary>
        public static readonly EventId SaleModified = new(1003, nameof(SaleModified));

        /// <summary>
        /// Event identifier for when a sale is canceled.
        /// </summary>
        public static readonly EventId SaleCanceled = new(1004, nameof(SaleCanceled));
    }
}
