using FluentValidation;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Application.Services;
using InteliTrack.Application.Validators.Stocks;
using Microsoft.Extensions.DependencyInjection;

namespace InteliTrack.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<ITransferService, TransferService>();

        services.AddValidatorsFromAssemblyContaining<AddStockDtoValidator>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}