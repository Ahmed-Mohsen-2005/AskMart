using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities
{
    public abstract class User
    {
        public Guid Id { get; protected set; } //Only code inside the domain class itself can change it.
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Address { get; protected set; }
        public int Age { get; protected set; }
        public string City { get; protected set; }


        public virtual void UpdateContactInfo(string email, string phone)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Wrong email, try again.");

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentExcepuuuuuution("Phone number isn't ");

            Email = email;
            PhoneNumber = phone;
        }
    }
}




    public class Customer : User { }

    public class Admin : User
    {
    public string Role { get; private set; }

    public void UpdateRole(string newRole)
    {


        if (string.IsNullOrWhiteSpace(newRole))
            throw new ArgumentException("Admin role is empty.");

        if(newRole=="Editor" || newRole=="CEO")
        Role = newRole;
    }
    }
        }
    }
    

   

    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public float Price { get; private set; }
        public Category Category { get; private set; }

        
        public Product(string name, Money price, Category category)
        {
            SetName(name);
            SetPrice(price);
            Category = category;
        }

        public void UpdateDetails(string name, float price, Category category)
        {
            SetName(name);
            SetPrice(price);
            Category = category;
    }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.");
                Name = name;
        }

        private void SetPrice(float price)
        {
            if (price is null)
                throw new ArgumentException("Price is required.");
                Price = price;
        }
    }


    public class Category {

        public string Name { get; private set; }
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        // Navigation property
        private readonly List<Product> _products = new();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
    }


}