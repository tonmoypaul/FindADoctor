using FindADoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindADoctor.ViewModels
{
    public class DoctorViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Degree> Degrees { get; set; }
        public IEnumerable<Specialty> Specialties { get; set; }
    }
}