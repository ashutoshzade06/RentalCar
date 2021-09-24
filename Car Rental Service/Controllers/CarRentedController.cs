using BLL_.RentedCarVM;
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
    public class CarRentedController : ControllerBase
    {
        private readonly IRepository _repository;
        public CarRentedController(Car_RentalDbContext context, IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllRentedCar")]
        public IActionResult GetAllRentedcar()
        {
            var model =  _repository.SelectAll<Rented_Car>(includeProperties: "Car,Customer");
            return Ok(model);
        }

        [HttpGet("GetRentedCarById/{id}")]
        public async Task<ActionResult<Rented_Car>> GetRentedCarById(int id)
        {
            var model = await _repository.SelectById<Rented_Car>(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("Update-RentedCarById/{id}")]
        public async Task<IActionResult> UpdateRentedCar(int id, [FromBody] Rented_CarVM model)
        {

            var newmodel = await _repository.SelectById<Rented_Car>(id);
            if (newmodel != null)
            {
                newmodel.Price = model.Price;
                newmodel.Odometer_Before = model.Odometer_Before;
                newmodel.Odometer_After = model.Odometer_After;
                newmodel.Car_ID = model.Car_ID;
                newmodel.Driver_License = model.Driver_License;
                newmodel.From_Date = model.From_Date;
                newmodel.To_Date = model.To_Date;
                newmodel.From_Location = model.From_Location;
                newmodel.To_Location = model.To_Location;
            }
            await _repository.UpdateAsync<Rented_Car>(newmodel);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Rented_Car>> InsertRentedCar([FromBody] Rented_CarVM model)
        {
            Rented_Car rented_Car = new Rented_Car
            {
                Car_ID = model.Car_ID,
                Driver_License = model.Driver_License,
                From_Date = model.From_Date,
                To_Date = model.To_Date,
                From_Location = model.From_Location,
                To_Location = model.To_Location,
                Price = model.Price,
                Odometer_Before = model.Odometer_Before,
                Odometer_After = model.Odometer_After
            };
            await _repository.CreateAsync<Rented_Car>(rented_Car);
            return Ok();
        }

        [HttpDelete("Delete-RentedCarById/{Rented_Id}")]
        public async Task<ActionResult<Rented_Car>> DeleteRentedCar(int Rented_Id)
        {
            var model = await _repository.SelectById<Rented_Car>(Rented_Id);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Rented_Car>(model);

            return model;
        }
    }
}
