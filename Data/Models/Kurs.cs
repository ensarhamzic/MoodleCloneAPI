using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.Models
{
    public class Kurs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public bool HronoloskiMod { get; set; }
        [Required]
        public int SmerId { get; set; }
        [Required]
        public Smer Smer { get; set; }
        [Required]
        public string ProfesorJMBG { get; set; }
        [Required]
        public Nastavnik Profesor { get; set; }
        [Required]
        public string AsistentJMBG { get; set; }
        [Required]
        public Nastavnik Asistent { get; set; }

        public ICollection<Student> Studenti { get; set; }
        public ICollection<Obavestenje> Obavestenja { get; set; }
        public ICollection<Materijal> Materijali { get; set; }
        public ICollection<PrijavaKurs> Prijave { get; set; }

    }
}
