using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class StepThreeViewModel
    {
        public int? SelectedMedicalCenter { get; set; }
        public int? SelectedDoctor { get; set; }
        public ApplicationUser LoggedInUser { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}