using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalClinic.Business.Services.Interfaces;
using MedicalClinic.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.API.Controllers
{
    [Authorize]
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ApiControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("", Name = "GetAllAppointments")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _appointmentService.GetAll();
                return HandleSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }

        }

        [HttpPost("", Name = "AddAppointment")]
        public async Task<IActionResult> Add([FromBody] AppointmentDTO appoimentDTO)
        {
            try
            {
                var response = await _appointmentService.Add(appoimentDTO);
                return HandleSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }

        }

        [HttpPost("{id}/cancel", Name = "CancelAppointment")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                var response = await _appointmentService.CancelAppoiment(id);
                return HandleSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }

        }

        [HttpDelete("{id}", Name = "DeleteAppointment")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _appointmentService.Delete(id);
                return HandleSuccessResponse(true);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }

        }
    }

    
}