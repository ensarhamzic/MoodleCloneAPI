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
            var userJMBG = userService.GetAuthUserId();
            var role = userService.GetAuthUserRole();
            var obavestenje = dbContext.Obavestenja.Include(o => o.Nastavnik).Include(o => o.Kurs).Include(o => o.Studenti).ThenInclude(s => s.Student).ThenInclude(s => s.Osoba).FirstOrDefault(o => o.Id == id);
            if(obavestenje == null)
                throw new Exception("Obavestenje nije pronadjeno");
            if(role == "Student")
            {
                var pregled = dbContext.StudentiObavestenja.FirstOrDefault(so => so.ObavestenjeId == id && so.StudentJMBG == userJMBG);
                if(pregled == null)
                {
                    var studentObavestenje = new StudentObavestenje
                    {
                        ObavestenjeId = id,
                        StudentJMBG = userJMBG,
                        Datum = DateTime.Now
                    };
                    dbContext.StudentiObavestenja.Add(studentObavestenje);
                    dbContext.SaveChanges();
                } else
                {
                    pregled.Datum = DateTime.Now;
                    dbContext.SaveChanges();
                }
            }
            var kurs = dbContext.Kursevi.FirstOrDefault(k => k.Id == obavestenje.KursId);
            if(kurs.ProfesorJMBG != userJMBG && kurs.AsistentJMBG != userJMBG)
                obavestenje.Studenti = null;
            return obavestenje;
        }
    }
}