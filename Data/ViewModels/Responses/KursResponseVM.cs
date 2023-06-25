using MoodleCloneAPI.Data.Models;

namespace MoodleCloneAPI.Data.ViewModels.Responses
{
    public class KursResponseVM
    {
        public Kurs Kurs { get; set; }
        public bool CanManage { get; set; }
    }
}
