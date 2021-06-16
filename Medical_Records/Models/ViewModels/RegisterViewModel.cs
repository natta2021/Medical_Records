using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Records.Models.ViewModels
{
    public class RegisterViewModel
    {
       // public int Id { get; set; }
       [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength =6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="The password and confirmation passwoard do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Phone Numeber")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Congenital Desease")]
        public string CongenitalDesease { get; set; }

        [Required]
        [Display(Name = "Current Medication")]
        public string CurrentMedication { get; set; }

        [Required]
        [Display(Name = "Drug Allergy")]
        public string DrugAllergy { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
