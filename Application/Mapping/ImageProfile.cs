
using AutoMapper;
using RestApi.Application.Models.ImageDtos;
using RestApi.Application.Models.ProductDtos;
using RestApi.Domain;

namespace RestApi.Application.Mapping
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>();
            CreateMap<CreateImageDto, Image>();
            CreateMap<UpdateImageDto, Image>();
        }
    }
}
