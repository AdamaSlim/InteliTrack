namespace InteliTrack.Domain.Entities;

public class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public ICollection<Section> Sections { get; set; } = new List<Section>();
}