using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class StepTwoViewModel
    {
        public int? SelectedSpecialty { get; set; }
        public int? SelectedMedicalCenter { get; set; }
        public IEnumerable<MedicalCenter> MedicalCenters { get; set; }
    }
}