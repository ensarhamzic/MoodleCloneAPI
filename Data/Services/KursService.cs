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
            if(userJMBG == null)
                kurs.Materijali = null;

            var canManage = false;
            var pending = false;
            if (kurs.AsistentJMBG == userJMBG || kurs.ProfesorJMBG == userJMBG)
                canManage = true;
            
            var student = dbContext.Studenti.FirstOrDefault(s => s.OsobaJMBG == userJMBG);
            if (student != null)
            {
                var studentKurs = dbContext.PrijaveKurseva.FirstOrDefault(sk => sk.StudentJMBG == student.OsobaJMBG && sk.KursId == kurs.Id);
                if(studentKurs == null)
                    kurs.Materijali = null;
                else if (studentKurs.NaCekanju)
                {
                    kurs.Materijali = null;
                    pending = true;
                }
                    
            }
            return new KursResponseVM()
            {
                Kurs = kurs,
                CanManage = canManage,
                Pending = pending
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

        public string PrijaviSeNaKurs(int id)
        {
            var userJMBG = userService.GetAuthUserId();
            var student = dbContext.Studenti.Include(s => s.Osoba).FirstOrDefault(s => s.OsobaJMBG == userJMBG) ?? throw new Exception("Student nije pronadjen");
            var course = dbContext.Kursevi.FirstOrDefault(k => k.Id == id) ?? throw new Exception("Kurs nije pronadjen");
            var studentCourse = dbContext.PrijaveKurseva.FirstOrDefault(sk => sk.StudentJMBG == student.OsobaJMBG && sk.KursId == course.Id);
            if (studentCourse != null)
            {
                dbContext.PrijaveKurseva.Remove(studentCourse);
                dbContext.SaveChanges();
            }
            else
            {
                dbContext.PrijaveKurseva.Add(new PrijavaKurs
                {
                    StudentJMBG = student.OsobaJMBG,
                    KursId = course.Id,
                    NaCekanju = true
                });
                dbContext.SaveChanges();
                var profesor = dbContext.Nastavnici.Include(n => n.Osoba).FirstOrDefault(n => n.OsobaJMBG == course.ProfesorJMBG);
                var asistent = dbContext.Nastavnici.Include(n => n.Osoba).FirstOrDefault(n => n.OsobaJMBG == course.AsistentJMBG);

                var emailSubject = $"Nova prijava na kurs {course.Naziv}";
                var emailBody = $"Student {student.Osoba.Ime} {student.Osoba.Prezime} se prijavio na kurs {course.Naziv}";
                userService.SendEmail(profesor.Osoba.Email, emailSubject, emailBody);
                userService.SendEmail(asistent.Osoba.Email, emailSubject, emailBody);
            }
            
            return "Uspesno";
        }
    }
}
