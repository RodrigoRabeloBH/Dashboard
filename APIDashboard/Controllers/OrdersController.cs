using System;
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
    public class OrdersController : ControllerBase
    {
        private readonly IOrder _order;
        private readonly IMapper _mapper;
        public OrdersController(IOrder order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _order.GetAll();

            var list = orders.Select(o => new OrderIndexDto
            {
                Id = o.Id,
                Placed = o.Placed.ToString("dd/MM/yyyy"),
                Total = o.Total,
                Completed = o.Completed?.ToString("dd/MM/yyyy")
            });

            var model = _mapper.Map<IEnumerable<OrderIndexDto>>(list);
            return Ok(model);
        }

        [HttpGet("{id:int:min(1)}", Name = "Detail")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _order.GetOrderCustomer(id);
            if (order == null) return NotFound($"Not exist any order with id:{id}!");
            var model = new OrderDto
            {
                Id = order.Id,
                Placed = order.Placed,
                Total = order.Total,
                Customer = order.Customer.Name,
                CustomerId = order.CustomerId,
                Completed = order.Completed
            };

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            var customer = await _order.GetCustomer(orderDto.CustomerId);
            if (!ModelState.IsValid || customer == null) return BadRequest(orderDto);
            await _order.Create(_mapper.Map<Order>(orderDto));
            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> Edit(OrderDto orderDto)
        {
            if (!ModelState.IsValid) return BadRequest(orderDto);
            var order = await _order.GetById(orderDto.Id);
            order.Total = orderDto.Total;
            await _order.Edit(order);
            return new CreatedAtRouteResult("Detail", new { id = order.Id }, order);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _order.Remove(id);
            return RedirectToAction("Index");
        }
    }
}