using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class DoctorAssignment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int MedicalCenterId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual MedicalCenter MedicalCenter { get; set; }
    }
}