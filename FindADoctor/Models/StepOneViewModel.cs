using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class StepOneViewModel
    {
        public int? SelectedSpecialty { get; set; }
        public IEnumerable<Specialty> Specialties { get; set; }
    }
}