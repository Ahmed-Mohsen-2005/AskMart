using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repositories
{
    public interface IProductRepositories
    {

        public interface IProductRepository
        {
            Task<Products?> GetByIdAsync(Guid id);
            Task<Products?> GetByNameAsync(string name);
            Task UpdateAsync(Products product);
        }

    }
}
