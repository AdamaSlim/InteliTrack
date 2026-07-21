using InteliTrack.Application.DTOs.Stocks;

namespace InteliTrack.Application.Interfaces.Services;

public interface IStockService
{
    Task<StockOperationResultDto>
        AddStockAsync(AddStockDto dto);

    Task<StockOperationResultDto>
        RemoveStockAsync(RemoveStockDto dto);
}