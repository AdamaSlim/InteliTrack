using InteliTrack.Application.DTOs.Transfers;

namespace InteliTrack.Application.Interfaces.Services;

public interface ITransferService
{
    Task<TransferResultDto> CreateTransferAsync(
        CreateTransferDto dto);

    Task<TransferResultDto> StartTransferAsync(
        int transferId,
        int employeeId);

    Task<TransferResultDto> CompleteTransferAsync(
        int transferId,
        int employeeId);

    Task<TransferResultDto> CancelTransferAsync(
        int transferId,
        int employeeId);
}