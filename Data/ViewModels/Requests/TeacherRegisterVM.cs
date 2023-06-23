using MoodleCloneAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.ViewModels.Requests
{
    public class TeacherRegisterVM : UserRegisterVM
    {
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public int GodineRadnogStaza { get; set; }
        [Required]
        public int ZvanjeId { get; set; }
        [Required]
        public int TipId { get; set; }
    }
}
