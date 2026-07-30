using InteliTrack.Application.DTOs.Employees;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.Api.Endpoints;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/employees");

        group.MapGet("/", async (IEmployeeService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id:int}", async (
            int id,
            IEmployeeService service) =>
        {
            var employee = await service.GetByIdAsync(id);

            return employee is null
                ? Results.NotFound()
                : Results.Ok(employee);
        });

        group.MapPost("/", async (
            CreateEmployeeDto dto,
            IEmployeeService service) =>
        {
            var employee = await service.CreateAsync(dto);

            return Results.Created(
                $"/api/employees/{employee.Id}",
                employee);
        });

        group.MapPut("/{id:int}", async (
            int id,
            UpdateEmployeeDto dto,
            IEmployeeService service) =>
        {
            var employee = await service.UpdateAsync(id, dto);

            return Results.Ok(employee);
        });

        group.MapDelete("/{id:int}", async (
            int id,
            IEmployeeService service) =>
        {
            await service.DeactivateAsync(id);

            return Results.NoContent();
        });
    }
}