using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindADoctor.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string SpecialtyArea { get; set; }
    }
}