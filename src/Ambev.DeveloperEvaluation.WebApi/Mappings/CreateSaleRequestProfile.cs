using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateSaleRequestProfile : Profile
{
    public CreateSaleRequestProfile()
    {
        CreateMap<GetProductRequest, GetProductCommand>();
    }
}