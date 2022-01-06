using AutoMapper;
using RestApi.Application.Models;
using RestApi.Infrastructure.Data.Service.Paging;

namespace RestApi.Application.Mapping
{
    public class PagingProfile : Profile
    {
        public PagingProfile()
        {
            CreateMap<SearchRequestDto, PagingParam>();
        }
    }
}
