namespace InteliTrack.Application.DTOs.Shelves;

public class UpdateShelfDto
{
    public string Code { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public int SectionId { get; set; }
}