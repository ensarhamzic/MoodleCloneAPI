using MoodleCloneAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.ViewModels.Requests
{
    public class KursVM
    {
        public string Naziv { get; set; }
        public bool HronoloskiMod { get; set; }
        public int SmerId { get; set; }
        public string AsistentJMBG { get; set; }
    }
}
