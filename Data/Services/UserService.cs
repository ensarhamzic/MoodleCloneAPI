using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using MoodleCloneAPI.Data.Models;
using MoodleCloneAPI.Data.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MoodleCloneAPI.Data.Services
{
    public class UserService
    {
        private AppDbContext dbContext;
        private IConfiguration configuration;
        private IHttpContextAccessor httpContextAccessor;

        public UserService(AppDbContext dbContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        private Osoba RegisterUser(UserRegisterVM request)
        {
            bool userExists = dbContext.Osobe
                .Any(u => u.Email == request.Email || u.Username == request.Username);
            if (userExists)
            {
                throw new Exception("User already exists");
            }
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            // add new user
            var newUser = new Osoba()
            {
                JMBG = request.JMBG,
                Ime = request.Ime,
                Prezime = request.Prezime,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            dbContext.Osobe.Add(newUser);
            dbContext.SaveChanges();

            return newUser;
        }

        public string RegisterAdmin(AdminRegisterVM request)
        {
            var user = RegisterUser(request);
            var newAdmin = new Administrator()
            {
                OsobaJMBG = user.JMBG,
                Superadmin = request.Superadmin,
            };
            dbContext.Administratori.Add(newAdmin);
            dbContext.SaveChanges();

            return CreateToken(user, "Admin");
        }

        public string RegisterTeacher(TeacherRegisterVM request)
        {
            var user = RegisterUser(request);
            var newTeacher = new Nastavnik()
            {
                OsobaJMBG = user.JMBG,
                ZvanjeId = request.ZvanjeId,
                TipId = request.TipId,
                GodineRadnogStaza = request.GodineRadnogStaza,
                DatumRodjenja = request.DatumRodjenja,
            };
            dbContext.Nastavnici.Add(newTeacher);
            dbContext.SaveChanges();

            return CreateToken(user, "Teacher");
        }

        public string RegisterStudent(StudentRegisterVM request)
        {
            var user = RegisterUser(request);
            var newStudent = new Student()
            {
                OsobaJMBG = user.JMBG,
                Adresa = request.Adresa
            };
            dbContext.Studenti.Add(newStudent);
            dbContext.SaveChanges();

            return CreateToken(user, "Student");
        }

        public string Login(UserLoginVM request)
        {
            var user = dbContext.Osobe.FirstOrDefault(u => u.Username == request.Username);
            var failedResponse = "Check your credentials and try again!";
            if (user == null)
                throw new Exception(failedResponse);
            var isPasswordCorrect = VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordCorrect)
                throw new Exception(failedResponse);
            var admin = dbContext.Administratori.FirstOrDefault(a => a.OsobaJMBG == user.JMBG);
            var teacher = dbContext.Nastavnici.FirstOrDefault(n => n.OsobaJMBG == user.JMBG);
            var student = dbContext.Studenti.FirstOrDefault(s => s.OsobaJMBG == user.JMBG);
            var role = "";
            if (admin != null)
                role = "Admin";
            else if (teacher != null)
                role = "Teacher";
            else if (student != null)
                role = "Student";
            else
                throw new Exception(failedResponse);
            return CreateToken(user, role);
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private string CreateToken(Osoba user, string Role)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.PrimarySid, user.JMBG.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, Role),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private int GetAuthUserId()
        {
            return int.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid));
        }

        private void SendEmail(string recipientEmail, string emailSubject, string emailText)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configuration.GetSection("Mail:From").Value));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = emailSubject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = emailText
            };
            using var smtp = new SmtpClient();
            smtp.Connect(
            configuration.GetSection("Mail:Smtp").Value,
                int.Parse(configuration.GetSection("Mail:Port").Value),
                SecureSocketOptions.StartTls
                );
            smtp.Authenticate(
                configuration.GetSection("Mail:Username").Value,
                configuration.GetSection("Mail:Password").Value
                );
            smtp.Send(email);
            smtp.Disconnect(true);
        }

    }
}
