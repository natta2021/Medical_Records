using Medical_Records.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Records.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.PatientList = _appointmentService.GetPatientList();
            return View();
        }
    }
}
