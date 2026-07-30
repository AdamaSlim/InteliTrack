using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Infrastructure.Data;
using InteliTrack.Infrastructure.Repos;
using InteliTrack.Infrastructure.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Application.Services;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Repositories;

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

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<IShelfRepository, ShelfRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ITransferRepository, TransferRepository>();
        services.AddScoped<IStockMovementRepository, StockMovementRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}