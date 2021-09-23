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
    public class CustomerController : ControllerBase
    {
        private readonly IRepository _repository;
        public CustomerController(Car_RentalDbContext context, IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllCustomer")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
        {
            var model = await _repository.SelectAll<Customer>();
            return model;
        }

        [HttpGet("GetCustomerByLicense/{License}")]
        public async Task<ActionResult<Customer>> GetCustomerById(string License)
        {
            var model = await _repository.SelectById<Customer>(License);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("Update-CustomerByLicense/{License}")]
        public async Task<IActionResult> UpdateMember(string License, [FromBody] Customer model)
        {
            if (License != model.Driver_License)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<Customer>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> InsertCustomer([FromBody] Customer model)
        {
            Customer new_customer = new Customer
            {
                City = model.City,
                Driver_License = model.Driver_License,
                First_Name = model.First_Name,
                Last_Name = model.Last_Name,
                Phone_No = model.Phone_No,
                Postal_Code = model.Postal_Code,
                State = model.State
            };
            await _repository.CreateAsync<Customer>(new_customer);
            return Ok();
        }

        [HttpDelete("Delete-CustomerByLicense/{License}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(string License)
        {
            var model = await _repository.SelectById<Customer>(License);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Customer>(model);

            return model;
        }
    }
}
