using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string PatientUserName { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; } // navigational property

        public int MedicalCenterId { get; set; }
        public virtual MedicalCenter MedicalCenter { get; set; } // navigational property

        public int AppointmentScheduleId { get; set; }
        public virtual AppointmentSchedule AppointmentSchedule { get; set; } // navigational property
    }
}