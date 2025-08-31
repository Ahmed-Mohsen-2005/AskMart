using Application.Dtos.CategoryDTO.Request;
using Application.Dtos.CategoryDTO.Response;
using Application.Dtos.ProductDTO.Request;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface ICategoryService
    {
       
        Task<Response<string>> RemoveCategoryAsync(RemoveCategoryRequest request);

        Task <Response<CategoryResponse>> AddCategoryAsync(AddCategoryRequest request);
        Task<Response<string>> ChangeCategoryNameAsync(ChangeCategoryNameRequest request);


    }
}
