using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace FindADoctor.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Gender")]
        public int? GenderId { get; set; }
        public Gender Gender { get; set; } // Navigational property

        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        [Display(Name = "Blood Group")]
        public int? BloodGroupId { get; set; }
        public BloodGroup BloodGroup { get; set; } // Navigational property
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        public DbSet<DoctorAssignment> DoctorAssignments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}