namespace InteliTrack.Application.DTOs.Shelves;

public class ShelfDto
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public int SectionId { get; set; }

    public bool IsActive { get; set; }
}