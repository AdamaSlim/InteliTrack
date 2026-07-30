using InteliTrack.Application.DTOs.Products;
using InteliTrack.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InteliTrack.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products");


        group.MapGet("/", async (
            [FromServices] IProductService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });


        group.MapGet("/{id:int}", async (
            int id,
            [FromServices] IProductService service) =>
        {
            var product = await service.GetByIdAsync(id);

            return product is null
                ? Results.NotFound()
                : Results.Ok(product);
        });


        group.MapPost("/", async (
            [FromBody] CreateProductDto dto,
            [FromServices] IProductService service) =>
        {
            var product = await service.CreateAsync(dto);

            return Results.Created(
                $"/api/products/{product.Id}",
                product);
        });


        group.MapPut("/{id:int}", async (
            int id,
            [FromBody] UpdateProductDto dto,
            [FromServices] IProductService service) =>
        {
            var product = await service.UpdateAsync(id, dto);

            return Results.Ok(product);
        });


        group.MapDelete("/{id:int}", async (
            int id,
            [FromServices] IProductService service) =>
        {
            await service.DeactivateAsync(id);

            return Results.NoContent();
        });
    }
}