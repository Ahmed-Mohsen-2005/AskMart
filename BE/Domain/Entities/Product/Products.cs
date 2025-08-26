using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Categories;

namespace Domain.Entities.Product
{
    public class Products
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int Stock { get; set; }
        public Category? Category { get; set; }
        public int? StockQuantity { get; set; }
    }
}
