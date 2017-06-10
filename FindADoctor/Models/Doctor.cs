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

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Specialty")]
        public int SpecialtyId { get; set; }

        public virtual Specialty Specialty { get; set; } // navigational property

        [Display(Name = "Degree")]
        public int DegreeId { get; set; }

        public virtual Degree Degree { get; set; } // navigational property

        public virtual ICollection<DoctorAssignment> DoctorAssignments { get; set; }

    }
}