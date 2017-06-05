using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class MedicalCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Decimal Latitute { get; set; }
        public Decimal Longitude { get; set; }

        public virtual ICollection<DoctorAssignment> DoctorAssignments { get; set; }
    }
}