namespace CarServiceAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CarServiceAPI.Services;
using CarServiceAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class CarModelsController : ControllerBase
{
    private readonly ICarModelService _carModelService;

    public CarModelsController(ICarModelService carModelService)
    {
        _carModelService = carModelService;
    }

    // GET api/carmodels/{id}
    [HttpGet("{id}")]
    public ActionResult<CarModel> GetCarModel(string id)
    {
        var carModel = _carModelService.GetById(id);
        if (carModel == null)
        {
            return NotFound();
        }
        return carModel;
    }

    // GET api/carmodels
    [HttpGet]
    public ActionResult<List<CarModel>> GetAllCarModels()
    {
        return _carModelService.GetAll();
    }

    // POST api/carmodels
    [HttpPost]
    public ActionResult<CarModel> PostCarModel([FromBody] CarModel carModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _carModelService.Add(carModel);
        return CreatedAtAction(nameof(GetCarModel), new { id = carModel.Id }, carModel);
    }

    // DELETE api/carmodels/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteCarModel(string id)
    {
        var success = _carModelService.Delete(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}
