using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }

        public int DegreeId { get; set; }
        public virtual Degree Degree { get; set; }

        public virtual ICollection<DoctorAssignment> DoctorAssignments { get; set; }

    }
}