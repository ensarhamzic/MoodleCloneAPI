﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoodleCloneAPI.Data;

#nullable disable

namespace MoodleCloneAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Administrator", b =>
                {
                    b.Property<string>("OsobaJMBG")
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("OsobaJMBG");

                    b.ToTable("Administratori");

                    b.HasData(
                        new
                        {
                            OsobaJMBG = "0000000000000"
                        });
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AsistentJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<bool>("HronoloskiMod")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfesorJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("SmerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AsistentJMBG");

                    b.HasIndex("ProfesorJMBG");

                    b.HasIndex("SmerId");

                    b.ToTable("Kursevi");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Materijal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<int>("NastavnikJMBG")
                        .HasColumnType("int");

                    b.Property<string>("NastavnikOsobaJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KursId");

                    b.HasIndex("NastavnikOsobaJMBG");

                    b.ToTable("Materijali");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Nastavnik", b =>
                {
                    b.Property<string>("OsobaJMBG")
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("GodineRadnogStaza")
                        .HasColumnType("int");

                    b.Property<int>("TipId")
                        .HasColumnType("int");

                    b.Property<bool>("Verifikovan")
                        .HasColumnType("bit");

                    b.Property<int>("ZvanjeId")
                        .HasColumnType("int");

                    b.HasKey("OsobaJMBG");

                    b.HasIndex("TipId");

                    b.HasIndex("ZvanjeId");

                    b.ToTable("Nastavnici");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Obavestenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NastavnikJMBG")
                        .HasColumnType("int");

                    b.Property<string>("NastavnikOsobaJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KursId");

                    b.HasIndex("NastavnikOsobaJMBG");

                    b.ToTable("Obavestenja");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Osoba", b =>
                {
                    b.Property<string>("JMBG")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("JMBG");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Osobe");

                    b.HasData(
                        new
                        {
                            JMBG = "0000000000000",
                            Email = "admin@admin.com",
                            Ime = "Admin",
                            PasswordHash = new byte[] { 122, 227, 76, 227, 3, 184, 68, 103, 145, 236, 123, 162, 65, 133, 41, 181, 60, 209, 66, 196, 105, 99, 181, 12, 49, 239, 183, 65, 4, 185, 60, 100, 180, 167, 89, 147, 4, 180, 29, 154, 42, 113, 80, 220, 244, 196, 176, 159, 230, 114, 111, 251, 139, 186, 147, 47, 51, 98, 248, 99, 178, 113, 33, 131 },
                            PasswordSalt = new byte[] { 94, 172, 170, 184, 5, 226, 251, 246, 19, 110, 75, 248, 116, 93, 165, 197, 235, 134, 214, 100, 241, 7, 202, 197, 50, 178, 45, 196, 195, 83, 184, 218, 73, 172, 75, 205, 29, 45, 0, 218, 128, 143, 83, 167, 164, 54, 155, 17, 105, 234, 216, 123, 34, 127, 95, 132, 53, 32, 90, 153, 35, 236, 183, 94, 45, 117, 145, 252, 50, 59, 18, 215, 182, 42, 117, 51, 74, 5, 62, 128, 1, 195, 11, 181, 103, 123, 5, 169, 38, 71, 136, 151, 173, 187, 133, 169, 141, 219, 119, 42, 121, 14, 88, 249, 56, 115, 15, 218, 25, 19, 4, 214, 170, 174, 224, 103, 148, 45, 169, 182, 150, 149, 97, 13, 140, 176, 143, 233 },
                            Pol = "M",
                            Prezime = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.PrijavaKurs", b =>
                {
                    b.Property<int>("StudentJMBG")
                        .HasColumnType("int");

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<bool>("NaCekanju")
                        .HasColumnType("bit");

                    b.Property<string>("StudentOsobaJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("StudentJMBG", "KursId");

                    b.HasIndex("KursId");

                    b.HasIndex("StudentOsobaJMBG");

                    b.ToTable("PrijaveKurseva");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Smer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Smerovi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Softversko inzenjerstvo"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Racunarska tehnika"
                        },
                        new
                        {
                            Id = 3,
                            Naziv = "Matematika"
                        },
                        new
                        {
                            Id = 4,
                            Naziv = "Ekonomija"
                        },
                        new
                        {
                            Id = 5,
                            Naziv = "Pravo"
                        });
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Student", b =>
                {
                    b.Property<string>("OsobaJMBG")
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KursId")
                        .HasColumnType("int");

                    b.Property<int?>("SmerId")
                        .HasColumnType("int");

                    b.HasKey("OsobaJMBG");

                    b.HasIndex("KursId");

                    b.HasIndex("SmerId");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.StudentMaterijal", b =>
                {
                    b.Property<int>("StudentJMBG")
                        .HasColumnType("int");

                    b.Property<int>("MaterijalId")
                        .HasColumnType("int");

                    b.Property<string>("StudentOsobaJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("StudentJMBG", "MaterijalId");

                    b.HasIndex("MaterijalId");

                    b.HasIndex("StudentOsobaJMBG");

                    b.ToTable("StudentiMaterijali");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.StudentObavestenje", b =>
                {
                    b.Property<int>("StudentJMBG")
                        .HasColumnType("int");

                    b.Property<int>("ObavestenjeId")
                        .HasColumnType("int");

                    b.Property<string>("StudentOsobaJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("StudentJMBG", "ObavestenjeId");

                    b.HasIndex("ObavestenjeId");

                    b.HasIndex("StudentOsobaJMBG");

                    b.ToTable("StudentiObavestenja");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.StudentSmer", b =>
                {
                    b.Property<string>("StudentJMBG")
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("SmerId")
                        .HasColumnType("int");

                    b.Property<string>("BrojIndeksa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentJMBG", "SmerId");

                    b.HasIndex("SmerId");

                    b.ToTable("StudentiSmerovi");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Tip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tipovi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Profesor"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Asistent"
                        });
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Zvanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zvanja");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Redovni profesor"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Vanredni profesor"
                        },
                        new
                        {
                            Id = 3,
                            Naziv = "Docent"
                        },
                        new
                        {
                            Id = 5,
                            Naziv = "Saradnik u nastavi"
                        });
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Administrator", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Osoba", "Osoba")
                        .WithOne()
                        .HasForeignKey("MoodleCloneAPI.Data.Models.Administrator", "OsobaJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Osoba");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Kurs", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Nastavnik", "Asistent")
                        .WithMany("KurseviAsistent")
                        .HasForeignKey("AsistentJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Nastavnik", "Profesor")
                        .WithMany("Kursevi")
                        .HasForeignKey("ProfesorJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Smer", "Smer")
                        .WithMany("Kursevi")
                        .HasForeignKey("SmerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asistent");

                    b.Navigation("Profesor");

                    b.Navigation("Smer");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Materijal", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Kurs", "Kurs")
                        .WithMany("Materijali")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikOsobaJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Nastavnik");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Nastavnik", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Osoba", "Osoba")
                        .WithOne()
                        .HasForeignKey("MoodleCloneAPI.Data.Models.Nastavnik", "OsobaJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Tip", "Tip")
                        .WithMany("Nastavnici")
                        .HasForeignKey("TipId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Zvanje", "Zvanje")
                        .WithMany("Nastavnici")
                        .HasForeignKey("ZvanjeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Osoba");

                    b.Navigation("Tip");

                    b.Navigation("Zvanje");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Obavestenje", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Kurs", "Kurs")
                        .WithMany("Obavestenja")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikOsobaJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Nastavnik");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.PrijavaKurs", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Kurs", "Kurs")
                        .WithMany("Prijave")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Student", "Student")
                        .WithMany("PrijavljeniKursevi")
                        .HasForeignKey("StudentOsobaJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Student", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Kurs", null)
                        .WithMany("Studenti")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MoodleCloneAPI.Data.Models.Osoba", "Osoba")
                        .WithOne()
                        .HasForeignKey("MoodleCloneAPI.Data.Models.Student", "OsobaJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Smer", null)
                        .WithMany("Studenti")
                        .HasForeignKey("SmerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Osoba");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.StudentMaterijal", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Materijal", "Materijal")
                        .WithMany("Studenti")
                        .HasForeignKey("MaterijalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Student", "Student")
                        .WithMany("PregledaniMaterijali")
                        .HasForeignKey("StudentOsobaJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Materijal");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.StudentObavestenje", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Obavestenje", "Obavestenje")
                        .WithMany("Studenti")
                        .HasForeignKey("ObavestenjeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Student", "Student")
                        .WithMany("PregledanaObavestenja")
                        .HasForeignKey("StudentOsobaJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Obavestenje");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.StudentSmer", b =>
                {
                    b.HasOne("MoodleCloneAPI.Data.Models.Smer", "Smer")
                        .WithMany()
                        .HasForeignKey("SmerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodleCloneAPI.Data.Models.Student", "Student")
                        .WithMany("Smerovi")
                        .HasForeignKey("StudentJMBG")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Smer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Kurs", b =>
                {
                    b.Navigation("Materijali");

                    b.Navigation("Obavestenja");

                    b.Navigation("Prijave");

                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Materijal", b =>
                {
                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Nastavnik", b =>
                {
                    b.Navigation("Kursevi");

                    b.Navigation("KurseviAsistent");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Obavestenje", b =>
                {
                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Smer", b =>
                {
                    b.Navigation("Kursevi");

                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Student", b =>
                {
                    b.Navigation("PregledanaObavestenja");

                    b.Navigation("PregledaniMaterijali");

                    b.Navigation("PrijavljeniKursevi");

                    b.Navigation("Smerovi");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Tip", b =>
                {
                    b.Navigation("Nastavnici");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.Zvanje", b =>
                {
                    b.Navigation("Nastavnici");
                });
#pragma warning restore 612, 618
        }
    }
}
