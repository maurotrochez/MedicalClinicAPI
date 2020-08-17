using AutoMapper;
using MedicalClinic.DataAccess.Interfaces;
using MedicalClinic.Models.DTOs;
using MedicalClinic.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinic.DataAccess.Repositories
{
    public class AppointmentTypeRepository : EFRepository<AppointmentType>, IAppointmentTypeRepository
    {
        private readonly IMapper _mapper;
        public AppointmentTypeRepository(MedicalClinicDBContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<AppointmentTypeDTO>> GetAllAsync()
        {
            return await GetAll().Select(x => _mapper.Map<AppointmentType, AppointmentTypeDTO>(x)).ToListAsync();
        }
    }
}
