using InteliTrack.Application.DTOs.Stocks;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.API.Endpoints;

public static class StockEndpoints
{
    public static void MapStockEndpoints(
        this WebApplication app)
    {
        var group = app.MapGroup("/api/stocks")
                       .WithTags("Stocks");


        group.MapPost("/add", async (
            AddStockDto dto,
            IStockService service) =>
        {
            var result =
                await service.AddStockAsync(dto);

            return result.Success
                ? Results.Ok(result)
                : Results.BadRequest(result);
        });


        group.MapPost("/remove", async (
            RemoveStockDto dto,
            IStockService service) =>
        {
            var result =
                await service.RemoveStockAsync(dto);

            return result.Success
                ? Results.Ok(result)
                : Results.BadRequest(result);
        });
    }
}