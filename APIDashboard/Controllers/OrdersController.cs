using System;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Dto;
using APIDashboard.Helpers;
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

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> Index(int pageIndex, int pageSize)
        {
            var orders = await _order.GetAll();         
            var page = new PaginatedResponse<Order>(orders.OrderByDescending(o => o.Total), pageIndex, pageSize);
            var totalPages = Math.Ceiling((double)orders.Count() / pageSize);

            var response = new
            {
                Page = page,
                TotalPages = totalPages
            };
            return Ok(response);
        }

        [HttpGet("ByState")]
        public async Task<IActionResult> ByState()
        {
            return Ok(await _order.GetByState());
        }

        [HttpGet("ByCustomer/{n}")]
        public async Task<IActionResult> ByCustomer(int n)
        {
            return Ok(await _order.GetByCustomer(n));
        }

        [HttpGet("{id:int:min(1)}", Name = "Detail")]
        public async Task<IActionResult> Detail(int id)
        {
            var order = await _order.GetOrderCustomer(id);
            if (order == null) return NotFound($"Not exist any order with id:{id}!");
            var model = new OrderDto
            {
                Id = order.Id,
                Placed = order.Placed.ToString("dd/MM/yyyy"),
                Total = order.Total,
                Customer = order.Customer.Name,
                CustomerId = order.CustomerId,
                Completed = order.Completed,
                State = order.Customer.State
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