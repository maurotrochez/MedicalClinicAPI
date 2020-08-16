using JetBrains.Annotations;
using MedicalClinic.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalClinic.DataAccess
{
    public class MedicalClinicDBContext : DbContext
    {
        public MedicalClinicDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}
