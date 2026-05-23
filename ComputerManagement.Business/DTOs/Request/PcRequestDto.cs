using System.ComponentModel.DataAnnotations;

namespace ComputerManagement.Business.DTOs.Request;

public class PcRequestDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "Weight must be greater than 0.")]
    public float Weight { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Warranty must be non-negative.")]
    public int Warranty { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative.")]
    public int Stock { get; set; }
}
