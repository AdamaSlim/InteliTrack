using InteliTrack.Application.DTOs.Suppliers;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.Api.Endpoints;

public static class SupplierEndpoints
{
    public static void MapSupplierEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/suppliers");

        group.MapGet("/", async (ISupplierService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id:int}", async (
            int id,
            ISupplierService service) =>
        {
            var supplier = await service.GetByIdAsync(id);

            return supplier is null
                ? Results.NotFound()
                : Results.Ok(supplier);
        });

        group.MapPost("/", async (
            CreateSupplierDto dto,
            ISupplierService service) =>
        {
            var supplier = await service.CreateAsync(dto);

            return Results.Created(
                $"/api/suppliers/{supplier.Id}",
                supplier);
        });

        group.MapPut("/{id:int}", async (
            int id,
            UpdateSupplierDto dto,
            ISupplierService service) =>
        {
            var supplier = await service.UpdateAsync(id, dto);

            return Results.Ok(supplier);
        });

        group.MapDelete("/{id:int}", async (
            int id,
            ISupplierService service) =>
        {
            await service.DeactivateAsync(id);

            return Results.NoContent();
        });
    }
}