using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customer;

        public CustomersController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customer.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetCustomer")]
        public async Task<IActionResult> Detail(int id)
        {
            var customer = await _customer.GetById(id);
            if (customer == null) return NotFound($"Not exist any customer with id:{id}!");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _customer.Create(customer);
            return new CreatedAtRouteResult("Getcustomer", new { id = customer.Id }, customer);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _customer.Edit(customer);
            return new CreatedAtRouteResult("Getcustomer", new { id = customer.Id }, customer);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customer.Remove(id);
            return RedirectToAction("GetAll");
        }
    }
}