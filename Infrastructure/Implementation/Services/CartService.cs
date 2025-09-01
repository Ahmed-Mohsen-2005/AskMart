
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Cart;
using Domain.Entities.Products;
using Domain.Interfaces.GenericrRepositoryInterfaces;
using Infrastructure.UnitOfWorkImplementation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Services
{
    public class CartService : ICartService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IGenericRepository<Cart> _cartRepository;
        private readonly IGenericRepository<CartItem> _cartItemRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public CartService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cartRepository = this._unitOfWork.GetRepository<Cart>();
            _cartItemRepository = this._unitOfWork.GetRepository<CartItem>();
            _productRepository = this._unitOfWork.GetRepository<Product>();
        }
        public async Task<Cart> GetCartByUserIdAsync(int userId)
        {

            // Get the cart for the user
            var cart = await _cartRepository.GetAsync(c => c.UserId == userId);

            // If no cart exists, create a new one
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                await _cartRepository.AddAsync(cart);
                await _unitOfWork.SaveAsync();
            }

            return cart;
        }

        public async Task<Cart> AddToCartAsync(int userId, int productId, int quantity)
        {
            // Get the user's cart
            var cart = await _cartRepository.GetAsync(c => c.UserId == userId, include: q => q.Include(c => c.Items));
            if (cart == null)
            {
                cart = new Cart { UserId = userId, Items = new List<CartItem>() };
                await _cartRepository.AddAsync(cart);
                await _unitOfWork.SaveAsync();
            }

            // Check if product exists
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not Available");

            // Check if the product is already in the cart
            var existingItem = cart.Items.FirstOrDefault(ci => ci.ProductId == productId);
            if (existingItem != null)
            {
                // increase quantity
                existingItem.Quantity += quantity;
                _cartItemRepository.Update(existingItem.Id, existingItem);
            }
            else
            {
                // add new cart item
                var cartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CartId = cart.CartId
                };

                await _cartItemRepository.AddAsync(cartItem);
                cart.Items.Add(cartItem);
            }

            await _unitOfWork.SaveAsync();

            return cart;
        }

        public async Task<Cart> UpdateItemQuantityAsync(int userId, int productId, int quantity)
        {
            // Fetch cart including items
            var cart = await _cartRepository.GetAsync(
                c => c.UserId == userId,
                include: q => q.Include(c => c.Items)
            );

            if (cart == null)
                throw new Exception("Cart not found");

            // Find cart item
            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (cartItem == null)
                throw new Exception("Product not in cart");

            if (quantity <= 0)
            {
                // Remove item if quantity set to 0
                cart.Items.Remove(cartItem);
                _cartItemRepository.Delete(cartItem);
            }
            else
            {
                // Update quantity
                cartItem.Quantity = quantity;
                _cartItemRepository.Update(cartItem.Id, cartItem);
            }

            await _unitOfWork.SaveAsync();

            return cart;
        }


        public async Task<bool> RemoveItemAsync(int userId, int productId)
        {
            // Load cart with items
            var cart = await _cartRepository.GetAsync(
                c => c.UserId == userId,
                include: q => q.Include(c => c.Items)
            );


            if (cart == null)
                throw new Exception("Cart not found");

            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (cartItem == null)
                throw new Exception("Item not found in cart");

            // remove item and save changes 
            cart.Items.Remove(cartItem);
            _cartItemRepository.Delete(cartItem);

            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task ClearCartAsync(int userId)
        {
            var cart = await _cartRepository.GetAsync(c => c.UserId == userId,include: q => q.Include(c => c.Items));

            if (cart == null)
                throw new Exception("Cart not found");

            // Remove all items
            foreach (var item in cart.Items.ToList())
            {
                _cartItemRepository.Delete(item);
            }
            cart.Items.Clear();

            await _unitOfWork.SaveAsync();
            return;
        }
    }
}