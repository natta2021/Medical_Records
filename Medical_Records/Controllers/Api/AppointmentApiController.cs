using Medical_Records.Models.ViewModels;
using Medical_Records.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Medical_Records.MedicalRecordsRoles
{
    namespace Medical_Records.Controllers.Api
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentApiController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;

        public AppointmentApiController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }

        [HttpPost]
        [Route("SaveCalendarDate")]
        public IActionResult SaveCalendarDate(AppointmentVM data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();

            try
            {
                commonResponse.status = _appointmentService.AddUpdate(data).Result;
                if (commonResponse.status == 1)
                {
                        commonResponse.message = MedicalRecordsRoles.appointmentUpdated;
                }
                    if (commonResponse.status == 2)
                {
                        commonResponse.message = MedicalRecordsRoles.appointmentAdded;
                }
            }
            catch (Exception e)
            {

                commonResponse.message = e.Message;
                    commonResponse.status = MedicalRecordsRoles.failure_code;
            }
            return Ok(commonResponse);
        }
    }
}
}
