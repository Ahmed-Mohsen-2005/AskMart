using Domain.Entities.User;

namespace Domain.Entities.Cart
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }

        //Used ICollection instead of List or Ilist because it represents the minimal contract EF needs:
        // Ability to Add, Remove, and enumerate entities
        //More Abstract
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>(); //Navigation Property
        public ApplicationUser User { get; set; } = null!; //Navigation Property
    }

    
}