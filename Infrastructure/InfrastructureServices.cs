using Application.Contracts.Services;
using Domain.Interfaces.GenericrRepositoryInterfaces;
using Domain.Interfaces.SPCallInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Interfaces.UtilityInterfaces.FileHandlerInterfaces;
using Domain.Interfaces.UtilityInterfaces.MimeTypesInterfaces;
using Infrastructure.Data;
using Infrastructure.Implementation.Services;
using Infrastructure.Repository.Implementations;
using Infrastructure.StoredProcedureCall;
using Infrastructure.UnitOfWorkImplementation;
using Infrastructure.Utility.FileHandler;
using Infrastructure.Utility.MimeTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(DbConnection.DefaultConnection, ServerVersion.AutoDetect(DbConnection.DefaultConnection));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISPCall, SPCall>();

            services.AddSingleton<IMimeTypesLoader>(new FileMimeTypesLoader("MimeTypes.json"));
            services.AddSingleton<IMimeTypesService, MimeTypes>();
           

            services.AddScoped<IFileHandler, FileHandler>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}

