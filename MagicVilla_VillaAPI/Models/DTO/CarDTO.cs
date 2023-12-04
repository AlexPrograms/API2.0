using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO;

public class CarDTO
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Model { get; set; }
    public string Brand { get; set; }
    public int Price { get; set; }
}