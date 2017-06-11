using FindADoctor.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindADoctor.Controllers
{
    [Authorize(Roles = "Patient, Admin")]
    public class AppointmentsController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AppointmentsController()
        {
        }

        public AppointmentsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Index
        [Authorize(Roles = "Admin, Patient")]
        public ActionResult Index()
        {
            if (User.IsInRole("Patient"))
            {
                var user = UserManager.FindById(User.Identity.GetUserId());

                var appointments = db.Appointments.Where(x => x.PatientUserName == user.UserName).ToList();

                return View(appointments);

            }

            else
            {
                var appointments = db.Appointments.ToList();

                return View(appointments);
            }

        }

        // GET: Appointment
        [Authorize(Roles = "Patient")]
        public ActionResult StepOne()
        {
            var specialties = db.Specialties.ToList();

            var viewModel = new StepOneViewModel
            {
                Specialties = specialties
            };

            return View("StepOne", viewModel);
        }

        // GET: StepTwo
        [Authorize(Roles = "Patient")]
        public ActionResult StepTwo()
        {
            return RedirectToAction("StepOne");
        }

        // GET: StepThree
        [Authorize(Roles = "Patient")]
        public ActionResult StepThree()
        {
            return RedirectToAction("StepOne");
        }

        // GET: StepFour
        [Authorize(Roles = "Patient")]
        public ActionResult StepFour()
        {
            return RedirectToAction("StepOne");
        }

        // GET: ConfirmAppointment
        [Authorize(Roles = "Patient")]
        public ActionResult ConfirmAppointment()
        {
            return RedirectToAction("StepOne");
        }

        // GET: CreateAppointment
        [Authorize(Roles = "Patient")]
        public ActionResult CreateAppointment()
        {
            return RedirectToAction("StepOne");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Patient")]
        public ActionResult StepTwo(StepOneViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("StepOne");
            }

            var selectedSpecialtyTypeId = viewModel.SelectedSpecialty;

            if (selectedSpecialtyTypeId == null)
            {
                return RedirectToAction("StepOne");
            }

            var possibleDoctors = from d in db.Doctors
                                  where d.SpecialtyId == selectedSpecialtyTypeId
                                  select d;

            var possibleAssignments = from a in db.DoctorAssignments
                              join b in possibleDoctors on a.DoctorId equals b.Id
                              select a;

            var possibleMedicalCenters = from a in db.MedicalCenters
                                         join b in possibleAssignments on a.Id equals b.MedicalCenterId
                                         select a;

            var nextViewModel = new StepTwoViewModel
            {
                SelectedSpecialty = selectedSpecialtyTypeId,
                MedicalCenters = possibleMedicalCenters
            };
            
            return View("StepTwo", nextViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Patient")]
        public ActionResult StepThree(StepTwoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("StepOne");
            }

            var selectedSpecialtyId = viewModel.SelectedSpecialty;
            var selectedMedicalCenterId = viewModel.SelectedMedicalCenter;

            var possibleAssignments = from a in db.DoctorAssignments
                                      where a.MedicalCenterId == selectedMedicalCenterId
                                      select a.DoctorId;

            var possibleSpecialDoctors = from d in db.Doctors
                                         where d.SpecialtyId == selectedSpecialtyId
                                         select d;

            var availableDoctors = possibleSpecialDoctors.Where(x => possibleAssignments.Contains(x.Id)).ToList();

            var nextViewModel = new StepThreeViewModel
            {
                SelectedMedicalCenter = selectedMedicalCenterId,
                Doctors = availableDoctors
            };

            return View("StepThree", nextViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Patient")]
        public ActionResult StepFour(StepThreeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("StepOne");
            }

            var selectedMedicalCenterId = viewModel.SelectedMedicalCenter;
            var selectedDoctorId = viewModel.SelectedDoctor;

            var allSchedules = db.AppointmentSchedules.ToList();

            var unavailableSchedules = from a in db.Appointments
                                     where a.DoctorId == selectedDoctorId
                                     &&
                                     a.MedicalCenterId == selectedMedicalCenterId
                                     &&
                                     a.Date == DateTime.Today
                                     select a;

            var availableSchedules = db.AppointmentSchedules.Where(s => !unavailableSchedules.Any(p => p.AppointmentScheduleId == s.Id));
            
            var nextViewModel = new StepFourViewModel
            {
                SelectedMedicalCenter = selectedMedicalCenterId,
                SelectedDoctor = selectedDoctorId,
                AppointmentSchedules = availableSchedules
            };

            return View("StepFour", nextViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Patient")]
        public ActionResult ConfirmAppointment(StepFourViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("StepOne");
            }

            var selectedMedicalCenterId = viewModel.SelectedMedicalCenter;
            var selectedDoctorId = viewModel.SelectedDoctor;
            var selectedSchedule = viewModel.SelectedSchedule;

            var nextViewModel = new Appointment
            {
                MedicalCenterId = (int)selectedMedicalCenterId,
                DoctorId = (int)selectedDoctorId,
                AppointmentScheduleId = (int)selectedSchedule,
                Date = DateTime.Today,
                Doctor = db.Doctors.Find(selectedDoctorId),
                MedicalCenter = db.MedicalCenters.Find(selectedMedicalCenterId),
                AppointmentSchedule = db.AppointmentSchedules.Find(selectedSchedule)
            };

            return View("ConfirmAppointment", nextViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Patient")]
        public ActionResult CreateAppointment(Appointment model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("StepOne");
            }

            model.PatientUserName = User.Identity.GetUserName();

            db.Appointments.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}