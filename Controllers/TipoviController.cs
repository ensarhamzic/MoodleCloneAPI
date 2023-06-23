using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleCloneAPI.Data.Services;

namespace MoodleCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoviController : ControllerBase
    {
        private readonly TipService tipService;

        public TipoviController(TipService tipService)
        {
            this.tipService = tipService;
        }

        [HttpGet]
        public IActionResult GetTipovi()
        {
            var result = tipService.GetTipovi();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTip(int id)
        {
            var result = tipService.GetTip(id);
            return Ok(result);
        }
    }
}
