using InteliTrack.Application.DTOs.Transfers;
using InteliTrack.Application.Interfaces.Services;

namespace InteliTrack.API.Endpoints;

public static class TransferEndpoints
{
    public static void MapTransferEndpoints(
        this WebApplication app)
    {
        var group = app.MapGroup("/api/transfers")
                       .WithTags("Transfers");


        group.MapPost("/", async (
            CreateTransferDto dto,
            ITransferService service) =>
        {
            var result =
                await service.CreateTransferAsync(dto);

            return result.Success
                ? Results.Ok(result)
                : Results.BadRequest(result);

        });


        group.MapPost("/{id}/start", async (
            int id,
            int employeeId,
            ITransferService service) =>
        {
            var result =
                await service.StartTransferAsync(
                    id,
                    employeeId);

            return result.Success
                ? Results.Ok(result)
                : Results.BadRequest(result);

        });


        group.MapPost("/{id}/complete", async (
            int id,
            int employeeId,
            ITransferService service) =>
        {
            var result =
                await service.CompleteTransferAsync(
                    id,
                    employeeId);

            return result.Success
                ? Results.Ok(result)
                : Results.BadRequest(result);

        });


        group.MapPost("/{id}/cancel", async (
            int id,
            int employeeId,
            ITransferService service) =>
        {
            var result =
                await service.CancelTransferAsync(
                    id,
                    employeeId);

            return result.Success
                ? Results.Ok(result)
                : Results.BadRequest(result);

        });
    }
}