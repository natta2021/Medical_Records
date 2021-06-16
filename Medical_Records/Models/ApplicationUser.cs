using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Records.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string CongenitalDesease { get; set; }
        public string CurrentMedication { get; set; }
        public string DrugAllergy { get; set; }

    }
}
