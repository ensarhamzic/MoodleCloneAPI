using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleCloneAPI.Data.Services;
using MoodleCloneAPI.Data.ViewModels.Requests;

namespace MoodleCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObavestenjaController : ControllerBase
    {
        private readonly ObavestenjesService obavestenjesService;

        public ObavestenjaController(ObavestenjesService obavestenjesService)
        {
            this.obavestenjesService = obavestenjesService;
        }

        [HttpGet("kursevi/{kursId}")]
        public IActionResult GetObavestenja(int kursId, [FromQuery] int? num)
        {
            var result = obavestenjesService.GetObavestenja(kursId, num);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetObavestenje(int id)
        {
            var result = obavestenjesService.GetObavestenje(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Profesor,Asistent")]
        public IActionResult AddObavestenje(ObavestenjeVM request)
        {
            try
            {
                var result = obavestenjesService.AddObavestenje(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
