using MedicalClinic.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinic.DataAccess.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        bool HasAppointment(long patientId, DateTime date);
        bool IsCancellable(long id);
        Task<List<Appointment>> GetAllAvailable();
    }
}
