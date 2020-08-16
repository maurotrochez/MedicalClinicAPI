using MedicalClinic.DataAccess.Interfaces;
using MedicalClinic.Models.Entities;
using System;
using System.Linq;

namespace MedicalClinic.DataAccess.Repositories
{
    public class AppointmentRepository : EFRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(MedicalClinicDBContext dbContext) : base(dbContext)
        {
        }

        public bool HasAppointment(long patientId, DateTime date)
        {
            return GetAll().Any(x => x.PatientId == patientId && x.Date.Date == date.Date);
        }

        public bool IsCancellable(long id)
        {
            return GetAll().Any(x => x.Id == id && x.Date.Subtract(DateTime.Now).TotalHours >= 24);
        }
    }
}
