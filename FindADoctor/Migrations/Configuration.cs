namespace FindADoctor.Migrations
{
    using FindADoctor.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FindADoctor.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FindADoctor.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var genders = new List<Gender>
            {
                new Gender {Id = 1, Name = "Male"},
                new Gender {Id = 2, Name = "Female"},
                new Gender {Id = 3, Name = "Other"}
            };

            genders.ForEach(g => context.Genders.AddOrUpdate(g));
            context.SaveChanges();

            var bloodGroups = new List<BloodGroup>
            {
                new BloodGroup {Id = 1, Type = "A+"},
                new BloodGroup {Id = 2, Type = "A-"},
                new BloodGroup {Id = 3, Type = "B+"},
                new BloodGroup {Id = 4, Type = "B-"},
                new BloodGroup {Id = 5, Type = "AB+"},
                new BloodGroup {Id = 6, Type = "AB-"},
                new BloodGroup {Id = 7, Type = "O+"},
                new BloodGroup {Id = 8, Type = "O-"}
            };

            bloodGroups.ForEach(b => context.BloodGroups.AddOrUpdate(b));
            context.SaveChanges();

            var degrees = new List<Degree>
            {
                new Degree { Id = 1, Name = "Bachelor of Medicine and Bachelor of Surgery", Abbreviation = "MBBS" },
                new Degree { Id = 2, Name = "Master of Clinical Medicine", Abbreviation = "MCM" },
                new Degree { Id = 3, Name = "Master of Medical Science", Abbreviation = "MMSc" },
                new Degree { Id = 4, Name = "Master of Medicine", Abbreviation = "MM" },
                new Degree { Id = 5, Name = "Master of Philosophy", Abbreviation = "MPhil" },
                new Degree { Id = 6, Name = "Master of Surgery", Abbreviation = "MS" },
                new Degree { Id = 7, Name = "Master of Science in Medicine or Surgery", Abbreviation = "MSc" },
                new Degree { Id = 8, Name = "Doctor of Medicine", Abbreviation = "MD" },
                new Degree { Id = 9, Name = "Doctor of Osteopathic Medicine", Abbreviation = "DO" },
                new Degree { Id = 10, Name = "Doctorate in Medicine", Abbreviation = "DM" },
                new Degree { Id = 11, Name = "Doctor of Philosophy", Abbreviation = "PhD" },
                new Degree { Id = 12, Name = "Doctor of Clinical Medicine", Abbreviation = "DCM" },
                new Degree { Id = 13, Name = "Doctor of Clinical Surgery", Abbreviation = "DClinSurg" },
                new Degree { Id = 14, Name = "Doctor of Medical Science", Abbreviation = "DMSc" },
                new Degree { Id = 15, Name = "Doctor of Surgery", Abbreviation = "DS" }
            };

            degrees.ForEach(d => context.Degrees.AddOrUpdate(d));
            context.SaveChanges();

            var specialties = new List<Specialty>
            {
                new Specialty { Id = 1, Type = "General Practitioner", SpecialtyArea = "I am looking for a Generation Doctor!" },
                new Specialty { Id = 2, Type = "Anesthesiologist", SpecialtyArea = "Need to consult about the operation!" },
                new Specialty { Id = 3, Type = "Cardiologist", SpecialtyArea = "I'm in love. Need a Cardiologist!" },
                new Specialty { Id = 4, Type = "Dermatologist", SpecialtyArea = "I am looking for a Generation Doctor!" },
                new Specialty { Id = 5, Type = "Diabetologist", SpecialtyArea = "I want a nice look like a white skinned American!" },
                new Specialty { Id = 6, Type = "Endocrinologist", SpecialtyArea = "Need Hormone related help! Want to look like a dinosaur" },
                new Specialty { Id = 7, Type = "Gynaecologist", SpecialtyArea = "Looking for the doctor who loves his working days" },
                new Specialty { Id = 8, Type = "Hematologist", SpecialtyArea = "Take care of my blood!" },
                new Specialty { Id = 9, Type = "Immunologist", SpecialtyArea = "Looking for an Immunologist" },
                new Specialty { Id = 10, Type = "Leprologist", SpecialtyArea = "Looking for a Leprologist" },
                new Specialty { Id = 11, Type = "Neurologist", SpecialtyArea = "Looking for a Neurologist" },
                new Specialty { Id = 12, Type = "Neurosurgeon", SpecialtyArea = "Looking for a Neurosurgeon" },
                new Specialty { Id = 13, Type = "Obstetrician", SpecialtyArea = "Looking for an Obstetrician" },
                new Specialty { Id = 14, Type = "Pathologist", SpecialtyArea = "Looking for a Pathologist" },
                new Specialty { Id = 15, Type = "Psychiatrist", SpecialtyArea = "Looking for a Psychiatrist" },
                new Specialty { Id = 16, Type = "Radiologist", SpecialtyArea = "Looking for a Radiologist" },
                new Specialty { Id = 17, Type = "Rheumatologist", SpecialtyArea = "Looking for a Rheumatologist" },
                new Specialty { Id = 18, Type = "Surgeon", SpecialtyArea = "Looking for a Surgeon" },
                new Specialty { Id = 19, Type = "Urologist", SpecialtyArea = "Looking for an Urologist" },
                new Specialty { Id = 20, Type = "Venereologist", SpecialtyArea = "Looking for a Venereologist" }
            };

            specialties.ForEach(s => context.Specialties.AddOrUpdate(s));
            context.SaveChanges();

            // seeding appointment periods
            var appointmentSchedule = new List<AppointmentSchedule>
            {
                new AppointmentSchedule { Id = 1, TimePeriod = "08:00am - 09:00am" },
                new AppointmentSchedule { Id = 2, TimePeriod = "09:00am - 10:00am" },
                new AppointmentSchedule { Id = 3, TimePeriod = "10:00am - 11:00pm" },
                new AppointmentSchedule { Id = 4, TimePeriod = "11:00am - 12:00pm" },
                new AppointmentSchedule { Id = 5, TimePeriod = "01:00pm - 02:00pm" },
                new AppointmentSchedule { Id = 6, TimePeriod = "02:00pm - 03:00pm" },
                new AppointmentSchedule { Id = 7, TimePeriod = "03:00pm - 04:00pm" },
                new AppointmentSchedule { Id = 8, TimePeriod = "04:00pm - 05:00pm" }
            };

            appointmentSchedule.ForEach(a => context.AppointmentSchedules.AddOrUpdate(a));
            context.SaveChanges();

            var doctors = new List<Doctor>
            {
                new Doctor { Id = 1, FirstName = "First01", LastName = "Last01", Phone = "123456", SpecialtyId = 1, DegreeId = 1 },
                new Doctor { Id = 2, FirstName = "First02", LastName = "Last02", Phone = "234567", SpecialtyId = 2, DegreeId = 2 },
                new Doctor { Id = 3, FirstName = "First03", LastName = "Last03", Phone = "345678", SpecialtyId = 3, DegreeId = 3 },
                new Doctor { Id = 4, FirstName = "First04", LastName = "Last04", Phone = "456789", SpecialtyId = 4, DegreeId = 4 },
                new Doctor { Id = 5, FirstName = "First05", LastName = "Last05", Phone = "567891", SpecialtyId = 5, DegreeId = 5 }
            };

            doctors.ForEach(d => context.Doctors.AddOrUpdate(d));
            context.SaveChanges();

            var medicalCenters = new List<MedicalCenter>
            {
            new MedicalCenter { Id = 1, Name = "Some Medical Center", Address = "22 Abc Road", Suburb = "Mt Wellington", PostCode = "1060", City = "Auckland", Phone = "09123456", Latitute=76, Longitude=71, Website = "http://www.test.com"},
            new MedicalCenter { Id = 2, Name = "Medical Center 2", Address = "43 Xyz Road", Suburb = "Mt Albert", PostCode = "1234", City = "Auckland", Phone = "09456789", Latitute=52, Longitude=37, Website = "http://www.test2.com"}
            };

            medicalCenters.ForEach(m => context.MedicalCenters.AddOrUpdate(m));
            context.SaveChanges();

            var assignments = new List<DoctorAssignment>
            {
                new DoctorAssignment { Id = 1, DoctorId = 1, MedicalCenterId = 1},
                new DoctorAssignment { Id = 2, DoctorId = 2, MedicalCenterId = 1},
                new DoctorAssignment { Id = 3, DoctorId = 3, MedicalCenterId = 1},
                new DoctorAssignment { Id = 4, DoctorId = 4, MedicalCenterId = 1},
                new DoctorAssignment { Id = 5, DoctorId = 3, MedicalCenterId = 2},
                new DoctorAssignment { Id = 6, DoctorId = 4, MedicalCenterId = 2},
                new DoctorAssignment { Id = 7, DoctorId = 5, MedicalCenterId = 2}
            };

            assignments.ForEach(a => context.DoctorAssignments.AddOrUpdate(a));
            context.SaveChanges();


            InitializeAdminUserAndRoles(context);
        }

        private void InitializeAdminUserAndRoles(ApplicationDbContext context)
        {
            // creating app admin role
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            // creating a app admin user
            if (!context.Users.Any(u => u.UserName == "findadoc@outlook.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "findadoc@outlook.com", Email = "findadoc@outlook.com", FirstName = "App", LastName = "Admin" };

                manager.Create(user, "P@ssw0rd2017#");
                manager.AddToRole(user.Id, "Admin");
            }

            // creating doctor role - for future app extension
            if (!context.Roles.Any(r => r.Name == "Doctor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Doctor" };

                manager.Create(role);
            }

            // creating patient role
            if (!context.Roles.Any(r => r.Name == "Patient"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Patient" };

                manager.Create(role);
            }
        }
    }
}
