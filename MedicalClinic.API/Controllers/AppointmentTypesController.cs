using MedicalClinic.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedicalClinic.API.Controllers
{
    [Authorize]
    [Route("api/appointmentTypes")]
    [ApiController]
    public class AppointmentTypesController : ApiControllerBase
    {
        private readonly IAppointmentTypeService _appointmentTypeService;
        public AppointmentTypesController(IAppointmentTypeService appointmentTypeService)
        {
            _appointmentTypeService = appointmentTypeService;
        }

        [HttpGet("", Name = "GetAllAppointmentTypes")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _appointmentTypeService.GetAll();
                return HandleSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }

        }
    }
}