namespace MoodleCloneAPI.Data.Models
{
    public class StudentMaterijal
    {
        public string StudentJMBG { get; set; }
        public Student Student { get; set; }
        public int MaterijalId { get; set; }
        public Materijal Materijal { get; set; }
    }
}
