using Application.Contracts.Services;
using Application.DTO.ProductDTO.Request;
using Application.DTO.ProductDTO.Response;
using Application.Dtos.ProductDTO.Request;
using Application.Dtos.ProductDTO.Response;
using AutoMapper;
using Domain.Entities.Products;
using Domain.Interfaces.GenericrRepositoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Results;
using System.Net;


namespace Infrastructure.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _productsRepository;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._productsRepository = this._unitOfWork.GetRepository<Product>();
            this._mapper = mapper;

        }


        // Change product name by ID
        public async Task<Response<string>> ChangeProductNameAsync(ChangeProductNameRequest request)
        {
            var product = await this._productsRepository.GetByIdAsync(request.ProductId);

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

            product.ProductName = request.NewName;
            await this._productsRepository.UpdateAsync(product.ProductId?? -1, product); // if product id is null put -1

            await _unitOfWork.SaveAsync();

            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Product name updated successfully.",
                Data = product.ProductName
            };
        }



        // Check if product is in stock
        public async Task<Response<IsInStockResponse>> IsInStockAsync(IsInStockRequest request)
        {
            var product = request.ProductId >=0
                ? await this._productsRepository.GetByIdAsync(request.ProductId)
                : null;
                

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
                ProductId = product.ProductId,
                Name = product.ProductName,
                StockQuantity = product.StockQuantity,
                Message = product.StockQuantity > 0
                    ? "Product is in stock."
                    : "Product is out of stock."
            };
            await _unitOfWork.SaveAsync();

            return new Response<IsInStockResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = responseData.Message,
                Data = responseData
            };
        }

        public async Task<Response<string>> UpdateDescriptionAsync(UpdateDescriptionRequest request)
        {

            var product = request.ProductId>=0
                ? await this._productsRepository.GetByIdAsync(request.ProductId)
                : null;
                

            if (product == null) { return new Response<string> { StatusCode = HttpStatusCode.NotFound, Succeeded = false, Message=" Product not found."}; }
            product.ProductDescription = request.NewDescription;
             await this._productsRepository.UpdateAsync(product.ProductId?? -1 , product);
            await _unitOfWork.SaveAsync();

            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Discription is updated."
            };
        }
        public async Task<Response<string>> RemoveProductAsync(RemoveProductRequest request)
        {
            var product = await _productsRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                return new Response<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Product not found."
                };
            }

            _productsRepository.Delete(product);

            
            await _unitOfWork.SaveAsync();

            return new Response<string>
            {
                StatusCode = HttpStatusCode.OK,
                Data = "Product removed successfully."
            };
        }



        public async Task<Response<ProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            var productEntity = _mapper.Map<Product>(request);
            await _productsRepository.AddAsync(productEntity);
            await _unitOfWork.SaveAsync();

            var productResponse = _mapper.Map<ProductResponse>(productEntity);

            return new Response<ProductResponse>
            {
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Product created successfully",
                Data = productResponse
            };
        }
    }
}
