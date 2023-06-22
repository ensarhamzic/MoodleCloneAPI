namespace MoodleCloneAPI.Data.Models
{
    public class StudentSmer
    {
        public int StudentJMBG { get; set; }
        public Student Student { get; set; }
        public int SmerId { get; set; }
        public Smer Smer { get; set; }
        public string BrojIndeksa { get; set; }
    }
}
