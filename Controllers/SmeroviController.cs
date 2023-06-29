using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MoodleCloneAPI.Data.Services;
using MoodleCloneAPI.Data.ViewModels.Requests;

namespace MoodleCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmeroviController : ControllerBase
    {
        private readonly SmeroviService smeroviService;

        public SmeroviController(SmeroviService smeroviService)
        {
            this.smeroviService = smeroviService;
        }

        [HttpGet]
        public IActionResult GetSmerovi()
        {
            var result = smeroviService.GetSmerovi();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetSmer(int id)
        {
            var result = smeroviService.GetSmer(id);
            return Ok(result);
        }

        [HttpGet("index-exists/{indeks}")]
        public IActionResult IndexExists(string indeks)
        {
            try
            {
                var result = smeroviService.IndexExists(indeks);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost("novi")]
        [Authorize(Roles = "Admin")]
        public IActionResult DodajSmer(SmerVM request)
        {
            try
            {
                var result = smeroviService.DodajSmer(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DodajStudentaNaSmer(StudentSmerVM request)
        {
            try
            {
                var result = smeroviService.DodajStudentaNaSmer(request);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }
    }
}
