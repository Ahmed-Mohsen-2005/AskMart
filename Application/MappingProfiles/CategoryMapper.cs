using Application.Dtos.CategoryDTO.Request;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Categories;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class CategoryMapper : Profile {
        public  CategoryMapper()

        {
            CreateMap<AddCategoryRequest, Category>();

            CreateMap<ChangeCategoryNameRequest, Category>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryNewName));
        }
    }
}
