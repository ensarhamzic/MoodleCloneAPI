using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.Models
{
    public class Smer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }

        public ICollection<Student> Studenti { get; set; }
        public ICollection<Kurs> Kursevi { get; set; }
    }
}
