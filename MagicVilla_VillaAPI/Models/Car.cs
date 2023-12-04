using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models;

public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Price { get; set; }
    public DateTime CreatedDate { get; set; }
}