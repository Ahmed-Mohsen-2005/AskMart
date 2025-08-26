using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.DTO.ProductDTO.Request;
using Application.DTO.ProductDTO.Response;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static Application.Contracts.Repositories.IProductRepositories;

namespace Infrastructure.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository; //DI
        }

        // Change product name by ID
        public async Task<Response<string>> ChangeProductNameAsync(ChangeProductNameRequest request)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return new Response<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Product not found.",
                    Errors = new List<string> { "Invalid product ID provided." }
                };
            }

            product.Name = request.NewName;
            await _repository.UpdateAsync(product);

            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Product name updated successfully.",
                Data = product.Name
            };
        }

        // Check if product is in stock
        public async Task<Response<IsInStockResponse>> IsInStockAsync(IsInStockRequest request)
        {
            var product = request.ProductId.HasValue && request.ProductId.Value != Guid.Empty
                ? await _repository.GetByIdAsync(request.ProductId.Value)
                : await _repository.GetByNameAsync(request.ProductName!);

            if (product == null)
            {
                return new Response<IsInStockResponse>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = "Product not found.",
                    Errors = new List<string> { "No product matches the provided information." }
                };
            }

            var responseData = new IsInStockResponse
            {
                success = product.StockQuantity > 0,
                ProductId = product.Id,
                Name = product.Name,
                StockQuantity = product.StockQuantity,
                Message = product.StockQuantity > 0
                    ? "Product is in stock."
                    : "Product is out of stock."
            };

            return new Response<IsInStockResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = responseData.Message,
                Data = responseData
            };
        }

        public async Task<Response<string>> UpdateDiscriptionAsync(UpdateDiscriptionRequest request)
        {

            var product = request.ProductId.HasValue && request.ProductId.Value != Guid.Empty
                ? await _repository.GetByIdAsync(request.ProductId.Value)
                : await _repository.GetByNameAsync(request.ProductName!);
            

            if (product == null) { return new Response<string> { StatusCode = HttpStatusCode.NotFound, Succeeded = false, Message=" Product not found."}; }
            product.Description = request.NewDiscription;
             await _repository.UpdateAsync(product);

            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Discription is updated."
            };
        }
    }
}
