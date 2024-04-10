using AutoMapper;
using Ns.Application.DTOs.ProductDtos;
using Ns.Domain.Models;

namespace Ns.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
