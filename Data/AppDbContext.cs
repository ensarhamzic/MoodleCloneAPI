using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MoodleCloneAPI.Data.Models;
using MoodleCloneAPI.Data.Services;

namespace MoodleCloneAPI.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Osoba>().Property(o => o.JMBG).ValueGeneratedNever();
            modelBuilder.Entity<Osoba>().HasIndex(o => o.Username).IsUnique();
            modelBuilder.Entity<Osoba>().HasIndex(o => o.Email).IsUnique();

            modelBuilder.Entity<Administrator>().HasOne(a => a.Osoba).WithOne().HasForeignKey<Administrator>(a => a.OsobaJMBG);
            modelBuilder.Entity<Nastavnik>().HasOne(n => n.Osoba).WithOne().HasForeignKey<Nastavnik>(n => n.OsobaJMBG);
            modelBuilder.Entity<Student>().HasOne(s => s.Osoba).WithOne().HasForeignKey<Student>(s => s.OsobaJMBG);

            modelBuilder.Entity<StudentMaterijal>().HasKey(sm => new { sm.StudentJMBG, sm.MaterijalId });
            modelBuilder.Entity<StudentObavestenje>().HasKey(so => new { so.StudentJMBG, so.ObavestenjeId });
            modelBuilder.Entity<StudentSmer>().HasKey(ss => new { ss.StudentJMBG, ss.SmerId });
            modelBuilder.Entity<PrijavaKurs>().HasKey(pk => new { pk.StudentJMBG, pk.KursId });

            modelBuilder.Entity<Kurs>().HasOne(k => k.Smer).WithMany(s => s.Kursevi).HasForeignKey(k => k.SmerId);
            modelBuilder.Entity<Kurs>().HasOne(k => k.Profesor).WithMany(n => n.Kursevi).HasForeignKey(k => k.ProfesorJMBG);
            modelBuilder.Entity<Kurs>().HasOne(k => k.Asistent).WithMany(n => n.KurseviAsistent).HasForeignKey(k => k.AsistentJMBG);

            modelBuilder.Entity<StudentSmer>().HasOne(ss => ss.Student).WithMany(s => s.Smerovi).HasForeignKey(ss => ss.StudentJMBG);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Tip>().HasData(
                new Tip { Id = 1, Naziv = "Profesor" },
                new Tip { Id = 2, Naziv = "Asistent" }
            );

            modelBuilder.Entity<Zvanje>().HasData(
                new Zvanje { Id = 1, Naziv = "Redovni profesor" },
                new Zvanje { Id = 2, Naziv = "Vanredni profesor" },
                new Zvanje { Id = 3, Naziv = "Docent" },
                new Zvanje { Id = 5, Naziv = "Saradnik u nastavi" }
            );

            UserService.CreatePasswordHash("admin123", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<Osoba>().HasData(
                new Osoba
                {
                    JMBG = "0000000000000",
                    Ime = "Admin",
                    Prezime = "Admin",
                    Username = "admin",
                    Email = "admin@admin.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Pol = 'M',
                });

            modelBuilder.Entity<Administrator>().HasData(
                new Administrator
                {
                    OsobaJMBG = "0000000000000"
                });

            modelBuilder.Entity<Smer>().HasData(
                new Smer()
                {
                    Id = 1,
                    Naziv = "Softversko inzenjerstvo"
                },
                new Smer()
                {
                    Id = 2,
                    Naziv = "Racunarska tehnika",
                },
                new Smer()
                {
                    Id = 3,
                    Naziv = "Matematika",
                },
                new Smer()
                {
                    Id = 4,
                    Naziv = "Ekonomija",
                },
                new Smer()
                {
                    Id = 5,
                    Naziv = "Pravo",
                }
                );
        }

        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Nastavnik> Nastavnici { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Smer> Smerovi { get; set; }
        public DbSet<Kurs> Kursevi { get; set; }
        public DbSet<Obavestenje> Obavestenja { get; set; }
        public DbSet<Materijal> Materijali { get; set; }
        public DbSet<PrijavaKurs> PrijaveKurseva { get; set; }
        public DbSet<StudentSmer> StudentiSmerovi { get; set; }
        public DbSet<StudentMaterijal> StudentiMaterijali { get; set; }
        public DbSet<StudentObavestenje> StudentiObavestenja { get; set; }
        public DbSet<Tip> Tipovi { get; set; }
        public DbSet<Zvanje> Zvanja { get; set; }
    }
}
