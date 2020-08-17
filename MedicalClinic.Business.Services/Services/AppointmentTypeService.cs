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
    public class AppointmentTypeService : IAppointmentTypeService
    {
        private readonly IAppointmentTypeRepository _appointmentTypeRepository;
        private readonly IMapper _mapper;
        public AppointmentTypeService(IAppointmentTypeRepository appointmentRepository, IMapper mapper)
        {
            _appointmentTypeRepository = appointmentRepository;
            _mapper = mapper;

        }
        public async Task<List<AppointmentTypeDTO>> GetAll()
        {
            try
            {
                return await _appointmentTypeRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
