using Application.Contracts.Repositories;
using Domain.Entities;
using Domain.Entities.Product;
using Infrastructure.Persistence; // <- updated
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static Application.Contracts.Repositories.IProductRepositories;

namespace Infrastructure.Implementations.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Products?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Products?> GetByNameAsync(string name)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task UpdateAsync(Products product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
