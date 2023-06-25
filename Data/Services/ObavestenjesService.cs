using Microsoft.EntityFrameworkCore;
using MoodleCloneAPI.Data.Models;
using MoodleCloneAPI.Data.ViewModels.Requests;

namespace MoodleCloneAPI.Data.Services
{
    public class ObavestenjesService
    {
        private readonly AppDbContext dbContext;
        private readonly UserService userService;

        public ObavestenjesService(AppDbContext dbContext, UserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public Obavestenje AddObavestenje(ObavestenjeVM request)
        {
            var user = userService.GetAuthUser();
            var obavestenje = new Obavestenje
            {
                Naslov = request.Naslov,
                Sadrzaj = request.Sadrzaj,
                KursId = request.KursId,
                NastavnikJMBG = user.JMBG,
                Datum = DateTime.Now
            };
            dbContext.Obavestenja.Add(obavestenje);
            dbContext.SaveChanges();
            return obavestenje;
        }

        public List<Obavestenje> GetObavestenja(int kursId, int? num)
        {
            var kurs = dbContext.Kursevi.FirstOrDefault(k => k.Id == kursId);
            if(kurs == null)
                throw new Exception("Kurs nije pronadjen");
            var obavestenja = dbContext.Obavestenja.Where(o => o.KursId == kursId).OrderByDescending(o => o.Datum).AsQueryable();
            if (num != null)
                obavestenja = obavestenja.Take(num.GetValueOrDefault(5));
            return obavestenja.ToList();
        }

        public Obavestenje GetObavestenje(int id)
        {
            return dbContext.Obavestenja.Include(o => o.Nastavnik).Include(o => o.Kurs).FirstOrDefault(o => o.Id == id);
        }
    }
}