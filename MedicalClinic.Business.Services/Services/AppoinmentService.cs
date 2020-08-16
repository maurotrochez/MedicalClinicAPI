using AutoMapper;
using MedicalClinic.Business.Services.Interfaces;
using MedicalClinic.DataAccess.Interfaces;
using MedicalClinic.Models.DTOs;
using MedicalClinic.Models.Entities;
using System;
using System.Threading.Tasks;

namespace MedicalClinic.Business.Services.Services
{
    public class AppoinmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appoinmentRepository;
        private readonly IMapper _mapper;

        public AppoinmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appoinmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDTO> Add(AppointmentDTO appointmentDTO)
        {
            try
            {
                var existAppointment = _appoinmentRepository.HasAppointment(appointmentDTO.PatientId, appointmentDTO.Date);
                if (existAppointment)
                    throw new Exception("This patient has already an appointment for this date");
                var appointment = _mapper.Map<AppointmentDTO, Appointment>(appointmentDTO);
                _appoinmentRepository.Add(appointment);

                await _appoinmentRepository.SaveAsync();

                return _mapper.Map<Appointment, AppointmentDTO>(appointment);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> CancelAppoiment(int id)
        {
            try
            {
                var isCancellable = _appoinmentRepository.IsCancellable(id);
                if (!isCancellable)
                    throw new Exception("Appointments must be cancelled at least 24 hours in advance");
                var appointment = _appoinmentRepository.GetById(id);

                appointment.IsCancelled = true;

                _appoinmentRepository.Update(appointment);
                await _appoinmentRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
