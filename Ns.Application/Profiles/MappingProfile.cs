using AutoMapper;
using Ns.Application.DTOs.ProductDtos;
using Ns.Domain.Models;

namespace Ns.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ChangeProductAvailableDto>().ReverseMap();
            #endregion
        }
    }
}
