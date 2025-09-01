using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Products;

namespace Domain.Entities.Categories
{
    public class Category
    {

        public int CategoryId { get; set; }   
        public string CategoryName { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();

    }
}