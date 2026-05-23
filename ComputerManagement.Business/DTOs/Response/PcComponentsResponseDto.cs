namespace ComputerManagement.Business.DTOs.Response;

public class PcComponentsResponseDto
{
    public int PcId { get; set; }
    public string PcName { get; set; } = null!;
    public List<ComponentDetailDto> Components { get; set; } = new();
}

public class ComponentDetailDto
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Amount { get; set; }
    public string ComponentType { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
}
