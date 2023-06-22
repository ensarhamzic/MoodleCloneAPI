using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.Models
{
    public class Zvanje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }

        public ICollection<Nastavnik> Nastavnici { get; set; }
    }
}
