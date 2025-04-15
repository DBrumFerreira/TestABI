using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleProductRequest, CreateSaleProductCommand>();
        CreateMap<CreateProductRequest, ProductCommand>();

        CreateMap<CreateSaleResult, CreateSaleResponse>();
        CreateMap<CreateSaleProductResult, CreateSaleProductResponse>();
    }
}
