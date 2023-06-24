using MoodleCloneAPI.Data.Models;

namespace MoodleCloneAPI.Data.ViewModels.Responses
{
    public class AuthVM
    {
        public Osoba Osoba { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public bool Verified { get; set; }
    }
}
