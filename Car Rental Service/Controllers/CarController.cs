using BLL_.Repository;
using DAL;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IRepository _repository;
        public CarController(Car_RentalDbContext context, IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllCar")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCar()
        {
            var model = await _repository.SelectAll<Car>();
            return model;
        }

        [HttpGet("GetCarByUIN/{UIN}")]
        public async Task<ActionResult<Car>> GetCarById(string UIN)
        {
            var model = await _repository.SelectById<Car>(UIN);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("Update-CarByUIN/{UIN}")]
        public async Task<IActionResult> UpdateMember(string UIN, [FromBody] Car model)
        {
            if (UIN != model.UIN)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<Car>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Car>> InsertCar([FromBody] Car model)
        {
            Car new_car = new Car
            {
                UIN = model.UIN,
                Fuel_Type = model.Fuel_Type,
                License = model.License,
                Model = model.Model,
                Type = model.Type
            };
            await _repository.CreateAsync<Car>(new_car);
            return Ok();
        }

        [HttpDelete("Delete-CarByUIN/{UIN}")]
        public async Task<ActionResult<Car>> DeleteCar(string UIN)
        {
            var model = await _repository.SelectById<Car>(UIN);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Car>(model);

            return model;
        }
    }
}