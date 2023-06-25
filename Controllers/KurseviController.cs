using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleCloneAPI.Data.Services;
using MoodleCloneAPI.Data.ViewModels.Requests;

namespace MoodleCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurseviController : ControllerBase
    {
        private readonly KursService kursService;

        public KurseviController(KursService kursService)
        {
            this.kursService = kursService;
        }

        [HttpGet("me")]
        public IActionResult Get()
        {
            try
            {
                var response = kursService.GetTeacherCourses();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = kursService.GetCourseById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Profesor")]
        public IActionResult Create([FromBody] KursVM request)
        {
            try
            {
                var response = kursService.CreateCourse(request);
                return Created(nameof(response), response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
