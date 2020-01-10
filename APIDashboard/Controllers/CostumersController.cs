using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostumersController : ControllerBase
    {
        private readonly ICostumer _costumer;

        public CostumersController(ICostumer costumer)
        {
            _costumer = costumer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var costumers = await _costumer.GetAll();
            return Ok(costumers);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetCostumer")]
        public async Task<IActionResult> Detail(int id)
        {
            var costumer = await _costumer.GetById(id);
            if (costumer == null) return NotFound($"Not exist any costumer with id:{id}!");
            return Ok(costumer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Costumer costumer)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _costumer.Create(costumer);
            return new CreatedAtRouteResult("GetCostumer", new { id = costumer.Id }, costumer);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Costumer costumer)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _costumer.Edit(costumer);
            return new CreatedAtRouteResult("GetCostumer", new { id = costumer.Id }, costumer);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _costumer.Remove(id);
            return RedirectToAction("GetAll");
        }
    }
}