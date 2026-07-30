using InteliTrack.Application.DTOs.Sections;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.Api.Endpoints;

public static class SectionEndpoints
{
    public static void MapSectionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/sections");

        group.MapGet("/", async (ISectionService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id:int}", async (
            int id,
            ISectionService service) =>
        {
            var section = await service.GetByIdAsync(id);

            return section is null
                ? Results.NotFound()
                : Results.Ok(section);
        });

        group.MapPost("/", async (
            CreateSectionDto dto,
            ISectionService service) =>
        {
            var section = await service.CreateAsync(dto);

            return Results.Created(
                $"/api/sections/{section.Id}",
                section);
        });

        group.MapPut("/{id:int}", async (
            int id,
            UpdateSectionDto dto,
            ISectionService service) =>
        {
            var section = await service.UpdateAsync(id, dto);

            return Results.Ok(section);
        });

        group.MapDelete("/{id:int}", async (
            int id,
            ISectionService service) =>
        {
            await service.DeactivateAsync(id);

            return Results.NoContent();
        });
    }
}