namespace MoodleCloneAPI.Data.Models
{
    public class StudentObavestenje
    {
        public int StudentJMBG { get; set; }
        public Student Student { get; set; }
        public int ObavestenjeId { get; set; }
        public Obavestenje Obavestenje { get; set; }
    }
}
