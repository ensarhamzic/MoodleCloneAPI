namespace MoodleCloneAPI.Data.Models
{
    public class PrijavaKurs
    {
        public int StudentJMBG { get; set; }
        public Student Student { get; set; }
        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
        public bool NaCekanju { get; set; }
    }
}
