using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Domain.Entities.Categories
{
    public class Category
    {
        private List<Products> products = new List<Products>();

        public Guid Id { get; private set; }   
        public string Name { get; set; } = string.Empty;


        


    }
}