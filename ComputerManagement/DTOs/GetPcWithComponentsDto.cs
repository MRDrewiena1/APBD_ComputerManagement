namespace ComputerManagement.DTOs;

public class GetPcWithComponentsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public IEnumerable<PcComponentDto> Components { get; set; } = [];
}

public class PcComponentDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Amount { get; set; }
    public string ComponentType { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
}
