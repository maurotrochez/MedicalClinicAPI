namespace MedicalClinic.Models.DTOs
{
    public class PatientDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentificationNumber { get; set; }
    }
}
