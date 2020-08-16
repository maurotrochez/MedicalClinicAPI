using MedicalClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Business.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> Add(AppointmentDTO appointmentDTO);
        Task<bool> CancelAppoiment(int id);
        Task<List<AppointmentDTO>> GetAll();
    }
}
