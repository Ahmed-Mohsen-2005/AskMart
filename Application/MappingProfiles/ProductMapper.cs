
using Application.DTO.ProductDTO.Request;
using Application.DTO.ProductDTO.Response;
using Application.Dtos.CategoryDTO.Request;
using Application.Dtos.ProductDTO.Request;
using Application.Dtos.ProductDTO.Response;
using AutoMapper;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using Domain.Entities.User;

namespace Application.MappingProfiles
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {

            CreateMap<CreateProductRequest,Product>();
            CreateMap<ChangeProductNameRequest,Product>();
            CreateMap<IsInStockRequest, Product>();
            CreateMap<RemoveProductRequest,Product>();
            CreateMap<UpdateDescriptionRequest,Product>();
           
            
               /* .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductPrice))
                .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.ProductStock))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName));*/

            CreateMap<Product, IsInStockResponse>();
            CreateMap<Product, ProductResponse>();



        }
    }
}


