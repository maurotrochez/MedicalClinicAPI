using AutoMapper;
using MedicalClinic.Business.Services.Interfaces;
using MedicalClinic.DataAccess.Interfaces;
using MedicalClinic.Models.DTOs;
using MedicalClinic.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinic.Business.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public async Task<List<PatientDTO>> GetAll()
        {
            try
            {
                return await _patientRepository.GetAllAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
