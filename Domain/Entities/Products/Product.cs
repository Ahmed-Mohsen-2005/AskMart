using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Categories;

namespace Domain.Entities.Products
{
    public class Product
    {
        public int? ProductId { get; set; }
        public string?  ProductName { get; set; }
        public string? ProductDescription { get; set; }

        public float? ProdyctPrice {  get; set; }
        public Category? Category { get; set; }
        public int? StockQuantity { get; set; }

        public int CategoryId {  get; set; }
    }
}
