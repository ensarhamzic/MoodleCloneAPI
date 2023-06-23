using MoodleCloneAPI.Data.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.ViewModels.Requests
{
    public class UserRegisterVM : IValidatableObject
    {
        [Required]
        public string JMBG { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public char Pol { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        public string ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("Passwords don't match");
            }
        }
    }
}
