using Application.Contracts.Services;
using Infrastructure.Implementations.Repositories;
using Infrastructure.Implementations.Services;
using Microsoft.Extensions.DependencyInjection;
using static Application.Contracts.Repositories.IProductRepositories;

namespace Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
           
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
