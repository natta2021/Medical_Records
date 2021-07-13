using Medical_Records.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Records.Models
{
    // IdentityDbContext<ApplicationUser> point to Customize column
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public IEnumerable<RegisterViewModel> RegisterViewModel { get; internal set; }
    }
}
