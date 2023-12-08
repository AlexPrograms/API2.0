using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models.DTO;

public class CarDTO
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Model { get; set; }
    public string Brand { get; set; }
    [Required]
    public int Price { get; set; }

    public string Description { get; set; }

    public int MaxSpeed { get; set; }

    public string CountryOfOrigin { get; set; }
}