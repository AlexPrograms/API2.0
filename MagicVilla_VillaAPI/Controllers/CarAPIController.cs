using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;

[ApiController]
[Route("api/CarAPI")]
public class CarAPIController : Controller
{
        private readonly ILogging _logger;

    public CarAPIController(ILogging logger)
    {
        _logger = logger;
    }
    
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<CarDTO>> GetCars()
    {
        _logger.Log("Getting all cars","");
        return Ok(CarStore.carList);
    }
    
    [HttpGet("{id:int}", Name = "GetCar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CarDTO> GetCar(int id)
    {
        if (id==0)
        {
            _logger.Log("Get car error with id" + id, "error");
            return BadRequest();
        }

        var car = CarStore.carList.FirstOrDefault(u => u.Id == id);
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
        if (CarStore.carList.FirstOrDefault(u=>u.Model.ToLower()==carDto.Model.ToLower()) != null)
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

        carDto.Id = CarStore.carList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
        CarStore.carList.Add(carDto);
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
        var car = CarStore.carList.FirstOrDefault(u => u.Id == id);
        if (car == null)
        {
            return NotFound();
        }

        CarStore.carList.Remove(car);
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
        var car = CarStore.carList.FirstOrDefault(u => u.Id == id);
        car.Model = carDto.Model;
        car.Brand = carDto.Brand;
        car.Price = carDto.Price;
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
        
        var car = CarStore.carList.FirstOrDefault(u => u.Id == id);
        if (car == null)
        {
            return BadRequest();
        }
        
        patchDTO.ApplyTo(car, ModelState);
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return NoContent();
    }
}