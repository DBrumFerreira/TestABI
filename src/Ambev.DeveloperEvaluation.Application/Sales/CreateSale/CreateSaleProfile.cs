﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<CreateSaleProductCommand, SaleProduct>();
        CreateMap<ProductCommand, Product>();
        CreateMap<Sale, CreateSaleResult>();
        CreateMap<SaleProduct, CreateSaleProductResult>();
    }
}
