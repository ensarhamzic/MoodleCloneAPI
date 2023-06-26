using Azure;
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

        [HttpGet("{id}/prijave")]
        [Authorize(Roles = "Profesor,Asistent")]
        public IActionResult GetApplications(int id)
        {
            try
            {
                var response = kursService.GetPrijaveNaKurs(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/prijave")]
        [Authorize(Roles = "Profesor,Asistent")]
        public IActionResult OdgovoriNaPrijavu(int id, [FromBody] OdgovorPrijavaVM request)
        {
            try
            {
                var response = kursService.OdgovoriNaPrijavu(request, id);
                return Ok(new {message = response});
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

        [HttpPost("{id}/prijava")]
        [Authorize(Roles = "Student")]
        public IActionResult Apply(int id)
        {
            try
            {
                var response = kursService.PrijaviSeNaKurs(id);
                return Ok(new {message = response});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/materijali")]
        [Authorize(Roles = "Profesor,Asistent")]
        public IActionResult DodajMaterijal(int id, [FromForm] MaterijalVM request)
        {
            try
            {
                var response = kursService.DodajMaterijal(request, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("materijali/{id}")]
        [Authorize(Roles = "Profesor,Asistent")]
        public IActionResult GetMaterijal(int id)
        {
            try
            {
                var response = kursService.GetMaterijal(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("materijali/{id}")]
        [Authorize(Roles = "Profesor,Asistent")]
        public IActionResult IzbrisiMaterijal(int id)
        {
            try
            {
                var response = kursService.IzbrisiMaterijal(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("materijali/{id}")]
        [Authorize(Roles = "Profesor,Asistent")]
        public IActionResult AzurirajMaterijal(int id, [FromForm] MaterijalVM request)
        {
            try
            {
                var response = kursService.AzurirajMaterijal(request, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
