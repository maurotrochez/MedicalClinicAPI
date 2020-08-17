using MedicalClinic.Models.DTOs;
using MedicalClinic.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinic.DataAccess.Interfaces
{
    public interface IAppointmentTypeRepository : IRepository<AppointmentType>
    {
        Task<List<AppointmentTypeDTO>> GetAllAsync();
    }
}
