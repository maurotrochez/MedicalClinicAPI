using MedicalClinic.Models.Entities;
using System;

namespace MedicalClinic.DataAccess.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        bool HasAppointment(long patientId, DateTime date);
        bool IsCancellable(long id);
    }
}
