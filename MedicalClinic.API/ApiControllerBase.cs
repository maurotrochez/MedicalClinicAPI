using Microsoft.AspNetCore.Mvc;
using System;

namespace MedicalClinic.API
{
    public class ApiControllerBase : Controller
    {
        public ApiControllerBase()
        {

        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("HandleSuccessResponse")]
        public IActionResult HandleSuccessResponse(object result)
        {
            return Ok(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("HandleErrorResponse")]
        public IActionResult HandleErrorResponse(Exception ex)
        {
            if (ex != null && ex.Message != null)
                return BadRequest(new { errorMessage = ex.Message });
            return BadRequest();
        }

    }
}
