using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Infrastructure.Data;
using InteliTrack.Infrastructure.Repos;
using InteliTrack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Application.Services;
using InteliTrack.Application.Interfaces.Repos;

namespace InteliTrack.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")
            ));

        services.AddScoped<IStockService, StockService>();
        services.AddScoped<ITransferService, TransferService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ITransferRepository, TransferRepository>();
        services.AddScoped<IStockMovementRepository, StockMovementRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        

        return services;
    }
}