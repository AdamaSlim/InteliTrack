using InteliTrack.Application.DTOs.Stores;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.Api.Endpoints;

public static class StoreEndpoints
{
    public static void MapStoreEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/stores");

        group.MapGet("/", async (IStoreService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id:int}", async (int id, IStoreService service) =>
        {
            var store = await service.GetByIdAsync(id);

            return store is null
                ? Results.NotFound()
                : Results.Ok(store);
        });

        group.MapPost("/", async (
            CreateStoreDto dto,
            IStoreService service) =>
        {
            var store = await service.CreateAsync(dto);

            return Results.Created(
                $"/api/stores/{store.Id}",
                store);
        });

        group.MapPut("/{id:int}", async (
            int id,
            UpdateStoreDto dto,
            IStoreService service) =>
        {
            var store = await service.UpdateAsync(id, dto);

            return Results.Ok(store);
        });

        group.MapDelete("/{id:int}", async (
            int id,
            IStoreService service) =>
        {
            await service.DeactivateAsync(id);

            return Results.NoContent();
        });
    }
}