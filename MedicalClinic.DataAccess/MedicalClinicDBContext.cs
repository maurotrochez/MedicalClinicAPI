using JetBrains.Annotations;
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
    }
}
