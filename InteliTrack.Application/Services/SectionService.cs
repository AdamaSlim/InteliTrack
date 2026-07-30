using InteliTrack.Application.DTOs.Sections;
using InteliTrack.Application.Interfaces.Repositories;
using InteliTrack.Application.Interfaces.Repos;
using InteliTrack.Application.Interfaces.Services;
using InteliTrack.Domain.Entities;

namespace InteliTrack.Application.Services;

public class SectionService : ISectionService
{
    private readonly ISectionRepository _sectionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SectionService(
        ISectionRepository sectionRepository,
        IUnitOfWork unitOfWork)
    {
        _sectionRepository = sectionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<SectionDto> CreateAsync(CreateSectionDto dto)
    {
        var section = new Section
        {
            Name = dto.Name,
            StoreId = dto.StoreId,
            IsActive = true
        };

        await _sectionRepository.AddAsync(section);
        await _unitOfWork.SaveChangesAsync();

        return MapToDto(section);
    }

    public async Task<SectionDto?> GetByIdAsync(int id)
    {
        var section = await _sectionRepository.GetByIdAsync(id);

        return section is null ? null : MapToDto(section);
    }

    public async Task<IEnumerable<SectionDto>> GetAllAsync()
    {
        var sections = await _sectionRepository.GetAllAsync();

        return sections.Select(MapToDto);
    }

    public async Task<SectionDto> UpdateAsync(
        int id,
        UpdateSectionDto dto)
    {
        var section = await _sectionRepository.GetByIdAsync(id);

        if (section == null)
            throw new Exception("Section not found.");

        section.Name = dto.Name;
        section.StoreId = dto.StoreId;

        _sectionRepository.Update(section);

        await _unitOfWork.SaveChangesAsync();

        return MapToDto(section);
    }

    public async Task DeactivateAsync(int id)
    {
        var section = await _sectionRepository.GetByIdAsync(id);

        if (section == null)
            throw new Exception("Section not found.");

        section.IsActive = false;

        _sectionRepository.Update(section);

        await _unitOfWork.SaveChangesAsync();
    }

    private static SectionDto MapToDto(Section section)
    {
        return new SectionDto
        {
            Id = section.Id,
            Name = section.Name,
            StoreId = section.StoreId,
            IsActive = section.IsActive
        };
    }
}