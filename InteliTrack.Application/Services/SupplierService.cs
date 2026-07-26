using InteliTrack.Application.DTOs.Suppliers;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(
        ISupplierRepository supplierRepository,
        IUnitOfWork unitOfWork)
    {
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<SupplierDto> CreateAsync(CreateSupplierDto dto)
    {
        var supplier = new Supplier
        {
            Name = dto.Name,
            ContactEmail = dto.ContactEmail,
            IsActive = true
        };

        await _supplierRepository.AddAsync(supplier);
        await _unitOfWork.SaveChangesAsync();

        return MapToDto(supplier);
    }

    public async Task<SupplierDto?> GetByIdAsync(int id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);

        return supplier is null ? null : MapToDto(supplier);
    }

    public async Task<IEnumerable<SupplierDto>> GetAllAsync()
    {
        var suppliers = await _supplierRepository.GetAllAsync();

        return suppliers.Select(MapToDto);
    }

    public async Task<SupplierDto> UpdateAsync(
        int id,
        UpdateSupplierDto dto)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);

        if (supplier == null)
            throw new Exception("Supplier not found.");

        supplier.Name = dto.Name;
        supplier.ContactEmail = dto.ContactEmail;

        _supplierRepository.Update(supplier);

        await _unitOfWork.SaveChangesAsync();

        return MapToDto(supplier);
    }

    public async Task DeactivateAsync(int id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);

        if (supplier == null)
            throw new Exception("Supplier not found.");

        supplier.IsActive = false;

        _supplierRepository.Update(supplier);

        await _unitOfWork.SaveChangesAsync();
    }

    private static SupplierDto MapToDto(Supplier supplier)
    {
        return new SupplierDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            ContactEmail = supplier.ContactEmail,
            IsActive = supplier.IsActive
        };
    }
}