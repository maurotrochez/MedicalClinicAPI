using MedicalClinic.DataAccess.Interfaces;
using MedicalClinic.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinic.DataAccess.Repositories
{
    public class AppointmentRepository : EFRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(MedicalClinicDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Appointment>> GetAllAvailable()
        {
            return await GetAll()
                .Include(x => x.Patient)
                .Include(x => x.AppointmentType)
                .Where(x => !x.IsCancelled).ToListAsync();
        }

        public bool HasAppointment(long patientId, DateTime date)
        {
            return GetAll()
                .Any(x => x.PatientId == patientId && x.Date.Date == date.Date);
        }

        public bool IsCancellable(long id)
        {
            return GetAll()
                .Any(x => x.Id == id && x.Date.Subtract(DateTime.Now).TotalHours >= 24);
        }
    }
}
