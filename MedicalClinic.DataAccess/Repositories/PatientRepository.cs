using AutoMapper;
using MedicalClinic.DataAccess.Interfaces;
using MedicalClinic.Models.DTOs;
using MedicalClinic.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.DataAccess.Repositories
{
    public class PatientRepository : EFRepository<Patient>, IPatientRepository
    {
        private readonly IMapper _mapper;
        public PatientRepository(MedicalClinicDBContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<PatientDTO>> GetAllAsync()
        {
            return await GetAll().Select(x => _mapper.Map<Patient, PatientDTO>(x)).ToListAsync();
        }
    }
}
