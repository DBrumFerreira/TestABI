using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSale operation
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Sale>();
        CreateMap<UpdateSaleProductCommand, SaleProduct>();
        CreateMap<ProductCommand, Product>();
        CreateMap<Sale, UpdateSaleResult>();
        CreateMap<SaleProduct, UpdateSaleProductResult>();
    }
}