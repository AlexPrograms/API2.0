using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;

[ApiController]
[Route("api/CarAPI")]
public class CarAPIController : Controller
{
    private readonly ApplicationDbContext _db;
    public CarAPIController(ApplicationDbContext db)
    {
        _db = db;
    }
  /*  private readonly ILogging _logger;

    public CarAPIController(ILogging logger)
    {
        _logger = logger;
    }*/
    
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<CarDTO>> GetCars()
    {
        //_logger.Log("Getting all cars","");
        return Ok(_db.Cars.ToList());
    }
    
    [HttpGet("{id:int}", Name = "GetCar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CarDTO> GetCar(int id)
    {
        if (id==0)
        {
            //_logger.Log("Get car error with id" + id, "error");
            return BadRequest();
        }

        var car = _db.Cars.FirstOrDefault(u => u.Id == id);
        if (car==null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<CarDTO> CreateVilla([FromBody]CarDTO carDto)
    {
        if (_db.Cars.FirstOrDefault(u=>u.Model.ToLower()==carDto.Model.ToLower()) != null)
        {
            ModelState.AddModelError("CustomError","Villa already Exists!");
            return BadRequest(ModelState);
        }
        if (carDto == null)
        {
            return BadRequest(carDto);
        }

        if (carDto.Id >0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        Car model = new Car()
        {
            Id = carDto.Id,
            Model = carDto.Model,
            Brand = carDto.Brand,
            Price = carDto.Price,
            Description = carDto.Description,
            MaxSpeed = carDto.MaxSpeed,
            CountryOfOrigin = carDto.CountryOfOrigin,
        };

        _db.Cars.Add(model);
        _db.SaveChanges();
        return CreatedAtRoute("GetCar", new { id = carDto.Id }, carDto);
    }

    [HttpDelete("{id:int}", Name = "DeleteCar")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteCar(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        var car = _db.Cars.FirstOrDefault(u => u.Id == id);
        if (car == null)
        {
            return NotFound();
        }

        _db.Cars.Remove(car);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdateCar(int id, [FromBody] CarDTO carDto)
    {
        if (carDto == null || id != carDto.Id)
        {
            return BadRequest();
        }
        /*        var car = CarStore.carList.FirstOrDefault(u => u.Id == id);
                car.Model = carDto.Model;
                car.Brand = carDto.Brand;
                car.Price = carDto.Price;*/

        Car model = new Car()
        {
            Id = carDto.Id,
            Model = carDto.Model,
            Brand = carDto.Brand,
            Price = carDto.Price,
            Description = carDto.Description,
            MaxSpeed = carDto.MaxSpeed,
            CountryOfOrigin = carDto.CountryOfOrigin,
        };
        _db.Cars.Update(model);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "UpdatePartialCar")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdatePartialCar(int id, JsonPatchDocument<CarDTO> patchDTO)
    {
        if (patchDTO == null || id ==0)
        {
            return BadRequest();
        }
        
        var car = _db.Cars.FirstOrDefault(u => u.Id == id);

        CarDTO carDTO = new()
        {
            Id = car.Id,
            Model = car.Model,
            Brand = car.Brand,
            Price = (int)car.Price,
            Description = car.Description,
            MaxSpeed = car.MaxSpeed,
            CountryOfOrigin = car.CountryOfOrigin,
        };

        if (car == null)
        {
            return BadRequest();
        }
        
        patchDTO.ApplyTo(carDTO, ModelState);
        Car model = new Car()
        {
            Id = carDTO.Id,
            Model = carDTO.Model,
            Brand = carDTO.Brand,
            Price = carDTO.Price,
            Description = carDTO.Description,
            MaxSpeed = carDTO.MaxSpeed,
            CountryOfOrigin = carDTO.CountryOfOrigin,
        };
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        _db.Cars.Update(model);
        _db.SaveChanges();

        return NoContent();
    }
}