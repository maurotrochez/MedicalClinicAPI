using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalClinic.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.API.Controllers
{
    [Authorize]
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ApiControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet("", Name = "GetAllPatients")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _patientService.GetAll();
                return HandleSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }

        }
    }
}