using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleCloneAPI.Data.Services;
using MoodleCloneAPI.Data.ViewModels;

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

    }
}
