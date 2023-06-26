using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.Models
{
    public class Student
    {
        [Key]
        public string OsobaJMBG { get; set; }
        [Required]
        public Osoba Osoba { get; set; }
        [Required]
        public string Adresa { get; set; }
        public ICollection<StudentMaterijal> Materijali { get; set; }
        public ICollection<PrijavaKurs> PrijavljeniKursevi { get; set; }
        public ICollection<StudentSmer> Smerovi { get; set; }
        public ICollection<StudentObavestenje> Obavestenja { get; set; }
    }
}
