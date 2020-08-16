using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalClinic.Models.Entities
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsCancelled { get; set; }
        public long PatientId { get; set; }
        public string Notes { get; set; }
        public long AppointmentTypeId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("AppointmentTypeId")]
        public AppointmentType AppointmentType { get; set; }
    }
}
