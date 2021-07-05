using Medical_Records.Models;
using Medical_Records.Models.ViewModels;
using Medical_Records.MedicalRecordsRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical_Records.Service;

namespace Medical_Records.MedicalRecordsRoles
{
    namespace Medical_Records.Service

    {
        public class AppointmentService : IAppointmentService
        {
            private readonly ApplicationDbContext _db;

            public AppointmentService(ApplicationDbContext db)
            {
                _db = db;
            }
            public List<PatientVM> GetPatientList()
            {
               
                var patients = (from user in _db.Users
                                join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                                join roles in _db.Roles.Where(x => x.Name == MedicalRecordsRoles.Patient) on userRoles.RoleId equals roles.Id
                                select new PatientVM
                                {
                                    Id = user.Id,
                                    UserName = user.UserName
                                }
                              ).ToList();

                return patients;
            }
        }
    }
}


