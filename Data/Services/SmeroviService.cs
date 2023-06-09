﻿using Microsoft.EntityFrameworkCore;
using MoodleCloneAPI.Data.Models;
using MoodleCloneAPI.Data.ViewModels.Requests;

namespace MoodleCloneAPI.Data.Services
{
    public class SmeroviService
    {
        private AppDbContext dbContext;
        private IHttpContextAccessor httpContextAccessor;

        public SmeroviService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public List<Smer> GetSmerovi(string? query)
        {
            IQueryable<Smer> smerovi = dbContext.Smerovi.AsQueryable().Include(s => s.Kursevi);
            if(query != null)
            {
                foreach(Smer smer in smerovi)
                    smer.Kursevi = smer.Kursevi.Where(k => k.Naziv.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return smerovi.ToList();
        }

        public Smer GetSmer(int id)
        {
            return dbContext.Smerovi.Find(id);
        }

        public Smer DodajSmer(SmerVM request)
        {
            if (dbContext.Smerovi.Any(s => s.Naziv == request.Naziv))
                throw new Exception("Smer sa tim nazivom vec postoji");
            var smer = new Smer
            {
                Naziv = request.Naziv
            };
            dbContext.Smerovi.Add(smer);
            dbContext.SaveChanges();
            return smer;
        }

        public bool IndexExists(string brojIndeksa)
        {
            var studentSmer = dbContext.StudentiSmerovi
                .Where(ss => ss.BrojIndeksa == brojIndeksa)
                .FirstOrDefault();
            if (studentSmer != null)
                return true;
            return false;
        }

        public string DodajStudentaNaSmer(StudentSmerVM request)
        {
            var student = dbContext.Studenti.Find(request.StudentJMBG);
            var smer = dbContext.Smerovi.Find(request.SmerId);
            if (student == null || smer == null)
                throw new Exception("Student ili Smer nisu pronadjeni");
            var studentSmer = dbContext.StudentiSmerovi
                .Where(ss => ss.StudentJMBG == request.StudentJMBG && ss.SmerId == request.SmerId)
                .FirstOrDefault();
            if (studentSmer != null)
                throw new Exception("Student je vec na tom smeru");
            var imaIndeks = dbContext.StudentiSmerovi
                .Where(ss => ss.BrojIndeksa == request.BrojIndeksa)
                .FirstOrDefault();
            if (imaIndeks != null)
                throw new Exception("Student sa tim brojem indeksa vec postoji");
            var newStudentSmer = new StudentSmer()
            {
                StudentJMBG = request.StudentJMBG,
                SmerId = request.SmerId,
                BrojIndeksa = request.BrojIndeksa
            };
            dbContext.StudentiSmerovi.Add(newStudentSmer);
            dbContext.SaveChanges();
            return "Student dodat na smer";
        }



    }
}
