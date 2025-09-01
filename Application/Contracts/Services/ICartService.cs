using Domain.Entities.Cart;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICartService
    {
        Task<Cart> GetCartByUserIdAsync(int userId);
        Task<Cart> AddToCartAsync(int userId, int productId, int quantity);
        Task<Cart> UpdateItemQuantityAsync(int userId, int productId, int quantity);
        Task<bool> RemoveItemAsync(int userId, int productId);
        Task ClearCartAsync(int userId);
    }
}
