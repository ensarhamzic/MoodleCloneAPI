using MoodleCloneAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.ViewModels.Requests
{
    public class ObavestenjeVM
    {
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public int KursId { get; set; }
    }
}
