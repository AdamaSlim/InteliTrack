using InteliTrack.Application.DTOs.Categories;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.Api.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/categories");

        group.MapGet("/", async (ICategoryService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id:int}", async (
            int id,
            ICategoryService service) =>
        {
            var category = await service.GetByIdAsync(id);

            return category is null
                ? Results.NotFound()
                : Results.Ok(category);
        });

        group.MapPost("/", async (
            CreateCategoryDto dto,
            ICategoryService service) =>
        {
            var category = await service.CreateAsync(dto);

            return Results.Created(
                $"/api/categories/{category.Id}",
                category);
        });

        group.MapPut("/{id:int}", async (
            int id,
            UpdateCategoryDto dto,
            ICategoryService service) =>
        {
            var category = await service.UpdateAsync(id, dto);

            return Results.Ok(category);
        });

        group.MapDelete("/{id:int}", async (
            int id,
            ICategoryService service) =>
        {
            await service.DeactivateAsync(id);

            return Results.NoContent();
        });
    }
}