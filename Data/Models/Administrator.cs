using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.Models
{
    public class Administrator
    {
        [Key]
        public string OsobaJMBG { get; set; }
        [Required]
        public Osoba Osoba { get; set; }
    }
}
