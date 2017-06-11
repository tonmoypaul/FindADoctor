using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class StepFourViewModel
    {
        public int? SelectedMedicalCenter { get; set; }
        public int? SelectedDoctor { get; set; }
        public int? SelectedSchedule { get; set; }
        public IEnumerable<AppointmentSchedule> AppointmentSchedules { get; set; }
    }
}