using MedicalClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Business.Services.Interfaces
{
    public interface IAppointmentTypeService
    {
        Task<List<AppointmentTypeDTO>> GetAll();
    }
}
