using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Dto;
using APIDashboard.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customer;
        private readonly IMapper _mapper;

        public CustomersController(ICustomer customer, IMapper mapper)
        {
            _customer = customer;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CustomerIndexDto>>(await _customer.GetAll()));
        }

        [HttpGet("{id:int:min(1)}", Name = "GetCustomer")]
        public async Task<IActionResult> Detail(int id)
        {
            var customer = await _customer.GetCustomerOrders(id);
            if (customer == null) return NotFound($"Not exist any customer with id:{id}!");
            var model = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                State = customer.State,
                Email = customer.Email,
                QtdOrdes = customer.Orders.Count(),
                Amount = customer.Orders.Sum(o => o.Total)
            };
            return Ok(model);   
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest(customerDto);
            var customer = _mapper.Map<Customer>(customerDto);
            await _customer.Create(customer);
            return new CreatedAtRouteResult("Getcustomer", new { id = customer.Id }, customer);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest(customerDto);
            await _customer.Edit(_mapper.Map<Customer>(customerDto));
            return new CreatedAtRouteResult("GetCustomer", new { id = customerDto.Id }, _mapper.Map<Customer>(customerDto));
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customer.Remove(id);
            return RedirectToAction("GetAll");
        }
    }
}