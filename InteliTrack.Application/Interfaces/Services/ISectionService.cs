using InteliTrack.Application.DTOs.Sections;

namespace InteliTrack.Application.Interfaces.Services;

public interface ISectionService
{
    Task<SectionDto> CreateAsync(CreateSectionDto dto);

    Task<SectionDto?> GetByIdAsync(int id);

    Task<IEnumerable<SectionDto>> GetAllAsync();

    Task<SectionDto> UpdateAsync(int id, UpdateSectionDto dto);

    Task DeactivateAsync(int id);
}