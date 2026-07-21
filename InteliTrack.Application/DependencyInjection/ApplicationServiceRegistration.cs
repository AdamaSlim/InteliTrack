using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InteliTrack.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<ITransferService, TransferService>();

        return services;
    }
}