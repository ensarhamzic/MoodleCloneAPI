using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.Models
{
    public class Materijal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Sadrzaj { get; set; }
        [Required]
        public string Tip { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public int NastavnikJMBG { get; set; }
        [Required]
        public Nastavnik Nastavnik { get; set; }
        [Required]
        public int KursId { get; set; }
        [Required]
        public Kurs Kurs { get; set; }

        public ICollection<StudentMaterijal> Studenti { get; set; }
    }
}
