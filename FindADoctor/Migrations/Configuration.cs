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
                new Specialty { Id = 1, Type = "General Practitioner", SpecialtyArea = "Do you need help with any types of illness that present in an undifferentiated way at an early stage of development, which may require urgent intervention. The holistic approach of general practice aims to take into consideration the biological, psychological, and social factors relevant to the care of each patient's illness. Their duties are not confined to specific organs of the body, and they have particular skills in treating people with multiple health issues." },
                new Specialty { Id = 2, Type = "Anesthesiologist", SpecialtyArea = "Do you need any medical consultation about during or after operation care usually in acute situations, including preoperative evaluation, consultation with the surgical team, creation of a plan for the anesthesia tailored to each individual patient, airway management, intraoperative life support and provision of pain control, intraoperative diagnostic stabilisation, proper post-operative management? Also in-hospital and pre-hospital emergencies, intensive care, acute pain units and chronic pain consultations?" },
                new Specialty { Id = 3, Type = "Cardiologist", SpecialtyArea = "Are you looking for a cardiologist with special training and skill in finding, treating and preventing diseases of the heart and blood vessels. The cardiologist sees you in the office or in the hospital, he or she will review your medical history and perform a physical examination which may include checking your blood pressure, weight, heart, lungs, and blood vessels. Some problems may be diagnosed by your symptoms and the doctor’s findings when you are examined. You may need additional tests such as an ECG, x-ray, or blood test. Other problems will require more specialized testing. Your cardiologist may recommend lifestyle changes or medicine. Each patient’s case is unique." },
                new Specialty { Id = 4, Type = "Dermatologist", SpecialtyArea = "Do you want to consult if you have any significant problem with your skin? Dermatology is the science that is concerned with the diagnosis and treatment of diseases of the skin, hair and nails. Dermatology involves but is not limited to study, research, and diagnosis of normal and disorders, diseases, cancers, cosmetic and ageing conditions of the skin, fat, hair, nails and oral and genital membranes, and the management of these by different investigations and therapies, including but not limited to dermatohistopathology, topical and systemic medications, dermatologic surgery and dermatologic cosmetic surgery, immunotherapy, phototherapy, laser therapy, radiotherapy and photodynamic therapy." },
                new Specialty { Id = 5, Type = "Diabetologist", SpecialtyArea = "Do you need help to diagnose and treat diabetes. This disease afflicts a growing number of people in the United States. For this reason opportunities to practice in this field are expected to increase. Aspiring diabetologists should first earn an undergraduate degree followed by a medical school degree. After this, they must complete a residency in internal medicine and choose an endocrinology sub-specialty." },
                new Specialty { Id = 6, Type = "Endocrinologist", SpecialtyArea = "Are you in need of physicians who diagnose diseases related to the glands? The diseases they are trained to treat often affect other parts of the body beyond glands. While primary care doctors know a lot about the human body, for diseases and conditions directly related to glands they will usually send a patient to an endocrinologist." },
                new Specialty { Id = 7, Type = "Gynaecologist", SpecialtyArea = "Do you care advise, diagnose and treat issues with the female reproductive system, and provide medical care for women before, during and after pregnancy? Gynaecology or gynecology (see spelling differences) is the medical practice dealing with the health of the female reproductive systems (vagina, uterus, and ovaries) and the breasts. Literally, outside medicine, the term means 'the science of women'. Its counterpart is andrology, which deals with medical issues specific to the male reproductive system." },
                new Specialty { Id = 8, Type = "Hematologist", SpecialtyArea = "Are you looking for consultation about the science or study of blood, blood-forming organs and blood diseases. The medical aspect of hematology is concerned with the treatment of blood disorders and malignancies, including types of hemophilia, leukemia, lymphoma and sickle-cell anemia. Hematology is a branch of internal medicine that deals with the physiology, pathology, etiology, diagnosis, treatment, prognosis and prevention of blood-related disorders." },
                new Specialty { Id = 9, Type = "Immunologist", SpecialtyArea = "Do you need specialized medical doctor who is trained in managing problems related to the immune system, such as allergies and autoimmune diseases. Doctors in other fields of medicine refer their patients to immunologists if they suspect their patient’s medical condition has to do with the immune system." },
                new Specialty { Id = 10, Type = "Leprologist", SpecialtyArea = "Are you looking for a specialist seeking special attention to the study of the nature and origin of leprosy and to its treatment" },
                new Specialty { Id = 11, Type = "Neurologist", SpecialtyArea = "Do you need treatment on disorders that affect the brain, spinal cord, and nerves, such as: Cerebrovascular disease, such as stroke, Demyelinating diseases of the central nervous system, such as multiple sclerosis, Headache disorders, Infections of the brain and peripheral nervous system, Movement disorders, such as Parkinson's disease, Neurodegenerative disorders, such as Alzheimer's disease, Parkinson's disease, and Amyotrophic Lateral Sclerosis (Lou Gehrig's disease), Seizure disorders, such as epilepsy, Spinal cord disorders, Speech and language disorders" },
                new Specialty { Id = 12, Type = "Neurosurgeon", SpecialtyArea = "Are you looking for a medical specialist who treats diseases and conditions affecting the nervous system, which includes the brain, the spine and spinal cord, and the peripheral nerves? Neurosurgeons provide non-operative and surgical treatment to patients of all ages." },
                new Specialty { Id = 13, Type = "Obstetrician", SpecialtyArea = "Select this to find a doctor who specializes in pregnancy, childbirth, and a woman's reproductive system. Although other doctors can deliver babies, many women see an obstetrician, also called an OB. Obstetrician can take care of you throughout pregnancy, and give follow-up care such as annual Pap tests for years to come" },
                new Specialty { Id = 14, Type = "Pathologist", SpecialtyArea = "Are you searching for doctors who study human diseases and conditions? They diagnose health problems by testing samples from tissues of the body, blood and other bodily fluids." },
                new Specialty { Id = 15, Type = "Psychiatrist", SpecialtyArea = "Do you need care focused on the diagnosis, treatment and prevention of mental, emotional and behavioral disorders? A psychiatrist is a medical doctor (an M.D. or D.O.) who specializes in mental health, including substance use disorders. Psychiatrists are qualified to assess both the mental and physical aspects of psychological problems." },
                new Specialty { Id = 16, Type = "Radiologist", SpecialtyArea = "Radiologist is a medical doctor who specializes in diagnosing and treating disease and injury through the use of medical imaging techniques such as x-rays, computed tomography (CT), magnetic resonance imaging (MRI), nuclear medicine, positron emission tomography (PET), fusion imaging, and ultrasound. Because some of these imaging techniques involve the use of radiation, adequate training in and understanding of radiation safety and protection is important." },
                new Specialty { Id = 17, Type = "Rheumatologist", SpecialtyArea = "A rheumatologist is an internist or pediatrician who received further training in the diagnosis (detection) and treatment of musculoskeletal disease and systemic autoimmune conditions commonly referred to as rheumatic diseases. These diseases can affect the joints, muscles, and bones causing pain, swelling, stiffness, and deformity. " },
                new Specialty { Id = 18, Type = "Surgeon", SpecialtyArea = "A surgeon is a doctor who performs operations. Surgeons may be physicians, podiatrists, dentists, or veterinarians." },
                new Specialty { Id = 19, Type = "Urologist", SpecialtyArea = "A urologist is a physician who has specialized knowledge and skill regarding problems of the male and female urinary tract and the male reproductive organs. Because of the variety of clinical problems encountered, knowledge of internal medicine, pediatrics, gynecology, and other specialties is required of the urologist." },
                new Specialty { Id = 20, Type = "Venereologist", SpecialtyArea = "Venereology is a branch of medicine that is concerned with the study and treatment of sexually transmitted diseases. The name derives from Roman goddess Venus, associated with love, beauty and fertility. A physician specializing in venereology is called a venereologist." }
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
