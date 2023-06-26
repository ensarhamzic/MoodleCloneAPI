using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;
        private Account account;
        private Cloudinary cloudinary;

        public KursService(AppDbContext dbContext, UserService userService, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.userService = userService;
            this.configuration = configuration;
            account = new Account(
               configuration.GetSection("Cloudinary:Cloud").Value,
               configuration.GetSection("Cloudinary:ApiKey").Value,
               configuration.GetSection("Cloudinary:ApiSecret").Value);
            cloudinary = new Cloudinary(account);
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

            int? brojPrijava = null;
            var canManage = false;
            var pending = false;
            if (kurs.AsistentJMBG == userJMBG || kurs.ProfesorJMBG == userJMBG)
            {
                canManage = true;
                brojPrijava = dbContext.PrijaveKurseva.Where(p => p.KursId == kurs.Id && p.NaCekanju).Count();
            }
                
            
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
                Pending = pending,
                BrojPrijava = brojPrijava
            };
        }

        public List<Student> GetPrijaveNaKurs(int kursId)
        {
            var kurs = dbContext.Kursevi
                .Include(k => k.Asistent)
                .Include(k => k.Profesor)
                .Include(k => k.Materijali)
                .Include(k => k.Smer)
                .FirstOrDefault(k => k.Id == kursId)
                ?? throw new Exception("Kurs nije pronadjen");

            var userJMBG = userService.GetAuthUserId();
            if (kurs.AsistentJMBG != userJMBG && kurs.ProfesorJMBG != userJMBG)
                throw new Exception("Nemate pristup ovom kursu");

            var prijave = dbContext.PrijaveKurseva.Where(p => p.KursId == kursId && p.NaCekanju).Include(p => p.Student).ThenInclude(s => s.Osoba).ToList();
            return prijave.Select(p => p.Student).ToList();
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

        public string OdgovoriNaPrijavu(OdgovorPrijavaVM request, int kursId)
        {
            var userJMBG = userService.GetAuthUserId();
            var course = dbContext.Kursevi.FirstOrDefault(k => k.Id == kursId) ?? throw new Exception("Kurs nije pronadjen");
            var student = dbContext.Studenti.Include(s => s.Osoba).FirstOrDefault(s => s.OsobaJMBG == request.StudentJMBG) ?? throw new Exception("Student nije pronadjen");
            var studentCourse = dbContext.PrijaveKurseva.FirstOrDefault(sk => sk.StudentJMBG == student.OsobaJMBG && sk.KursId == course.Id) ?? throw new Exception("Student nije prijavljen na kurs");
            if (studentCourse.NaCekanju == false)
                throw new Exception("Student je vec prihvacen");

            if(request.Prihvacena)
                studentCourse.NaCekanju = false;
            else
                dbContext.PrijaveKurseva.Remove(studentCourse);
     
            dbContext.SaveChanges();

            var emailSubject = $"Odgovor na prijavu na kurs {course.Naziv}";
            var emailBody = $"Vasa prijava na kurs {course.Naziv} je ";
            if (request.Prihvacena)
                emailBody += "prihvacena";
            else
                emailBody += "odbijena";
            userService.SendEmail(student.Osoba.Email, emailSubject, emailBody);
            return "Uspesno";
        }

        public Materijal DodajMaterijal(MaterijalVM request, int id)
        {
            var userJMBG = userService.GetAuthUserId();
            var course = dbContext.Kursevi.FirstOrDefault(k => k.Id == id) ?? throw new Exception("Kurs nije pronadjen");
            if (course.ProfesorJMBG != userJMBG && course.AsistentJMBG != userJMBG)
                throw new Exception("Nemate pristup ovom kursu");

            var tip = "Predavanja";
            if (course.AsistentJMBG == userJMBG)
                tip = "Vezbe";

            var fileName = Path.GetFileNameWithoutExtension(request.File.FileName);
            var fileExtension = Path.GetExtension(request.File.FileName);
            var tempPath = Path.Combine(Path.GetTempPath(), $"{fileName}{fileExtension}");
            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                request.File.CopyTo(stream);
            }
            var guid = Guid.NewGuid().ToString();
            var filePublicId = $"{configuration.GetSection("Cloudinary:FolderName").Value}/{guid}{fileExtension}";
            var uploadParams = new RawUploadParams()
            {
                File = new FileDescription(tempPath),
                PublicId = filePublicId,
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            var materijal = new Materijal()
            {
                Naziv = request.Naziv,
                Sadrzaj = uploadResult.Uri.ToString(),
                KursId = id,
                Tip = tip,
                NastavnikJMBG = userJMBG,
                Datum = DateTime.Now
            };

            dbContext.Materijali.Add(materijal);
            dbContext.SaveChanges();

            return materijal;
        }
    }
}
    