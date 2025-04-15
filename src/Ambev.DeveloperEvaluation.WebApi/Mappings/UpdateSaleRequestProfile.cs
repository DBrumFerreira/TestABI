using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class UpdateSaleRequestProfile : Profile
{
    public UpdateSaleRequestProfile()
    {
        CreateMap<GetProductRequest, GetProductCommand>();
        CreateMap<UpdateSaleProductRequest, UpdateSaleProductCommand>();
    }
}
