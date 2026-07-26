using InteliTrack.Application.DTOs.Suppliers;

namespace InteliTrack.Application.Interfaces.Services;

public interface ISupplierService
{
    Task<SupplierDto> CreateAsync(CreateSupplierDto dto);
    Task<SupplierDto?> GetByIdAsync(int id);
    Task<IEnumerable<SupplierDto>> GetAllAsync();
    Task<SupplierDto> UpdateAsync(int id, UpdateSupplierDto dto);
    Task DeactivateAsync(int id);
}