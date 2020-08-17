using MedicalClinic.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinic.Business.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientDTO>> GetAll();
    }
}
