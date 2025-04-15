using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateSaleHandler> _logger;

    /// <summary>
    /// Initializes a new instance of UpdateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public UpdateSaleHandler(ISaleRepository saleRepository,
                             IProductRepository productRepository,
                             IMapper mapper,
                             ILogger<UpdateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the UpdateSaleCommand request
    /// </summary>
    /// <param name="command">The UpdateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale details</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new UpdateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var originalSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
            if (originalSale == null)
                throw new InvalidOperationException($"The product with ID {command.Id} does not exist.");

            var updatedSale = _mapper.Map<Sale>(command);

            bool hasChanged = HasSaleChanged(originalSale, updatedSale);

            if (!hasChanged)
                throw new InvalidOperationException($"No changes detected. Update operation aborted.");

            originalSale.TotalAmount = 0;
            foreach (var item in updatedSale.SaleProducts)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);

                if (product == null)
                    throw new InvalidOperationException($"The product with ID {item.ProductId} does not exist.");

                item.UnitPrice = product.Price;

                DiscountCalculator.Calculate(item);

                originalSale.TotalAmount += item.TotalItemAmount;
            }
            originalSale.SaleProducts = updatedSale.SaleProducts;

            await _saleRepository.UpdateAsync(originalSale, cancellationToken);
            var result = _mapper.Map<UpdateSaleResult>(originalSale);

            _logger.LogInformation(SaleEvents.SaleRegistered, "Sale {SaleId} updated successfully.", originalSale.Id);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(SaleEvents.SaleRegistrationError, ex, "Error updating sale.");
            throw;
        }
    }

    /// <summary>
    /// Determines whether there have been any changes between the original and updated Sale objects.
    /// </summary>
    /// <param name="originalSale">The original Sale object.</param>
    /// <param name="updatedSale">The updated Sale object.</param>
    /// <returns>true if there are any changes in the customer name, branch, or sale products; otherwise, false.</returns>
    private static bool HasSaleChanged(Sale originalSale, Sale updatedSale) 
    {
        bool hasCustomerChanged = originalSale.CustomerName != updatedSale.CustomerName;
        bool hasBranchChanged = originalSale.Branch != updatedSale.Branch;

        bool hasProductsChanged = !originalSale.SaleProducts.OrderBy(s => s.ProductId)
                                                            .SequenceEqual(updatedSale.SaleProducts.OrderBy(s => s.ProductId), new SaleProductComparer());

        return hasCustomerChanged || hasBranchChanged || hasProductsChanged;
    }
}
