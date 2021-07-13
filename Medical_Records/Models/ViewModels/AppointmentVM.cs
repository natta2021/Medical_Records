using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_Records.Models.ViewModels
{
    public class AppointmentVM
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; } // convert dateTime to string
        public string EndDate { get; set; }
        public int Duration { get; set; }
        public string PatientId { get; set; }

        public string PatientName { get; set; }
        //public bool IsForClient { get; set; }
    }
}
