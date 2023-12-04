using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Data;

public class CarStore
{
    public static List<CarDTO> carList = new List<CarDTO>
    {
        new CarDTO{Id=1, Model = "Zonda", Brand = "Pagani", Price = 5}, 
        new CarDTO{Id=2, Model = "Cebertruck", Brand  = "Tesla", Price = 80},
        new CarDTO{Id=3, Model = "4", Brand = "BWM", Price = 50},
        new CarDTO{Id=4, Model = "5", Brand = "Audi", Price = 1}
        
    };
}