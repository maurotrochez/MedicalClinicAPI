using MedicalClinic.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedicalClinic.DataAccess
{
    public class MedicalClinicDBContext : IdentityDbContext<ApplicationUser>
    {
        public MedicalClinicDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppointmentType>().HasData(new AppointmentType
            {
                Id = 1,
                Description = "Medicina General"
            }, new AppointmentType
            {
                Id = 2,
                Description = "Odontología"
            }, new AppointmentType
            {
                Id = 3,
                Description = "Pediatría"
            }, new AppointmentType
            {
                Id = 4,
                Description = "Neurología"
            });

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 1,
                FirstName = "Juan",
                LastName = "Perez",
                IdentificationNumber = 1234
            }, new Patient
            {
                Id=2,
                FirstName="David",
                LastName="Trochez",
                IdentificationNumber=12345
            }
            );

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                Id=1,
                AppointmentTypeId=1,
                Date= new System.DateTime(2020, 08, 15, 10, 0, 0),
                IsCancelled=false,
                Notes="Consulta general",
                PatientId=1,
            }, new Appointment
            {
                Id = 2,
                AppointmentTypeId = 2,
                Date = new System.DateTime(2020, 08, 15, 9, 0, 0),
                IsCancelled = false,
                Notes = "Consulta general dientes",
                PatientId = 2,
            }
            );

            //Seeding user and role
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID = ADMIN_ID;

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }

    }
}
