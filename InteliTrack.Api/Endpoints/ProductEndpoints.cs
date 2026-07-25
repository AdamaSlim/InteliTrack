using InteliTrack.Application.DTOs.Products;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products");

        group.MapGet("/", async (IProductService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id:int}", async (int id, IProductService service) =>
        {
            var product = await service.GetByIdAsync(id);

            return product is null
                ? Results.NotFound()
                : Results.Ok(product);
        });

        group.MapPost("/", async (
            CreateProductDto dto,
            IProductService service) =>
        {
            var product = await service.CreateAsync(dto);

            return Results.Created($"/api/products/{product.Id}", product);
        });

        group.MapPut("/{id:int}", async (
            int id,
            UpdateProductDto dto,
            IProductService service) =>
        {
            var product = await service.UpdateAsync(id, dto);

            return Results.Ok(product);
        });

        group.MapDelete("/{id:int}", async (
            int id,
            IProductService service) =>
        {
            await service.DeactivateAsync(id);

            return Results.NoContent();
        });
    }
}