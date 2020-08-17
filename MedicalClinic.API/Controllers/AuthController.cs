using System;
using System.Threading.Tasks;
using MedicalClinic.Business.Services.Interfaces;
using MedicalClinic.Models.DTOs.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login", Name = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var response = await _authService.Login(loginDTO);
                return HandleSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }

        }
    }
}