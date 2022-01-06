
using AutoMapper;
using RestApi.Application.Models.ProductDtos;
using RestApi.Domain;

namespace RestApi.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
