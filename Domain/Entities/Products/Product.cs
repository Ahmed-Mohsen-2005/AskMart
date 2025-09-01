
using Domain.Entities.Categories;

namespace Domain.Entities.Products
{
    public class Product
    {
        public int ProductId { get; set; }
        public string?  ProductName { get; set; }
        public string? ProductDescription { get; set; }

        public float? ProductPrice {  get; set; }
        public int? StockQuantity { get; set; }

        public int CategoryId {  get; set; }
        public Category? Category { get; set; }
    }
}
