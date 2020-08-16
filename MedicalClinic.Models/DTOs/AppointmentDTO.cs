using System;

namespace MedicalClinic.Models.DTOs
{
    public class AppointmentDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsCancelled { get; set; }
        public long PatientId { get; set; }
        public string Notes { get; set; }
        public long AppointmentTypeId { get; set; }
        public PatientDTO Patient { get; set; }
        public AppointmentTypeDTO AppointmentType { get; set; }
    }
}
