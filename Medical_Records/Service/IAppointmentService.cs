using Medical_Records.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Records.Service
{
    public interface IAppointmentService
    {
        public List<PatientVM> GetPatientList();

        public Task<int> AddUpdate(AppointmentVM model);
    }
}
