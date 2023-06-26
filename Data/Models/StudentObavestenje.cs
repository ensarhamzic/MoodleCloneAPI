namespace MoodleCloneAPI.Data.Models
{
    public class StudentObavestenje
    {
        public string StudentJMBG { get; set; }
        public Student Student { get; set; }
        public int ObavestenjeId { get; set; }
        public Obavestenje Obavestenje { get; set; }
        public DateTime Datum { get; set; }
    }
}
