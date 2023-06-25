using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MoodleCloneAPI.Data.Models;
using MoodleCloneAPI.Data.ViewModels.Requests;
using MoodleCloneAPI.Data.ViewModels.Responses;

namespace MoodleCloneAPI.Data.Services
{
    public class KursService
    {
        private readonly AppDbContext dbContext;
        private readonly UserService userService;

        public KursService(AppDbContext dbContext, UserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public Kurs CreateCourse(KursVM request)
        {
            var profesorZvanjeId = dbContext.Tipovi.FirstOrDefault(z => z.Naziv == "Profesor").Id;
            var userJMBG = userService.GetAuthUserId();
            var teacher = dbContext.Nastavnici.FirstOrDefault(n => n.OsobaJMBG == userJMBG && n.TipId == profesorZvanjeId) ?? throw new Exception("Nastavnik nije pronadjen");
            var course = new Kurs
            {
                Naziv = request.Naziv,
                HronoloskiMod = request.HronoloskiMod,
                SmerId = request.SmerId,
                ProfesorJMBG = teacher.OsobaJMBG,
                AsistentJMBG = request.AsistentJMBG
            };
            dbContext.Kursevi.Add(course);
            dbContext.SaveChanges();
            return course;

        }

        public KursResponseVM GetCourseById(int id)
        {
            var kurs = dbContext.Kursevi.Include(k => k.Asistent).Include(k => k.Profesor).Include(k => k.Materijali).Include(k => k.Smer).FirstOrDefault(k => k.Id == id) ?? throw new Exception("Kurs nije pronadjen");
            var userJMBG = userService.GetAuthUserId();
            var canManage = false;
            if (kurs.AsistentJMBG == userJMBG || kurs.ProfesorJMBG == userJMBG)
                canManage = true;
            return new KursResponseVM()
            {
                Kurs = kurs,
                CanManage = canManage
            };
        }

        public List<Kurs> GetTeacherCourses()
        {
            var userJMBG = userService.GetAuthUserId();
            var teacher = dbContext.Nastavnici.Include(n => n.Tip).FirstOrDefault(n => n.OsobaJMBG == userJMBG) ?? throw new Exception("Nastavnik nije pronadjen");
            if (teacher.Tip.Naziv == "Profesor")
                return dbContext.Kursevi.Where(k => k.ProfesorJMBG == teacher.OsobaJMBG).Include(k => k.Asistent).ThenInclude(o => o.Osoba).Include(k => k.Profesor).ThenInclude(o => o.Osoba).Include(k => k.Smer).ToList();
            else
                return dbContext.Kursevi.Where(k => k.AsistentJMBG == teacher.OsobaJMBG).Include(k => k.Asistent).ThenInclude(o => o.Osoba).Include(k => k.Profesor).ThenInclude(o => o.Osoba).Include(k => k.Smer).ToList();
        }

        internal object CanManageCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}
