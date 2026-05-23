using System.ComponentModel.DataAnnotations;

namespace ComputerManagement.DTOs;

public class AddPcDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Weight must be greater than 0.")]
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
