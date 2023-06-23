using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleCloneAPI.Data.Services;

namespace MoodleCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZvanjaController : ControllerBase
    {
        private readonly ZvanjeService zvanjaService;

        public ZvanjaController(ZvanjeService zvanjaService)
        {
            this.zvanjaService = zvanjaService;
        }

        [HttpGet]
        public IActionResult GetZvanja()
        {
            var result = zvanjaService.GetZvanja();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetZvanje(int id)
        {
            var result = zvanjaService.GetZvanje(id);
            return Ok(result);
        }
    }
}
