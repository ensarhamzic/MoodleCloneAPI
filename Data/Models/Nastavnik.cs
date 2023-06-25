using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.Models
{
    public class Nastavnik
    {
        [Key]
        public string OsobaJMBG { get; set; }
        [Required]
        public Osoba Osoba { get; set; }
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public int GodineRadnogStaza { get; set; }
        [Required]
        public int ZvanjeId { get; set; }
        [Required]
        public Zvanje Zvanje { get; set; }
        [Required]
        public int TipId { get; set; }
        [Required]
        public Tip Tip { get; set; }
        public bool Verifikovan { get; set; }
        public ICollection<Kurs> Kursevi { get; set; }
        public ICollection<Kurs> KurseviAsistent { get; set; }
        public ICollection<Obavestenje> Obavestenja { get; set; }
    }
}
