using Application.Dtos.ProductDTO.Request;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Products;


namespace Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductRequest, Product>();
        }
    }
}