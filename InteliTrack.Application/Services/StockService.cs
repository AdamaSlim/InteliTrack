using InteliTrack.Application.DTOs.Stocks;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Domain.Entities;
using InteliTrack.Domain.Enums;

namespace InteliTrack.Application.Services;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IStockMovementRepository _movementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StockService(
        IStockRepository stockRepository,
        IEmployeeRepository employeeRepository,
        IStockMovementRepository movementRepository,
        IUnitOfWork unitOfWork)
    {
        _stockRepository = stockRepository;
        _employeeRepository = employeeRepository;
        _movementRepository = movementRepository;
        _unitOfWork = unitOfWork;
    }

  public async Task<StockOperationResultDto>
    AddStockAsync(AddStockDto dto)
{
    var result = new StockOperationResultDto();

    var stock = await _stockRepository.GetByIdAsync(dto.StockId);

    if (stock is null)
    {
        result.Success = false;
        result.Message = "Stock not found.";
        return result;
    }

    var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeId);

    if (employee is null)
    {
        result.Success = false;
        result.Message = "Employee not found.";
        return result;
    }

    if (employee.StoreId != stock.Shelf.Section.StoreId)
    {
        result.Success = false;
        result.Message = "Employee cannot access another store stock.";
        return result;
    }

    var totalShelfQuantity =
        await _stockRepository.GetTotalQuantityOnShelfAsync(stock.ShelfId);

    if (totalShelfQuantity + dto.Quantity > stock.Shelf.Capacity)
    {
        result.Success = false;
        result.Message = "Shelf capacity exceeded.";
        return result;
    }

    stock.Quantity += dto.Quantity;

    var movement = new StockMovement
    {
        ProductId = stock.ProductId,
        StoreId = employee.StoreId,
        EmployeeId = employee.Id,
        Quantity = dto.Quantity,
        MovementType = MovementType.StockIn,
        Reason = dto.Reason
    };

    await _movementRepository.AddAsync(movement);

    _stockRepository.Update(stock);

    await _unitOfWork.SaveChangesAsync();

    result.Success = true;
    result.Message = "Stock added successfully.";

    return result;
}

    public async Task<StockOperationResultDto>
    RemoveStockAsync(RemoveStockDto dto)
{
    var result = new StockOperationResultDto();

    var stock = await _stockRepository.GetByIdAsync(dto.StockId);

    if (stock is null)
    {
        result.Success = false;
        result.Message = "Stock not found.";
        return result;
    }

    var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeId);

    if (employee is null)
    {
        result.Success = false;
        result.Message = "Employee not found.";
        return result;
    }

   if (employee.StoreId != stock.Shelf.Section.StoreId)
{
    result.Success = false;
    result.Message =
        $"Employee={employee.StoreId}, Section={stock.Shelf.Section.StoreId}";
    return result;
}

    if (stock.Quantity < dto.Quantity)
    {
        result.Success = false;
        result.Message = "Insufficient stock.";
        return result;
    }

    stock.Quantity -= dto.Quantity;

    var movement = new StockMovement
    {
        ProductId = stock.ProductId,
        StoreId = employee.StoreId,
        EmployeeId = employee.Id,
        Quantity = dto.Quantity,
        MovementType = MovementType.StockOut,
        Reason = dto.Reason
    };

    await _movementRepository.AddAsync(movement);

    _stockRepository.Update(stock);

    await _unitOfWork.SaveChangesAsync();

    result.Success = true;
    result.Message = "Stock removed successfully.";

    if (stock.Quantity < stock.Product.MinimumStockLevel)
    {
        result.HasWarning = true;
        result.WarningMessage =
            "Stock level is below minimum threshold.";
    }

    return result;
}
}