using System;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Dto.ServersDto;
using APIDashboard.Helpers;
using APIDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServersController : ControllerBase
    {
        private IServer _server;

        public ServersController(IServer server)
        {
            _server = server;
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<IActionResult> Index(int pageIndex, int pageSize)
        {
            var servers = await _server.GetAll();
            var page = new PaginatedResponse<Server>(servers, pageIndex, pageSize);
            var totalPage = Math.Ceiling((double)servers.Count() / pageSize);

            var response = new
            {
                Page = page,
                TotalPages = totalPage
            };
            return Ok(response);
        }

        [HttpGet("ById/{id:int:min(1)}")]
        public async Task<IActionResult> Detail(int id)
        {
            return Ok(await _server.GetById(id));
        }

        [HttpGet("GetOnline")]
        public async Task<IActionResult> Online()
        {
            var servers = await _server.GetAll();
            var online = servers.Where(server => server.IsOnline == true);
            return Ok(online);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Message(int id, ServerDto msg)
        {
            var server = await _server.GetById(id);
            if (msg.PayLoad == "activate") server.IsOnline = true;
            if (msg.PayLoad == "deactivate") server.IsOnline = false;

            await _server.Edit(server);
            return Ok("Status changed");
        }
    }
}