using MedicalClinic.Models.DTOs;
using MedicalClinic.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.DataAccess.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<List<PatientDTO>> GetAllAsync();
    }
}
