using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.ViewModels.Requests
{
    public class UserLoginVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
