using Domain.Entities.Products;

namespace Domain.Entities.Cart
{
    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;   // Navigation Property

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!; // Navigation Property

        public int Quantity { get; set; }
    }
}