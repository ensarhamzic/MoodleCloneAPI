﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoodleCloneAPI.Data;

#nullable disable

namespace MoodleCloneAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230626174331_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("NastavnikJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicId")
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

                    b.HasIndex("NastavnikJMBG");

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

                    b.Property<string>("NastavnikJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KursId");

                    b.HasIndex("NastavnikJMBG");

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
                            PasswordHash = new byte[] { 6, 66, 0, 3, 75, 58, 94, 155, 135, 216, 139, 126, 5, 165, 98, 42, 234, 89, 131, 121, 42, 209, 163, 30, 31, 97, 128, 169, 60, 235, 11, 125, 154, 98, 73, 83, 79, 240, 137, 28, 62, 244, 51, 109, 181, 69, 143, 164, 249, 83, 170, 203, 13, 89, 31, 79, 146, 255, 218, 137, 214, 15, 205, 158 },
                            PasswordSalt = new byte[] { 104, 75, 233, 219, 249, 85, 125, 126, 21, 251, 235, 172, 187, 27, 209, 72, 43, 20, 225, 24, 29, 144, 82, 164, 72, 4, 173, 69, 138, 39, 27, 78, 180, 98, 87, 79, 217, 87, 1, 187, 255, 13, 37, 110, 241, 48, 220, 43, 160, 153, 235, 105, 197, 200, 146, 15, 54, 174, 153, 156, 232, 60, 46, 64, 197, 137, 3, 176, 136, 176, 177, 134, 34, 54, 23, 5, 16, 12, 197, 47, 6, 5, 95, 38, 24, 160, 44, 66, 246, 24, 40, 84, 59, 33, 110, 92, 203, 218, 191, 10, 2, 158, 245, 154, 199, 185, 29, 162, 80, 180, 116, 209, 154, 105, 27, 44, 110, 167, 168, 207, 231, 150, 48, 173, 32, 130, 116, 134 },
                            Pol = "M",
                            Prezime = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.PrijavaKurs", b =>
                {
                    b.Property<string>("StudentJMBG")
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<bool>("NaCekanju")
                        .HasColumnType("bit");

                    b.HasKey("StudentJMBG", "KursId");

                    b.HasIndex("KursId");

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
                    b.Property<string>("StudentJMBG")
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("MaterijalId")
                        .HasColumnType("int");

                    b.HasKey("StudentJMBG", "MaterijalId");

                    b.HasIndex("MaterijalId");

                    b.ToTable("StudentiMaterijali");
                });

            modelBuilder.Entity("MoodleCloneAPI.Data.Models.StudentObavestenje", b =>
                {
                    b.Property<string>("StudentJMBG")
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("ObavestenjeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentJMBG", "ObavestenjeId");

                    b.HasIndex("ObavestenjeId");

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
                        .WithMany("Materijali")
                        .HasForeignKey("NastavnikJMBG")
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
                        .WithMany("Obavestenja")
                        .HasForeignKey("NastavnikJMBG")
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
                        .HasForeignKey("StudentJMBG")
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
                        .WithMany("Materijali")
                        .HasForeignKey("StudentJMBG")
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
                        .WithMany("Obavestenja")
                        .HasForeignKey("StudentJMBG")
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

                    b.Navigation("Materijali");

                    b.Navigation("Obavestenja");
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
                    b.Navigation("Materijali");

                    b.Navigation("Obavestenja");

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
