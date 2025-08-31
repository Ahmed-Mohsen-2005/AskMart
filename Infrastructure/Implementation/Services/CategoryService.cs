using Application.Dtos;
using Application.Dtos.CategoryDTO.Request;
using AutoMapper;
using Domain.Entities.Categories;
using Domain.Entities.Products;
using Domain.Interfaces.GenericrRepositoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Results;
using Microsoft.AspNetCore.Http;
using Application.Dtos.CategoryDTO.Response;
using Application.Contracts.Services;





namespace Infrastructure.Implementation.Services
{
    public class CategoryService:ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork,  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._categoryRepository = this._unitOfWork.GetRepository<Category>();
            _mapper = mapper;
        }

        public async Task<Response<CategoryResponse>> AddCategoryAsync(AddCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();
            var categoryResponse = _mapper.Map<CategoryResponse>(category);

            return new Response<CategoryResponse>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Category created sucessfully.",
                Data = categoryResponse
            };

        }

        public async Task<Response<string>> ChangeCategoryNameAsync(ChangeCategoryNameRequest request)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return new Response<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Category can't be found"
                };


            }

            _mapper.Map(request, category);
            await _unitOfWork.SaveAsync();
            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Category name changed successfully."


            };
        }
        public async Task<Response<string>> RemoveCategoryAsync(RemoveCategoryRequest request)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return new Response<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Category can't be found"
                };

            }

           
            await _categoryRepository.DeleteAsync(category);
            await _unitOfWork.SaveAsync();

            return new Response<string>
            {
                Message = "Category deleted sucessfully.",
                StatusCode = HttpStatusCode.OK
            };

        }
    }
}
//mapper takes an object from specific class and convert it to another class