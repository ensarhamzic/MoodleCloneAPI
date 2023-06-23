using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DodajStudentaNaSmer(StudentSmerVM request)
        {
            var result = smeroviService.DodajStudentaNaSmer(request);
            return Ok(result);
        }
    }
}
