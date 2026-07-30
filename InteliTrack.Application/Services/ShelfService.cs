using InteliTrack.Application.DTOs.Shelves;
using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Services;

public class ShelfService : IShelfService
{
    private readonly IShelfRepository _shelfRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ShelfService(
        IShelfRepository shelfRepository,
        IUnitOfWork unitOfWork)
    {
        _shelfRepository = shelfRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ShelfDto> CreateAsync(CreateShelfDto dto)
    {
        var shelf = new Shelf
        {
            Code = dto.Code,
            Capacity = dto.Capacity,
            SectionId = dto.SectionId,
            IsActive = true
        };

        await _shelfRepository.AddAsync(shelf);
        await _unitOfWork.SaveChangesAsync();

        return MapToDto(shelf);
    }

    public async Task<ShelfDto?> GetByIdAsync(int id)
    {
        var shelf = await _shelfRepository.GetByIdAsync(id);

        return shelf is null ? null : MapToDto(shelf);
    }

    public async Task<IEnumerable<ShelfDto>> GetAllAsync()
    {
        var shelves = await _shelfRepository.GetAllAsync();

        return shelves.Select(MapToDto);
    }

    public async Task<ShelfDto> UpdateAsync(int id, UpdateShelfDto dto)
    {
        var shelf = await _shelfRepository.GetByIdAsync(id);

        if (shelf == null)
            throw new Exception("Shelf not found.");

        shelf.Code = dto.Code;
        shelf.Capacity = dto.Capacity;
        shelf.SectionId = dto.SectionId;

        _shelfRepository.Update(shelf);

        await _unitOfWork.SaveChangesAsync();

        return MapToDto(shelf);
    }

    public async Task DeactivateAsync(int id)
    {
        var shelf = await _shelfRepository.GetByIdAsync(id);

        if (shelf == null)
            throw new Exception("Shelf not found.");

        shelf.IsActive = false;

        _shelfRepository.Update(shelf);

        await _unitOfWork.SaveChangesAsync();
    }

    private static ShelfDto MapToDto(Shelf shelf)
    {
        return new ShelfDto
        {
            Id = shelf.Id,
            Code = shelf.Code,
            Capacity = shelf.Capacity,
            SectionId = shelf.SectionId,
            IsActive = shelf.IsActive
        };
    }
}