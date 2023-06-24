using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleCloneAPI.Data.Services;
using MoodleCloneAPI.Data.ViewModels.Requests;

namespace MoodleCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private UserService userService;
        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register-admin")]
        public IActionResult RegisterAdmin([FromBody] AdminRegisterVM request)
        {
            try
            {
                var response = userService.RegisterAdmin(request);
                return Created(nameof(response), response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }        
        
        [HttpPost("register-student")]
        public IActionResult RegisterStudent([FromBody] StudentRegisterVM request)
        {
            try
            {
                var response = userService.RegisterStudent(request);
                return Created(nameof(response), response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }       
        
        [HttpPost("register-teacher")]
        public IActionResult RegisterTeacher([FromBody] TeacherRegisterVM request)
        {
            try
            {
                var response = userService.RegisterTeacher(request);
                return Created(nameof(response), response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginVM request)
        {
            try
            {
                var response = userService.Login(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("email-exists/{email}")]
        public IActionResult EmailExists(string email)
        {
            try
            {
                var response = userService.EmailExists(email);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("username-exists/{username}")]
        public IActionResult UsernameExists(string username)
        {
            try
            {
                var response = userService.UsernameExists(username);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("jmbg-exists/{jmbg}")]
        public IActionResult JMBGExists(string jmbg)
        {
            try
            {
                var response = userService.JMBGExists(jmbg);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("check-token")]
        public IActionResult CheckToken()
        {
            try
            {
                var response = userService.CheckToken();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("unverified-teachers")]
        public IActionResult GetUnverifiedTeachers()
        {
            try
            {
                var response = userService.GetUnverifiedTeachers();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("verify-teacher/{jmbg}")]
        public IActionResult VerifyTeacher(string jmbg)
        {
            try
            {
                var response = userService.VerifyTeacher(jmbg);
                return Ok(new {message = response});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-teacher/{jmbg}")]
        public IActionResult DeleteTeacher(string jmbg)
        {
            try
            {
                var response = userService.DeleteTeacher(jmbg);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("students")]
        public IActionResult GetStudents()
        {
            try
            {
                var response = userService.GetStudents();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}