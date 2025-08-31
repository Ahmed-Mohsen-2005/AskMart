using Application.DTO.ProductDTO.Request;
using Application.DTO.ProductDTO.Response;
using Application.Dtos.ProductDTO.Request;
using Application.Dtos.ProductDTO.Response;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface IProductService
    {
        Task<Response<IsInStockResponse>> IsInStockAsync(IsInStockRequest request);
        Task<Response<string>> ChangeProductNameAsync(ChangeProductNameRequest request);
        Task <Response<string>> UpdateDescriptionAsync(UpdateDescriptionRequest request);

        Task<Response<ProductResponse>> CreateProductAsync(CreateProductRequest request);
        Task<Response<string>> RemoveProductAsync(RemoveProductRequest request);
    }
}
