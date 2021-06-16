using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Records.MedicalRecordsRoles
{
    public static class MedicalRecordsRoles
    {
        public static string Admin = "Admin";
        public static string Patient = "Patient";
        //public static string Doctor = "Doctor";

        public static List<SelectListItem>GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value=MedicalRecordsRoles.Admin,Text=MedicalRecordsRoles.Admin},
                new SelectListItem{Value=MedicalRecordsRoles.Patient,Text=MedicalRecordsRoles.Patient}
               // new SelectListItem{Value=MedicalRecordsRoles.Doctor,Text=MedicalRecordsRoles.Doctor}
            };
        }
    }
}
