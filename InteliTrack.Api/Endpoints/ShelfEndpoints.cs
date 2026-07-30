using InteliTrack.Application.DTOs.Shelves;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.Api.Endpoints;

public static class ShelfEndpoints
{
    public static void MapShelfEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/shelves");

        group.MapGet("/", async (IShelfService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id:int}", async (int id, IShelfService service) =>
        {
            var shelf = await service.GetByIdAsync(id);

            return shelf is null
                ? Results.NotFound()
                : Results.Ok(shelf);
        });

        group.MapPost("/", async (
            CreateShelfDto dto,
            IShelfService service) =>
        {
            var shelf = await service.CreateAsync(dto);

            return Results.Created(
                $"/api/shelves/{shelf.Id}",
                shelf);
        });

        group.MapPut("/{id:int}", async (
            int id,
            UpdateShelfDto dto,
            IShelfService service) =>
        {
            var shelf = await service.UpdateAsync(id, dto);

            return Results.Ok(shelf);
        });

        group.MapDelete("/{id:int}", async (
            int id,
            IShelfService service) =>
        {
            await service.DeactivateAsync(id);

            return Results.NoContent();
        });
    }
}