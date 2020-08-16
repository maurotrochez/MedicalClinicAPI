using AutoMapper;
using MedicalClinic.Models.DTOs;
using MedicalClinic.Models.Entities;

namespace MedicalClinic.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Appointment>();

            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();

            CreateMap<AppointmentType, AppointmentTypeDTO>();
            CreateMap<AppointmentTypeDTO, AppointmentType>();
        }
    }
}
