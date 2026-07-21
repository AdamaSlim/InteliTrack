using InteliTrack.Application.DTOs.Transfers;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Domain.Entities;
using InteliTrack.Domain.Enums;

namespace InteliTrack.Application.Services;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _transferRepository;
    private readonly IStockRepository _stockRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IStockMovementRepository _movementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TransferService(
        ITransferRepository transferRepository,
        IStockRepository stockRepository,
        IEmployeeRepository employeeRepository,
        IStockMovementRepository movementRepository,
        IUnitOfWork unitOfWork)
    {
        _transferRepository = transferRepository;
        _stockRepository = stockRepository;
        _employeeRepository = employeeRepository;
        _movementRepository = movementRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TransferResultDto> CreateTransferAsync(
    CreateTransferDto dto)
    {
        var result = new TransferResultDto();
        Console.WriteLine($"EmployeeId received: {dto.EmployeeId}");
Console.WriteLine($"SourceStoreId received: {dto.SourceStoreId}");

        var employee =
    await _employeeRepository.GetByIdAsync(dto.EmployeeId);

Console.WriteLine(
    employee == null 
    ? "Employee NOT FOUND"
    : $"Employee FOUND: {employee.FirstName}"
);
        if (employee is null)
        {
            result.Success = false;
            result.Message = "Employee not found.";
            return result;
        }

        if (employee.StoreId != dto.SourceStoreId)
        {
            result.Success = false;
            result.Message =
                "Employee can only create transfers from their own store.";
            return result;
        }

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var transfer = new Transfer
            {
                SourceStoreId = dto.SourceStoreId,
                DestinationStoreId = dto.DestinationStoreId,
                Status = TransferStatus.Pending
            };

            foreach (var item in dto.Items)
            {
                var stock =
                    await _stockRepository.GetByProductAndStoreAsync(
                        item.ProductId,
                        dto.SourceStoreId);

                if (stock is null)
                {
                    await _unitOfWork.RollbackTransactionAsync();

                    result.Success = false;
                    result.Message =
                        $"Product {item.ProductId} not found in source store.";

                    return result;
                }

                if (stock.Quantity < item.Quantity)
                {
                    await _unitOfWork.RollbackTransactionAsync();

                    result.Success = false;
                    result.Message =
                        $"Insufficient stock for product {item.ProductId}.";

                    return result;
                }

                

                transfer.Items.Add(
                    new TransferItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
            }

            await _transferRepository.AddAsync(transfer);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitTransactionAsync();

            result.Success = true;
            result.Message =
                "Transfer created and sent successfully.";

            return result;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();

            result.Success = false;
            result.Message =
                "An error occurred while creating transfer.";

            return result;
        }
    }
    public async Task<TransferResultDto> StartTransferAsync(
    int transferId,
    int employeeId)
{
    var result = new TransferResultDto();

    var employee =
        await _employeeRepository.GetByIdAsync(employeeId);

    if (employee is null)
    {
        result.Success = false;
        result.Message = "Employee not found.";
        return result;
    }


    var transfer =
        await _transferRepository.GetByIdWithItemsAsync(
            transferId);


    if (transfer is null)
    {
        result.Success = false;
        result.Message = "Transfer not found.";
        return result;
    }


    if (transfer.Status != TransferStatus.Pending)
    {
        result.Success = false;
        result.Message =
            "Only Pending transfers can start.";

        return result;
    }


    if (employee.StoreId != transfer.SourceStoreId)
    {
        result.Success = false;
        result.Message =
            "Only source store can start transfer.";

        return result;
    }


    await _unitOfWork.BeginTransactionAsync();


    try
    {

        foreach(var item in transfer.Items)
        {
            var stock =
                await _stockRepository.GetByProductAndStoreAsync(
                    item.ProductId,
                    transfer.SourceStoreId);


            if(stock is null)
            {
                await _unitOfWork.RollbackTransactionAsync();

                result.Success = false;
                result.Message =
                    "Product not found in source store.";

                return result;
            }


            if(stock.Quantity < item.Quantity)
            {
                await _unitOfWork.RollbackTransactionAsync();

                result.Success = false;
                result.Message =
                    "Insufficient stock.";

                return result;
            }


            stock.Quantity -= item.Quantity;

            _stockRepository.Update(stock);



            var movement = new StockMovement
            {
                ProductId = item.ProductId,
                StoreId = transfer.SourceStoreId,
                EmployeeId = employee.Id,
                Quantity = item.Quantity,
                MovementType = MovementType.StockOut,
                Reason = "Transfer Started"
            };


            await _movementRepository.AddAsync(movement);
        }


        transfer.Status = TransferStatus.InTransit;


        _transferRepository.Update(transfer);


        await _unitOfWork.SaveChangesAsync();


        await _unitOfWork.CommitTransactionAsync();


        result.Success = true;
        result.Message =
            "Transfer is now in transit.";

        return result;

    }
    catch
    {
        await _unitOfWork.RollbackTransactionAsync();

        result.Success = false;
        result.Message =
            "Error while starting transfer.";

        return result;
    }
}

    public async Task<TransferResultDto> CompleteTransferAsync(
     int transferId,
     int employeeId)
    {
        var result = new TransferResultDto();

        var employee =
            await _employeeRepository.GetByIdAsync(employeeId);

        if (employee is null)
        {
            result.Success = false;
            result.Message = "Employee not found.";
            return result;
        }

        var transfer =
            await _transferRepository.GetByIdWithItemsAsync(
                transferId);

        if (transfer is null)
        {
            result.Success = false;
            result.Message = "Transfer not found.";
            return result;
        }

        if (transfer.Status != TransferStatus.InTransit)
        {
            result.Success = false;
            result.Message =
                "Only InTransit transfers can be completed.";

            return result;
        }

        if (employee.StoreId != transfer.DestinationStoreId)
        {
            result.Success = false;
            result.Message =
                "Only destination store can complete transfer.";

            return result;
        }

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            foreach (var item in transfer.Items)
            {
                var stock =
                    await _stockRepository.GetByProductAndStoreAsync(
                        item.ProductId,
                        transfer.DestinationStoreId);

                if (stock is not null)
                {
                    stock.Quantity += item.Quantity;

                    _stockRepository.Update(stock);
                }

                var movement = new StockMovement
                {
                    ProductId = item.ProductId,
                    StoreId = transfer.DestinationStoreId,
                    EmployeeId = employee.Id,
                    Quantity = item.Quantity,
                    MovementType = MovementType.StockIn,
                    Reason = "Transfer Completed"
                };

                await _movementRepository.AddAsync(movement);
            }

            transfer.Status = TransferStatus.Completed;
            transfer.CompletedAt = DateTime.UtcNow;

            _transferRepository.Update(transfer);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitTransactionAsync();

            result.Success = true;
            result.Message =
                "Transfer completed successfully.";

            return result;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();

            result.Success = false;
            result.Message =
                "An error occurred while completing transfer.";

            return result;
        }
    }

    public async Task<TransferResultDto> CancelTransferAsync(
    int transferId,
    int employeeId)
{
    var result = new TransferResultDto();


    var employee =
        await _employeeRepository.GetByIdAsync(employeeId);


    if (employee is null)
    {
        result.Success = false;
        result.Message = "Employee not found.";
        return result;
    }


    var transfer =
        await _transferRepository.GetByIdWithItemsAsync(
            transferId);


    if (transfer is null)
    {
        result.Success = false;
        result.Message = "Transfer not found.";
        return result;
    }


    if (transfer.Status != TransferStatus.InTransit)
    {
        result.Success = false;
        result.Message =
            "Only InTransit transfers can be cancelled.";

        return result;
    }


    if (employee.StoreId != transfer.SourceStoreId)
    {
        result.Success = false;
        result.Message =
            "Only source store can cancel transfer.";

        return result;
    }



    await _unitOfWork.BeginTransactionAsync();


    try
    {
        foreach(var item in transfer.Items)
        {

            var stock =
                await _stockRepository.GetByProductAndStoreAsync(
                    item.ProductId,
                    transfer.SourceStoreId);


            if(stock is null)
            {
                await _unitOfWork.RollbackTransactionAsync();

                result.Success = false;
                result.Message =
                    "Original stock location not found.";

                return result;
            }



            stock.Quantity += item.Quantity;


            _stockRepository.Update(stock);



            var movement = new StockMovement
            {
                ProductId = item.ProductId,
                StoreId = transfer.SourceStoreId,
                EmployeeId = employee.Id,
                Quantity = item.Quantity,
                MovementType = MovementType.StockIn,
                Reason = "Transfer Cancelled"
            };


            await _movementRepository.AddAsync(movement);
        }



        transfer.Status = TransferStatus.Cancelled;


        _transferRepository.Update(transfer);



        await _unitOfWork.SaveChangesAsync();


        await _unitOfWork.CommitTransactionAsync();



        result.Success = true;
        result.Message =
            "Transfer cancelled successfully.";


        return result;

    }
    catch
    {
        await _unitOfWork.RollbackTransactionAsync();


        result.Success = false;
        result.Message =
            "Error while cancelling transfer.";


        return result;
    }
}
}