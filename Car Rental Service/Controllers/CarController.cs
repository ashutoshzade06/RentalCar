using BLL_.Repository;
using DAL;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
        public IActionResult GetAllCar()
        {
            var model =  _repository.SelectAll<Car>();
            return Ok(model);
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
            if (UIN != model.CarID)
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
                CarID = model.CarID,
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

        [HttpPost("uploadBulkData")]
        public  async Task<ActionResult<Car[]>> uploadBulkData([FromBody] Car[] carData)
        {
            if (carData != null)
            {
                foreach (Car car in carData) {
                    Car new_car = new Car
                    {
                        CarID = car.CarID,
                        Fuel_Type = car.Fuel_Type,
                        License = car.License,
                        Model = car.Model,
                        Type = car.Type
                    };
                    await _repository.CreateAsync<Car>(new_car);
                    
                }
                return Ok();
            }


           
                return NotFound();
            
        }


    }
}