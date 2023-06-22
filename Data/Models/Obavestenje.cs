using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.Models
{
    public class Obavestenje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naslov { get; set; }        
        [Required]
        public string Sadrzaj { get; set; }
        [Required]
        public int NastavnikJMBG { get; set; }
        [Required]
        public Nastavnik Nastavnik { get; set; }
        [Required]
        public int KursId { get; set; }
        [Required]
        public Kurs Kurs { get; set; }
        [Required]
        public DateTime Datum { get; set; }

        public ICollection<StudentObavestenje> Studenti { get; set; }

    }
}
