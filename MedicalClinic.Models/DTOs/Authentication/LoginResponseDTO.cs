using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalClinic.Models.DTOs.Authentication
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
